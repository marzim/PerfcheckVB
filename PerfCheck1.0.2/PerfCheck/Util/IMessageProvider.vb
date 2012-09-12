'
' Created by SharpDevelop.
' User: mc185104
' Date: 7/16/2012
' Time: 4:38 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
'Namespace PerfCheck
	Public Interface IMessageProvider
		Sub ShowInfo(message As String, caption As String)

		Sub ShowError(message As String, caption As String)

		Sub ShowWarning(message As String, caption As String)

		Function ShowYesNo(message As String, caption As String) As Boolean		
	End Interface	
'End Namespace	

