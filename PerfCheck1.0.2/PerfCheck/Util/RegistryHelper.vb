'
' Created by SharpDevelop.
' User: mc185104
' Date: 7/30/2012
' Time: 8:14 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports System
Imports Microsoft.Win32

Public NotInheritable Class RegistryHelper
	Private Sub New()
	End Sub
	Shared manager As IRegistryManager

	Shared Sub New()
		Attach(New RegistryManager())
	End Sub

	Public Shared Sub Attach(manager As IRegistryManager)
		RegistryHelper.manager = manager
	End Sub

'	Public Shared Function Exists(key As String, subKey As RegistryKey) As Boolean
'		If manager Is Nothing Then
'			Throw New ArgumentNullException("RegistryManager")
'		End If
'		Return manager.Exists(key, subKey)
'	End Function
	
	Public Shared Function Exists(key As String, subKey As RegistryKey) As RegistryKey
		If manager Is Nothing Then
			Throw New ArgumentNullException("RegistryManager")
		End If
		Return manager.Exists(key, subKey)
	End Function

	Public Shared Function GetValue(name As String, subKey As RegistryKey) As String
		If manager Is Nothing Then
			Throw New ArgumentNullException("RegistryManager")
		End If
		Return manager.GetValue(name, subKey)
	End Function

	Public Shared Function GetValue(name As String, subKey As RegistryKey, defaultValue As String) As String
		If manager Is Nothing Then
			Throw New ArgumentNullException("RegistryManager")
		End If
		Return manager.GetValue(name, subKey, defaultValue)
	End Function

End Class
