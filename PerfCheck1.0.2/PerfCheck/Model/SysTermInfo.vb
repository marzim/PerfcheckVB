'
' Created by SharpDevelop.
' User: mc185104
' Date: 6/7/2012
' Time: 9:53 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
'Namespace PerfCheck
	Public Class SysTermInfo
		
		Dim m_adk As String
				
		Public Property Adk() As String
			Get
				Return m_adk
			End Get
			Set
				m_adk = value
			End Set
		End Property
		
		dim m_memory as String		
		
		Public Property Memory() As String
			Get
				Return m_memory
			End Get
			Set
				m_memory = value
			End Set
		End Property
		
		Dim m_proctype As String		
		
		Public Property Proctype() As String
			Get
				Return m_proctype
			End Get
			Set
				m_proctype = value
			End Set
		End Property

		Dim m_procspeed As String		
		
		Public Property Procspeed() As String
			Get
				Return m_procspeed
			End Get
			Set
				m_procspeed = value
			End Set
		End Property

		
		
	End Class
'End Namespace

