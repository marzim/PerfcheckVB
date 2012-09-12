'
' Created by SharpDevelop.
' User: mc185104
' Date: 7/16/2012
' Time: 6:13 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
'Namespace PerfCheck
Public NotInheritable Class MessageService
	
		Public Sub New()
		End Sub
		
		Shared provider As IMessageProvider

		Public Shared Sub Attach(provider As IMessageProvider)
			MessageService.provider = provider
		End Sub

		Public Shared Sub ShowInfo(message As String)
			ShowInfo(message, "Information")			
		End Sub

		Public Shared Sub ShowInfo(message As String, caption As String)
			If provider Is Nothing Then
				Throw New ArgumentNullException("MessageProvider")
			End If
			provider.ShowInfo(message, caption)
			LogHelper.Log(message, LogType.INFO)
		End Sub

		Public Shared Sub ShowError(message As String, caption As String)
			If provider Is Nothing Then
				Throw New ArgumentNullException("MessageProvider")
			End If
			provider.ShowError(message, caption)
			LogHelper.Log(message, LogType.ERR)
		End Sub

		Public Shared Sub ShowError(message As String)
			ShowError(message, "Error")
			
		End Sub

		Public Shared Sub ShowWarning(message As String)
			ShowWarning(message, "Warning")			
		End Sub

		Public Shared Sub ShowWarning(message As String, caption As String)
			If provider Is Nothing Then
				Throw New ArgumentNullException("MessageProvider")
			End If
			provider.ShowWarning(message, caption)
			LogHelper.Log(message, LogType.WARNING)
		End Sub

		Public Shared Function ShowYesNo(message As String) As Boolean
			Return ShowYesNo(message, "Question")
		End Function

		Public Shared Function ShowYesNo(message As String, caption As String) As Boolean
			If provider Is Nothing Then
				Throw New ArgumentNullException("MessageProvider")
			End If
			Return provider.ShowYesNo(message, caption)
		End Function
	End Class	
'End Namespace	

