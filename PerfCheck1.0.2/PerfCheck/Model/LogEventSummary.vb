'
' Created by SharpDevelop.
' User: mc185104
' Date: 6/2/2012
' Time: 6:16 AM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
'Namespace PerfCheck



	Public Class LogEventSummary
		
		Public Sub New()
			
		End Sub
		
		Public Sub New(ByVal _measure As String, ByVal _count As String, _
			ByVal _min As String, ByVal _max As String, ByVal _ave As String, _
			byval _std as String, Optional byval _flag As Integer=0, optional byval _col As Integer=0)
			Me.m_measure = _measure
			Me.m_count = _count
			Me.m_minimum = _min
			Me.m_maximum = _max
			Me.m_average = _ave
			Me.m_stdDev = _std						
		End Sub
		
		Dim m_measure As String	
		
		Public Property Measure() As String
			Get
				Return m_measure
			End Get
			Set
				m_measure = value
			End Set
		End Property
		
		Dim m_count As String
		Public Property Count() As String
			Get
				Return m_count
			End Get
			Set
				m_count = value
			End Set
		End Property
		
		Dim m_minimum as String
		
		
		Public Property Minimum() As String
			Get
				Return m_minimum
			End Get
			Set
				m_minimum = value
			End Set
		End Property
		
		Dim m_maximum as String
		
		
		Public Property Maximum() As String
			Get
				Return m_maximum
			End Get
			Set
				m_maximum = value
			End Set
		End Property
		
		Dim m_average as String		
		
		Public Property Average() As String
			Get
				Return m_average
			End Get
			Set
				m_average = value
			End Set
		End Property
		
		Dim m_stdDev as String	
		
		Public Property StdDev() As String
			Get
				Return m_stdDev
			End Get
			Set
				m_stdDev = value
			End Set
		End Property
		
		Dim m_values(6) As String
		
		Public ReadOnly Property Values() As String()
			Get				
				m_values = New String(){m_measure,m_count,m_minimum, m_maximum,m_average,m_stdDev}
				Return m_values
			End Get
		End Property
		
		Dim m_flag As New ArrayList()
		
		Public Property Flag() As ArrayList
			Get
				Return m_flag
			End Get
			Set
				m_flag = value
			End Set
		End Property		
		
		Dim m_col As New ArrayList()
		
		Public Property Col() As ArrayList
			Get
				Return m_col
			End Get
			Set
				m_col = value
			End Set
		End Property
		
		
		
		
	End Class	
		
'End Namespace

