'
' Created by SharpDevelop.
' User: ta185044
' Date: 7/20/2012
' Time: 1:27 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports NUnit.Framework

<TestFixture> _
Public Class SampleTests
	Private frmLogMain As formLogAnalysisMain	
	<SetUp()> _
	Public Sub SetUp()
		frmLogMain = New formLogAnalysisMain()
	End Sub
	<Test> _
	Public Sub TestAddEventsToDataGridView
		' TODO: Add your test.
		Dim p1 As New SignifEvents()
		p1.ParseDictionary(New ExtendedStringReader("App_Waiting, SMState::TBParse() and not ScanAndBag state, " & Environment.NewLine & "PSX_Done, -EventHandler Event( ,Display,BagAndEAS,ChangeContext )" & Environment.NewLine))
		p1.ParseEvents(New ExtendedStringReader("12352421) 06/02 21:27:04;0956314406 -RCMgri@21   <<< RAInterface::OnEvent"  & Environment.NewLine & "12355291) 06/02 21:29:53;0956483375 PS-PSt@651  -EventHandler Event( ,Display,BagAndEAS,ChangeContext ) "  & Environment.NewLine & "12355763) 06/02 21:29:58;0956487968 SM-SmStateTB@140  SMState::TBParse() and not ScanAndBag state, setting bItemSoldButNoTotalYet=false" & Environment.NewLine))
		Dim p2 As New SignifEvents()
		p2.ParseDictionary(New ExtendedStringReader("Description, key=item-description.  value=" & Environment.NewLine & "UnMatched_Weight, UnMatched: Weight increase of" & Environment.NewLine))
		p2.ParseEvents(New ExtendedStringReader("SM: 05/02 05:49:34       581,686 0A24> --- Begin Data Capture --- (continued)" & Environment.NewLine & "SM: 05/09 07:18:41   610,713,759 00FC> UnMatched: Weight increase of  5730. App determining if allowed..." & Environment.NewLine & "SM: 05/09 07:19:28   610,760,897 00FC> Parsing key=item-description.  value=""" & Environment.NewLine))
		Dim p3 As New SignifEvents()
		p3.Merge(p1, p2)		
		Dim logevents As New LogEvents()
		logevents = p3.ListAllEvents()
		Assert.AreEqual(2, logevents.GetEvents().Count)
		frmLogMain.MergedTraceEvents = p3
		frmLogMain.addEventsToDataGridView()
		Assert.Less(0,frmLogMain.DataGridView1.RowCount)
	End Sub
End Class
