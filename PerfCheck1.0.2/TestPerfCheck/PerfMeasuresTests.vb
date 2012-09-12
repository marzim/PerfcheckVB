'
' Created by SharpDevelop.
' User: mc185104
' Date: 7/20/2012
' Time: 11:34 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports NUnit.Framework

<TestFixture()> _
Public Class PerfMeasuresTests
	
	Dim pm As PerfMeasures
	Dim p As PerfMeasure
	
	<SetUp> _
	Public Sub SetUp()
		MessageService.Attach(New ConsoleMessageProvider())
		pm = New PerfMeasures()
		p = New PerfMeasure()
		p.DAvgHiLim = 123
		p.DAvgLoLim = 12
		p.Measure = "test measure"
		p.NMaxHiLim = 345
		p.NMaxLoLim = 123
		p.NMinHiLim = 34
		p.NMinLoLim = 3
	End Sub
	
	<Test> _
	Public Sub testValues()
		Assert.AreEqual(123, p.DAvgHiLim)
		Assert.AreEqual(12, p.DAvgLoLim)
		Assert.AreEqual("test measure", p.Measure)
		Assert.AreEqual(345, p.NMaxHiLim)
		Assert.AreEqual(123, p.NMaxLoLim)
		Assert.AreEqual(34, p.NMinHiLim)
		Assert.AreEqual(3, p.NMinLoLim)
	End Sub
	
	<Test> _
	Public Sub TestGetMeasures()
		pm = New PerfMeasures(p)
		Assert.AreEqual(1, pm.GetMeasures().Count)
	End Sub
	
	<Test> _
	Public Sub TestAdd()
		pm.Add(p)
		Assert.AreEqual(1, pm.GetMeasures().Count)
	End Sub
End Class
