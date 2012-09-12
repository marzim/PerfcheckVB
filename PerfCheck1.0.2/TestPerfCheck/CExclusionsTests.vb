'
' Created by SharpDevelop.
' User: ta185044
' Date: 7/17/2012
' Time: 12:33 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports NUnit.Framework
Imports PerfCheck
<TestFixture> _
Public Class CExclusionsTests
	Private cExclusion As CExclusions
	<SetUp()> _
	Public Sub SetUp()
		cExclusion = New CExclusions
		MessageService.Attach(New ConsoleMessageProvider())
	End Sub
	<TearDown()> _
	Public Sub TearDown()
		cExclusion = Nothing
	End Sub
	'<ExpectedException(GetType(NullReferenceException))> _	
	<Test> _
	Public Sub TestAdd_WithsKey()
		Dim eStateName As Integer = TestData.ParseEventsSample().Item(1).NameIndex
		Dim state As CPatternState
		state = cExclusion.Add(eStateName,"Sample 1")
		Assert.NotNull(state,"Not Null")
		StringAssert.Contains(cExclusion.Item(1).StateName,state.StateName)
		Assert.AreEqual(1,cExclusion.Count)
	End Sub
	
	<Test> _
	Public Sub TestAdd_NosKey()
		Dim eStateName As Integer = TestData.ParseEventsSample().Item(1).NameIndex
		Assert.NotNull(cExclusion.Add(eStateName,""),"Not Null")
		Assert.AreEqual(1,cExclusion.Count)
		cExclusion.Remove(1)
		Assert.AreEqual(0,cExclusion.Count)
		cExclusion.Add(1,"Scan And Bag")
		Assert.AreEqual(1,cExclusion.Count)
	End Sub
	
	<ExpectedException(GetType(NullReferenceException))> _
	<Test> _
	Public Sub TestAdd_EmptyStaTeName()
		Dim cExclusion As New CExclusions
		cExclusion.Add(0,"")
	End Sub
	
	<ExpectedException(GetType(InvalidCastException))> _
	<Test> _
	Public Sub TestAdd_InvalidInputs()
		'Dim cExclusion As New CExclusions	
		cExclusion.Add("",4343)
	End Sub
	
	'<Test> _
	'Public Sub TestRemove
		'Dim cExclusion As New CExclusions
		'Dim index As Object = cExclusion.Item.CollectionIndex
		'Dim obj As Object
		'cExclusion.Remove(cExclusion.Item.CollectionIndex)
		'Assert.IsNull(cExclusion.Remove(1),"This is null")
	'End Sub
	'<ExpectedException(GetType(InvalidCastException))> _	
	'<Test> _
	'Public Sub TestGetEnumerator
		'Dim cExclusion As New CExclusions
		'Dim index As Object = cExclusion.Item.CollectionIndex
		'Dim dataEnum As System.Collections.IEnumerable

		'CollectionAssert.IsNotEmpty(cExclusion.GetEnumerator(),"This should be not empty")
	'End Sub
	
End Class
