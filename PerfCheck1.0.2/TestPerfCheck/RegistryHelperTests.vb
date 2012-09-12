'
' Created by SharpDevelop.
' User: mc185104
' Date: 7/30/2012
' Time: 8:43 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'

Imports System
Imports NUnit.Framework
Imports Microsoft.Win32

<TestFixture> _
	Public Class RegistryHelperTests
		<SetUp> _
		Public Sub Setup()
			RegistryHelper.Attach(New RegistryManagerStub())
		End Sub

		<Test> _
		<ExpectedException(GetType(ArgumentNullException))> _
		Public Sub TestExistsOnNullManager()
			RegistryHelper.Attach(Nothing)
			Assert.IsNotNull(RegistryHelper.Exists("Configure", Registry.LocalMachine))
		End Sub

		<Test> _
		Public Sub TestExists()
			Assert.IsNull(RegistryHelper.Exists("Configure", Registry.LocalMachine))
		End Sub

		<Test> _
		<ExpectedException(GetType(ArgumentNullException))> _
		Public Sub TestGetValueOnNullManager()
			RegistryHelper.Attach(Nothing)
			Assert.AreEqual("unicode", RegistryHelper.GetValue("Configure", Registry.LocalMachine))
		End Sub

		<Test> _
		Public Sub TestGetValue()
			Assert.AreEqual("unicode", RegistryHelper.GetValue("Configure", Registry.LocalMachine))
		End Sub

		<Test> _
		<ExpectedException(GetType(ArgumentNullException))> _
		Public Sub TesetGetValueWithDefaultOnNullManager()
			RegistryHelper.Attach(Nothing)
			Assert.AreEqual("world", RegistryHelper.GetValue("hello", Nothing, "world"))
		End Sub

		<Test> _
		Public Sub TesetGetValueWithDefault()
			Assert.AreEqual("world", RegistryHelper.GetValue("hello", Nothing, "world"))
			Assert.AreEqual("hello", RegistryHelper.GetValue("hello", Registry.LocalMachine, "world"))
		End Sub
	End Class
