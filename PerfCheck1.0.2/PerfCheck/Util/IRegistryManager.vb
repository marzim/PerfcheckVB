'
' Created by SharpDevelop.
' User: mc185104
' Date: 7/30/2012
' Time: 8:03 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports System
Imports Microsoft.Win32

Public Interface IRegistryManager
	Function Exists(key As String, subKey As RegistryKey) As RegistryKey

	Function GetValue(key As String, subKey As RegistryKey) As String

	Function GetValue(key As String, subKey As RegistryKey, defaultValue As String) As String
	

End Interface
