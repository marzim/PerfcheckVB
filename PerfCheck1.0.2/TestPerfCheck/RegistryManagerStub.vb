'
' Created by SharpDevelop.
' User: mc185104
' Date: 7/31/2012
' Time: 8:11 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports System
Imports Microsoft.Win32
Imports NUnit.Framework

Public Class RegistryManagerStub
	Implements IRegistryManager
		Dim rkey As RegistryKey
		Public Function Exists(key As String, subKey As RegistryKey) As RegistryKey Implements IRegistryManager.Exists
			Return rkey
		End Function

		Public Function GetValue(key As String, subKey As RegistryKey) As String Implements IRegistryManager.GetValue
			Select Case key
				Case "Configure"
					Return "unicode"
				Case "ComponentVersion"
					Return "4.5"
				Case Else
					Throw New NotSupportedException()
			End Select
		End Function

		Public Function GetValue(key As String, subKey As RegistryKey, defaultValue As String) As String Implements IRegistryManager.GetValue
			Return If(subKey Is Nothing, defaultValue, key)
		End Function
	End Class
