'
' Created by SharpDevelop.
' User: ta185044
' Date: 8/9/2012
' Time: 2:23 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports NUnit.Framework
Imports System.IO

<TestFixture> _
Public Class LogFileFormTests
	
	Private frmMain As formLogAnalysisMain
	Private logfileFrm As LogFileForm
	Dim perfConfigData As PerfConfigData
	
	<SetUp()> _
	Public Sub SetUp()
		perfConfigData = New PerfConfigData()
		perfConfigData.DictionaryPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\test\config\NCR39\"
		perfConfigData.DiagFilesPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\test\logs"
		TestData.createDictionaryFiles()
		TestData.createEventLogFile()	
		frmMain = New formLogAnalysisMain()
		frmMain.PerfConfigData = perfConfigData
		getGeneratedEvents(getTraceList())
		MessageService.Attach(New ConsoleMessageProvider())
	End Sub
	
	<TearDown()> _
	Public Sub TearDown()
		frmMain = Nothing
		logfileFrm = Nothing
	End Sub
	
	<Test> _
	Public Sub Initialize_Empty()
		logfileFrm = New LogFileForm()
	End Sub
	
	<Test> _
	Public Sub TestFindDataInFile()
		' TODO: Add your test.
		Dim searchData As String
		frmMain.DataGridView1.CurrentCell = frmMain.DataGridView1(1,1)
		searchData = frmMain.DataGridView1.SelectedRows(0).Cells(1).Value.ToString() + frmMain.DataGridView1.SelectedRows(0).Cells(2).Value.ToString() + "`" + frmMain.DataGridView1.SelectedRows(0).Cells(8).Value.ToString()
		logfileFrm = New LogFileForm(searchData,perfConfigData)
		logfileFrm.LogFileFormLoad(Nothing,Nothing)
		
	End Sub
	
	<Test> _
	Public Sub TestFindDataInFile_TraceListNotFound()
		' TODO: Add your test.
		Dim searchData As String
		perfConfigData.DictionaryPath = ""
		frmMain.DataGridView1.CurrentCell = frmMain.DataGridView1(1,1)
		searchData = frmMain.DataGridView1.SelectedRows(0).Cells(1).Value.ToString() + frmMain.DataGridView1.SelectedRows(0).Cells(2).Value.ToString() + "`" + frmMain.DataGridView1.SelectedRows(0).Cells(8).Value.ToString()
		logfileFrm = New LogFileForm(searchData,perfConfigData)
		logfileFrm.LogFileFormLoad(Nothing,Nothing)
		
	End Sub

	
	Public Sub getGeneratedEvents(eventsFound As SignifEvents)
		frmMain.EventsFound = eventsFound
		frmMain.ShowMergedTrace(frmMain.EventsFound)
		Assert.AreNotEqual(0,frmMain.DataGridView1.RowCount)
	End Sub
	
	Public Function getTraceList() As SignifEvents
		Dim i as Integer
    	Dim logfileController As New LogFileController()
    	Dim logEventsController As New LogEventsController()
    	logfileController.DiagPath = perfConfigData.DiagFilesPath
		logfileController.getTraceList(New ExtendedStringReader(TestData.LogAnalTraceListStub()))
    	frmMain.EventsFound = New SignifEvents()
    	
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
