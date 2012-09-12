'
' Created by SharpDevelop.
' User: mc185104
' Date: 6/14/2012
' Time: 10:26 PM
'
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'

Imports System.IO
'Namespace PerfCheck
	Public Class LogHelper
		
		Public Shared Sub Log(ByVal data As String, byval type as LogType, Optional byval writeToConsole as Boolean = False)
			
			Dim path As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\logs"
			Dim di As New DirectoryInfo(path)
			If Not di.Exists Then
				di.Create()
			End If
			
			If writeToConsole Then
				Console.WriteLine(data)
			End If
			
			Using sw As New StreamWriter(path + "\PerfCheck" + DateTime.Now.ToString("MM-dd-yy") + ".log", True)				
				If type <> -1 Then
					sw.WriteLine("[" + type.ToString() + "] " + data)
				Else
					sw.WriteLine(data)
				End If				
			End Using
		End Sub
		
	End Class
	
	Public Enum LogType
		INFO = 1 
		WARNING = 2
		ERR = 3
	End Enum
		
'End Namespace

