'
' Created by SharpDevelop.
' User: ta185044
' Date: 7/20/2012
' Time: 7:12 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports NUnit.Framework
Imports System.IO
Imports System.Reflection
Imports Microsoft.Win32
<TestFixture> _
Public Class FormAnalyisMainTests
	
	Private frmLogMain As formLogAnalysisMain
	Private fls As formLogAnalSearch
	Private parserEventValues As ParserEventValues
	Dim perfConfigData As PerfConfigData
	Dim parseValueDictionaryPath As String
	<SetUp()> _
	Public Sub SetUp()
		perfConfigData = New PerfConfigData()
		perfConfigData.DictionaryPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\test\config\NCR39\"
		perfConfigData.DiagFilesPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\test\logs"
		TestData.createDictionaryFiles()
		TestData.createEventLogFile()
		parseValueDictionaryPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\test\config\NCR39\EventValues.dictionary"
		parserEventValues = New ParserEventValues()
		frmLogMain = New formLogAnalysisMain()
		frmLogMain.PerfConfigData = perfConfigData
		fls = New formLogAnalSearch()
		frmLogMain.Subscribe(fls)
		MessageService.Attach(New ConsoleMessageProvider())
	End Sub
	
	<TearDown()> _
	Public Sub TearDown()
		frmLogMain.RemoveSubscription(fls)
		frmLogMain = Nothing	
	End Sub
	
	<Test> _
	Public Sub TestAddEventsToDataGridView_FormNotLoad()
		' TODO: Add your test.
'		Dim p1 As New SignifEvents()
'		p1.ParseDictionary(New ExtendedStringReader("App_Waiting, SMState::TBParse() and not ScanAndBag state, " & Environment.NewLine & "PSX_Done, -EventHandler Event( ,Display,BagAndEAS,ChangeContext )" & Environment.NewLine))
'		p1.ParseEvents(New ExtendedStringReader("12352421) 06/02 21:27:04;0956314406 -RCMgri@21   <<< RAInterface::OnEvent"  & Environment.NewLine & "12355291) 06/02 21:29:53;0956483375 PS-PSt@651  -EventHandler Event( ,Display,BagAndEAS,ChangeContext ) "  & Environment.NewLine & "12355763) 06/02 21:29:58;0956487968 SM-SmStateTB@140  SMState::TBParse() and not ScanAndBag state, setting bItemSoldButNoTotalYet=false" & Environment.NewLine))
'		Dim p2 As New SignifEvents()
'		p2.ParseDictionary(New ExtendedStringReader("Description, key=item-description.  value=" & Environment.NewLine & "UnMatched_Weight, UnMatched: Weight increase of" & Environment.NewLine))
'		p2.ParseEvents(New ExtendedStringReader("SM: 05/02 05:49:34       581,686 0A24> --- Begin Data Capture --- (continued)" & Environment.NewLine & "SM: 05/09 07:18:41   610,713,759 00FC> UnMatched: Weight increase of  5730. App determining if allowed..." & Environment.NewLine & "SM: 05/09 07:19:28   610,760,897 00FC> Parsing key=item-description.  value=""" & Environment.NewLine))
'		Dim p3 As New SignifEvents()
'		p3.Merge(p1, p2)		
'		Dim logevents As New LogEvents()
'		logevents = p3.ListAllEvents()
'		Assert.AreEqual(2, logevents.GetEvents().Count)
'		frmLogMain.MergedTraceEvents = p3
		frmLogMain.EventsFound = TestData.ParseEventsSample()
		Assert.AreEqual(2,frmLogMain.EventsFound.Count)
		frmLogMain.addEventsToDataGridView()
		Assert.Less(0,frmLogMain.DataGridView1.RowCount)		
		'frmLogMain.ExportMergeToolStripMenuItem.PerformClick
		'Assert.True(File.Exists(frmLogMain))
	End Sub	
	
	<Test> _
	Public Sub TestCopyToolStrip()
		Dim p1 As New SignifEvents()
		p1.ParseDictionary(New ExtendedStringReader("App_Waiting, SMState::TBParse() and not ScanAndBag state, " & Environment.NewLine & "PSX_Done, -EventHandler Event( ,Display,BagAndEAS,ChangeContext )" & Environment.NewLine))
		p1.ParseEvents(New ExtendedStringReader("12352421) 06/02 21:27:04;0956314406 -RCMgri@21   <<< RAInterface::OnEvent"  & Environment.NewLine & "12355291) 06/02 21:29:53;0956483375 PS-PSt@651  -EventHandler Event( ,Display,BagAndEAS,ChangeContext ) "  & Environment.NewLine & "12355763) 06/02 21:29:58;0956487968 SM-SmStateTB@140  SMState::TBParse() and not ScanAndBag state, setting bItemSoldButNoTotalYet=false" & Environment.NewLine))
		Dim p2 As New SignifEvents()
		p2.ParseDictionary(New ExtendedStringReader("Description, key=item-description.  value=" & Environment.NewLine & "UnMatched_Weight, UnMatched: Weight increase of" & Environment.NewLine))
		p2.ParseEvents(New ExtendedStringReader("SM: 05/02 05:49:34       581,686 0A24> --- Begin Data Capture --- (continued)" & Environment.NewLine & "SM: 05/09 07:18:41   610,713,759 00FC> UnMatched: Weight increase of  5730. App determining if allowed..." & Environment.NewLine & "SM: 05/09 07:19:28   610,760,897 00FC> Parsing key=item-description.  value=""" & Environment.NewLine))
		Dim p3 As New SignifEvents()
		p3.Merge(p1, p2)
		p3.DicEventValues = parserEventValues.Parsed(New ExtendedStreamReader(New FileStream(parseValueDictionaryPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), System.Text.Encoding.Default))
		Dim logevents As New LogEvents()
		logevents = p3.ListAllEvents()
		frmLogMain.EventsFound = p3
		frmLogMain.addEventsToDataGridView()
		frmLogMain.CopyToolStripMenuItemClick(Nothing, Nothing)
	End Sub
	
'	<Test> _
'	Public Sub testDeleteSaveReg()
'		Registry.CurrentUser.DeleteSubKey(perfConfigData.Subkey)
'		frmLogMain.InitPerfConfig()
'		frmLogMain.SaveToReg()
'	End Sub
	
'	<Test> _
'	Public Sub testSetKgsToLbsAndSetHideDuplicates()
'		frmLogMain.setKgsToLbs()
'		frmLogMain.KgsToLbsToolStripMenuItem.Checked = True
'		frmLogMain.setKgsToLbs()		
'		frmLogMain.setHideDuplicates()
'		frmLogMain.HideDuplicatesToolStripMenuItem.Checked = True
'		frmLogMain.setHideDuplicates()
'	End Sub
	
	<Test> _
	Public Sub TestAddEventsToDataGridView_FormIsLoad()
		' TODO: Add your test.
		Me.TestAddEventsToDataGridView_FormNotLoad()
		frmLogMain.LoadMain()
		'frmLogMain.ExportMergeToolStripMenuItem.PerformClick
		'Assert.True(File.Exists(frmLogMain.SFullFileName))
	End Sub	
	
	<Test> _
	Public Sub TestExportMergeToolStripMenuItem_NoDataGridView()
		' TODO: Add your test.
		frmLogMain.ExportMergeToolStripMenuItem.PerformClick
		Assert.AreEqual(0,frmLogMain.DataGridView1.RowCount)
	End Sub
	
'	<Test> _
'	Public Sub TestCMDShowMergedTrace_Click
'		Dim p1 As New SignifEvents()
'		p1.ParseDictionary(New ExtendedStringReader("App_Waiting, SMState::TBParse() and not ScanAndBag state, " & Environment.NewLine & "PSX_Done, -EventHandler Event( ,Display,BagAndEAS,ChangeContext )" & Environment.NewLine))
'		p1.ParseEvents(New ExtendedStringReader("12352421) 06/02 21:27:04;0956314406 -RCMgri@21   <<< RAInterface::OnEvent"  & Environment.NewLine & "12355291) 06/02 21:29:53;0956483375 PS-PSt@651  -EventHandler Event( ,Display,BagAndEAS,ChangeContext ) "  & Environment.NewLine & "12355763) 06/02 21:29:58;0956487968 SM-SmStateTB@140  SMState::TBParse() and not ScanAndBag state, setting bItemSoldButNoTotalYet=false" & Environment.NewLine))
'		Dim p2 As New SignifEvents()
'		p2.ParseDictionary(New ExtendedStringReader("Description, key=item-description.  value=" & Environment.NewLine & "UnMatched_Weight, UnMatched: Weight increase of" & Environment.NewLine))
'		p2.ParseEvents(New ExtendedStringReader("SM: 05/02 05:49:34       581,686 0A24> --- Begin Data Capture --- (continued)" & Environment.NewLine & "SM: 05/09 07:18:41   610,713,759 00FC> UnMatched: Weight increase of  5730. App determining if allowed..." & Environment.NewLine & "SM: 05/09 07:19:28   610,760,897 00FC> Parsing key=item-description.  value=""" & Environment.NewLine))
'		Dim p3 As New SignifEvents()
'		p3.Merge(p1, p2)		
'		Dim logevents As New LogEvents()
'		logevents = p3.ListAllEvents()
'		Assert.AreEqual(2, logevents.GetEvents().Count)
'		frmLogMain.MergedTraceEvents = p3
'		frmLogMain.addEventsToDataGridView()
'		'frmLogMain.cmdShowMergedTrace_Click()
'		Assert.IsNotNull(frmLogMain.MergedTraceEvents)
'	End Sub
'	
'	<Test> _
'	Public Sub TestCMDShowMergedTrace_Click_EmptyMergedTraceEvents
'
'		frmLogMain.MergedTraceEvents = Nothing
'		'frmLogMain.cmdShowMergedTrace_Click()
'		Assert.IsNull(frmLogMain.MergedTraceEvents)
'	End Sub
	
'	<Test> _
'	Public Sub TestCMDShowMergedTrace_Click_NoEventsFound
'		
'		Dim p1 As New SignifEvents()
'		p1.ParseDictionary(New ExtendedStringReader("App_Waiting, SMState::TBParse() and not ScanAndBag state, " & Environment.NewLine & "PSX_Done, -EventHandler Event( ,Display,BagAndEAS,ChangeContext )" & Environment.NewLine))
'		p1.ParseEvents(New ExtendedStringReader("12352421) 06/02 21:27:04;0956314406 -RCMgri@21   <<< RAInterface::OnEvent"  & Environment.NewLine & "12355291) 06/02 21:29:53;0956483375 PS-PSt@651  -EventHandler Event( ,Display,BagAndEAS,ChangeContext ) "  & Environment.NewLine & "12355763) 06/02 21:29:58;0956487968 SM-SmStateTB@140  SMState::TBParse() and not ScanAndBag state, setting bItemSoldButNoTotalYet=false" & Environment.NewLine))
'		Dim p2 As New SignifEvents()
'		p2.ParseDictionary(New ExtendedStringReader("Description, key=item-description.  value=" & Environment.NewLine & "UnMatched_Weight, UnMatched: Weight increase of" & Environment.NewLine))
'		p2.ParseEvents(New ExtendedStringReader("SM: 05/02 05:49:34       581,686 0A24> --- Begin Data Capture --- (continued)" & Environment.NewLine & "SM: 05/09 07:18:41   610,713,759 00FC> UnMatched: Weight increase of  5730. App determining if allowed..." & Environment.NewLine & "SM: 05/09 07:19:28   610,760,897 00FC> Parsing key=item-description.  value=""" & Environment.NewLine))
'		Dim p3 As New SignifEvents()
'		p3.Merge(p1, p2)		
'		Dim logevents As New LogEvents()
'		logevents = p3.ListAllEvents()
'		Assert.AreEqual(2, logevents.GetEvents().Count)
'		frmLogMain.MergedTraceEvents = p3
'		frmLogMain.addEventsToDataGridView()
'		'frmLogMain.cmdShowMergedTrace_Click()
'		Assert.IsNotNull(frmLogMain.MergedTraceEvents)
'		
'	End Sub
	
'	<Test> _
'	Public Sub TestExportSummaryReportToCSV
'		frmLogMain.MergedTraceEvents = TestData.ParseEventsSample_TestReturnZero()
'		frmLogMain.addEventsToDataGridView()
'		frmLogMain.ExportsummaryreportClick(Nothing,Nothing)
'	End Sub	
	
	<Test> _
	Public Sub TestExportSummaryReportToCSV_NoData()
		' TODO: Add your test.
		Dim obj As New Object
		Dim sEvent As New System.EventArgs
		frmLogMain.ExportsummaryreportClick(obj,sEvent)
		Assert.AreEqual(0,frmLogMain.DataGridView1.RowCount)
	End Sub
	
	<Test> _
	Public Sub TestAllPattern()
		' TODO: Add your test.
		Dim p1 As New SignifEvents()
		p1.ParseDictionary(New ExtendedStringReader("App_Waiting, SMState::TBParse() and not ScanAndBag state, " & Environment.NewLine & "PSX_Done, -EventHandler Event( ,Display,BagAndEAS,ChangeContext )" & Environment.NewLine))
		p1.ParseEvents(New ExtendedStringReader("12352421) 06/02 21:27:04;0956314406 -RCMgri@21   <<< RAInterface::OnEvent"  & Environment.NewLine & "12355291) 06/02 21:29:53;0956483375 PS-PSt@651  -EventHandler Event( ,Display,BagAndEAS,ChangeContext ) "  & Environment.NewLine & "12355763) 06/02 21:29:58;0956487968 SM-SmStateTB@140  SMState::TBParse() and not ScanAndBag state, setting bItemSoldButNoTotalYet=false" & Environment.NewLine))
		Dim p2 As New SignifEvents()
		p2.ParseDictionary(New ExtendedStringReader("Description, key=item-description.  value=" & Environment.NewLine & "UnMatched_Weight, UnMatched: Weight increase of" & Environment.NewLine))
		p2.ParseEvents(New ExtendedStringReader("SM: 05/02 05:49:34       581,686 0A24> --- Begin Data Capture --- (continued)" & Environment.NewLine & "SM: 05/09 07:18:41   610,713,759 00FC> UnMatched: Weight increase of  5730. App determining if allowed..." & Environment.NewLine & "SM: 05/09 07:19:28   610,760,897 00FC> Parsing key=item-description.  value=""" & Environment.NewLine))
		Dim p3 As New SignifEvents()
		p3.Merge(p1, p2)
		p3.DicEventValues = parserEventValues.Parsed(New ExtendedStreamReader(New FileStream(parseValueDictionaryPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), System.Text.Encoding.Default))
		Dim logevents As New LogEvents()
		logevents = p3.ListAllEvents()
		frmLogMain.EventsFound = p3
		frmLogMain.addEventsToDataGridView()
		'frmLogMain.LoadMain()
		frmLogMain.AllPatterns()
		Assert.AreEqual(2,frmLogMain.DataGridView1.RowCount)
	End Sub
	
	<Test> _
	Public Sub TestExportSummaryReport()
		'CommandLine.ParseLogEvents(New ExtendedStringReader(TestData.LogAnalTraceListStub()), diagPath, fpath)
		
		
		frmLogMain.EventsFound = getTraceList()
		frmLogMain.ShowMergedTrace(frmLogMain.EventsFound)
		'frmLogMain.ExportSummaryReportToCSV(Path.GetDirectoryName(perfConfigData.DictionaryPath), perfConfigData.DiagFilesPath, getTraceList())
		frmLogMain.ExportSummaryReportToCSV(perfConfigData.DictionaryPath, perfConfigData.DiagFilesPath, frmLogMain.EventsFound)
	End Sub
	
	<Test> _
	Public Sub TestExportSummaryReportNotingToExport()
		'CommandLine.ParseLogEvents(New ExtendedStringReader(TestData.LogAnalTraceListStub()), diagPath, fpath)
		
		'frmLogMain.ShowMergedTrace(getTraceList())
		'frmLogMain.EventsFound = getTraceList()
		frmLogMain.ExportSummaryReportToCSV(Path.GetDirectoryName(perfConfigData.DictionaryPath), perfConfigData.DiagFilesPath, Nothing)
	End Sub
	
	<Test> _
	Public Sub TestExportSummaryReportNoEventsFoundToExport()
		'CommandLine.ParseLogEvents(New ExtendedStringReader(TestData.LogAnalTraceListStub()), diagPath, fpath)
		
		'frmLogMain.ShowMergedTrace(getTraceList())
		'frmLogMain.EventsFound = getTraceList()
		frmLogMain.ExportSummaryReportToCSV(Path.GetDirectoryName(perfConfigData.DictionaryPath), perfConfigData.DiagFilesPath,getTraceList())
	End Sub
	
	<Test> _
	Public Sub TestExportAllMergedEvents()
		'CommandLine.ParseLogEvents(New ExtendedStringReader(TestData.LogAnalTraceListStub()), diagPath, fpath)
		
		'frmLogMain.ShowMergedTrace(getTraceList())
		frmLogMain.ParsedEventValues(perfConfigData.DictionaryPath)
		frmLogMain.ExportMergeEvents(perfConfigData.DiagFilesPath, getTraceList())
	End Sub	
	
	<Test> _
	Public Sub TestShowMergedTrace()
		getGeneratedEvents(getTraceList()) 'parsed and generate merged data 
		Assert.AreNotEqual(0,frmLogMain.DataGridView1.RowCount)	
	End Sub
	
	<Test> _
	Public Sub TestShowMergedTraceNoEventsMerge()
		'GeneratedNoEvents(TestData.GenerateEmptyMergeEvents()) 
		'parsed and generate merged data
		frmLogMain.EventsFound = TestData.ParseEventsSampleGenerateEmptyEvents()
		frmLogMain.ShowMergedTrace(frmLogMain.EventsFound)
	End Sub
	
	<Test> _
	Public Sub TestFindToolStripMenuItem_Click()
		'Dim frmSearch As New formSearchString()
		Dim isFoundTest1,isFoundTest2,isFoundTest3 As Boolean
		Dim searchString As String = "ButtonClick"
		
		getGeneratedEvents(getTraceList()) 'parsed and generate merged data 
		'GenerateEventsForFormMain(frmLogMain,"FindToolStripMenuItem_Click")
		'frmSearch.txtSearchText.Text = "PSX_Done"
		'frmSearch.Close()
		'GenerateEventsForFormSearch(frmSearch,"OKButton_Click")
		isFoundTest1 = frmLogMain.do_find(searchString) 'search string was found
		Assert.IsTrue(isFoundTest1)
		frmLogMain.FindAgainToolStripMenuItemClick(Nothing,Nothing)
		
		isFoundTest2 = frmLogMain.do_find("data") 'reached end of file
		Assert.IsFalse(isFoundTest2)
		frmLogMain.FindAgainToolStripMenuItemClick(Nothing,Nothing)
		
		isFoundTest3 = frmLogMain.do_find(Nothing) ' Produce Exception "Current cell cannot be set to an invisible cell"
		Assert.IsFalse(isFoundTest3)
		frmLogMain.FindAgainToolStripMenuItemClick(Nothing,Nothing)
	End Sub
	
'	<Test> _
'	Public Sub TestFindAgainToolStripMenuItemClick()
'		Dim isFoundTest1 As Boolean
'		Dim searchString As String = "DrawQuickPick"
'		frmLogMain.EventsFound = getTraceList()
'		frmLogMain.ShowMergedTrace(frmLogMain.EventsFound)
'		isFoundTest1 = frmLogMain.do_find(searchString) 'search string was found
'		Assert.IsTrue(isFoundTest1)
'		frmLogMain.FindAgainToolStripMenuItemClick(Nothing,Nothing)
'	End Sub
'	Public Sub GeneratePrivateMethodTestForFormMain(frmMain As formLogAnalysisMain,methodName As String)
'		
'		'Get the constructor and create an instance of FormDiagOpen
'		Dim type As Type=frmMain.GetType()
'		Dim frmLogMainDetailConstructor As ConstructorInfo = type.GetConstructor(Type.EmptyTypes)
'        Dim frmLogMainDetailClassObject As Object = frmLogMainDetailConstructor.Invoke(New Object(){})
'		
'		' Get the OK_Button_Click method and invoke with a parameter value of Nothing
'		Dim dynamicMethod As MethodInfo = type.GetMethod(methodName, BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.DeclaredOnly)
'		Dim obj As Object() = {frmMain,Nothing}
'		dynamicMethod.Invoke(frmLogMainDetailClassObject,obj)
'		
'	End Sub
	
'	Public Sub GenerateEventsForFormMain(frmMain As formLogAnalysisMain,eventName As String)
'		
'		'Get the constructor and create an instance of FormDiagOpen
'		Dim type As Type=frmMain.GetType()
'		Dim frmLogMainDetailConstructor As ConstructorInfo = type.GetConstructor(Type.EmptyTypes)
'        Dim frmLogMainDetailClassObject As Object = frmLogMainDetailConstructor.Invoke(New Object(){})
'		
'		' Get the OK_Button_Click method and invoke with a parameter value of Nothing
'		Dim dynamicMethod As MethodInfo = type.GetMethod(eventName, BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.DeclaredOnly)
'		Dim obj As Object() = {frmMain,Nothing}
'		dynamicMethod.Invoke(frmLogMainDetailClassObject,obj)
'		
'	End Sub
'	
'	Public Sub GenerateEventsForFormSearch(frmSearch As formSearchString,eventName As String)
'		
'		'Get the constructor and create an instance of FormDiagOpen
'		Dim type As Type=frmSearch.GetType()
'		Dim frmSearchDetailConstructor As ConstructorInfo = type.GetConstructor(Type.EmptyTypes)
'        Dim frmSearchDetailClassObject As Object = frmSearchDetailConstructor.Invoke(New Object(){})
'		
'		' Get the OK_Button_Click method and invoke with a parameter value of Nothing
'		Dim dynamicMethod As MethodInfo = type.GetMethod(eventName, BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.DeclaredOnly)
'		Dim obj As Object() = {frmSearch,Nothing}
'		dynamicMethod.Invoke(frmSearchDetailClassObject,obj)
'		
'	End Sub
	
	<Test> _
	Public Sub TestClickHideDuplicate()
		
		getGeneratedEvents(getTraceList()) 'parsed and generate merged data 
		
		'initialy HideDuplicatestool menu item is unchecked
		Assert.IsFalse(frmLogMain.KgsToLbsToolStripMenuItem.Checked)
		
		frmLogMain.HideDuplicatesToolStripMenuItemClick(frmLogMain,Nothing) 'it was clicked
		Assert.IsTrue(frmLogMain.HideDuplicatesToolStripMenuItem.Checked) 'it is now checked
		frmLogMain.HideDuplicatesToolStripMenuItemClick(frmLogMain,Nothing) 'it was clicked
		Assert.IsFalse(frmLogMain.HideDuplicatesToolStripMenuItem.Checked) 'it is now unchecked
		
	End Sub
	
	<Test> _
	Public Sub TestClickKgsToLbs()
		
		getGeneratedEvents(getTraceList()) 'parsed and generate merged data 
		
		'initialy kgstolbs menu item is unchecked
		Assert.IsFalse(frmLogMain.KgsToLbsToolStripMenuItem.Checked)
		
		frmLogMain.KgsToLbsToolStripMenuItemClick(frmLogMain,Nothing) 'it was clicked
		Assert.IsTrue(frmLogMain.KgsToLbsToolStripMenuItem.Checked) 'it is now checked
		
		frmLogMain.KgsToLbsToolStripMenuItemClick(frmLogMain,Nothing)'it was clicked again
		Assert.IsFalse(frmLogMain.KgsToLbsToolStripMenuItem.Checked) 'it is now unchecked
	End Sub
	
	<Test> _
	Public Sub TestAutoDetectTemplate()
		Dim isSuccess As Boolean
		perfConfigData = New PerfConfigData()
		perfConfigData.DictionaryPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\test\config\NCR39\"
		perfConfigData.DiagFilesPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\test\logs"
		frmLogMain.PerfConfigData = perfConfigData
		isSuccess = frmLogMain.AutoDetectTemplate(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\test\logs")
		Assert.IsTrue(isSuccess)
	End Sub
	
	<Test> _
	Public Sub TestAutoDetectTemplate_DictionaryPathNotFound()
		Dim isSuccess As Boolean
		perfConfigData = New PerfConfigData()
		perfConfigData.DictionaryPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\testing\config\NCR39\"
		perfConfigData.DiagFilesPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\test\logs"
		frmLogMain.PerfConfigData = perfConfigData
		isSuccess = frmLogMain.AutoDetectTemplate(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\test\logs")
		Assert.IsFalse(isSuccess) 'false'
	End Sub
	
	<Test> _
	Public Sub TestCheckForListingClockEvents()
		frmLogMain.CheckForListingClockEvents() 
	End Sub
	
	<Test> _
	Public Sub TestParsedEventValuesFileNotFound()
		File.Delete(parseValueDictionaryPath)
		frmLogMain.ParsedEventValues(perfConfigData.DictionaryPath)
	End Sub
	
'	<Test> _
'	Public Sub TestAutoDetectTemplate_ADKNotFound()
'		Dim isSuccess As Boolean
'		Directory.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\test\config\NCR39",True)
'		TestData.createDictionaryFiles2()
'		perfConfigData = New PerfConfigData()
'		perfConfigData.DictionaryPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\test\config\NCR39\"
'		perfConfigData.DiagFilesPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\test\logs"
'		isSuccess = frmLogMain.AutoDetectTemplate(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\test\logs")
'		Assert.IsFalse(isSuccess)
'	End Sub
	
'	<Test> _
'	Public Sub TestAutoDetectTemplatesToolStripMenuItemClick()
'		frmLogMain.AutoDetectTemplatesToolStripMenuItemClick(frmLogMain,Nothing)
'	End Sub
'	<Test> _
'	Public Sub TestOpenDiagFile()
'		Dim folderBrowser As New  FolderBrowserDialog()
'		frmLogMain.OpenDiagFile(folderBrowser)
'	End Sub

	Public Sub getGeneratedEvents(eventsFound As SignifEvents)
		frmLogMain.EventsFound = eventsFound
		frmLogMain.ShowMergedTrace(frmLogMain.EventsFound)
		Assert.AreNotEqual(0,frmLogMain.DataGridView1.RowCount)
	End Sub
	
	Public Sub GeneratedNoEvents(eventsFound As SignifEvents)
		frmLogMain.EventsFound = eventsFound
		frmLogMain.ShowMergedTrace(frmLogMain.EventsFound)
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
    			logEventsController.ObjTraceEvents.DicEventValues = parserEventValues.Parsed(New ExtendedStreamReader(New FileStream(parseValueDictionaryPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), System.Text.Encoding.Default))
        		logEventsController.getEventsFromFile(keyval.Value, logfileController.m_cFormat(i), perfConfigData.DictionaryPath)
				i+=1		
    		End If
    	Next	
    	Return logEventsController.EventsFound
	End Function

End Class
