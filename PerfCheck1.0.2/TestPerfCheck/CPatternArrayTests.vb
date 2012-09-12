'
' Created by SharpDevelop.
' User: Administrator
' Date: 8/3/2012
' Time: 2:59 AM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports NUnit.Framework

<TestFixture> _
Public Class CPatternArrayTests
	
	Dim cpatternArray As CPatternArray
	
	<SetUp()> _
	Public Sub SetUp()
		cpatternArray = New CPatternArray()
	End Sub
	
	<TearDown()> _
	Public Sub TearDown()	
		cpatternArray = Nothing
	End Sub
	
	<Test> _
	<ExpectedException(GetType(System.NullReferenceException))> _
	Public Sub TestGetItem()
		Dim item As Object = cpatternArray.Item(-1)
	End Sub
	
	<Test> _
	Public Sub TestEmptyGetItem()
		Assert.AreEqual(0,cpatternArray.Item(Nothing))
	End Sub
	
	<Test> _
	Public Sub TestTally()
		cpatternArray.Tally(1)
		Assert.AreEqual(51,cpatternArray.Size)
	End Sub
	
	<Test> _
	<ExpectedException(GetType(System.NullReferenceException))> _
	Public Sub TestEmptyTally()
		cpatternArray.Tally(0)
	End Sub
End Class
