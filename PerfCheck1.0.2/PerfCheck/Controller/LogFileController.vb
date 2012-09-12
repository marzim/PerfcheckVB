'
' Created by SharpDevelop.
' User: mc185104
' Date: 6/1/2012
' Time: 4:36 AM
'
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'

Imports System.Collections.Generic
Imports System.IO
Imports System.Text.RegularExpressions
'Namespace PerfCheck
	Public Class LogFileController
		
		Dim m_lstTraceFile As New List(Of String)
		Dim m_finalLstTraceFile As New List(Of FileInfo)
		Dim m_dicTraceFile As New Dictionary(Of String, FileInfo)
		Dim m_tr As IExtendedTextReader
		Dim Public m_sLogFiles(g_MAX_LOG_FILES) As String
		Dim Public m_cFormat(g_MAX_LOG_FILES) As String
		Dim m_diagPath As String = String.Empty
		
		
		Public ReadOnly Property DicTraceFile() As Dictionary(Of String, FileInfo)
			Get
				Return m_dicTraceFile
			End Get			
		End Property		
		
		Public WriteOnly Property DiagPath() As String			
			Set
				m_diagPath = value
			End Set
		End Property
		
		Public Sub getTraceList(tr As IExtendedTextReader)
			If tr Is Nothing Then
				Throw New ArgumentNullException("getTraceList")
			End If
			If Not Directory.Exists(m_diagPath) Then
				Throw New DirectoryNotFoundException("Directory not found. " + m_diagPath)
			End If
			m_tr = tr
			getTraceList()
		End Sub
		
		Private Sub getTraceList()			
			Dim i As Integer, j As Integer, k As Integer, cc As String			
			Me.m_dicTraceFile = New Dictionary(Of String, FileInfo)
			Dim line As String = String.Empty
			While (InlineAssignHelper(line, m_tr.ReadLine())) IsNot Nothing
				If (Len(line) > 0) And Not (line.StartsWith(";")) Then
	                j = InStr(1, line, "=")
	                If (j > 0) Then
	                    'CheckedListBox1.Items.Add(Trim(Mid(s, 1, j - 1)), False)
	                    Dim tfile as String = Trim(Mid(line, 1, j - 1))
	                    'me.m_lstTraceFile.Add(tfile)
	                    k = InStr(j, line, ",")
	                    If (k > 0) Then
	                        ' there is a unicode/ascii tag to parse
	
	                        m_sLogFiles(i) = Trim(Mid(line, j + 1, k - j - 1))
	                        cc = UCase(Trim(Mid(line, k + 1)))
	                        m_cFormat(i) = Mid(cc, 1, 1) 'cc.Substring(1, 1)
	                    Else
	                        m_sLogFiles(i) = Trim(Mid(line, j + 1))
	                    End If
	                    
	                    Dim ftfile As String = m_diagPath + "\" + m_sLogFiles(i)
	                    
	                    Dim fi as New FileInfo(ftfile)
	                    If fi.Exists Then		   
	                    	If Not CheckKeyExists(tfile) Then
	                    		Me.m_dicTraceFile.Add(tfile, fi)	
	                    	End If		                    	
	                    Else	
	                    	If Not CheckKeyExists(tfile) Then
	                    		Me.m_dicTraceFile.Add(tfile, Nothing)	
	                    	End If		                    	
	                    End If
	                    i = i + 1
	                End If
	             End If
			End While
			
			m_tr.Close()
			
		End Sub
		
		Private Function CheckKeyExists(valKey As String) As Boolean			
			For Each keyval As KeyValuePair(Of String, FileInfo) In m_dicTraceFile
				If keyval.Key = valKey Then
					Return True
				End If
			Next
			Return False
		End Function
		
		Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
			target = value
			Return value
		End Function
		
		Public Function LogFileData(fpath As String) As String
			If File.Exists(fpath) Then
				Return File.ReadAllText(fpath, System.Text.Encoding.Default)	
			End If
			Return String.Empty
		End Function
		
		Public Function SearchDataInLogFile(tr As IExtendedTextReader, sData As String) As Integer
			Dim line As String = String.Empty
			Dim sData2 As String() = sData.Split("`")
			Dim newData As String = Regex.Replace(sData2(0), "[ ]+", "")
			Dim newData2 As String = Regex.Replace(sData2(1), "[ |, | ; ]+","")			
			Dim lineindex As Integer = 0
			Dim found As Boolean = False
			While (InlineAssignHelper(line, tr.ReadLine())) IsNot Nothing
				Dim newline As String = Regex.Replace(line, "[ |, | ; ]+","")			
				If newline.Contains(newData) And newline.Contains(newData2) Then															
					return lineindex
				End If
				lineindex += 1
			End While
			If Not found Then
				lineindex = 0
			End If
			Return lineindex
		End Function
		
	End Class
'End Namespace

