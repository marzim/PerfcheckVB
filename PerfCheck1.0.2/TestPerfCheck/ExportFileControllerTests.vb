'
' Created by SharpDevelop.
' User: ta185044
' Date: 8/9/2012
' Time: 8:25 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports NUnit.Framework
Imports System.IO

<TestFixture> _
Public Class ExportFileControllerTests
	
	Private frmLogMain As formLogAnalysisMain
	Private exportFileController As ExportFileController
	
	Dim perfConfigData As PerfConfigData
	
	<SetUp()> _
	Public Sub SetUp()
		perfConfigData = New PerfConfigData()
		perfConfigData.DictionaryPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\test\config\NCR39\"
		perfConfigData.DiagFilesPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\test\logs"
		TestData.createDictionaryFiles()
		TestData.createEventLogFile()	
		frmLogMain = New formLogAnalysisMain()
		frmLogMain.PerfConfigData = perfConfigData
		exportFileController = New ExportFileController()
		MessageService.Attach(New ConsoleMessageProvider())
	End Sub
	
	<TearDown()> _
	Public Sub TearDown()
		frmLogMain = Nothing
		exportFileController = Nothing
	End Sub
	
	<Test> _
	Public Sub TestSummaryReport()
		Dim isSuccess As Boolean
		frmLogMain.EventsFound = getTraceList()
		frmLogMain.ShowMergedTrace(frmLogMain.EventsFound)
		isSuccess = exportFileController.SummaryReport(perfConfigData.DictionaryPath,perfConfigData.DiagFilesPath,frmLogMain.EventsFound)
		Assert.IsTrue(isSuccess)
	End Sub
	
	<Test> _
	Public Sub TestSummaryReport_NoEventsFound()
		Dim isSuccess As Boolean
		frmLogMain.EventsFound = getTraceList()
		isSuccess = exportFileController.SummaryReport(perfConfigData.DictionaryPath,perfConfigData.DiagFilesPath,frmLogMain.EventsFound)
		Assert.IsFalse(isSuccess)
	End Sub
	
	<Test> _
	Public Sub TestAllMergedEvents()
		Dim isSuccess As Boolean
		frmLogMain.EventsFound = getTraceList()
		frmLogMain.ShowMergedTrace(frmLogMain.EventsFound)
		isSuccess = exportFileController.AllMergedEvents(perfConfigData.DiagFilesPath,frmLogMain.EventsFound.ListAllEvents())
		Assert.IsTrue(isSuccess)
	End Sub
	
	Public Function getTraceList() As SignifEvents
		Dim i as Integer
    	Dim logfileController As New LogFileController()
    	Dim logEventsController As New LogEventsController()
    	logfileController.DiagPath = perfConfigData.DiagFilesPath
		logfileController.getTraceList(New ExtendedStringReader(TestData.LogAnalTraceListStub()))
    	frmLogMain.EventsFound = New SignifEvents()
    	
    	For Each keyval As KeyValuePair(Of String, FileInfo) In logFileController.DicTraceFile
    		If Not keyval.Value Is Nothing Then
    			logEventsController.ObjTraceEvents = New SignifEvents()
        		logEventsController.getEventsFromFile(keyval.Value, logfileController.m_cFormat(i), perfConfigData.DictionaryPath)
				i+=1		
    		End If
    	Next	
    	Return logEventsController.EventsFound
	End Function
End Class
