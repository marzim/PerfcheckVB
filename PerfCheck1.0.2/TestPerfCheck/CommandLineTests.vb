'
' Created by SharpDevelop.
' User: mc185104
' Date: 7/22/2012
' Time: 10:02 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'

Imports NUnit.Framework
Imports System.IO
Imports System.Collections.Generic
<TestFixture()> _	
Public Class CommandLineTests
	
	Dim tr As ExtendedStreamReader
	
	Dim perfConfigData As PerfConfigData
	Dim zipFileHelper As ZipFileHelper
	<SetUp> _
	Public Sub SetUp()
		CommandLine.underNUNIT = True
		MessageService.Attach(New ConsoleMessageProvider())
		perfConfigData = New PerfConfigData()
		perfConfigData.DictionaryPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\test\config\NCR39\"
		perfConfigData.DiagFilesPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\test\logs"
		TestData.createDictionaryFiles()
		TestData.createEventLogFile()
		zipFileHelper = New ZipFileHelper()
		zipFileHelper.Create(perfConfigData.DiagFilesPath + "\test.zip", Directory.GetFiles(perfConfigData.DiagFilesPath), "test")
	End Sub
	
	<TearDown> _
	Public Sub TearDown()
		If File.Exists(perfConfigData.DiagFilesPath + "\test.zip") Then
			File.Delete(perfConfigData.DiagFilesPath + "\test.zip")			
		End If
		If Directory.Exists(perfConfigData.DiagFilesPath + "\test") Then
			For Each s As String In Directory.GetFiles(perfConfigData.DiagFilesPath + "\test")
				File.Delete(s)
			Next
			Directory.Delete(perfConfigData.DiagFilesPath + "\test")
		End If
	End Sub
	
	<Test> _
	Public Sub TestPerformTaskSummaryReport()
		CommandLine.PerformTask(False, perfConfigData.DiagFilesPath, New ExtendedStringReader(TestData.LogAnalTraceListStub()), Path.GetDirectoryName(perfConfigData.DictionaryPath))		
	End Sub
	
	<Test> _
	Public Sub TestPerformTaskMergeEvents()		
		CommandLine.PerformTask(True, perfConfigData.DiagFilesPath, New ExtendedStringReader(TestData.LogAnalTraceListStub()), Path.GetDirectoryName(perfConfigData.DictionaryPath))		
	End Sub
	
	
	<Test> _
	<ExpectedException(GetType(DirectoryNotFoundException))> _
	Public Sub TestPerformTask_DiagDirNotExist()	
		CommandLine.PerformTask(True,"", New ExtendedStringReader(TestData.LogAnalTraceListStub()), Path.GetDirectoryName(perfConfigData.DictionaryPath))		
	End Sub
	
	<Test> _
	Public Sub TestExtractFiles()		
		CommandLine.ExtractFiles(perfConfigData.DiagFilesPath, False, perfConfigData.DictionaryPath, New ExtendedStringReader("psx_ScotAppU.log"))
	End Sub
	
	<Test> _
	Public Sub TestMergedRun()
		Dim l As New List(Of String)
		l.Add("-m")
		l.Add(perfConfigData.DiagFilesPath)
		Dim s As New System.Collections.ObjectModel.ReadOnlyCollection(Of String)(l)	
		CommandLine.Run(s, New ExtendedStringReader(TestData.LogAnalTraceListStub()), New ExtendedStringReader("psx_ScotAppU.log"), perfConfigData)
	End Sub
	
	<Test> _
	Public Sub TestMergedRun_GenerateConsoleException()
		Dim l As New List(Of String)
		l.Add("-m")
		l.Add(perfConfigData.DiagFilesPath)
		Dim s As New System.Collections.ObjectModel.ReadOnlyCollection(Of String)(l)
		CommandLine.Run(s, New ExtendedStringReader(""), New ExtendedStringReader("psx_ScotAppU.log"), perfConfigData)
	End Sub
	
	<Test> _
	Public Sub TestSummaryRun()
		Dim l As New List(Of String)		
		l.Add(perfConfigData.DiagFilesPath)
		Dim s As New System.Collections.ObjectModel.ReadOnlyCollection(Of String)(l)	
		CommandLine.Run(s, New ExtendedStringReader(TestData.LogAnalTraceListStub()), New ExtendedStringReader("psx_ScotAppU.log"), perfConfigData)
	End Sub
	
	<Test> _
	Public Sub TestSummaryRun_GenerateConsoleException()
		Dim l As New List(Of String)		
		l.Add(perfConfigData.DiagFilesPath)
		Dim s As New System.Collections.ObjectModel.ReadOnlyCollection(Of String)(l)	
		CommandLine.Run(s, New ExtendedStringReader(""), New ExtendedStringReader("psx_ScotAppU.log"), perfConfigData)
	End Sub
	
	<Test> _
	Public Sub TestInvalidArgsRun()
		Dim l As New List(Of String)		
		'l.Add("")
		Dim s As New System.Collections.ObjectModel.ReadOnlyCollection(Of String)(l)	
		CommandLine.Run(s, New ExtendedStringReader(TestData.LogAnalTraceListStub()), New ExtendedStringReader("psx_ScotAppU.log"), perfConfigData)
	End Sub
	
	<Test> _
	Public Sub TestInvalidArgsRun2()
		Dim l As New List(Of String)		
		l.Add("-x")
		l.Add("")		
		Dim s As New System.Collections.ObjectModel.ReadOnlyCollection(Of String)(l)	
		CommandLine.Run(s, New ExtendedStringReader(TestData.LogAnalTraceListStub()), New ExtendedStringReader("psx_ScotAppU.log"), perfConfigData)
	End Sub
	
	<Test> _
	Public Sub TestExtractRun()
		Dim l As New List(Of String)
		l.Add("-dp")
		l.Add(perfConfigData.DiagFilesPath)
		Dim s As New System.Collections.ObjectModel.ReadOnlyCollection(Of String)(l)	
		CommandLine.Run(s, New ExtendedStringReader(TestData.LogAnalTraceListStub()), New ExtendedStringReader("psx_ScotAppU.log"), perfConfigData)
	End Sub
	
	<Test> _
	Public Sub TestExtractRun_NoZipFilesFound()
		Dim l As New List(Of String)
		l.Add("-dp")
		l.Add(perfConfigData.DiagFilesPath)
		Dim s As New System.Collections.ObjectModel.ReadOnlyCollection(Of String)(l)
		File.Delete(perfConfigData.DiagFilesPath + "\test.zip")
		CommandLine.Run(s, New ExtendedStringReader(TestData.LogAnalTraceListStub()), New ExtendedStringReader("psx_ScotAppU.log"), perfConfigData)
	End Sub
	
	<Test> _
	<ExpectedException(GetType(DirectoryNotFoundException))> _
	Public Sub TestDirectoryNotFound()
		CommandLine.ExtractFiles("c:\notfound\directory", False, "", New ExtendedStringReader(""))
	End Sub
	
	<Test> _
	Public Sub testsample()
		Dim line As String = "10112328) 05/09 07:24:51;061,108,4092 0A24> SM-SMdmBase@4329 +DMSaySecurity <0> <ScanYourClubCard> <hWaitEvent=0x0>"
		Dim newline As String = System.Text.RegularExpressions.Regex.Replace(line, "[ |, | ; ]+","")
		Console.WriteLine(newline)
	End Sub
	
End Class
