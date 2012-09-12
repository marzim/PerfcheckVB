'
' Created by SharpDevelop.
' User: mc185104
' Date: 7/16/2012
' Time: 6:17 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
'Namespace PerfCheck
	Public Class ConsoleMessageProvider
		Implements IMessageProvider
		Public Sub ShowInfo(message As String, caption As String) Implements IMessageProvider.ShowInfo
			Console.WriteLine(message)			
		End Sub

		Public Sub ShowError(message As String, caption As String) Implements IMessageProvider.ShowError
			Console.WriteLine(message)			
		End Sub

		Public Sub ShowWarning(message As String, caption As String) Implements IMessageProvider.ShowWarning
			Console.WriteLine(message)		
		End Sub

		Public Function ShowYesNo(message As String, caption As String) As Boolean Implements IMessageProvider.ShowYesNo
			'			Console.Write("[yn] ");
			'			return Console.ReadLine().ToLower().Equals("y");
			Console.WriteLine(message)	
			Return False
			' FIXME: Get console ReadLine
		End Function
	End Class	
'End Namespace	

