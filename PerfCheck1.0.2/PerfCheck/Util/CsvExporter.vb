'
' Created by SharpDevelop.
' User: mc185104
' Date: 5/29/2012
' Time: 9:48 PM
'
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'

Imports System.Data
Imports System.Text
Imports System.Collections.Generic
Imports System.IO
Imports System.Text.RegularExpressions

'Namespace PerfCheck
	Public Class CsvExporter
		Dim systemTermInfo As String = ""
		
		Function CsvHeaderMergeEvents() As String
			Dim csvline As New StringBuilder
			csvline.Append("Rel Time,")
			csvline.Append("Date Time,")
			csvline.Append("Millisec,")
			csvline.Append("Source,")
			csvline.Append("Line Number,")
			csvline.Append("Event Name,")
			'csvline.Append("Data")
			Return csvline.ToString()
			
		End Function
		
		Function CsvHeaderEventsSummary() As String
			Dim csvline As New StringBuilder
			
			csvline.Append("Measure,")
			csvline.Append("Count,")
			csvline.Append("Minimum,")
			csvline.Append("Maximum,")
			csvline.Append("Average,")
			csvline.Append("Std Dev,")
			csvline.Append("Min Low Threshold,")
			csvline.Append("Min Hi Threshold,")
			csvline.Append("Max Low Threshold,")
			csvline.Append("Max Hi threshold,")
			csvline.Append("Avg Lo Threshold,")
			csvline.Append("Avg Hi Threshold,")
			csvline.Append(" ,")
			csvline.Append("Diag FileName,")
			csvline.Append("ADK Version,")
			csvline.Append("Memory,")
			csvline.Append("Proc Type,")
			csvline.Append("Proc Speed")
			
			Return csvline.ToString()
			
		End Function		
		
		Public Sub ExportMergeEvents(ByVal logEvents As LogEvents, ByVal filePath As String)
			If logEvents Is Nothing Or filePath Is Nothing Then
				Throw New ArgumentNullException("ExportMergeEvents. Logevents or filePath is null")	
			End If
			
			If Not Directory.Exists(Path.GetDirectoryName(filePath)) Then
				Throw New DirectoryNotFoundException("ExportMergeEvents. Directory not found: " + Path.GetDirectoryName(filePath))
			End If
			
			Try
				Dim csvline As New StringBuilder()
				Dim relTime As Double
				Using sw As New StreamWriter(filePath)
					csvline.Append(Me.CsvHeaderMergeEvents())
					sw.WriteLine(csvline.ToString())
					For Each logevent As LogEvent In logEvents.GetEvents()
						If logevent.Datetime = Nothing And logevent.Millisec = Nothing Then
							sw.WriteLine("          ")
						Else
							csvline = New StringBuilder()
							Double.TryParse(logevent.RelTime.ToString(), relTime)
							csvline.Append(Me.PrepForCSV(relTime) + ",")
							'csvline.Append(Me.PrepForCSV(logevent.RelTime.ToString()) + ",")
							
							If Not logevent.Datetime Is Nothing Then
								csvline.Append(Me.PrepForCSV(logevent.Datetime) + ",")
							Else
								sw.WriteLine(csvline.ToString())
							End If
							
							'csvline.Append(Me.PrepForCSV(logevent.Datetime) + ",")
							csvline.Append(Me.PrepForCSV(logevent.Millisec.ToString()) + ",")
							
							If Not logevent.Source Is Nothing Then
								csvline.Append(Me.PrepForCSV(logevent.Source) + ",")
							Else
								sw.WriteLine(csvline.ToString())
							End If
							
							'csvline.Append(Me.PrepForCSV(logevent.Source) + ",")
							csvline.Append(Me.PrepForCSV(logevent.Lineno.ToString()) + ",")
							'csvline.Append(Me.PrepForCSV(logevent.Millisec.ToString()) + ",")
							
							If Not logevent.Events Is Nothing Then
								csvline.Append(Me.PrepForCSV(logevent.Events) + ",")
							Else
								sw.WriteLine(csvline.ToString())
							End If
							
							'csvline.Append(Me.PrepForCSV(logevent.Events) + ",")
							
							If Not logevent.Data Is Nothing Then
								If logevent.Data.Equals("empty row") Then
									sw.WriteLine("               ")
								End If
							Else
								sw.WriteLine(csvline.ToString())
							End If
						End If					
						'append add another for data column
						'csvline.Append(me.PrepForCSV(logevent.Data))
					Next
				End Using
			Catch ex As Exception
				MessageService.ShowError(ex.Message, "Error in " +  Me.GetType().Name + ":" + System.Reflection.MethodBase.GetCurrentMethod.Name)
				Throw New Exception()			
			End Try
		End Sub
		
		Public Sub ExportSummaryEvents(ByVal logEvents as LogEventsSummary, ByVal filePath As String, Byval perfmeasures as PerfMeasures, Byval diagPath As String)
			'Try
				Dim csvline As New StringBuilder()
				
				Using sw As New StreamWriter(filePath)
					csvline.Append(Me.CsvHeaderEventsSummary())
					sw.WriteLine(csvline.ToString())
					sw.WriteLine("")
					'Dim di as new DirectoryInfo(g_sINITIAL_DIRECTORY)
					For Each logevent As LogEventSummary In logEvents.GetEvents()
						csvline = New StringBuilder()
						csvline.Append(Me.PrepForCSV(logevent.Measure.ToString()) + ",")
						csvline.Append(Me.PrepForCSV(logevent.Count.ToString()) + ",")
						csvline.Append(Me.PrepForCSV(logevent.Minimum.ToString()) + ",")
						csvline.Append(Me.PrepForCSV(logevent.Maximum.ToString()) + ",")
						csvline.Append(Me.PrepForCSV(logevent.Average.ToString()) + ",")
						csvline.Append(Me.PrepForCSV(logevent.StdDev.ToString()) + ",")
						csvline.Append(Me.GetPerfMeasure(logevent.Measure, perfmeasures, diagPath))
						sw.WriteLine(csvline.ToString())
					Next
				End Using
			'Catch ex As Exception
			'	If g_cmdline Then
			'		LogHelper.Log(ex.ToString(), LogType.ERR, True)
			'	Else
			'		If (File.Exists(g_sINITIAL_DIRECTORY + "/TerminalInfo.dat")=False) Then
			'			MsgBox("File does not Exist: " + g_sINITIAL_DIRECTORY + "/TerminalInfo.dat", MsgBoxStyle.Exclamation)
			'		End If
			'		If (File.Exists(g_sINITIAL_DIRECTORY + "/SummaryInfo.dat")=False) Then
			'			MsgBox("File does not Exist: " + g_sINITIAL_DIRECTORY + "/SummaryInfo.dat", MsgBoxStyle.Exclamation)
			'		End If
			'	End If
			'End Try
		End Sub
		
		Function PrepForCSV(ByVal value As String) As String
			return String.Format("""{0}""", value.Replace("""", """"""))
		End Function
		
		Function GetPerfMeasure(byval measure as String, byval perfms as PerfMeasures, diagPath As String) As String
			Dim csvline As New StringBuilder
			Dim foundval As Boolean
			'Dim sysTermInfo As String = ""
			For Each perfm As PerfMeasure In perfms.GetMeasures()
				'If Regex.IsMatch(measure, perfm.Measure, RegexOptions.IgnoreCase) Then
				If measure.ToUpper.Equals(perfm.Measure.ToUpper) Then
					csvline.Append(perfm.NMinLoLim.ToString() + ",")
					csvline.Append(perfm.NMinHiLim.ToString() + ",")
					csvline.Append(perfm.NMaxLoLim.ToString() + ",")
					csvline.Append(perfm.NMaxHiLim.ToString() + ",")
					csvline.Append(perfm.DAvgLoLim.ToString() + ",")
					csvline.Append(perfm.DAvgHiLim.ToString() + ",")
					csvline.Append(" ,")
					If(systemTermInfo = "") Then
						systemTermInfo = GetSysTermInfo(diagPath)
						csvline.Append(systemTermInfo)
					Else
						csvline.Append(systemTermInfo)
					End If
					
					foundval = True
					Exit For
				End If
			Next
			
			If Not foundval Then
				csvline.Append(" ,")
				csvline.Append(" ,")
				csvline.Append(" ,")
				csvline.Append(" ,")
				csvline.Append(" ,")
				csvline.Append(" ,")
			End If
			
			return csvline.ToString()
		End Function
		
		Function GetSysTermInfo(diagPath As String) As String
			'Try
				Dim csvline As New StringBuilder
				Dim di As New DirectoryInfo(diagPath)
				Dim sys As New SysTermInfo()
				
				CheckFileExistence(diagPath,sys)
				
				csvline.Append(Me.PrepForCSV(di.Name) + ",")
				csvline.Append(Me.PrepForCSV(sys.Adk.ToString()) + ",")
				csvline.Append(Me.PrepForCSV(sys.Memory.ToString()) + ",")
				csvline.Append(Me.PrepForCSV(sys.Proctype.ToString()) + ",")
				csvline.Append(Me.PrepForCSV(sys.Procspeed.ToString()) + ",")
				Return csvline.ToString()
			'Catch ex As Exception
				'LogHelper.Log(ex.ToString(), LogType.WARNING, True)
				'MessageService.ShowError(ex.Message,"Error in "  + Me.GetType().Name + ":" + System.Reflection.MethodBase.GetCurrentMethod.Name)
                'Return ""
			'End Try
		End Function
		
		Public Sub CheckFileExistence(diagPath As String, sysTermInfo As SysTermInfo)

			If File.Exists(diagPath + "/TerminalInfo.dat") Then
					SysTermInfoController.getTerminalInfo(New ExtendedStreamReader(New FileStream(diagPath + "/TerminalInfo.dat", FileMode.Open, FileAccess.Read, FileShare.ReadWrite), System.Text.Encoding.Default), sysTermInfo)
			Else
					sysTermInfo.Memory = ""
					sysTermInfo.Proctype = ""
					sysTermInfo.Procspeed = ""
					MessageService.ShowWarning("Could not find TerminalInfo.dat " + "at " + diagPath , "Error in " + Me.GetType().Name + ":" + System.Reflection.MethodBase.GetCurrentMethod.Name)
					
			End If
				
			If File.Exists(diagPath + "/SummaryInfo.dat") Then
					SysTermInfoController.getSystemInfo(New ExtendedStreamReader(New FileStream(diagPath + "/SummaryInfo.dat", FileMode.Open, FileAccess.Read, FileShare.ReadWrite), System.Text.Encoding.Default), sysTermInfo)	            
			Else
					sysTermInfo.Adk = ""
					MessageService.ShowWarning("Could not find SummaryInfo.dat " + "at " + diagPath , "Error in " + Me.GetType().Name + ":" + System.Reflection.MethodBase.GetCurrentMethod.Name)
					
			End If
			
		End Sub
		
	End Class
'End Namespace
	
	

