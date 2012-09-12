'
' Created by SharpDevelop.
' User: mc185104
' Date: 7/18/2012
' Time: 10:35 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports NUnit.Framework
Imports System.IO
Imports System.Text
<TestFixture()> _
Public Class ExtendedStreamReaderTests
	
	Private r As ExtendedStreamReader	
	Private fpath As String = String.Empty
	
	<SetUp> _
	Public Sub Setup()
		MessageService.Attach(New ConsoleMessageProvider())
		fpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\test\test.log"		
		If Not Directory.Exists(Path.GetDirectoryName(fpath)) Then
			Directory.CreateDirectory(Path.GetDirectoryName(fpath))
		End If
		Using sw As New StreamWriter(fpath)
			sw.WriteLine(String.Empty)
		End Using	
	End Sub
	
	<TearDown> _ 
	Public Sub Teardown()
		r.Dispose()
		File.Delete(fpath)
	End Sub
	
	<Test> _
	Public Sub TestConstructorWithStreamParameter()
		r = New ExtendedStreamReader(New FileStream(fpath, FileMode.Open))
		Assert.AreEqual(0, r.Position)
		Assert.AreEqual(2, r.Length)
	End Sub

	<Test> _
	Public Sub TestConstructorWithStreamEncodingParameter()
		r = New ExtendedStreamReader(New FileStream(fpath, FileMode.Open), Encoding.[Default])
		Assert.AreEqual(0, r.Position)
		Assert.AreEqual(2, r.Length)
	End Sub

	<Test> _
	Public Sub TestConstructorWithFileNameEncodingParameter()
		r = New ExtendedStreamReader(fpath, Encoding.[Default])
		Assert.AreEqual(0, r.Position)
		Assert.AreEqual(2, r.Length)
	End Sub

	<Test> _
	Public Sub TestConstructorWithFileNameParameter()
		r = New ExtendedStreamReader(fpath)
		Assert.AreEqual(0, r.Position)
		Assert.AreEqual(2, r.Length)
	End Sub
End Class
