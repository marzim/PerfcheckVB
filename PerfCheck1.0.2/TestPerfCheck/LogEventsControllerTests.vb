'
' Created by SharpDevelop.
' User: mc185104
' Date: 7/23/2012
' Time: 6:37 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports NUnit.Framework
Imports System.IO
<TestFixture> _
Public Class LogEventsControllerTests	
	Dim ec As LogEventsController
	Dim lf As LogFileController
	Dim fpath As String
	Dim dicPath As String
	
	<TestFixtureSetUp> _
	Public Sub Init
		MessageService.Attach(New ConsoleMessageProvider())
		TestData.createDictionaryFiles()
		TestData.createEventLogFile()
		dicPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\test\config\NCR39\"
		fPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\test\logs\"
		ec = New LogEventsController()		
		lf = New LogFileController()
		
	End Sub
	
	<TestFixtureTearDown> _
	Public Sub Dispose
		
		ec = Nothing
	End Sub
	
	<Test> _
	Public Sub TestGetEventsFromFile()
		Dim i As Integer = 0
		'TODO: create a logfile stub
		lf.DiagPath = fpath
		lf.getTraceList(New ExtendedStringReader(TestData.LogAnalTraceListStub()))
		For Each keyval As KeyValuePair(Of String, FileInfo) In lf.DicTraceFile
    		If Not keyval.Value Is Nothing Then
        		ec.getEventsFromFile(keyval.Value, lf.m_cFormat(i), dicPath)
				i+=1		
    		End If
    		If i > 2 Then
    			Exit For
    		End If
    	Next
	End Sub
	
	<Test> _
	<ExpectedException(GetType(ArgumentNullException))> _		
	Public Sub TestGetEventsFromFileNull		
		ec.getEventsFromFile(Nothing, "", dicPath)
	End Sub
	
	<Test> _
	<ExpectedException(GetType(FileNotFoundException))> _		
	Public Sub TestGetEventsFromFileNotFound			
		ec.getEventsFromFile(New FileInfo("test.log"), "", dicPath)
	End Sub
End Class
