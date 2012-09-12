'
' Created by SharpDevelop.
' User: ta185044
' Date: 7/26/2012
' Time: 11:57 AM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports NUnit.Framework

<TestFixture> _
Public Class CPatternPointersTests
	
	Private cPP As CPatternPointers	
	Private parseData As SignifEvents
	Private colIndex As Integer
	Private duration As Double
	
	<SetUp()> _
	Public Sub SetUp()
		MessageService.Attach(New ConsoleMessageProvider())		
		cPP = New CPatternPointers()
		parseData = TestData.ParseEventsSample()
		colIndex = parseData.Item(1).CollectionIndex
		duration = parseData.Item(parseData.Count).TimeMs - parseData.Item(1).TimeMs
	End Sub
	
	<TearDown()> _
	Public Sub TearDown()
		cPP = Nothing
	End Sub
	
	<Test> _
	Public Sub TestAdd_NoSKey()
		' TODO: Add your test.
		cPP.Add(colIndex,duration)
	End Sub
	
	<Test> _
	Public Sub TestAdd_WithSKey()
		' TODO: Add your test.
		Dim sKey As String = "Sample Key"
		cPP.Add(colIndex,duration,sKey)
	End Sub
	
	<Test> _
	Public Sub TestReadOnlyProperties()
		cPP.Add(colIndex,duration)
		Assert.Greater(cPP.Count,0)
		Assert.GreaterOrEqual(cPP.Item(1).TimeMs,0)
		Assert.NotNull(cPP.GetEnumerator())
		cPP.Remove(1)
		Assert.AreEqual(0,cPP.Count)
	End Sub
End Class
