'
' Created by SharpDevelop.
' User: mc185104
' Date: 6/8/2012
' Time: 10:32 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
'Namespace PerfCheck
	Public Class PerfMeasures
	
		Public Sub New()
			
		End Sub
		
		Public Sub New(ByVal perfm As PerfMeasure)
			me.m_perfmeasures.Add(perfm)
			
		End Sub
		
		Dim m_perfmeasures As New List(Of PerfMeasure)				
		
		
		Public Sub Add(ByVal perfm As PerfMeasure)
			me.m_perfmeasures.Add(perfm)
		End Sub
		
		Public Function GetMeasures() As List(Of PerfMeasure)
			return me.m_perfmeasures
		End Function
		
	End Class
'End Namespace

