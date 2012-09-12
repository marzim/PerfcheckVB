'
' Created by SharpDevelop.
' User: ta185044
' Date: 6/25/2012
' Time: 1:14 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports Microsoft.Win32
'Imports System
Public Partial Class AboutTheTool
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		
			
			Me.InitializeComponent()
			GetToolInformation()
		'
		' TODO : Add constructor code after InitializeComponents
		'
	End Sub
	
	Sub BtnCloseAboutClick(sender As Object, e As EventArgs)
		Me.Close()		
	End Sub
	
	Private Sub GetToolInformation()
        Const userRoot As String = "HKEY_LOCAL_MACHINE"
        Const subkey As String = "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\SSCO Application Performance Assessment Tool"
        Const keyName As String = userRoot & "\" & subkey
        Dim versionNum As String
        Try
        	versionNum = Registry.GetValue(keyName,"DisplayVersion","1.0.0")
        	lblVersion.Text = versionNum
        Catch ex As Exception
        	MessageService.ShowWarning(ex.ToString)
        End Try
        	
    End Sub
	
End Class
