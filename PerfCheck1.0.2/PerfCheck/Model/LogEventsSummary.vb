'
' Created by SharpDevelop.
' User: mc185104
' Date: 6/2/2012
' Time: 6:19 AM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports System.Collections.Generic


'Namespace PerfCheck
	Public Class LogEventsSummary
		
		Public Sub New()
			
		End Sub
		
		Public Sub New(ByVal logevent As LogEventSummary)
			me.m_logEvents.Add(logevent)
			
		End Sub
		
		Dim m_logEvents As New List(Of LogEventSummary)				
		
		
		Public Sub Add(ByVal logevent As LogEventSummary)
			me.m_logEvents.Add(logevent)	
		End Sub
		
		Public Function GetEvents() As List(Of LogEventSummary)
			return me.m_logEvents
		End Function
		
	End Class
'End Namespace
	

