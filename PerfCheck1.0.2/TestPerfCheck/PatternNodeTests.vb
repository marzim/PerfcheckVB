'
' Created by SharpDevelop.
' User: ta185044
' Date: 7/30/2012
' Time: 5:13 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports NUnit.Framework

<TestFixture> _
Public Class PatternNodeTests
	Private pNode As PatternNode
	<SetUp()> _
	Public Sub SetUp()
		pNode = New PatternNode()
		
	End Sub
	<TearDown()> _
	Public Sub TearDown()
		pNode = Nothing
		
	End Sub
	
	<Test> _
	Public Sub TestAdd()
		' TODO: Add your test.
		pNode.Add("ItemScanned",0,Nothing,"ScaleFilter@1, StableWeight")
		Assert.AreEqual(1,pNode.Count)
		pNode.Add("ItemScanned",1,Nothing,"") 'nodeString is empty it will not add to the collection
		Assert.AreEqual(1,pNode.Count)
		pNode.Add("ItemScanned",1,Nothing,"Matched_Weight")
		Assert.AreEqual(2,pNode.Count)
		pNode.Add("",3,Nothing,"DbLookupSuccess, To_SMBagAndEAS, SetSoldItemInfo")
		Assert.AreEqual(3,pNode.Count)
		pNode.Add("",4,Nothing,"")
		Assert.AreEqual(3,pNode.Count)
		pNode.Remove(3)
		Assert.AreEqual(2,pNode.Count)
		Assert.AreNotEqual(0, pNode.Level)
		Assert.AreEqual("ScaleFilter@1",pNode.Item(1).AliasName)
		Assert.AreEqual("Matched_Weight",pNode.Item(2).AliasName)
		Assert.AreEqual(1, pNode(1).Level)
		pNode.Item(1).Level = 2
		Assert.AreEqual(2,pNode(1).Level)
	End Sub
	
	<Test> _
	Public Sub TestAdd2()
		Dim i As Integer = 1
		pNode.Add2("DbLookupSuccess, To_SMBagAndEAS, SetSoldItemInfo",1,Nothing)
		Assert.AreEqual(1,pNode.Count)
	End Sub
	
	<Test> _
	Public Sub TestSearch()
		Dim sEvent As New SignifEvents()
		Dim isSuccess As Boolean
		sEvent = TestData.ParseEventsSample_TestReturnZero()
		pNode.Parent = pNode.Add("EndDrawContext",0,Nothing,"")
		Assert.IsTrue(pNode.Search(sEvent,True,Nothing))
		pNode.Parent = pNode.Add("EndDrawContext",1,pNode.Parent,"EventName:ChangeContext,")
		Assert.IsTrue(pNode.Search(sEvent,True,Nothing))
		pNode.Parent = pNode.Add("ItemScanned",0,pNode.Parent,"")
		Assert.IsFalse(pNode.Search(sEvent,True,Nothing))
		pNode.Parent = pNode.Add("ButtonClick",1,pNode.Parent,"EventName:Click,")
		isSuccess = pNode.Search(sEvent,True,Nothing)
		Assert.IsTrue(isSuccess)
		Assert.AreEqual(2,pNode.Count)
		Assert.IsNotEmpty(pNode.getFullPath())
		Assert.IsNotEmpty(pNode.getErrorString())
		pNode.SearchAnchor = 2
		isSuccess = pNode.Search(sEvent,True,Nothing)
		Assert.IsTrue(isSuccess)
		pNode.ClearStats()
		
	End Sub
	
	<Test> _
	Public Sub TestReport()
		Dim bDetails As  Boolean = True
		Dim objList As New ListBox()
		Dim pNodeParent As New PatternNode()
		pNodeParent = pNode.Add("ButtonClick",1,Nothing,"EventName:Click,")
		pNode.Add("EndDrawContext",2,pNodeParent,"EventName:ChangeContext,")
		Assert.AreEqual(2,pNode.Count)
		pNode.Report(bDetails,objList)
		Assert.AreEqual(3,objList.Items.Count)
		Assert.IsNotEmpty(objList.Items(0))
		Assert.IsNotEmpty(objList.Items(1))
		Assert.IsNotEmpty(objList.Items(2))
	End Sub
End Class
