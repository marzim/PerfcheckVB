'
' Created by SharpDevelop.
' User: mc185104
' Date: 7/12/2012
' Time: 5:47 AM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'

Imports NUnit.Framework
Imports System.IO
Imports PerfCheck

<TestFixture()> _
Public Class SignifEventsTests
	
	Private p As SignifEvents
	Private parserEventValues As ParserEventValues
	Dim parseValueDictionaryPath As String
	<SetUp()> _
	Public Sub SetUp()
		TestData.createDictionaryFiles()
		MessageService.Attach(New ConsoleMessageProvider())
		p = New SignifEvents()
		parseValueDictionaryPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\test\config\NCR39\EventValues.dictionary"
		parserEventValues = New ParserEventValues()
	End Sub
	
	<Test()> _
	Public Sub testParseDictionary()		
		
		p.ParseDictionary(New ExtendedStringReader("ItemDetails, SetItemDetails--ItemDetail:"))
		Assert.AreEqual(1, p.MPhrases.Count)
	End Sub
	
	<Test()> _
	Public Sub testAdd()
		
		p.Add(12, "12:01:22", 183934, "sample fullline string","sample event name",1,"Trace", "sample event")
		Assert.AreEqual(1, p.MergeCollection.Count)
		p.Add(12, "12:01:22", 183934, "sample fullline string","sample event name",1,"Trace","sampleskey")
		Assert.AreEqual(2, p.MergeCollection.Count)
	End Sub	
	
	<Test()> _	
	<ExpectedException(GetType(OverflowException))> _
	Public Sub testExceptionAdd()		
		p.Add("112312323242", "12:01:22", 38934839, 1111,"Event1",1,"Trace", "sample event")
	End Sub
	
	<Test()> _
	Public Sub testFindFirstDelim()
		Dim i As Integer = p.FindFirstDelim("12352603) 06/02 21:27:09;0956318640 DM-DMp@3448 +DMp::Enable 11 1 ")
		Assert.AreEqual(10, i, "Found the first delimiter space")
		i = p.FindFirstDelim("0956318640 DM-DMp@3448 +DMp::Enable 11 1 ")
		Assert.AreEqual(0, i, "No delimiter found")
	End Sub
	
	<Test()> _
	Public Sub testParseEventsTraceLog()
		p.ParseDictionary(New ExtendedStringReader("App_Waiting, SMState::TBParse() and not ScanAndBag state, " & Environment.NewLine & "PSX_Done, -EventHandler Event( ,Display,BagAndEAS,ChangeContext )" & Environment.NewLine))
		p.ParseEvents(New ExtendedStringReader("12352421) 06/02 21:27:04;0956314406 -RCMgri@21   <<< RAInterface::OnEvent"  & Environment.NewLine & "12355291) 06/02 21:29:53;0956483375 PS-PSt@651  -EventHandler Event( ,Display,BagAndEAS,ChangeContext ) "  & Environment.NewLine & "12355763) 06/02 21:29:58;0956487968 SM-SmStateTB@140  SMState::TBParse() and not ScanAndBag state, setting bItemSoldButNoTotalYet=false" & Environment.NewLine))
		Assert.AreEqual(1, p.MergeCollection.Count)
	End Sub
	
	<Test()> _
	Public Sub testParseEventsTraceLog_InvalidTimeStamp()
		p.ParseDictionary(New ExtendedStringReader("App_Waiting, SMState::TBParse() and not ScanAndBag state, " & Environment.NewLine & "PSX_Done, -EventHandler Event( ,Display,BagAndEAS,ChangeContext )" & Environment.NewLine))
		p.ParseEvents(New ExtendedStringReader("12352421) 06/02 21:27:04;-0956314406 -RCMgri@21   <<< RAInterface::OnEvent"  & Environment.NewLine & "12355291) 06/02 21:29:53;0956483375 PS-PSt@651  -EventHandler Event( ,Display,BagAndEAS,ChangeContext ) "  & Environment.NewLine & "12355763) 06/02 21:29:58;0956487968 SM-SmStateTB@140  SMState::TBParse() and not ScanAndBag state, setting bItemSoldButNoTotalYet=false" & Environment.NewLine))
		Assert.AreEqual(0, p.MergeCollection.Count)
	End Sub
	
	<Test()> _ 
	Public Sub testParseEventsSMLog()
		p.ParseDictionary(New ExtendedStringReader("Description, key=item-description.  value=" & Environment.NewLine & "UnMatched_Weight, UnMatched: Weight increase of" & Environment.NewLine))
		p.ParseEvents(New ExtendedStringReader("SM: 05/02 05:49:34       581,686 0A24> --- Begin Data Capture --- (continued)" & Environment.NewLine & "SM: 05/09 07:18:41   610,713,759 00FC> UnMatched: Weight increase of  5730. App determining if allowed..." & Environment.NewLine & "SM: 05/09 07:19:28   610,760,897 00FC> Parsing key=item-description.  value=""" & Environment.NewLine))
		Assert.AreEqual(1, p.MergeCollection.Count)
	End Sub
	
	<Test()> _ 
	Public Sub testParseEventsPatraceLog()
		p.ParseDictionary(New ExtendedStringReader("CardMissingData, lEventCode=[2] PA_EV_DATA_MISSING  lOperationCode=[8] PA_OP_CARD" & Environment.NewLine & "CardDataToPOS, Operation:[PA_OP_CARD] - Data:[<CardEntryIn" & Environment.NewLine))
		p.ParseEvents(New ExtendedStringReader("Maximum file size reached. See file c:\scot\logs\patrace.log.bak for previous trace records." & Environment.NewLine & "05/09 06:09:33     606566166 057C> [I]CPAApp@544:PAEventProc(): lEventCode=[2] PA_EV_DATA_MISSING  lOperationCode=[8] PA_OP_CARD" & Environment.NewLine & "05/09 05:57:11     605823828 00B4> [+]CPAAppEvents@346:CPAApp::PARequest() - Operation:[PA_OP_CARD] - Data:[<CardEntryIn xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:noNamespaceSchemaLocation=""Schema\PA\CardEntryInv4.0.xsd""><SaleType>normal</SaleType><AccountNo>XXXXXXXXXXXXXXXXXX</AccountNo></CardEntryIn>" & Environment.NewLine))
		Assert.AreEqual(1, p.MergeCollection.Count)		
	End Sub
	
	<Test()> _ 
	Public Sub testParseEventsPatraceLogInvalidTime()
		p.ParseDictionary(New ExtendedStringReader("CardMissingData, lEventCode=[2] PA_EV_DATA_MISSING  lOperationCode=[8] PA_OP_CARD" & Environment.NewLine & "CardDataToPOS, Operation:[PA_OP_CARD] - Data:[<CardEntryIn" & Environment.NewLine & _ 
			"RED, +setTriColorLight, color = 3"))
		p.ParseEvents(New ExtendedStringReader("Maximum file size reached. See file c:\scot\logs\patrace.log.bak for previous trace records." & Environment.NewLine & "24724871) 05/31 10:17:36;-2056495174 04E8> DM-DMp@2287 +setTriColorLight, color = 3 state = 0 request = 0" & Environment.NewLine & "05/09 05:57:11     605823828 00B4> [+]CPAAppEvents@346:CPAApp::PARequest() - Operation:[PA_OP_CARD] - Data:[<CardEntryIn xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:noNamespaceSchemaLocation=""Schema\PA\CardEntryInv4.0.xsd""><SaleType>normal</SaleType><AccountNo>XXXXXXXXXXXXXXXXXX</AccountNo></CardEntryIn>" & Environment.NewLine))
		Assert.AreEqual(0, p.MergeCollection.Count)		
	End Sub
	
	<Test()> _ 
	Public Sub testMergeEvents()
		Dim p1 As New SignifEvents()
		p1.ParseDictionary(New ExtendedStringReader("App_Waiting, SMState::TBParse() and not ScanAndBag state, " & Environment.NewLine & "PSX_Done, -EventHandler Event( ,Display,BagAndEAS,ChangeContext )" & Environment.NewLine))
		p1.ParseEvents(New ExtendedStringReader("12352421) 06/02 21:27:04;0956314406 -RCMgri@21   <<< RAInterface::OnEvent"  & Environment.NewLine & "12355291) 06/02 21:29:53;0956483375 PS-PSt@651  -EventHandler Event( ,Display,BagAndEAS,ChangeContext ) "  & Environment.NewLine & "12355763) 06/02 21:29:58;0956487968 SM-SmStateTB@140  SMState::TBParse() and not ScanAndBag state, setting bItemSoldButNoTotalYet=false" & Environment.NewLine))
		Dim p2 As New SignifEvents()
		p2.ParseDictionary(New ExtendedStringReader("Description, key=item-description.  value=" & Environment.NewLine & "UnMatched_Weight, UnMatched: Weight increase of" & Environment.NewLine))
		p2.ParseEvents(New ExtendedStringReader("SM: 05/02 05:49:34       581,686 0A24> --- Begin Data Capture --- (continued)" & Environment.NewLine & "SM: 05/09 07:18:41   610,713,759 00FC> UnMatched: Weight increase of  5730. App determining if allowed..." & Environment.NewLine & "SM: 05/09 07:19:28   610,760,897 00FC> Parsing key=item-description.  value=""" & Environment.NewLine))
		Dim p3 As New SignifEvents()
		p3.Merge(p1, p2)
		Assert.AreEqual(2, p3.MergeCollection.Count)	
	End Sub
	
	<Test()> _ 
	Public Sub testListAllEvents()
		Dim p1 As New SignifEvents()
		p1.ParseDictionary(New ExtendedStringReader("App_Waiting, SMState::TBParse() and not ScanAndBag state, " & Environment.NewLine & "PSX_Done, -EventHandler Event( ,Display,BagAndEAS,ChangeContext )" & Environment.NewLine))
		p1.ParseEvents(New ExtendedStringReader("12352421) 06/02 21:27:04;0956314406 -RCMgri@21   <<< RAInterface::OnEvent"  & Environment.NewLine & "12355291) 06/02 21:29:53;0956483375 PS-PSt@651  -EventHandler Event( ,Display,BagAndEAS,ChangeContext ) "  & Environment.NewLine & "12355763) 06/02 21:29:58;0956487968 SM-SmStateTB@140  SMState::TBParse() and not ScanAndBag state, setting bItemSoldButNoTotalYet=false" & Environment.NewLine))
		Dim p2 As New SignifEvents()
		p2.ParseDictionary(New ExtendedStringReader("Description, key=item-description.  value=" & Environment.NewLine & "UnMatched_Weight, UnMatched: Weight increase of" & Environment.NewLine))
		p2.ParseEvents(New ExtendedStringReader("SM: 05/02 05:49:34       581,686 0A24> --- Begin Data Capture --- (continued)" & Environment.NewLine & "SM: 05/09 07:18:41   610,713,759 00FC> UnMatched: Weight increase of  5730. App determining if allowed..." & Environment.NewLine & "SM: 05/09 07:19:28   610,760,897 00FC> Parsing key=item-description.  value=""" & Environment.NewLine))
		Dim p3 As New SignifEvents()
		p3.Merge(p1, p2)
		p3.DicEventValues = parserEventValues.Parsed(New ExtendedStreamReader(New FileStream(parseValueDictionaryPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), System.Text.Encoding.Default))
		Dim logevents As LogEvents = p3.ListAllEvents()
		Assert.AreEqual(2, logevents.GetEvents().Count)
	End Sub
	
	
	
	<Test> _
	<ExpectedException(GetType(ArgumentNullException))> _
	Public Sub testParseDictionaryArgumentNullException()
		p.ParseDictionary(Nothing)
	End Sub
	
	<Test> _
	<ExpectedException(GetType(ArgumentNullException))> _
	Public Sub testParseEventsArgumentNullException()
		p.ParseEvents(Nothing)
	End Sub	
		
End Class
