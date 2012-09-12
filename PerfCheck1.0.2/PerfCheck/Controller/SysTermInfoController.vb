'
' Created by SharpDevelop.
' User: mc185104
' Date: 6/7/2012
' Time: 9:56 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports System.IO
Imports System.Text.RegularExpressions

'Namespace PerfCheck
	Public Class SysTermInfoController
		
'		Public Shared Function GetInfo() As SysTermInfo
'			Dim sys As New SysTermInfo()
'			readFile(sys)
'			return  sys
'		End Function
		
		Public Shared Sub getTerminalInfo(byval tr As IExtendedTextReader, ByVal sys As SysTermInfo)
			Dim line As String = String.Empty
			Dim templine As String()
			'Using sr As New StreamReader(g_sINITIAL_DIRECTORY + "/TerminalInfo.dat")				
			'	While sr.Peek() >= 0
			While (InlineAssignHelper(line, tr.ReadLine())) IsNot Nothing
				templine = line.Split(":")
				If templine.Length > 0 Then
					If Regex.IsMatch(templine(0).Trim(), "processor type", RegexOptions.IgnoreCase) Then
						sys.Proctype = templine(1).Trim()
					Else If Regex.IsMatch(templine(0).Trim(), "processor speed", RegexOptions.IgnoreCase)
						sys.Procspeed = templine(1).Trim()
					Else If	Regex.IsMatch(templine(0).Trim(), "physical memory", RegexOptions.IgnoreCase)
						sys.Memory = templine(1).Trim()						
					End If
				End If
			End While
			tr.Close()
			'End Using			
		End Sub		
		
		Public Shared Sub getSystemInfo(ByVal tr As IExtendedTextReader, ByVal sys As SysTermInfo)
			Dim line As String = String.Empty
			Dim templine As String()
			
			While (InlineAssignHelper(line, tr.ReadLine())) IsNot Nothing				
				templine = line.Split(":")
				If templine.Length > 0 Then
					If Regex.IsMatch(templine(0).Trim(), "application", RegexOptions.IgnoreCase) Then
						sys.Adk = templine(1).Trim()
						Exit While
					End If
				End If				
			End While
			tr.Close()
		End Sub
		
		Public Shared Function getTemplateADKVersion(ByVal tr As IExtendedTextReader) As String
			Dim line As String = String.Empty
			Dim templine As String()
			Dim ADKVersion As String = ""
			While (InlineAssignHelper(line, tr.ReadLine())) IsNot Nothing				
				templine = line.Split(":")
				If templine.Length > 0 Then
					If Regex.IsMatch(templine(0).Trim(), "ADK Version", RegexOptions.IgnoreCase) Then
						ADKVersion = templine(1).Trim()
						Exit While
					End If
				End If				
			End While
			tr.Close()
			Return ADKVersion
		End Function
		
		Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
			target = value
			Return value
		End Function
	End Class
'End Namespace

