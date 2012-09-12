'
' Created by SharpDevelop.
' User: mc185104
' Date: 7/20/2012
' Time: 10:57 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports NUnit.Framework

<TestFixture()> _
Public Class LogEventsSummaryTests
	Dim les As LogEventsSummary	
	Dim le As LogEventSummary
	<SetUp> _
	Public Sub SetUp()
		MessageService.Attach(New ConsoleMessageProvider())
		les = New LogEventsSummary()
		le = New LogEventSummary()
		le.Average = "12.0"		
		le.Col.Add(2)
		le.Count = "3"
		le.Flag.Add(1)
		le.Maximum = "123"
		le.Measure = "12"
		le.Minimum = "1"
		le.StdDev = "12.2"		
		
	End Sub
	
	<Test> _
	Public Sub testValues()
		Assert.AreEqual("12.0", le.Average)
		Assert.AreEqual(2, le.Col.Item(0))
		Assert.AreEqual("3", le.Count)
		Assert.AreEqual(1, le.Flag.Item(0))
		Assert.AreEqual("123", le.Maximum)
		Assert.AreEqual("12", le.Measure)
		Assert.AreEqual("1", le.Minimum)
		Assert.AreEqual("12.2", le.StdDev)
		Dim s As String() = {"12","3","1","123","12.0","12.2"}
		Assert.AreEqual(s, le.Values)
	End Sub
	
	<Test> _
	Public Sub TestInitialize()
		les = New LogEventsSummary(New LogEventSummary("","","","","",""))
		Assert.NotNull(les)
	End Sub
	
	<Test> _
	Public Sub TestAdd()
		les.Add(New LogEventSummary("","","","","",""))
		Assert.AreEqual(1, les.GetEvents().Count)
	End Sub
	
	
End Class
