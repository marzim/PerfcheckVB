'
' Created by SharpDevelop.
' User: ta185044
' Date: 7/17/2012
' Time: 12:27 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports NUnit.Framework
Imports PerfCheck
<TestFixture> _
Public Class CStatisticsTests
	Private cStats As CStatistics	
	Private cPattern As CPattern 
	<SetUp()> _
	Public Sub SetUp()
		MessageService.Attach(New ConsoleMessageProvider())
		cPattern = New CPattern()
		cStats = New CStatistics()
		cPattern = SampleReportData()
	End Sub
	
	<TearDown()> _
	Public Sub TearDown()
		cStats = Nothing
	End Sub
	
	<Test> _
	Public Sub TestReport()
		' TODO: Add your test.
		'Dim cStats As New CStatistics
		Dim str As String=cStats.Report()
		Assert.IsNotEmpty(str,"Not empty")
	End Sub
	'<ExpectedException(GetType(IndexOutOfRangeException))> _
	<Test> _
	Public Sub TestReport_WithParam()
		' TODO: Add your test.
		Dim dgr(6) As String
		Dim flag(6) As Integer
		Dim str As String=cPattern.stats.Report(dgr,flag,cPattern.NMaxLoLim,cPattern.NMinLoLim,cPattern.NMaxHiLim, cPattern.NMaxLoLim,cPattern.DAvgHiLim,cPattern.DAvgLoLim)
		cStats = cPattern.stats
		Assert.Greater(cStats.Count,0)
		Assert.AreEqual(cStats.Count,cPattern.stats.Count)
		Assert.Greater(cStats.Max,cPattern.NMaxHiLim)
		Assert.Greater(cStats.Min,cPattern.NMinHiLim)
		Assert.Greater(cStats.Average,cPattern.DAvgHiLim)
		Assert.IsNotEmpty(str.ToString,"not empty")
	End Sub
	
	<Test> _
	Public Sub TestLumpStats()
		cStats = cPattern.stats
		cStats.LumpStats(cStats)
	End Sub
	
	<Test> _
	Public Sub TestCSV_Labels()
		Dim csvLabels As String
		cStats = cPattern.stats
		csvLabels = cStats.CSV_Labels()
		cStats.sName = ""
		Assert.IsNotEmpty(csvLabels)
	End Sub
	
	<Test> _
	Public Sub TestCSV_Data()
		Dim csvData As String
		cStats = cPattern.stats
		csvData = cStats.CSV_Data()
		Assert.IsNotEmpty(csvData)
		Assert.Greater(cStats.Count,0)
		Assert.Greater(cStats.Max,0)
		Assert.Greater(cStats.Min,0)
		Assert.Greater(cStats.Average,0)
	End Sub
	
	<Test> _
	Public Sub TestClear()
		cStats = cPattern.stats
		cStats.Clear()
		Assert.AreEqual(0,cStats.Count)
		Assert.AreEqual(0,cStats.Max)
		Assert.AreEqual(0,cStats.Min)
		Assert.AreEqual(0,cStats.Average)
		Assert.AreEqual(0,cStats.Sum)
	End Sub
	
	Public Function SampleReportData() As CPattern
		Dim cpatt As New CPattern
		
		Dim parseData As SignifEvents = TestData.ParseEventsSample()
		Dim TotalCount As Integer = parseData.Count
		Dim newMS As ULong = parseData.Item(TotalCount).TimeMs
		Dim lastMS As ULong = parseData.Item(1).TimeMs
		cpatt.AccumulateStatsMs(lastMS,newMS)
		cpatt.KeyValPairs="Category=Transaction Start,MinLowLim=3000, MinUprLim=3500, MaxLowLim=4000, MaxUprLim=5000, AvgLowLim=3000, AvgUprLim=3500"
		cpatt.PatternName = "Scan From Attract"
		Assert.Greater(newMS,lastMS)
		'another set of event
		Dim parseData1 As SignifEvents = TestData.ParseEventsSample()
		cpatt.AccumulateStatsMs(parseData1.Item(1).TimeMs,parseData1.Item(parseData1.Count).TimeMs)
		
		Return cpatt
		
	End Function
	
End Class
