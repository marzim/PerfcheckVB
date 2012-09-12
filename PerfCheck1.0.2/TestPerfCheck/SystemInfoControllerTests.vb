'
' Created by SharpDevelop.
' User: mc185104
' Date: 7/18/2012
' Time: 10:19 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports NUnit.Framework
Imports System.IO

<TestFixture()> _
Public Class SystemInfoControllerTests
	Dim sys As SysTermInfo
	Dim sysController As SysTermInfoController
	<SetUp()> _
	Public Sub SetUp()
		MessageService.Attach(New ConsoleMessageProvider())
		sys = New SysTermInfo()
		sysController = New SysTermInfoController()
	End Sub
	
	<Test()> _
	Public Sub testGetSystemInfo()		
		SysTermInfoController.getSystemInfo(New ExtendedStringReader("Application               	: 4.04.00.0.000.391"), sys)
		Assert.IsNotEmpty(sys.Adk, "adk version is " + sys.Adk)
		SysTermInfoController.getSystemInfo(New ExtendedStringReader("Application               	: "), sys)
		Assert.IsEmpty(sys.Adk, "adk version is " + sys.Adk)
		SysTermInfoController.getSystemInfo(New ExtendedStringReader("              	: 4.04.00.0.000.391"), sys)
		Assert.IsEmpty(sys.Adk, "adk version is " + sys.Adk)
		SysTermInfoController.getSystemInfo(New ExtendedStringReader("Sample              	: 4.04.00.0.000.391"), sys)
		Assert.IsEmpty(sys.Adk, "adk version is " + sys.Adk)
	End Sub
	
	<Test()> _
	Public Sub testGetTerminalInfo()		
		SysTermInfoController.getTerminalInfo(New ExtendedStringReader("Processor Type            	: x86 Family 15 Model 2 Stepping 9" & Environment.NewLine & "Processor Speed           	: 2492 MHz" & Environment.NewLine & "Physical Memory           	: 238 MB"), sys)
		Assert.IsNotEmpty(sys.Proctype, "processor type is " + sys.Proctype)
		Assert.IsNotEmpty(sys.Procspeed, "processor speed is " + sys.Procspeed)
		Assert.IsNotEmpty(sys.Memory, "memory is " + sys.Memory)
	End Sub
	
	<Test()> _
	Public Sub TestGetTemplateADKVersion()
		Dim adkVersion As String
		adkVersion = SysTermInfoController.getTemplateADKVersion(New ExtendedStringReader("ADK Version : 4.04.00.0.000.339"))
		Assert.IsNotEmpty(adkVersion)
		Assert.AreEqual("4.04.00.0.000.339",adkVersion)
	End Sub
	
	<Test()> _
	Public Sub TestGetTemplateADKVersion_NotFound()
		Dim adkVersion As String
		adkVersion = SysTermInfoController.getTemplateADKVersion(New ExtendedStringReader("Some Version : "))
		Assert.IsEmpty(adkVersion)
	End Sub
End Class
