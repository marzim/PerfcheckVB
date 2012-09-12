'
' Created by SharpDevelop.
' User: mc185104
' Date: 5/24/2012
' Time: 10:24 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports System.Collections.Generic


'Namespace PerfCheck
	Public Class LogEvents
		
		Public Sub New()
			
		End Sub
		
		Public Sub New(ByVal logevent As LogEvent)
			me.m_logEvents.Add(logevent)
			
		End Sub
		
		Dim m_logEvents As New List(Of LogEvent)				
		
		
		Public Sub Add(ByVal logevent As LogEvent)
			me.m_logEvents.Add(logevent)	
		End Sub
		
		Public Function GetEvents() As List(Of LogEvent)
			return me.m_logEvents
		End Function
		
	End Class
'End Namespace

