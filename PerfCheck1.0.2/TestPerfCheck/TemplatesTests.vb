'
' Created by SharpDevelop.
' User: ta185044
' Date: 7/18/2012
' Time: 5:04 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports NUnit.Framework
Imports System.IO
Imports System.Text
<TestFixture> _
Public Class TemplatesTests
	Private temp As CTemplates
	Private r As ExtendedStringReader
	Private parsedData As SignifEvents
	Private frmLogMain As formLogAnalysisMain
	
	Private fpath As String = String.Empty
	
	<SetUp()> _
	Public Sub SetUp()
		temp = New CTemplates
		parsedData = New SignifEvents()
		frmLogMain = New formLogAnalysisMain()
		MessageService.Attach(New ConsoleMessageProvider())
		
	End Sub
	
	<TearDown()> _
	Public Sub TearDown()
		temp = Nothing
		parsedData = Nothing
		frmLogMain = Nothing
		'r.Dispose
	End Sub
	
	<Test> _
	Public Sub TestInitialize_EmptyIniFile()
		r = New ExtendedStringReader("")
		Assert.IsNull(temp.Initialize(r))
		'r.Dispose
	End Sub
	
	<Test> _
	Public Sub TestInitialize_NoSection()
		r = New ExtendedStringReader("Scan from Attract, ItemScanned-TB_Start-To_SMBagAndEAS, ButtonClick - RED , Category=Transaction Start,MinLowLim=3000, MinUprLim=3500, MaxLowLim=4000, MaxUprLim=5000, AvgLowLim=3000, AvgUprLim=3500")
		Assert.NotNull(temp.Initialize(r))
		'r.Dispose
	End Sub
	
	<Test> _
	Public Sub TestInitialize_AnchorStates_Section()
		r = New ExtendedStringReader("[AnchorStates]" & Environment.NewLine & "" & Environment.NewLine & "ItemScanned" & Environment.NewLine & "ClickPickList" & Environment.NewLine & "To_SMFinish" & Environment.NewLine & "DrawAttract")
		Assert.NotNull(temp.Initialize(r))
		'r.Dispose
	End Sub
	<Test> _
	Public Sub TestInitialize_Patterns_Section()
		r = New ExtendedStringReader("[Patterns]" & Environment.NewLine & "" & Environment.NewLine & "" & Environment.NewLine & "Scan from Attract, ItemScanned-TB_Start-To_SMBagAndEAS, ButtonClick - RED , Category=Transaction Start,MinLowLim=3000, MinUprLim=3500, MaxLowLim=4000, MaxUprLim=5000, AvgLowLim=3000, AvgUprLim=3500")
		Assert.NotNull(temp.Initialize(r))
		Assert.AreEqual(4000,temp.Patterns.Item(1).NMaxLoLim)
		Assert.AreEqual(3000,temp.Patterns.Item(1).NMinLoLim)
		Assert.AreEqual(5000,temp.Patterns.Item(1).NMaxHiLim)
		Assert.AreEqual(4000,temp.Patterns.Item(1).NMaxLoLim)
		Assert.AreEqual(3500,temp.Patterns.Item(1).DAvgHiLim)
		Assert.AreEqual(3000,temp.Patterns.Item(1).DAvgLoLim)
		Assert.AreEqual("Transaction Start",temp.Patterns.Item(1).Category)
		'r.Dispose
	End Sub
	
	<Test> _
	Public Sub TestInitialize_Empty_State()
		r = New ExtendedStringReader("[Patterns]" & Environment.NewLine & "" & Environment.NewLine & "" & Environment.NewLine & "Scan from Attract, ItemScanned-TB_Start-To_SMBagAndEAS, ButtonClick - RED  ")
		Assert.NotNull(temp.Initialize(r))
		r.Dispose
	End Sub
	<Test> _
	Public Sub TestInitialize_Unknown_Section()
		r = New ExtendedStringReader("[Sample]" & Environment.NewLine & "" & Environment.NewLine & "" & Environment.NewLine & "Scan from Attract, ItemScanned-TB_Start-To_SMBagAndEAS, ButtonClick - RED , Category=Transaction Start,MinLowLim=3000, MinUprLim=3500, MaxLowLim=4000, MaxUprLim=5000, AvgLowLim=3000, AvgUprLim=3500")
		Assert.NotNull(temp.Initialize(r))
		'r.Dispose
	End Sub
	
	<Test> _
	Public Sub TestInitialize_AnchorStates_Section_UnknownState()
		r = New ExtendedStringReader("[AnchorStates]" & Environment.NewLine & "" & Environment.NewLine & "" & Environment.NewLine & "!From_SMScanAndBag-!From_SMScanAndBag-To_SMFinish, ButtonClick - To_SMScanAndBag - DrawContinueTrans , Category=Tender Select, MinLowLim=250, MinUprLim=300, MaxLowLim=300, MaxUprLim=400, AvgLowLim=300, AvgUprLim=350")
		Assert.NotNull(temp.Initialize(r))
		'r.Dispose
	End Sub
	
	<Test> _
	Public Sub TestInitialize_Lacking_PatternState()
		r = New ExtendedStringReader("[Patterns]" & Environment.NewLine & "" & Environment.NewLine & "" & Environment.NewLine & "Scan from Attract, ItemScanned-To_SMBagAndEAS, ButtonClick - RED , Category=Transaction Start")
		Assert.NotNull(temp.Initialize(r))
		'r.Dispose
	End Sub
	
	<Test> _
	Public Sub testReport()
		
		parsedData = TestData.ParseEventsSample_TestReturnZero()
		ProcessPattern(frmLogMain,parsedData)
		
		Assert.AreNotEqual(0,frmLogMain.DataGridView1.RowCount)
		
		temp.Initialize(New ExtendedStringReader(TestData.PatternStub_LogAnalINI()))
		temp.PatternMatch(frmLogMain.EventsFound,frmLogMain)
		
		Assert.AreEqual(45, temp.Report().GetEvents().Count)
	End Sub

	<Test> _
	Public Sub TestPatternMatchReturnsNonNegative()

		parsedData = TestData.ParseEventsSample_TestReturnZero()
		ProcessPattern(frmLogMain,parsedData)

		temp.Initialize(New ExtendedStringReader(TestData.PatternStub_LogAnalINI()))
		
		Assert.AreEqual(1,temp.PatternMatch(frmLogMain.EventsFound,frmLogMain))
		Assert.Greater(temp.TotalPatterns,0)

	End Sub
	
	<Test> _
	Public Sub TestPatternMatchReturnsNegative()
		
		parsedData = TestData.ParseEventsSample()
		ProcessPattern(frmLogMain,parsedData)
		
		temp.Initialize(New ExtendedStringReader(TestData.PatternStub_LogAnalINI()))
		Assert.AreEqual(-1,temp.PatternMatch(frmLogMain.EventsFound,frmLogMain))
	End Sub
	
	<Test> _
	<ExpectedException(GetType(Exception))> _
	Public Sub TestPatternMatchThrowException()
		
		parsedData = TestData.ParseEventsSampleGenerateEmptyEvents()
		ProcessPattern(frmLogMain,parsedData)
		
		temp.Initialize(New ExtendedStringReader(TestData.PatternStub_LogAnalINI()))
		temp.PatternMatch(frmLogMain.EventsFound,frmLogMain)
		'Assert.AreEqual(-1,temp.PatternMatch(frmLogMain.EventsFound,frmLogMain))
	End Sub
	
	<Test> _
	<ExpectedException(GetType(ArgumentNullException))> _
	Public Sub TestPatternNoEvents()
		
		parsedData = Nothing
		ProcessPattern(frmLogMain,parsedData)

		temp.Initialize(New ExtendedStringReader(TestData.PatternStub_LogAnalINI()))
		Assert.AreEqual(-1,temp.PatternMatch(frmLogMain.EventsFound,frmLogMain))
	End Sub
	
	<Test> _
	Public Sub TestGetPerfMeasureData()
		Dim cpattern As New CPattern()
		cpattern.PatternName = "Scan from Attract"
		cpattern.KeyValPairs = "Category=Transaction Start,MinLowLim=3000, MinUprLim=3500, MaxLowLim=4000, MaxUprLim=5000, AvgLowLim=3000, AvgUprLim=3500"
		Dim perf As PerfMeasure = temp.GetPerfMeasureData(cpattern)
'		For Each s As PerfMeasure In temp.Perfmeasures.GetMeasures
'			Assert.AreEqual(s.Measure,perf.Measure)
'			Exit For
'		Next
		Assert.AreEqual(cpattern.PatternName,perf.Measure)
		Assert.AreEqual(cpattern.DAvgHiLim,perf.DAvgHiLim)
		Assert.AreEqual(cpattern.DAvgLoLim,perf.DAvgLoLim)
		Assert.AreEqual(cpattern.NMaxHiLim,perf.NMaxHiLim)
		Assert.AreEqual(cpattern.NMaxLoLim,perf.NMaxLoLim)
		Assert.AreEqual(cpattern.NMinHiLim,perf.NMinHiLim)
		Assert.AreEqual(cpattern.NMinLoLim,perf.NMinLoLim)
		
	End Sub
	
	<Test> _
	Public Sub TestMakeCSVFile()
		Dim bAppendTransactionStats As Boolean = True
		Dim perf As PerfMeasures
		
		parsedData = TestData.ParseEventsSample_TestReturnZero()
		ProcessPattern(frmLogMain,parsedData)
		
		temp.Initialize(New ExtendedStringReader(TestData.PatternStub_LogAnalINI()))
		Assert.AreEqual(1,temp.PatternMatch(frmLogMain.EventsFound,frmLogMain))
		Assert.Greater(temp.TotalPatterns,0)
		temp.cmdMakeCSVFiles(TestData.createPathReports() & "\AllPatterns",bAppendTransactionStats)
		temp.AddPerfMeasuresData(temp.TotalPatterns,temp.Patterns)
		perf = temp.Perfmeasures
		
		Assert.AreEqual(perf.GetMeasures.Item(1).Measure,temp.Perfmeasures.GetMeasures.Item(1).Measure)
		Assert.Greater(perf.GetMeasures.Count,0)
		temp.Perfmeasures.GetMeasures.Clear()
		temp.Perfmeasures = perf
		
		Assert.AreEqual(perf.GetMeasures.Count,temp.Perfmeasures.GetMeasures.Count)
		Assert.IsTrue(System.IO.File.Exists(TestData.createPathReports() & "\AllPatterns_pat.csv"))
	End Sub
	
	<Test> _
	Public Sub TestMakeCSVFile_NoPatternToExport()
		Dim bAppendTransactionStats As Boolean = True
		temp.cmdMakeCSVFiles("AllPatterns",bAppendTransactionStats)
	End Sub
	
'	<ExpectedException(GetType(ArgumentNullException))> _
'	<Test> _
'	Public Sub TestPatternMatchReturnsException
'		Dim parsedData As SignifEvents = TestData.ParseEventsSample_TestCreatesException()
'		Assert.IsNull(parsedData)
'		Dim frmLogMain As formLogAnalysisMain = TestData.SampleFormLogAnalysisMain(parsedData)
'		
'		Assert.AreEqual(0,parsedData.MergeCollection.Count)
'		temp.Initialize(New ExtendedStringReader(TestData.PatternStub_LogAnalINI()))
'		temp.PatternMatch(parsedData,frmLogMain)
'		'Assert.AreEqual(-1,temp.PatternMatch(parsedData,frmLogMain))
'	End Sub

	Public Sub ProcessPattern(ByRef frmMain As formLogAnalysisMain, ByRef parsedData As SignifEvents)
		frmMain.EventsFound = parsedData
		frmMain.ShowMergedTrace(frmMain.EventsFound)
	End Sub
End Class
