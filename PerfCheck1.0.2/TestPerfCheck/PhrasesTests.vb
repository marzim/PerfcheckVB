'
' Created by SharpDevelop.
' User: ta185044
' Date: 7/26/2012
' Time: 5:00 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports NUnit.Framework

<TestFixture> _
Public Class PhrasesTests
	Private phrases As Phrases	
	Private phraseName As String
	Private aliasName As String
	
	<SetUp()> _
	Public Sub SetUp()
		MessageService.Attach(New ConsoleMessageProvider())
		phrases = New Phrases()
		phraseName = "EventName:ChangeContext"
		aliasName = "EndDrawContext"
	End Sub
	<TearDown()> _
	Public Sub TearDown()
		phrases = Nothing
	End Sub
	
	<Test> _
	Public Sub TestAdd_NoSkey()
		' TODO: Add your test.
		phrases.Add(phraseName,aliasName)
		Assert.AreEqual(1,phrases.Count)
	End Sub
	<Test> _
	Public Sub TestAdd()
		' TODO: Add your test.
		Dim sKey As String = "Sample Key"
		phrases.Add(phraseName,aliasName,sKey)
		Assert.AreEqual(1,phrases.Count)
	End Sub
	
	<Test> _
	Public Sub TestProperties()
		' TODO: Add your test.
		phrases.Add(phraseName,aliasName)
		Assert.AreEqual(1,phrases.Count)
		Assert.AreEqual("EndDrawContext",phrases.Item(1).AliasName)
		Assert.AreEqual("EventName:ChangeContext",phrases.Item(1).Phrase)
		phrases.Remove(1)
		Assert.AreEqual(0,phrases.Count)
	End Sub
	
	<Test> _
	Public Sub TestExists()
		Dim sEvent As New SignifEvents()
		Dim isExits As Boolean
		Dim fLine As String
		Dim aliasName As String
		Dim nIndex As Integer
		sEvent.ParseDictionary(New ExtendedStringReader("App_Waiting, SMState::TBParse() and not ScanAndBag state, " & Environment.NewLine & "PSX_Done, -EventHandler Event( ,Display,BagAndEAS,ChangeContext )" & Environment.NewLine))
		sEvent.ParseEvents(New ExtendedStringReader("12352421) 06/02 21:27:04;0956314406 -RCMgri@21   <<< RAInterface::OnEvent"  & Environment.NewLine & "12355291) 06/02 21:29:53;0956483375 PS-PSt@651  -EventHandler Event( ,Display,BagAndEAS,ChangeContext ) "  & Environment.NewLine & "12355763) 06/02 21:29:58;0956487968 SM-SmStateTB@140  SMState::TBParse() and not ScanAndBag state, setting bItemSoldButNoTotalYet=false" & Environment.NewLine))
		fLine = sEvent.Item(1).FullLine
		aliasName = sEvent.Item(1).EventName
		nIndex = sEvent.Item(1).NameIndex
		isExits = phrases.Exists(fLine,aliasName,nIndex)
		Assert.IsFalse(isExits)
		Assert.AreEqual(1, sEvent.MergeCollection.Count)
	
	End Sub
	
	<Test> _
	Public Sub TestEmptyExists()
		Dim isExits As Boolean
		isExits = phrases.Exists(Nothing, Nothing, Nothing)
		Assert.IsFalse(isExits)
	End Sub
	
	<Test> _
	<ExpectedException(GetType(ArgumentNullException))> _
	Public Sub TestEmptyAdd()
		phrases.add(Nothing, Nothing, Nothing)
	End Sub
End Class
