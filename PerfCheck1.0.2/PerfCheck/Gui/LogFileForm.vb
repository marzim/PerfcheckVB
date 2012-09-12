'
' Created by SharpDevelop.
' User: mc185104
' Date: 8/7/2012
' Time: 9:05 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports System.Collections.Generic
Imports System.IO

Public Partial Class LogFileForm
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
		'
		' TODO : Add constructor code after InitializeComponents
		'
	End Sub
	Private searchData As String
	Private pConfigData As PerfConfigData
	Private lfController As LogFileController
	Private dicFiles As Dictionary(Of String, FileInfo)
	
	Public Sub New(data As String, pc As PerfConfigData)
		Me.searchData = data
		Me.pConfigData = pc
		
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
		'
		' TODO : Add constructor code after InitializeComponents
		'
	End Sub	
	
	Sub LogFileFormLoad(sender As Object, e As EventArgs)		
		lfController = New LogFileController()		
		FindDataInFile()
	End Sub	
	
	Sub FindDataInFile()
		Dim traceList As String = pConfigData.DictionaryPath + "\LogAnalTraceList.txt"
		lfController.DiagPath = pConfigData.DiagFilesPath
    	If Not File.Exists(traceList) Then
    		MessageService.ShowError("Cannot find file: " + traceList + Environment.NewLine + "Check if you set the right directory for the dictionary files.", "File not found.")
    		Me.Close()
    	Else
    		lfController.getTraceList(New ExtendedStreamReader(New FileStream(traceList, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), System.Text.Encoding.Default))	
    	End If    	
    	For Each keyval As KeyValuePair(Of String, FileInfo) In lfController.DicTraceFile
    		If keyval.Value IsNot Nothing Then
    			Dim lineindex As Integer = lfController.SearchDataInLogFile(New ExtendedStreamReader(New FileStream(keyval.Value.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), System.Text.Encoding.Default), searchData)
    			If lineindex > 0 Then
    				FindDataInRichTextBox(keyval.Value.FullName, lineindex)
    				Exit For
    			End If    			
    		End If    		
		Next
	End Sub
	
	Sub FindDataInRichTextBox(fpath As String, lineindex As Integer)
		Me.richTextBox1.Text = lfController.LogFileData(fpath)	
		Dim first As Integer = Me.RichTextBox1.GetFirstCharIndexFromLine(lineindex)
	    Dim last As Integer = Me.RichTextBox1.GetFirstCharIndexFromLine(lineindex + 1)
	    If last = -1 Then last = Me.RichTextBox1.TextLength
	    Me.RichTextBox1.Select(first, last - first)
	    Me.RichTextBox1.SelectionBackColor = Color.Yellow		
		Me.Text += "    " + fpath
	End Sub
	
End Class
