'
' Created by SharpDevelop.
' User: mc185104
' Date: 5/31/2012
' Time: 9:37 PM
'
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Collections.ObjectModel

'Namespace PerfCheck
	Public Class CommandLine
		 Declare Function AllocConsole Lib "kernel32" () As Integer
		Declare Function FreeConsole Lib "kernel32" () As Integer
	
	Public Shared Sub Run(ByVal args As ReadOnlyCollection(Of String), _
		logAnalTraceStream As IExtendedTextReader, _
		lstExtractFilesStream As IExtendedTextReader, _ 
		perfConfigData As PerfConfigData)		
	    	Try
	    		Dim createMergeEvents As Boolean = False
	    		If args.Count = 2 and Not args.Count > 2 Then
    				If args(0) = "-m" Then
    					createMergeEvents = True
    					perfConfigData.DiagFilesPath = args(1)
    					PerformTask(createMergeEvents, perfConfigData.DiagFilesPath, logAnalTraceStream, perfConfigData.DictionaryPath)
    				Else If args(0) = "-dp" Then
    					createMergeEvents = False
    					ExtractFiles(args(1), createMergeEvents, perfConfigData.DictionaryPath, lstExtractFilesStream)
    				Else
    					InvalidArgs()
    				End If
    			Else If args.Count = 1
    				perfConfigData.DiagFilesPath = args(0)
    				PerformTask(createMergeEvents,perfConfigData.DiagFilesPath, logAnalTraceStream, perfConfigData.DictionaryPath)
    			Else If args.Count = 0    				
    				InvalidArgs()
    			End If
				Console.WriteLine("Press any key to close console")
				CloseConsole()
	    	Catch ex As Exception
	    		'LogHelper.Log(ex.ToString(), LogType.ERR, True)
	    		MessageService.ShowError(ex.Message)
	    		Console.WriteLine("Press any key to close console")
	    		CloseConsole()
	    	End Try
	    End Sub
	    
	    Public Shared Sub ExtractFiles(ByVal DiagsPath As String, ByVal createMergeEvents As Boolean, dictionaryPath As String, tr As IExtendedTextReader)
	    	If Not Directory.Exists(DiagsPath) Then	    		
	    		Throw New DirectoryNotFoundException("Diag zip not found. " + DiagsPath)	    
	    	End If
	    	
	    	Dim lstFilesToExtract As List(Of String) = getFilesToExtract(tr)
    		Dim diagZipFiles As String() = Directory.GetFiles(DiagsPath, "*.zip")
    		If diagZipFiles.Length > 0 Then
    			For Each file as String In diagZipFiles
	    			Dim fi As New FileInfo(file)
	    			Dim di As New DirectoryInfo(fi.Directory.FullName)
					'di.Create()
					Dim stopwatch As New Stopwatch()
					stopwatch.Start()
					'LogHelper.Log("Extracting diag file: " + fi.Name, LogType.INFO, true)
					MessageService.ShowInfo("Extracting diag file: " + fi.Name)
	    			ZipFileHelper.Extract(fi, di, lstFilesToExtract)
	    			stopwatch.Stop()
	    			'LogHelper.Log("Done Extracting diag file " + fi.Name + " elapsed=" + stopwatch.Elapsed.ToString(), LogType.INFO, true)
	    			MessageService.ShowInfo("Done Extracting diag file " + fi.Name + " elapsed=" + stopwatch.Elapsed.ToString())
	    			DiagsPath = di.FullName  + "/" + Regex.Replace(fi.Name, fi.Extension, "")
	    			PerformTask(createMergeEvents, DiagsPath, New ExtendedStreamReader(New FileStream(dictionaryPath + "\LogAnalTraceList.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite), System.Text.Encoding.Default), dictionaryPath)
	    			
	    		Next
    		Else
    			'LogHelper.Log("No diag zip file found in " + DiagsPath, LogType.WARNING, true)
    			MessageService.ShowError("No diag zip file found in " + DiagsPath)
    		End If	
	    End Sub	    
	    
	    Private Shared Function getFilesToExtract(tr As IExtendedTextReader) As List(Of String)
	    	Dim lst As New List(Of String)
	    	Dim line As String = String.Empty
			While(InlineAssignHelper(line, tr.ReadLine())) IsNot Nothing
				lst.Add(line)
			End While
			tr.Close()	
	    	return lst
	    End Function
	    
	    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
			target = value
			Return value
		End Function
		
		Public Shared underNUNIT As Boolean = False
		Private Shared Sub InvalidArgs()
			Console.WriteLine("Invalid Parameter supplied!")
			Console.WriteLine("-m Option <path of diag files>")
			Console.WriteLine("-m parameter means it will create a csv file containing all the merge events. NOTE: diag path containing spaces shall enclosed with double quotes.")
		End Sub
		
		Private Shared Sub CloseConsole()
			If Not underNUNIT Then								
				Console.ReadKey()
				FreeConsole()
				System.Environment.Exit(1)		'ends entire application	
			End If	    	
	    End Sub
	    
	    Public Shared Sub PerformTask(ByVal createMergeEvents As Boolean, diagDir As String, tr As IExtendedTextReader, dictionaryPath As String)
	    	If Not Directory.Exists(diagDir) Then	    		
	    		Throw New DirectoryNotFoundException("Directory not found. " + diagDir)
	    	End If	    	
	    	Dim eventsFound As SignifEvents
	    	eventsFound = ParseLogEvents(tr, diagDir, dictionaryPath)
			Console.WriteLine("")
			ExportSummaryToCsv(dictionaryPath, diagDir, eventsFound)
			Console.WriteLine("")
			If createMergeEvents Then
				ExportMergeEventsToCsv(diagDir, eventsFound)
			End If
			Console.WriteLine("")
	    End Sub
	    
	    Public Shared Function ParseLogEvents(tr As IExtendedTextReader, diagPath As String, dictionaryPath As String) As SignifEvents
	    	Dim i as Integer
	    	Dim logfileController As New LogFileController()
	    	Dim logEventsController As New LogEventsController()
	    	Dim parserEventValues As New ParserEventValues()
	    	logfileController.DiagPath = diagPath
			logfileController.getTraceList(tr)
			'formLogAnalysisMain.MergedTraceEvents = New SignifEvents()
			logEventsController.EventsFound = New SignifEvents()
	    	
	    	For Each keyval As KeyValuePair(Of String, FileInfo) In logFileController.DicTraceFile
	    		If Not keyval.Value Is Nothing Then
	    			logEventsController.ObjTraceEvents = New SignifEvents()
	        		logEventsController.getEventsFromFile(keyval.Value, logfileController.m_cFormat(i), dictionaryPath)
	        		logEventsController.EventsFound.DicEventValues = parserEventValues.Parsed(New ExtendedStreamReader(New FileStream(dictionaryPath + "\EventValues.dictionary", FileMode.Open, FileAccess.Read, FileShare.ReadWrite), System.Text.Encoding.Default))
	        		i+=1
	    		End If
	    	Next	    	
	    	Return logEventsController.EventsFound
	    End Function
	    
	    Private Shared Function PrepExport(eventsFound As SignifEvents)	    	
	    	Dim dateString As String
	    	dateString = DateTime.Now.ToString("d")
	    	
	    	Dim i As Long
	    	If eventsFound IsNot Nothing and eventsFound.Count > 0 Then
	    		MessageService.ShowInfo(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff") + " Number of merged events: " + eventsFound.Count.ToString())
		        For i = 1 To eventsFound.Count -1
		            eventsFound(i).objNextState = eventsFound(i + 1)
		            eventsFound(i).CollectionIndex = i
		        Next
		        eventsFound((eventsFound.Count)).objNextState = Nothing
		        return 1
	    	End If	    	
	    	Return 0
	    End Function
	    
	    Private Shared Sub ExportMergeEventsToCsv(diagDir As String, eventsFound As SignifEvents)		
	    	Dim dateString As String
	    	dateString = DateTime.Now.ToString("d")	    	
	    	Dim efc As New ExportFileController()
	    	efc.AllMergedEvents(diagDir, eventsFound.ListAllEvents())        
	    End Sub
	    
	    Private Shared Sub ExportSummaryToCsv(dictionaryPath As String, diagPath As String, eventsFound As SignifEvents)	    	
	    	Dim dateString As String
	    	dateString = DateTime.Now.ToString("d")            
	    	If PrepExport(eventsFound) > 0 Then
				Dim efc As New ExportFileController()
				efc.SummaryReport(dictionaryPath, diagPath, eventsFound)			        
			End If	    		    	
	    End Sub
	End Class
'End Namespace
	

