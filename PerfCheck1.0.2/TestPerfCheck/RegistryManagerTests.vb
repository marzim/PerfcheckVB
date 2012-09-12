'
' Created by SharpDevelop.
' User: mc185104
' Date: 7/31/2012
' Time: 8:13 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports System
Imports Microsoft.Win32
Imports NUnit.Framework

<TestFixture> _
Public Class RegistryManagerTests
		Private m As RegistryManager

		<SetUp> _
		Public Sub Setup()
			m = New RegistryManager()
		End Sub

		<Test> _
		Public Sub TestExists()
			Assert.IsNull(m.Exists("Qwerty", Registry.LocalMachine))
		End Sub
		
		<Test> _
		<ExpectedException(GetType(System.NullReferenceException))> _
		Public Sub TestEmptyExists()
			m.GetValue(Nothing, Nothing)
		End Sub

		<Test> _
		Public Sub TestGetValue()
			Assert.IsNull(m.GetValue("Qwerty", Registry.LocalMachine))
		End Sub
		
		<Test> _
		<ExpectedException(GetType(System.NullReferenceException))> _
		Public Sub TestEmptyGetValue()
			m.GetValue(Nothing, Nothing)
		End Sub

		<Test> _
		Public Sub TestGetValueWithDefault()
			Assert.AreEqual("Tyuiop", m.GetValue("Qwerty", Registry.LocalMachine, "Tyuiop"))
		End Sub
		
		<Test> _
		Public Sub TestEmptyGetValueWithDefault()
			Assert.IsNull(m.GetValue(Nothing, Nothing, Nothing))
		End Sub
	End Class
