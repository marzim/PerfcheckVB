'
' Created by SharpDevelop.
' User: mc185104
' Date: 7/20/2012
' Time: 11:05 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports NUnit.Framework

<TestFixture()> _
Public Class LogEventsTests
	
	Dim logEvnts As LogEvents
	Dim logEvnt As LogEvent	
	<SetUp> _
	Public Sub SetUp()
		MessageService.Attach(New ConsoleMessageProvider())
		logEvnts = New LogEvents()
		logEvnt = New LogEvent()
		logEvnt.Data = "sample data"
		logEvnt.Datetime = "12/12/2012"
		logEvnt.Events = "sample events test"
		logEvnt.Lineno = 12
		logEvnt.Millisec = 12345
		logEvnt.RelTime = 14993
		logEvnt.Source = "sample source test"
	End Sub
	
	<Test> _
	Public Sub testValues()
		Assert.AreEqual("sample data", logEvnt.Data)
		Assert.AreEqual("12/12/2012", logEvnt.Datetime)
		Assert.AreEqual("sample events test", logEvnt.Events)
		Assert.AreEqual(12, logEvnt.Lineno)
		Assert.AreEqual(12345, logEvnt.Millisec)
		Assert.AreEqual(14993, logEvnt.RelTime)
		Assert.AreEqual("sample source test", logEvnt.Source)
	End Sub
	
	<Test> _
	Public Sub TestInitialize()
		Dim l As New LogEvent()		
		logEvnts = New LogEvents(l)
		Assert.NotNull(logEvnts)
	End Sub
	
	<Test> _
	Public Sub TestAddLogEvents()
		logEvnts.Add(logEvnt)
		Assert.AreEqual(1,logEvnts.GetEvents.Count)
	End Sub
End Class
