'
' Created by SharpDevelop.
' User: mc185104
' Date: 6/8/2012
' Time: 10:30 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
'Namespace PerfCheck
	Public Class PerfMeasure
		
		Private m_dAvgHiLim As Double
	    Private m_dAvgLoLim As Double
		Private m_nMinHiLim As Integer
	    Private m_nMinLoLim As Integer  
	    Private m_nMaxHiLim As Integer
	    Private m_nMaxLoLim As Integer    
		Private m_measure As String	        
		
		Public Property DAvgLoLim() As Double
			Get
				Return m_dAvgLoLim
			End Get
			Set
				m_dAvgLoLim = value
			End Set
		End Property
		Public Property DAvgHiLim() As Double
			Get
				Return m_dAvgHiLim
			End Get
			Set
				m_dAvgHiLim = value
			End Set
		End Property    
		Public Property NMinLoLim() As Integer
			Get
				Return m_nMinLoLim
			End Get
			Set
				m_nMinLoLim = value
			End Set
		End Property
		Public Property NMinHiLim() As Integer
			Get
				Return m_nMinHiLim
			End Get
			Set
				m_nMinHiLim = value
			End Set
		End Property	
		Public Property Measure() As String
			Get
				Return m_measure
			End Get
			Set
				m_measure = value
			End Set
		End Property
		Public Property NMaxLoLim() As Integer
			Get
				Return m_nMaxLoLim
			End Get
			Set
				m_nMaxLoLim = value
			End Set
		End Property
		Public Property NMaxHiLim() As Integer
			Get
				Return m_nMaxHiLim
			End Get
			Set
				m_nMaxHiLim = value
			End Set
		End Property
	End Class
'End Namespace

