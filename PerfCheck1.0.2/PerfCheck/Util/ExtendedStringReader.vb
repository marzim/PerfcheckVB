'
' Created by SharpDevelop.
' User: mc185104
' Date: 7/13/2012
' Time: 3:13 AM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports System
Imports System.IO

'Namespace PerfCheck
Public Class ExtendedStringReader 	
	Inherits StringReader 
	Implements IExtendedTextReader
		Private m_position As Long = 0
		Private m_length As Long = 0

		Public Sub New(str As String)
			MyBase.New(str)
			Me.m_length = str.Length
		End Sub

		Public ReadOnly Property Length() As Long Implements IExtendedTextReader.Length
			Get
				Return m_length
			End Get
		End Property

		Public ReadOnly Property Position() As Long Implements IExtendedTextReader.Position
			Get
				Return m_position
			End Get
		End Property

		Public Overrides Function Read() As Integer
			m_position += 1
			Return MyBase.Read()
		End Function
		
		Public Overrides Sub Close() Implements IExtendedTextReader.Close
			MyBase.Close()
		End Sub
		
		Public Overrides Function ReadLine() As String Implements IExtendedTextReader.ReadLine
			Return MyBase.ReadLine()			
		End Function
	
End Class	
'End Namespace	


