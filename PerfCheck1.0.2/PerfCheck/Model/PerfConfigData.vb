'
' Created by SharpDevelop.
' User: mc185104
' Date: 7/31/2012
' Time: 5:54 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'

Imports System
Imports System.Collections.Generic

Public Class PerfConfigData
	Public Sub New()
		
	End Sub
	
	Private m_dictionaryPath As String
	
	Public Property DictionaryPath() As String
		Get
			Return m_dictionaryPath
		End Get
		Set
			m_dictionaryPath = value
		End Set
	End Property
	Private m_diagFilesPath As String
	
	Public Property DiagFilesPath() As String
		Get
			Return m_diagFilesPath
		End Get
		Set
			m_diagFilesPath = value
		End Set
	End Property
	
	Public ReadOnly Property CurrentVersion() As String
		Get
			Return "1.0.0"
		End Get
		
	End Property
	
	Private m_kgs As Boolean
	
	Public Property Kgs() As Boolean
		Get
			Return m_kgs
		End Get
		Set
			m_kgs = value
		End Set
	End Property	
	
	Public ReadOnly Property Subkey() As String
		Get
			Return "LogAnal\Settings"
		End Get
		
	End Property
	
	Private m_autoDetectTemplate As Boolean
	
	Public Property AutoDetectTemplate() As Boolean
		Get
			Return m_autoDetectTemplate
		End Get
		Set
			m_autoDetectTemplate = value
		End Set
	End Property
End Class
