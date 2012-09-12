'
' Created by SharpDevelop.
' User: ta185044
' Date: 7/18/2012
' Time: 4:08 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports NUnit.Framework

<TestFixture> _
Public Class CPatternsTests
	Private cpatterns As CPatterns	
	Private cpattern As CPattern
	<SetUp()> _ 
	Public Sub SetUp()
		cpatterns = New CPatterns
		cpattern = New CPattern
		MessageService.Attach(New ConsoleMessageProvider())
	End Sub
	<Test> _
	Public Sub TestAdd()
		cpatterns.Add(cpattern,"Normal Scan")
		Assert.IsNotNull(cpatterns)
		Assert.AreEqual(1,cpatterns.Count)
		cpatterns.Add(cpattern,"")
		Assert.IsNotNull(cpatterns)
		cpattern = Nothing
		cpatterns.Add(cpattern,"Normal Bag")
		Assert.IsNotNull(cpatterns)
		cpatterns.Remove(1)
		Assert.AreEqual(2,cpatterns.Count)
		Assert.IsNull(cpatterns.Item(1).Category)
		Assert.IsTrue(cpatterns.Exists)
		Assert.IsNotNull(cpatterns.GetEnumerator())
		' TODO: Add your test.
	End Sub
	
	'Scan From Attract, SMAttract - SMBagAndEAS - SMScanAndBag, Category=Normal
	<Test> _
	Public Sub TestAdd2()
		cpatterns.Add2("Scan From Attract","SMAttract - SMBagAndEAS - SMScanAndBag","Category=Normal","Category")
		Assert.IsNotNull(cpatterns)
		cpatterns.Add2("Scan from Attract","ItemScanned-TB_Start-To_SMBagAndEAS", "Category=Transaction Start","MinLowLim=3000, MinUprLim=3500, MaxLowLim=4000, MaxUprLim=5000, AvgLowLim=3000, AvgUprLim=3500")
		Assert.IsNotNull(cpatterns)
		cpatterns.Add2("","","")
		Assert.AreEqual(3,cpatterns.Count)
		
		Assert.AreEqual("Scan From Attract",cpatterns.Item(1).PatternName)
		Assert.AreEqual("Transaction Start",cpatterns.Item(2).Category)
		
		Assert.AreEqual(Nothing,cpatterns.Item(3).Category)
		Assert.AreEqual("",cpatterns.Item(3).PatternName)
		Assert.AreEqual("",cpatterns.Item(3).StateList)
		Assert.IsTrue(cpatterns.Exists)
		Assert.IsNotNull(cpatterns.GetEnumerator())
	End Sub
End Class
