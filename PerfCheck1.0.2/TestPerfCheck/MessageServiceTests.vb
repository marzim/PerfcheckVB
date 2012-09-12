'
' Created by SharpDevelop.
' User: mc185104
' Date: 7/25/2012
' Time: 4:03 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports NUnit.Framework

<TestFixture> _
Public Class MessageServiceTests
		<SetUp> _
		Public Sub Setup()
			
			MessageService.Attach(New ConsoleMessageProvider())
		End Sub

		<Test> _
		<ExpectedException(GetType(ArgumentNullException))> _
		Public Sub TestShowInfoOnNullProvider()
			MessageService.Attach(Nothing)
			MessageService.ShowInfo("Info...")
		End Sub

		<Test> _
		Public Sub TestShowInfo()
			MessageService.ShowInfo("Info...")
		End Sub

		<Test> _
		<ExpectedException(GetType(ArgumentNullException))> _
		Public Sub TestShowWarningOnNullProvider()
			MessageService.Attach(Nothing)
			MessageService.ShowWarning("Warning...")
		End Sub

		<Test> _
		Public Sub TestShowWarning()
			MessageService.ShowWarning("Warning...")
		End Sub

		<Test> _
		<ExpectedException(GetType(ArgumentNullException))> _
		Public Sub TestShowErrorOnNullProvider()
			MessageService.Attach(Nothing)
			MessageService.ShowError("Error...")
		End Sub

		<Test> _
		Public Sub TestShowError()
			MessageService.ShowError("Error...")
		End Sub

		<Test> _
		<ExpectedException(GetType(ArgumentNullException))> _
		Public Sub TestShowYesNoOnNullProvider()
			MessageService.Attach(Nothing)
			MessageService.ShowYesNo("Yes? ")
		End Sub

		<Test> _
		Public Sub TestShowYesNo()
			MessageService.ShowYesNo("Yes? ")
		End Sub
		
		<Test> _
		Public Sub init()
			Dim m As New MessageService()
			Assert.NotNull(m)
		End Sub
	End Class
