'
' Created by SharpDevelop.
' User: mc185104
' Date: 7/16/2012
' Time: 3:09 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports System.IO
Imports System.Text

'Namespace PerfCheck
	Public Class ExtendedStreamReader
		Inherits StreamReader
		Implements IExtendedTextReader
		
		Public Sub New(stream As Stream)
			MyBase.New(stream)
		End Sub

		Public Sub New(stream As Stream, encoding As Encoding)
			MyBase.New(stream, encoding)
		End Sub

		Public Sub New(path As String)
			MyBase.New(path)
		End Sub

		Public Sub New(path As String, encoding As Encoding)
			MyBase.New(path, encoding)
		End Sub

		Public ReadOnly Property Position() As Long Implements IExtendedTextReader.Position
			Get
				Return Me.BaseStream.Position
			End Get
		End Property

		Public ReadOnly Property Length() As Long Implements IExtendedTextReader.Length
			Get
				Return Me.BaseStream.Length
			End Get
		End Property
		
		Public Overrides Sub Close() Implements IExtendedTextReader.Close
			MyBase.Close()
		End Sub
		
		Public Overrides Function ReadLine() As String Implements IExtendedTextReader.ReadLine
			Return MyBase.ReadLine()			
		End Function
	End Class
	
'End Namespace	
	