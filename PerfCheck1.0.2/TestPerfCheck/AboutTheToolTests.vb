'
' Created by SharpDevelop.
' User: ta185044
' Date: 8/1/2012
' Time: 7:37 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports NUnit.Framework

<TestFixture> _
Public Class AboutTheToolTests
	Private aboutTool As AboutTheTool 	
	
	<SetUp()> _
	Public Sub SetUp()
		aboutTool = New AboutTheTool()
	End Sub
	
	<TearDown()> _	
	Public Sub TearDown()
		aboutTool = Nothing
	End Sub
	<Test> _
	Public Sub TestBtnCloseAboutClick()
		' TODO: Add your test.
		aboutTool.BtnCloseAboutClick(aboutTool,Nothing)
	End Sub
End Class
