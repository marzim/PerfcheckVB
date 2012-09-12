'
' Created by SharpDevelop.
' User: ta185044
' Date: 7/24/2012
' Time: 10:14 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports NUnit.Framework

<TestFixture> _
Public Class FormListClkCtrlTests
	
	Private frmListClock As formListClkCtrl
	Private parsedData As SignifEvents
	Private frmLogMain As formLogAnalysisMain
	
	<SetUp()> _
	Public Sub SetUp()
		frmListClock = New formListClkCtrl()
		frmLogMain = New formLogAnalysisMain()
		
		parsedData = TestData.ParseEventsSample_TestReturnZero()
		frmLogMain.EventsFound = parsedData
		frmLogMain.addEventsToDataGridView()
		
		MessageService.Attach(New ConsoleMessageProvider())
	End Sub
	
	<TearDown()> _
	Public Sub TearDown()
		frmListClock = Nothing
		parsedData = Nothing
		frmLogMain = Nothing
	End Sub
	
	<Test> _
	Public Sub TestLoadFrmListClk()
		' TODO: Add your test.
		frmListClock.LoadFrmListClkCtrl()
		'frmLogMain.EventsFound = parsedData.ListAllEvents()
		'Assert.AreNotEqual(0,frmLogMain.EventsFound.Count)
		Assert.Greater(frmListClock.List1.Items.Count,0)
		
	End Sub
	
	<Test> _
	Public Sub TestResetListingClockEvents()
		' TODO: Add your test.
		Dim indexToBeCheck As Integer
		frmListClock.LoadFrmListClkCtrl()
		Assert.Greater(frmListClock.List1.Items.Count,0)
		indexToBeCheck = frmListClock.List1.Items.IndexOf("DrawAttract")
		frmListClock.List1.SetItemChecked(indexToBeCheck,True)
		frmListClock.ResetListingClockEvents()
		Assert.AreNotEqual(0,indexToBeCheck)
		Assert.IsTrue(frmListClock.List1.GetItemChecked(indexToBeCheck))
		Assert.AreEqual("DrawAttract",frmListClock.List1.Items(indexToBeCheck))
		
	End Sub
	
	<Test> _
	Public Sub TestCheckAllEvent()
		Dim i As Integer
		
		frmListClock.LoadFrmListClkCtrl()
		frmListClock.CheckAllListingClock()
		For i = 0 To frmListClock.List1.Items.Count -1
    		Assert.IsTrue(frmListClock.List1.GetItemChecked(i))
		Next
	End Sub
	
	<Test> _
	Public Sub TestUnCheckAllEvent()
		Dim i As Integer
		frmListClock.LoadFrmListClkCtrl()
		frmListClock.UnCheckAllListingClock()
		For i = 0 To frmListClock.List1.Items.Count -1
    		Assert.IsFalse(frmListClock.List1.GetItemChecked(i))
    	Next
	End Sub
	
	<Test> _
	Public Sub TestLastCheckState()
		Dim chkState As CheckState
		frmListClock.LoadFrmListClkCtrl()
		chkState = frmListClock.LoadLastState()
		frmListClock.CancelButton_RenamedClick(Nothing,Nothing)
		Assert.AreEqual(chkState,frmListClock.LoadLastState)
	End Sub
	
	<Test> _
	Public Sub TestCheckBox1CheckedChanged()
		Dim i As Integer
		frmListClock.LoadFrmListClkCtrl()
		frmListClock.chkAll.CheckState = CheckState.Unchecked
		frmListClock.CheckBox1CheckedChanged(frmListClock,Nothing) 'UncheckAllEvent function is called
		For i = 0 To frmListClock.List1.Items.Count -1
    		Assert.IsFalse(frmListClock.List1.GetItemChecked(i))
		Next
		frmListClock.chkAll.CheckState = CheckState.Checked
		frmListClock.CheckBox1CheckedChanged(frmListClock,Nothing) 'CheckAllEvent function is called
		For i = 0 To frmListClock.List1.Items.Count -1
    		Assert.isTrue(frmListClock.List1.GetItemChecked(i))
		Next
	End Sub
	
	'test the chkAll checkstate when list1 item checkstates changes
	'2 possible scenarios:
	
	'1. TestList1SelectedIndexChanged_ChkAllChecked test that when chkAll was checked, chkAll checkState will INDITERMINATE when
	'there will changes in the checkstate of events
	
	'2. TestList1SelectedIndexChanged_ChkAllIndeterminate :
		'3 Possible Scenarios:
		'2.1 Checked -> this will happen if change of selected index checkstate of each event becomes checked 
		'2.2 Unchecked -> this will happen if change of selected index checkstate of each event becomes unchecked 
		'2.3 Indeterminate -> this will happen if change of selected index checkstate of each event becomes either checked or unchecked
	
	<Test> _
	Public Sub TestList1SelectedIndexChanged_ChkAllChecked() 
		Dim ctrl As Integer									 
		frmListClock.LoadFrmListClkCtrl()
		frmListClock.chkAll.CheckState = checkState.Checked
		ctrl = frmListClock.List1.Items.IndexOf("ButtonClick")
		frmListClock.List1.SetItemCheckState(ctrl,CheckState.Unchecked)
		frmListClock.List1SelectedIndexChanged(frmListClock,Nothing)
		Assert.AreEqual("Indeterminate",frmListClock.chkAll.CheckState.ToString())
	End Sub
	
	<Test> _
	Public Sub TestList1SelectedIndexChanged_ChkAllIndeterminate()
		Dim ctrl As Integer
		frmListClock.LoadFrmListClkCtrl()
		frmListClock.chkAll.CheckState = checkState.Indeterminate
		ctrl = frmListClock.List1.Items.IndexOf("ButtonClick")
		frmListClock.List1.SetItemCheckState(ctrl,CheckState.Unchecked)
		frmListClock.List1SelectedIndexChanged(frmListClock,Nothing)
		Assert.AreEqual("Indeterminate",frmListClock.chkAll.CheckState.ToString())
		
		ctrl = frmListClock.List1.Items.IndexOf("ButtonClick")
		frmListClock.List1.SetItemCheckState(ctrl,CheckState.Checked)
		frmListClock.List1SelectedIndexChanged(frmListClock,Nothing)
		Assert.AreEqual("Checked",frmListClock.chkAll.CheckState.ToString())
		
		frmListClock.chkAll.CheckState = checkState.Indeterminate
		
		frmListClock.UnCheckAllListingClock()
		frmListClock.List1SelectedIndexChanged(frmListClock,Nothing)
		Assert.AreEqual("Unchecked",frmListClock.chkAll.CheckState.ToString())
	End Sub
	
'	<Test> _
'	Public Sub TestList1SelectedIndexChanged_ChkAllChecked()
'		Dim checkState As CheckState
'		frmListClock.LoadFrmListClkCtrl()
'		frmListClock.List1SelectedIndexChanged(frmListClock,Nothing)
'		checkState = frmListClock.chkAll.CheckState
'		Assert.AreEqual(CheckState.Unchecked,checkState)
'	End Sub
	
'	Public Sub GenerateEventCheckBox(frmListClock As formListClkCtrl,eventName As String)
'		
'		'Get the constructor and create an instance of FormDiagOpen
'		Dim type As Type=frmListClock.GetType()
'		Dim frmListClockDetailConstructor As ConstructorInfo = type.GetConstructor(Type.EmptyTypes)
'        Dim frmListClockDetailClassObject As Object = frmListClockDetailConstructor.Invoke(New Object(){})
'		
'		' Get the OK_Button_Click method and invoke with a parameter value of Nothing
'		Dim dynamicMethod As MethodInfo = type.GetMethod(eventName, BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.DeclaredOnly)
'		Dim obj As Object() = {frmListClock,Nothing}
'		dynamicMethod.Invoke(frmListClockDetailClassObject,obj)
'		
'	End Sub
		
End Class
