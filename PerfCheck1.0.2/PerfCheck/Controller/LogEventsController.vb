'
' Created by SharpDevelop.
' User: mc185104
' Date: 5/31/2012
' Time: 12:02 AM
'
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports System.IO

'Namespace PerfCheck
Public Class LogEventsController	
	
	Dim m_objTraceEvents As New SignifEvents()
	
	Public Property ObjTraceEvents() As SignifEvents
		Get
			Return m_objTraceEvents
		End Get
		Set
			m_objTraceEvents = value
		End Set
	End Property
	
	Dim objTempTraceEvents As New SignifEvents()
	Dim stopwatch As New Stopwatch()
	Dim dateString As String
	Dim dicFile As String()
	Dim m_traceFile As FileInfo
	Dim m_eventsFound As New SignifEvents
	
	Public Property EventsFound() As SignifEvents
		Get
			Return m_eventsFound
		End Get
		Set
			m_eventsFound = value
		End Set
	End Property
	
	Public Sub getEventsFromFile(ByVal traceFile As FileInfo, ByVal m_cFormat As String, dictionaryPath As String)
		If traceFile Is Nothing Then
			Throw New ArgumentNullException("GetEventsFromFile")
		End If
		
		'm_objTraceEvents = New SignifEvents()
		objTempTraceEvents = New SignifEvents()
		stopwatch = New Stopwatch()
		dicFile = traceFile.Name.Split(".")
		dateString = DateTime.Now.ToString("d")        	        
		If dicFile.Length > 0 Then
			Dim dictionaryFile As String = dictionaryPath + "\" + dicFile(0) + ".dictionary"
			'Debug.Print(dictionaryFile)
        	If File.Exists(dictionaryFile) Then
        		m_objTraceEvents.DictionaryFileName = dictionaryFile	
        		m_traceFile = traceFile
        		getEventsFromFile(m_cFormat)
        	Else
        		'MessageService.ShowWarning("Cannot find file: " + g_sDICTIONARY_DIR + "\" + dicFile(0) + ".dictionary")	
        		Throw New FileNotFoundException("Cannot find file: " + dictionaryPath + "\" + dicFile(0) + ".dictionary")		        		
        	End If		        			        
		End If          

	End Sub
	
	Private Sub getEventsFromFile(ByVal m_cFormat As String)
		m_objTraceEvents.SourceFileName = m_traceFile.FullName
        m_objTraceEvents.MergeCollection.Clear()
        stopwatch.Start()
        LogHelper.Log("----------------------------------------------",-1,True)	            
        LogHelper.Log(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff") + " Parsing " + m_objTraceEvents.SourceFileName.ToString() , LogType.INFO, True)	            
        
        m_objTraceEvents.ParseDictionary(New ExtendedStreamReader(New FileStream(m_objTraceEvents.DictionaryFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), System.Text.Encoding.Default))	            
        
        m_objTraceEvents.ParseEvents(New ExtendedStreamReader(New FileStream(m_objTraceEvents.SourceFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), System.Text.Encoding.Default), g_bUnicodeDiagFiles, m_cFormat)
        'objTraceEvents.ParseEvents(g_bUnicodeDiagFiles, m_cFormat)
        stopwatch.Stop()
        'DoEvents()
        System.Windows.Forms.Application.DoEvents()

        If (m_objTraceEvents.Count > 0) Then

'            If (formLogAnalysisMain.MergedTraceEvents Is Nothing) Then
'                formLogAnalysisMain.MergedTraceEvents = objTraceEvents
'            Else
'                objTempTraceEvents = formLogAnalysisMain.MergedTraceEvents
'                formLogAnalysisMain.MergedTraceEvents = New SignifEvents
'                formLogAnalysisMain.MergedTraceEvents.Merge(objTempTraceEvents, objTraceEvents)
'            End If
			If (m_eventsFound Is Nothing) Then
                m_eventsFound = m_objTraceEvents
            Else
                objTempTraceEvents = m_eventsFound
                m_eventsFound = New SignifEvents
                m_eventsFound.Merge(objTempTraceEvents, m_objTraceEvents)
            End If
'				objTempTraceEvents = m_eventsFound
'                m_eventsFound = New SignifEvents
'                m_eventsFound.Merge(objTempTraceEvents, m_eventsFound)
        End If			
	End Sub	
End Class
	
	
		
'End Namespace

