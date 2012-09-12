'
' Created by SharpDevelop.
' User: mc185104
' Date: 5/29/2012
' Time: 10:03 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
'Namespace PerfCheck
Public Class LogEvent
	
		Dim m_rawEvent As String
		'sample comment
		Public Property RawEvent() As String
			Get
				Return m_rawEvent
			End Get
			Set
				m_rawEvent = value
			End Set
		End Property
		
		Dim m_relTime As Double
		Public Property RelTime() As Double
			Get
				Return m_relTime
			End Get
			Set
				m_relTime = value
			End Set
		End Property
		
		Dim m_datetime As String
		Public Property Datetime() As String
			Get
				Return m_datetime
			End Get
			Set
				m_datetime = value
			End Set
		End Property
		
		Dim m_millisec As UInt64
		
		Public Property Millisec() As UInt64
			Get
				Return m_millisec
			End Get
			Set
				m_millisec = value
			End Set
		End Property
		
		Dim m_source As String	
		
		Public Property Source() As String
			Get
				Return m_source
			End Get
			Set
				m_source = value
			End Set
		End Property
		
		Dim m_lineno As Integer	
		
		Public Property Lineno() As Integer
			Get
				Return m_lineno
			End Get
			Set
				m_lineno = value
			End Set
		End Property
		
		Dim m_events As String
		
		Public Property Events() As String
			Get
				Return m_events
			End Get
			Set
				m_events = value
			End Set
		End Property
		
		Dim m_data As String	
		
		Public Property Data() As String
			Get
				Return m_data
			End Get
			Set
				m_data = value
			End Set
		End Property
		
		Dim m_colIndex As Integer
		
		Public Property ColIndex() As Integer
			Get
				Return m_colIndex
			End Get
			Set
				m_colIndex = value
			End Set
		End Property
	End Class

'End Namespace
