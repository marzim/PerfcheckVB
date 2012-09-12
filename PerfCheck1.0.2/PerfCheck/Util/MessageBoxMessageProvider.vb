'
' Created by SharpDevelop.
' User: mc185104
' Date: 7/16/2012
' Time: 6:16 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
'Namespace PerfCheck
	Public Class MessageBoxMessageProvider
		Implements IMessageProvider
		Public Sub ShowInfo(message As String, caption As String) Implements IMessageProvider.ShowInfo
			MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information)
		End Sub

		Public Sub ShowError(message As String, caption As String) Implements IMessageProvider.ShowError
			MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.[Error])
		End Sub

		Public Sub ShowWarning(message As String, caption As String) Implements IMessageProvider.ShowWarning
			MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
		End Sub

		Public Function ShowYesNo(message As String, caption As String) As Boolean Implements IMessageProvider.ShowYesNo
			Return MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
		End Function
	End Class	
'End Namespace	

