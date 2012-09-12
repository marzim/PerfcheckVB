'
' Created by SharpDevelop.
' User: mc185104
' Date: 7/18/2012
' Time: 9:25 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports NUnit.Framework
Imports System.IO
Imports System.Text

<TestFixture()> _
Public Class LogFileControllerTests
	
	Dim c As LogFileController
	Dim diagPath As String
	<SetUp()> _
	Public Sub SetUp()
		MessageService.Attach(New ConsoleMessageProvider())		
		c = New LogFileController()
		TestData.createDiagPath()
		TestData.createDictionaryFiles()
		TestData.createEventLogFile()
		diagPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\test\logs"
		c.DiagPath = diagPath
	End Sub
	
	<Test()> _
	Public Sub testGetTraceList()		
		c.getTraceList(New ExtendedStringReader(TestData.LogAnalTraceListStub()))
		Assert.AreEqual(18, c.DicTraceFile.Count)		
		c.getTraceList(New ExtendedStringReader(""))
		Assert.AreEqual(0, c.DicTraceFile.Count)	
	End Sub
	
	<Test()> _
	Public Sub testGetTraceListUnicode()		
		c.getTraceList(New ExtendedStringReader("Traces=Traces.log,TracesU.log"))
		Assert.AreEqual(1, c.DicTraceFile.Count)		
		
	End Sub
	
	<Test> _
	<ExpectedException(GetType(ArgumentNullException))> _
	Public Sub TestArgumentNullException()		
		c.getTraceList(Nothing)		
	End Sub
	
	<Test> _
	<ExpectedException(GetType(DirectoryNotFoundException))> _
	Public Sub TestDirectoryNotFound()	
		c = New LogFileController()
		c.getTraceList(New ExtendedStringReader(""))
	End Sub
	
	<Test> _
	Public Sub TestLogFileData()
		c.LogFileData(diagPath + "/psx_ScotAppU.log")
	End Sub
	
	<Test> _
	Public Sub TestLogFileData_EmptyPath()
		c.LogFileData("")
	End Sub
	
	<Test> _
	Public Sub TestSearchDataInLogFile()
		Dim searchData As String = "05/05 17:25:23301517919`EventName:ChangeContext,"
		c.SearchDataInLogFile(New ExtendedStreamReader(New FileStream(diagPath + "/psx_ScotAppU.log", FileMode.Open, FileAccess.Read, FileShare.ReadWrite), System.Text.Encoding.Default), searchData)
	End Sub
	
	<Test> _
	Public Sub TestSearchDataInLogFile_DataNotFound()
		Dim searchData As String = "05/05 17:25:23301517919`EventName:Sample,"
		c.SearchDataInLogFile(New ExtendedStreamReader(New FileStream(diagPath + "/psx_ScotAppU.log", FileMode.Open, FileAccess.Read, FileShare.ReadWrite), System.Text.Encoding.Default), searchData)
	End Sub
	
End Class
