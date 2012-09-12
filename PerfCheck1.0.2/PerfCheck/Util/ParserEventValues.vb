'
' Created by SharpDevelop.
' User: mc185104
' Date: 8/23/2012
' Time: 7:02 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports System.IO
Imports System.Collections

Public Class ParserEventValues	
	
	Private m_dicEvents As New Dictionary(Of String, String)	
	
	Public Function Parsed(tr As IExtendedTextReader) As Dictionary(Of String, String)
		Dim line As String = ""
		While(InlineAssignHelper(line, tr.ReadLine())) IsNot Nothing			
			If Not line.StartsWith(";") Then
				Dim arrline As String() = line.Split("~")
				If arrline.Length > 1 Then
					If Not m_dicEvents.ContainsKey(arrline(0).Trim()) Then
						m_dicEvents.Add(arrline(0).Trim(), arrline(1))		
					End If	
				End If				
			End If			
		End While		
		tr.Close()
		Return m_dicEvents
	End Function
	
	Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
		target = value
		Return value
	End Function
	
End Class
