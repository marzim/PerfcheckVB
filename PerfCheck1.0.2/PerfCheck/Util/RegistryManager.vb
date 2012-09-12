'
' Created by SharpDevelop.
' User: mc185104
' Date: 5/30/2012
' Time: 4:35 AM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports System
Imports Microsoft.Win32

Public Class RegistryManager
	Implements IRegistryManager
	
	Public Function Exists(key As String, subKey As RegistryKey) As RegistryKey Implements IRegistryManager.Exists
		Return subKey.OpenSubKey(key)
	End Function

	Public Function GetValue(name As String, subKey As RegistryKey) As String Implements IRegistryManager.GetValue
		Return DirectCast(subKey.GetValue(name), String)
	End Function

	Public Function GetValue(name As String, subKey As RegistryKey, defaultValue As String) As String Implements IRegistryManager.GetValue
		If subKey IsNot Nothing Then
			Dim val As String = DirectCast(subKey.GetValue(name), String)
			If String.IsNullOrEmpty(val) Then
				Return defaultValue
			End If
			Return val
		End If
		Return defaultValue
	End Function
	
End Class
