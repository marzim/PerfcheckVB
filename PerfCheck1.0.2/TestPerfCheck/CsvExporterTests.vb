'
' Created by SharpDevelop.
' User: ta185044
' Date: 7/25/2012
' Time: 7:47 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports NUnit.Framework
Imports System.IO
<TestFixture> _
Public Class CsvExporterTests
	
	Private csvExporter As CsvExporter
	Private parserEventValues As ParserEventValues
	Dim parseValueDictionaryPath As String
	Dim diagPath As String = String.Empty
	Dim fpath As String = String.Empty
	<SetUp()> _
	Public Sub SetUp()
		parserEventValues = New ParserEventValues()
		TestData.createDictionaryFiles()
		diagPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\test\logs"
		fpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\test\config\NCR39\"
		parseValueDictionaryPath = fpath + "EventValues.dictionary"
		csvExporter = New CsvExporter()
		MessageService.Attach(New ConsoleMessageProvider())
	End Sub
	
	<TearDown()> _
	Public Sub TearDown()
		csvExporter = Nothing
	End Sub
	
	<Test> _
	Public Sub TestExportMergeEvents()
		Dim parsedData As SignifEvents = TestData.ParseEventsSample_TestReturnZero()
		Dim dateNow As String = DateTime.Now.ToString("MM-dd-yyHHmmssfff")
		Dim fileName As String = "reports" & "_" + dateNow + "Merged.csv"
		
		parsedData.DicEventValues = parserEventValues.Parsed(New ExtendedStreamReader(New FileStream(parseValueDictionaryPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), System.Text.Encoding.Default))
		csvExporter.ExportMergeEvents(parsedData.ListAllEvents(),TestData.createPathReports() &  "\" & fileName)
		Assert.IsTrue(System.IO.File.Exists(TestData.createPathReports() &  "\" & fileName))
	End Sub
	
	<Test> _
	Public Sub TestExportMergeEvents_NoDateNoMs()
		Dim parsedData As SignifEvents = TestData.ParseEventsSampleNoDateNoMs
		Dim dateNow As String = DateTime.Now.ToString("MM-dd-yyHHmmssfff")
		Dim fileName As String = "reports" & "_" + dateNow + "Merged.csv"
		csvExporter.ExportMergeEvents(parsedData.ListAllEvents(),TestData.createPathReports() &  "\" & fileName)
		Assert.IsTrue(System.IO.File.Exists(TestData.createPathReports() &  "\" & fileName))
	End Sub
	
	<Test> _
	Public Sub TestExportMergeEvents_NoDate()
		Dim parsedData As SignifEvents = TestData.ParseEventsSampleNoDate()
		Dim dateNow As String = DateTime.Now.ToString("MM-dd-yyHHmmssfff")
		Dim fileName As String = "reports" & "_" + dateNow + "Merged.csv"
		csvExporter.ExportMergeEvents(parsedData.ListAllEvents(),TestData.createPathReports() &  "\" & fileName)
		Assert.IsTrue(System.IO.File.Exists(TestData.createPathReports() &  "\" & fileName))
	End Sub
	<Test> _
	<ExpectedException(GetType(DirectoryNotFoundException))> _
	Public Sub TestExportMergeEvents_DirectoryNotFound()
		Dim parsedData As SignifEvents = TestData.ParseEventsSample_TestReturnZero()
		csvExporter.ExportMergeEvents(New LogEvents(New LogEvent()),"c:/directorynotfound/test.log")		
	End Sub
	
	<Test> _
	<ExpectedException(GetType(ArgumentNullException))> _
	Public Sub TestExportMergeEvents_ArgumentNull()		
		csvExporter.ExportMergeEvents(Nothing,"")		
	End Sub	
	
	<Test> _
	Public Sub TestExportSummaryEvents()
		'TODO: create a sample diag file 
		TestData.createSummaryAndTerminalInfoFiles()
		Dim bAppendTransactionStats As Boolean = True
		Dim cTemplates As New CTemplates
		Dim perfs As PerfMeasures
		Dim logEvents As LogEventsSummary
		Dim dateNow As String = DateTime.Now.ToString("MM-dd-yyHHmmssfff")
		Dim fileName As String = "reports" & "_" + dateNow + "Report.csv"
		Dim parsedData As New SignifEvents()
		Dim frmLogMain As New formLogAnalysisMain
		
		parsedData = TestData.ParseEventsSample_TestReturnZero()
		frmLogMain.EventsFound = parsedData
		frmLogMain.ShowMergedTrace(parsedData)
		
		cTemplates.Initialize(New ExtendedStringReader(TestData.PatternStub_LogAnalINI()))
		Assert.AreEqual(1,cTemplates.PatternMatch(frmLogMain.EventsFound,frmLogMain))
		Assert.Greater(cTemplates.TotalPatterns,0)
		cTemplates.cmdMakeCSVFiles(TestData.createPathReports() & "\AllPatterns",bAppendTransactionStats)
		Assert.IsTrue(System.IO.File.Exists(TestData.createPathReports() & "\AllPatterns_pat.csv"))
		perfs = cTemplates.Perfmeasures
		logEvents = cTemplates.Report()
		
		csvExporter.ExportSummaryEvents(logEvents,TestData.createPathReports() & "\" & fileName ,perfs, diagPath)
		
	End Sub
	
End Class
