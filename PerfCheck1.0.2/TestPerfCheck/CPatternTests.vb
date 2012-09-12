'
' Created by SharpDevelop.
' User: ta185044
' Date: 7/16/2012
' Time: 11:54 AM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports NUnit.Framework
Imports PerfCheck
<TestFixture> _
Public Class CPatternTests
	Private cpattern As CPattern

	<SetUp()> _
	Public Sub SetUp()
		cpattern = New CPattern()
		cpattern.PatternName = "Scan from Attract"
		cpattern.KeyValPairs = "Category=Transaction Start,MinLowLim=3000, MinUprLim=3500, MaxLowLim=4000, MaxUprLim=5000, AvgLowLim=3000, AvgUprLim=3500"
		cpattern.ExclusionList = "ButtonClick-Red"
		MessageService.Attach(New ConsoleMessageProvider())
	End Sub
	
	<TearDown()> _
	Public Sub TearDown()
		cpattern = Nothing
	End Sub
	
'	<Test()> _
'	Public Sub TestExclusionList
'		Dim exList As String
'		exList = cpattern.ExclusionList.ToString()
'		Assert.IsNotEmpty(exList)
'	End Sub
	
	<Test> _
	Public Sub TestAccumulateStatsMs()
		'Dim cpattern As New CPattern
		Dim parseData As SignifEvents = TestData.ParseEventsSample()
		Dim TotalCount As Integer = parseData.Count
		Dim newMS As ULong = parseData.Item(TotalCount).TimeMs
		Dim lastMS As ULong = parseData.Item(1).TimeMs
		cpattern.AccumulateStatsMs(lastMS,newMS)
		Assert.Greater(newMS,lastMS)
		' TODO: Add your test.
	End Sub
	
	<Test> _
	Public Sub TestParseListState()
		Dim cpatterns As New CPatterns()
		cpattern = cpatterns.Add2("Scan from Attract","ItemScanned-TB_Start-To_SMBagAndEAS","Category=Transaction Start,MinLowLim=3000, MinUprLim=3500, MaxLowLim=4000, MaxUprLim=5000, AvgLowLim=3000, AvgUprLim=3500","Scan from Attract")
		Dim bExclude As Boolean = False
		cpattern.ParseStateList(cpattern.StateList,bExclude)
		'Assert.AreEqual(58,cpattern.nIndex)
	End Sub
	
	<Test> _
	Public Sub TestParseListState_WrongPattern()
		Dim cpatterns As New CPatterns()
		cpattern = cpatterns.Add2("Scan from Attract","!From_SMScanAndBag-To_SMFinish","Category=Transaction Start,MinLowLim=3000, MinUprLim=3500, MaxLowLim=4000, MaxUprLim=5000, AvgLowLim=3000, AvgUprLim=3500","Scan from Attract")
		'Dim stateList As String = "!From_SMScanAndBag-To_SMFinish"
		Dim bExclude As Boolean = False
		cpattern.ParseStateList(cpattern.StateList,bExclude)
		'Assert.AreEqual(59,cpattern.nIndex)
	End Sub
	
	<Test> _
	Public Sub TestAdd_WithsKey()
		
		Dim eStateName As Integer = TestData.ParseEventsSample().Item(2).NameIndex
		Dim state As CPatternState
		state = cpattern.Add(eStateName,"Sample 1")
		Assert.NotNull(state,"Not Null")
		Assert.AreEqual("PSX_Done",state.StateName)
		Assert.AreEqual(1,cpattern.Count)
		Assert.AreEqual(cpattern.Item(1).StateName,state.StateName)
		Assert.AreEqual(1,cpattern.PoisonStates.Count)
		Assert.AreEqual(cpattern.PatternPointers.Count,0)
		Assert.IsNotNull(cpattern.GetEnumerator())
	End Sub
	
	
	<Test> _
	Public Sub TestAdd()
		Dim eStateName As Integer = TestData.ParseEventsSample().Item(1).NameIndex
		Dim state As CPatternState
		state = cpattern.Add(eStateName,"")
		Assert.NotNull(state,"Not Null")
		Assert.AreEqual("UnMatched_Weight",state.StateName.ToString())
		Assert.AreEqual(1,cpattern.Count)
		Assert.AreEqual(cpattern.Item(1).StateName,state.StateName)
	End Sub
	
	<Test> _
	Public Sub TestRemove()
		
		Dim eStateName As Integer = TestData.ParseEventsSample().Item(2).NameIndex
		Dim state As CPatternState
		state = cpattern.Add(eStateName,"Sample 1")
		Assert.NotNull(state,"Not Null")
		StringAssert.Contains("PSX_Done",state.StateName)
		Assert.AreEqual(1,cpattern.Count)
		Assert.AreEqual(cpattern.Item(1).StateName,state.StateName)
		cpattern.Remove(1)
		Assert.AreEqual(0,cpattern.Count)
	End Sub	

	<Test> _
	Public Sub TestKeyValue_Category()
		'MsgBox(cpattern.KeyValPairs)
		cpattern.Category = cpattern.keyValue("Category")
		Assert.AreEqual("Transaction Start",cpattern.Category)
	End Sub
	
	<Test> _
	Public Sub TestKeyValue_MinLowLim()
		Assert.AreEqual(3000,CInt(cpattern.keyValue("MinLowLim")))
	End Sub
	
	<Test> _
	Public Sub TestKeyValue_MinUprLim()
		Assert.AreEqual(3500,CInt(cpattern.keyValue("MinUprLim")))
	End Sub
	
	<Test> _
	Public Sub TestKeyValue_MaxLowLim()
		Assert.AreEqual(4000,CInt(cpattern.keyValue("MaxLowLim")))
	End Sub
	
	<Test> _
	Public Sub TestKeyValue_MaxUprLim()
		Assert.AreEqual(5000,CInt(cpattern.keyValue("MaxUprLim")))
	End Sub
	
	<Test> _
	Public Sub TestKeyValue_AvgLowLim()
		Assert.AreEqual(3000,CInt(cpattern.keyValue("AvgLowLim")))
	End Sub
	
	<Test> _
	Public Sub TestKeyValue_AvgUprLim()
		Assert.AreEqual(3500,CInt(cpattern.keyValue("AvgUprLim")))
	End Sub
	
	<Test> _
	Public Sub TestKeyValue_Empty()
		'Dim cpattern As New CPattern
		cpattern.KeyValPairs = ""
		Assert.IsEmpty(cpattern.keyValue("Category"))
		Assert.IsEmpty(cpattern.keyValue("MinLowLim"))
		Assert.IsEmpty(cpattern.keyValue("MinUprLim"))
		Assert.IsEmpty(cpattern.keyValue("MaxLowLim"))
		Assert.IsEmpty(cpattern.keyValue("MaxUprLim"))
		Assert.IsEmpty(cpattern.keyValue("AvgLowLim"))
		Assert.IsEmpty(cpattern.keyValue("AvgUprLim"))
	End Sub
	
	<Test> _
	Public Sub TestCSV_Labels()
		Assert.IsNotEmpty(cpattern.CSV_Labels(),"Not Empty")
		Assert.AreEqual("Name,StateSequence,Category," & "" & "Count," & "" & "Min," & "" & "Max," & "" & "Mean," & "" & "StdDev,",cpattern.CSV_Labels())

	End Sub
	
	<Test> _
	Public Sub TestCSV_Data()
		Dim dgr(6) As String
		Dim flags(6) As Integer
		ParsedData()
		Dim formattedLine As String = cpattern.Report(dgr,flags)
		Assert.Greater(cpattern.stats.Max,0)
		Assert.Greater(cpattern.stats.Min,0)
		Assert.Greater(cpattern.stats.Average,0)
		Assert.IsNotEmpty(formattedLine)
		Assert.IsNotEmpty(cpattern.CSV_Data(0,0))
	End Sub
	
	<Test> _
	Public Sub TestReport()
		Dim dgr(6) As String
		Dim flags(6) As Integer
		ParsedData()
		Dim formattedLine As String = cpattern.Report(dgr,flags)
		Assert.IsNotEmpty(cpattern.KeyValPairs)
		Assert.AreEqual(3000,cpattern.NMinLoLim)
		Assert.AreEqual(3500,cpattern.NMinHiLim)
		Assert.AreEqual(4000,cpattern.NMaxLoLim)
		Assert.AreEqual(5000,cpattern.NMaxHiLim)
		Assert.AreEqual(3000,cpattern.DAvgLoLim)
		Assert.AreEqual(3500,cpattern.DAvgHiLim)
		Assert.AreEqual("Scan from Attract",cpattern.PatternName)
		Assert.IsNotEmpty(formattedLine)
		
	End Sub
	
	<Test> _
	Public Sub testEmptyAccumulateStats()
		Dim cpattern As New CPattern()
		cpattern.AccumulateStats(Nothing, Nothing)
	End Sub

	<Test> _
	Public Sub TestGetExclusionList()
		Assert.AreEqual("ButtonClick",cpattern.ExclusionList)
	End Sub
	
	Public Sub ParsedData()
		
		Dim parseData As SignifEvents = TestData.ParseEventsSample()
		Dim TotalCount As Integer = parseData.Count
		Dim newMS As ULong = parseData.Item(TotalCount).TimeMs
		Dim lastMS As ULong = parseData.Item(1).TimeMs
		cpattern.AccumulateStatsMs(lastMS,newMS)
		Assert.Greater(newMS,lastMS)
		Dim parseData1 As SignifEvents = TestData.ParseEventsSample()
		cpattern.AccumulateStatsMs(parseData1.Item(1).TimeMs,parseData1.Item(parseData1.Count).TimeMs)
		
	End Sub
End Class
