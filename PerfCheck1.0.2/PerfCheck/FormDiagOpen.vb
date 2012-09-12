Option Explicit On

Imports System.Windows.Forms
Imports System
Imports System.IO
Imports System.Collections.Generic

'Namespace PerfCheck
	Public Class FormDiagOpen
    Dim m_nFileSize As Long, m_nBytesRead As Long
    Dim m_sLogFiles(g_MAX_LOG_FILES) As String
    Dim m_cFormat(g_MAX_LOG_FILES) As String
    Dim logfileController As New LogFileController()      
	Dim lstIndetermined As New List(Of String)
    Dim m_lstEventLogs as New List(Of String)
    
	Public Property LstEventLogs() As List(Of String)
		Get
			Return m_lstEventLogs
		End Get
		Set
			m_lstEventLogs = value
		End Set
	End Property
    
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.Close()    
    End Sub
    
    Public Sub Subscribe(s As SignifEvents)
			AddHandler s.progress, New SignifEvents.ProgressHandler(AddressOf progressHasChanged)
	End Sub

	Public Sub progressHasChanged(sender As Object, e As ProgressEventArgs)
		If TypeOf sender Is SignifEvents Then
			Me.ProgressBar1.Minimum = e.min
			Me.ProgressBar1.Maximum = e.max
			Me.ProgressBar1.Value = e.value
			If Not e.text.Equals("") Then
				Me.lststatus.Items.Add(e.text)
			End If
			
			If e.text.Trim().StartsWith("Done Parsing") Then
				Me.lststatus.Items.Add("--------------------------------")
				Me.lststatus.Items.Add("")				
			End If
			
		End If
	End Sub
	
'    Public Sub SetLogFiles(ByVal i As Integer, ByVal s As String)
'        m_sLogFiles(i) = s
'    End Sub
'
'    Public Function GetLogFiles(ByVal i As Integer) As String
'        GetLogFiles = m_sLogFiles(i)
'    End Function
'
'    Public Sub SetProgressBarLimit(ByVal n As Long)
'        m_nFileSize = n
'    End Sub
'    
    Dim m_eventsFound As SignifEvents
	
	Public ReadOnly Property EventsFound() As SignifEvents
		Get
			Return m_eventsFound
		End Get		
	End Property	
	
	Dim m_perfConfigData As PerfConfigData
	
	Public WriteOnly Property PerfConfigData() As PerfConfigData		
		Set
			m_perfConfigData = value
		End Set
	End Property
    
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
    	Try
    		ParsedDiag()
    	Catch ex As Exception
    		MessageService.ShowError(ex.Message)
    	End Try        
    End Sub
    
'    Public Sub PopulateLogEventList()
'    	Dim i As Integer
'    	For i = 0  To CheckedListBox1.Items.Count - 1
'    		If(CheckedListBox1.Items.Item(i).'check if the checklistbox(i) was checked
'    			lstEventLogs.Add(CheckedListBox1.CheckedItems(i).ToString())
'    		End If
'    	Next
'    End Sub
    
    
    Public Sub ParsedDiag()
    	
    	Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Dim i As Integer
'        Dim LogEventList As CheckedListBox
'        LogEventList = PopulateLogEventList()
        
        'tom.        g_bUnicodeDiagFiles = IIf(chkUnicode.Value = 0, False, True)
        
        'formLogAnalysisMain.DataGridView1.Rows.Clear()
        Dim logEventsController as New LogEventsController()
        ' if a merged event list exists from a previous button press, release it
'        If (eventsFound IsNot Nothing) Then
'        	eventsFound = Nothing
'        End If
		
        OK_Button.Enabled = False		
        logEventsController.EventsFound = New SignifEvents()
       
        'For i = 0 To CheckedListBox1.Items.Count - 1
        	'If Me.CheckedListBox1.GetItemCheckState(i) = CheckState.Checked and Not Me.CheckedListBox1.GetItemCheckState(i) = CheckState.Indeterminate Then
         For Each eventList As String In m_lstEventLogs 
	    		For Each keyval As KeyValuePair(Of String, FileInfo) In logfileController.DicTraceFile
	    			'If keyval.Key = Me.CheckedListBox1.Items(i).ToString() Then
	    			'If keyval.Key = eventList. Then
	    			If eventList.Equals(keyval.Key) Then
	    				If Not keyval.Value Is Nothing Then
			        		txtLogFile.Text = keyval.Value.Name
			        		lststatus.Items.Add("Processing " + Me.txtLogFile.Text)
			        		System.Windows.Forms.Application.DoEvents()
			                m_nFileSize = keyval.Value.Length
			                m_nBytesRead = 0                ' reset scroll bar byte counter
			                'ProgressBar1.Value = 1
			                logEventsController.ObjTraceEvents = New SignifEvents()
							Subscribe(logEventsController.ObjTraceEvents)
							logEventsController.getEventsFromFile(keyval.Value, m_cFormat(i), m_perfConfigData.DictionaryPath)
		
			                'Me.lststatus.Items.Add("------------------------------------------------------------")
			                me.lststatus.SelectedIndex = me.lststatus.Items.Count -1
			                
	        			End If
	    				Exit For
	    			End If
	    		Next	    				
	    	'End If
        Next        	
        
        OK_Button.Enabled = True
        '    btnSearch.Enabled = True
        txtLogFile.Text = " ** Load Complete **"
        m_eventsFound = logEventsController.EventsFound
        'formLogAnalysisMain.ShowMergedTrace()
        'Me.Hide()

       	Me.Close()
    End Sub

    Private Sub chkJapan_Click()
        '        If (chkUnicode.Value = 0) Then
        '       g_bUnicodeDiagFiles = False
        '       Else
        '       g_bUnicodeDiagFiles = True
        '       End If
    End Sub
    
    Private Sub Dir1_Change()
        ' Indexes 0-4 match the control array indexes
        Dim i As Integer, bFoundOne As Boolean
        bFoundOne = False
        For i = 0 To CheckedListBox1.Items.Count - 1
            bFoundOne = bFoundOne Or EnableLogCheckbox(i)
        Next
        OK_Button.Enabled = bFoundOne
    End Sub
    
    Private Function EnableLogCheckbox(ByVal nCheckBox As Integer) As Boolean
        Dim fso As FileInfo
        fso = New FileInfo(m_perfConfigData.DiagFilesPath + "\" + m_sLogFiles(nCheckBox))
        If (fso.Exists()) Then
            CheckedListBox1.SetItemChecked(nCheckBox, True)
            '           CheckedListBox1.Items(nCheckBox).Enabled = True
            '           CheckedListBox1.Items(nCheckBox).Value = 1
            EnableLogCheckbox = True            
        Else
        	CheckedListBox1.SetItemCheckState(nCheckBox, CheckState.Indeterminate)
        	Dim remVal As String = Me.CheckedListBox1.Items(nCheckBox).ToString()
            Me.lstIndetermined.Add(remVal)
            If CheckList(remVal) Then
            	m_lstEventLogs.Remove(remVal)
            End If
            'CheckedListBox1.Items(nCheckBox).Enabled = False
            'CheckedListBox1.Items(nCheckBox).Value = 0
        End If
    End Function


    Private Sub Drive1_Change()
        '       m_Dir1.Path = Drive1.Drive
    End Sub

    Private Sub FormDiagOpen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    	'Dim i As Integer, j As Integer, k As Integer, s As String, cc As String
    	Dim traceList As String = m_perfConfigData.DictionaryPath + "\LogAnalTraceList.txt"
    	If Not File.Exists(traceList) Then
    		MessageService.ShowError("Cannot find file: " + traceList + Environment.NewLine + "Check if you set the right directory for the dictionary files.", "File not found.")
    		Me.Close()
    	Else
    		LoadFormDiagOpen(New ExtendedStreamReader(New FileStream(traceList, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), System.Text.Encoding.Default))	
    	End If    	
    End Sub
    
    Public Sub LoadFormDiagOpen(tr As IExtendedTextReader)
    	Try
    		Dim di as New DirectoryInfo(m_perfConfigData.DiagFilesPath)
	        Me.txtdiagname.Text = di.Name
	        Me.txtLogFile.Text = ""
	        Me.lststatus.Items.Clear()
	        me.CheckedListBox1.Items.Clear()	    
			logfileController.DiagPath = m_perfConfigData.DiagFilesPath
			logfileController.getTraceList(tr)
			For Each keyval As KeyValuePair(Of String, FileInfo) In logfileController.DicTraceFile
				Me.CheckedListBox1.Items.Add(keyval.Key)
				m_lstEventLogs.Add(keyval.Key)
			Next
			
			'PopulateLogEventList()
			Me.m_cFormat = logfileController.m_cFormat
			me.m_sLogFiles = logfileController.m_sLogFiles
			Dir1_Change()			
    	Catch ex As Exception
    		MessageService.ShowError(ex.Message, "LoadFormDiagOpen")
    	End Try
    	
    End Sub
    
    
    Sub checkedlistbox_selectedindexchanged(sender As Object, e As EventArgs)
    	Dim val As String = Me.CheckedListBox1.SelectedItem.ToString()
    	Dim selectedIndex As Integer = Me.CheckedListBox1.SelectedIndex
    	For Each s As String In Me.lstIndetermined
    		If s.Equals(val) Then
    			Me.CheckedListBox1.SetItemCheckState(Me.CheckedListBox1.SelectedIndex, CheckState.Indeterminate)
'    			If CheckList(s) Then
'    				m_lstEventLogs.Remove(s)
'    			End If
'    				
    			Exit For
    		End If
    	Next    	
		
		OK_Button.Enabled = False
		'For i As Integer = 0 To Me.CheckedListBox1.Items.Count -1
			If Me.CheckedListBox1.GetItemCheckState(selectedIndex) = CheckState.Checked _
				And Not Me.CheckedListBox1.GetItemCheckState(selectedIndex) = CheckState.Indeterminate				
				OK_Button.Enabled = True
				If Not CheckList(CheckedListBox1.Items(selectedIndex).ToString()) Then
					m_lstEventLogs.Add(CheckedListBox1.Items(selectedIndex).ToString())
				End If
				'Exit For
			Else
				If CheckList(val) Then
					'm_lstEventLogs.Remove(val)
					LstEventLogs.Remove(val)
				End If
				If m_lstEventLogs.Count > 0 Then
					OK_Button.Enabled = True
				Else
					OK_Button.Enabled = False
				End if
				'Exit For
			End If
		'Next
		'PopulateLogEventList()
    End Sub
    
    Public Function CheckList(val as String) As Boolean
    	Dim isFound As Boolean = False
    	For Each s As String In LstEventLogs
    		If s.Equals(val) Then
    			isFound = True
    			Exit For
    		End If
    	Next
    	Return isFound
    End Function
    
   
	End Class	
'End Namespace

