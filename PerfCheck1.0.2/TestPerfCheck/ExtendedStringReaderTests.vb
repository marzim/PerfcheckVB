'
' Created by SharpDevelop.
' User: mc185104
' Date: 7/22/2s 012
' Time: 8:59 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'

Imports NUnit.Framework

<TestFixture> _
Public Class ExtendedStringReaderTests
	
	Dim es As ExtendedStringReader
	
	<SetUp> _
	Public Sub SetUp()
		MessageService.Attach(New ConsoleMessageProvider())
		es = New ExtendedStringReader("")		
	End Sub
	
	<TearDown> _
	Public Sub TearDown()
		es.Dispose()
	End Sub
	
	<Test> _
	Public Sub TestValues()
		es = New ExtendedStringReader("sample test")
		Assert.AreEqual("sample test", es.ReadLine())
		Assert.AreEqual(11, es.Length)
		Assert.AreEqual(0, es.Position)
	End Sub
	
	<Test> _
	Public Sub TestRead()
		es = New ExtendedStringReader("test")
		Assert.AreEqual(116, es.Read())
		
	End Sub
End Class
