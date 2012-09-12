'
' Created by SharpDevelop.
' User: ta185044
' Date: 7/26/2012
' Time: 12:21 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports NUnit.Framework

<TestFixture> _
Public Class CPatternPointerTests
	
	Private cPP As CPatternPointer	
	
	<SetUp()> _
	Public Sub SetUp()
		MessageService.Attach(New ConsoleMessageProvider())
		cPP = New CPatternPointer()
	End Sub
	
	<TearDown()> _
	Public Sub TearDown()
		cPP = Nothing
	End Sub
	
	<Test> _
	Public Sub TestProperties()
		' TODO: Add your test.
		Dim parsedData As SignifEvents = TestData.ParseEventsSample()
		Assert.Greater(parsedData.Count,0)
		cPP.TimeMs = parsedData.Item(1).TimeMs
		cPP.CollectionIndex = parsedData.Item(1).CollectionIndex
		Assert.AreEqual(cPP.CollectionIndex,parsedData.Item(1).CollectionIndex)
		Assert.AreEqual(cPP.TimeMs,parsedData.Item(1).TimeMs)
		
	End Sub
End Class
