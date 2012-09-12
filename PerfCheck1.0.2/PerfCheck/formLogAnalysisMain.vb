Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System
Imports Microsoft.Win32
Imports System.Threading
Imports System.Text.RegularExpressions
Imports System.IO


'Namespace PerfCheck
Public Class formLogAnalysisMain
	
	Declare Function AllocConsole Lib "kernel32" () As Integer
    Const sVERSION As String = "1.0.0"
    Const nFILE_HISTORY_SIZE = 4
    Dim Patterns As PatternNode
    'Dim mvar_objMergedTraceEvents As SignifEvents
    Private m_Templates As CTemplates
    
	Public ReadOnly Property Templates() As CTemplates
		Get
			Return m_Templates
		End Get
	End Property
	
    Dim m_bPreviousCheckBoxes(g_MAX_LOG_FILES) As Boolean
    Private m_tHideDuplicates As Thread
    Private m_KgsToLbs As Thread
    Dim lst_SearchItems As List(Of String) = new List(Of String)
    Dim currSearchIndex As Integer = 0
    Dim aboutTheTool As New AboutTheTool()
    Public FolderBrowserDialog1 As New FolderBrowserDialog()
    Dim m_sFullFileName As String
    Dim m_logEventsForExport As LogEvents
    Dim m_perfConfigData As New PerfConfigData()
    
	Public WriteOnly Property PerfConfigData() As PerfConfigData		
		Set
			m_perfConfigData = value
		End Set
	End Property	    
	Dim m_parserEValues As New Dictionary(Of String, String)
	
	Public ReadOnly Property ParserEValues() As Dictionary(Of String, String)
		Get
			Return m_parserEValues
		End Get
	End Property
    
    Private Sub formLogAnalysisMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LoadMain()
    End Sub
    
    Public Sub LoadMain()
    	
    	InitPerfConfig()
    	
		If my.Application.CommandLineArgs.Count > 0 Then
			MessageService.Attach(New ConsoleMessageProvider())
			If Convert.ToBoolean(AllocConsole()) Then
			CommandLine.Run(my.Application.CommandLineArgs, _ 
		  		New ExtendedStreamReader(New FileStream(m_perfConfigData.DictionaryPath + "\LogAnalTraceList.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite), System.Text.Encoding.Default), _
		  		New ExtendedStreamReader(New FileStream(Application.StartupPath + "\unziplist.lst", FileMode.Open, FileAccess.Read, FileShare.ReadWrite),System.Text.Encoding.Default), m_perfConfigData)	
			End If		  	
        Else
        	MessageService.Attach(New MessageBoxMessageProvider())
        End If    	
    End Sub
    
    Public Function GetADTFlag() As String
    	Dim vValue As String = ""
    	Dim flag As String
    	Const userRoot As String = "HKEY_CURRENT_USER"
        Const subkey As String = "LogAnal\Settings"
        Const keyName As String = userRoot & "\" & subkey
        flag = Registry.GetValue(keyName,"AutoDetectTemplate",vValue).ToString()
        If flag = "" Then
        	flag = ""
        End If
        Return flag
        	
    End Function    	
    
    Public Sub ResizeForm()
    	Me.Width = SystemInformation.VirtualScreen.Width / 2
    	Me.Height = SystemInformation.VirtualScreen.Height / 2
    	
    End Sub
    
    Public Sub InitPerfConfig()    	
    	'ResizeForm()
    	m_perfConfigData.Kgs = True
    	If m_perfConfigData.Kgs Then
    	KgsToLbsToolStripMenuItem.Checked = True
    	End If
        If Not RestoreFromReg() Then
        	m_perfConfigData.DictionaryPath = Application.StartupPath + "\config\TescoUK-NCR40"
        	m_perfConfigData.DiagFilesPath = Application.StartupPath
        End If
        
        ParsedEventValues(m_perfConfigData.DictionaryPath)
        
        Me.autoDetectTemplatesToolStripMenuItem.Checked = m_perfConfigData.AutoDetectTemplate
        If m_perfConfigData.AutoDetectTemplate Then
        	Me.TemplateDirectoryToolStripMenuItem.Enabled = False
        Else
        	Me.TemplateDirectoryToolStripMenuItem.Enabled = True
        End If
    End Sub
    
    Public Sub ParsedEventValues(dictionaryPath As String)
    	Dim filepath As String = dictionaryPath + "\EventValues.dictionary"
    	Try    		
    		Dim PEValues As New ParserEventValues()
    		m_parserEValues = PEValues.Parsed(New ExtendedStreamReader(New FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), System.Text.Encoding.Default))
    	Catch ex As FileNotFoundException
    		MessageService.ShowError("File not found: " + filepath)
    	End Try    	
    End Sub
    
    Private Sub ListingClockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListingClockToolStripMenuItem.Click
    	Dim listClock As New formListClkCtrl()
    	If listClock.ShowDialog() = DialogResult.OK Then
			ShowMergedTrace(m_eventsFound)
    	End If
    End Sub
    
    Public Sub OpenDiagFile(fbd As FolderBrowserDialog)
    	'Dim FolderBrowserDialog1 As New FolderBrowserDialog
        fbd.Description = "Select a folder of an extracted diag file"
        fbd.SelectedPath = m_perfConfigData.DiagFilesPath
        fbd.ShowNewFolderButton = False

        If fbd.ShowDialog() = DialogResult.OK Then
            'MessageBox.Show("You selected: " + FolderBrowserDialog1.SelectedPath)
            m_perfConfigData.DiagFilesPath = fbd.SelectedPath
            System.IO.Directory.SetCurrentDirectory(m_perfConfigData.DiagFilesPath)
	            If autoDetectTemplatesToolStripMenuItem.CheckState = CheckState.Checked Then
		            If AutoDetectTemplate(m_perfConfigData.DiagFilesPath) Then
		            	  formDiagOpen()  
		            End If
	            Else
	            	formDiagOpen()
	            End If
        End If
    	
    End Sub
    
    Public Sub formDiagOpen()
    	 SaveToReg()
		 Dim formDiagOpen As New FormDiagOpen()
		 formDiagOpen.PerfConfigData = m_perfConfigData
		 formDiagOpen.ShowDialog()
		            
		 m_eventsFound = formDiagOpen.EventsFound            
		 If m_eventsFound IsNot Nothing Then
		 	If m_eventsFound.Count > 0 Then
			 	If Not Regex.IsMatch(Me.Text, Regex.Escape("    (" + m_perfConfigData.DiagFilesPath + ")"), RegexOptions.IgnoreCase) Then
				    Me.Text = "SSCO Log File Analysis Utility"
				    me.Text += "    (" + m_perfConfigData.DiagFilesPath + ")"
			 	End If
		 	End If
		 End If 
		 
		 CheckForListingClockEvents()
		 ShowMergedTrace(m_eventsFound)
		 
    End Sub
    
    Public Sub CheckForListingClockEvents()
    	 Dim lClock As New formListClkCtrl()
		 lClock.LoadFrmListClkCtrl() 'load the listing clock events 
		 
		 If lClock.List1.CheckedItems.Count > 0 Then
			 lClock.ResetListingClockEvents() 'reset
		 End If
    End Sub
    
    Private Sub OpenDiagFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenDiagFileToolStripMenuItem.Click
        OpenDiagFile(Me.FolderBrowserDialog1)	
    End Sub
    
    Dim m_eventsFound As SignifEvents
	
	Public Property EventsFound() As SignifEvents
		Get
			Return m_eventsFound
		End Get
		Set
			m_eventsFound = value
		End Set
	End Property
	
	Public Function RestoreFromReg() as Boolean
        Dim vValue As Object		
        'Const subkey As String = "LogAnal\Settings"
        
        RegistryHelper.Attach(New RegistryManager)
        Dim rkey As RegistryKey = RegistryHelper.Exists(m_perfConfigData.Subkey, Registry.CurrentUser)
        If rkey IsNot Nothing Then
        	vValue = RegistryHelper.GetValue("Version", rkey, "")
        	If m_perfConfigData.CurrentVersion <> vValue Then
        		MessageService.ShowWarning("Version File Mismatch","Warning in RestoreFromReg()")        		
        	End If
        	
        	m_perfConfigData.DictionaryPath = RegistryHelper.GetValue("DictionaryDir", rkey, "")
        	m_perfConfigData.DiagFilesPath = RegistryHelper.GetValue("InitialDir", rkey, "")
        	
        	If Not GetADTFlag() = "" Then
        		m_perfConfigData.AutoDetectTemplate = CBool(GetADTFlag())
	    	Else
	    		m_perfConfigData.AutoDetectTemplate = True
	    	End If
        	SaveAutoDetectToReg(m_perfConfigData.AutoDetectTemplate)
        	Return True
        End If
        Return False
    End Function

	Public Sub SaveToReg()                        
        Dim rkey As RegistryKey = Registry.CurrentUser.CreateSubKey(m_perfConfigData.Subkey, RegistryKeyPermissionCheck.ReadWriteSubTree)        
        rkey.SetValue("Version", m_perfConfigData.CurrentVersion)
        rkey.SetValue("DictionaryDir", m_perfConfigData.DictionaryPath)
        rkey.SetValue("InitialDir", m_perfConfigData.DiagFilesPath)
        rkey.SetValue("AutoDetectTemplate",m_perfConfigData.AutoDetectTemplate)
    End Sub
        
    Public Sub InitializeNextState(byval mergedEvents As SignifEvents)
       	Dim i As Long
       	If (mergedEvents IsNot Nothing) Then
       		If mergedEvents.Count > 0 Then
       			For i = 1 To mergedEvents.Count - 1
	            	mergedEvents(i).objNextState = mergedEvents(i + 1)
	            	mergedEvents(i).CollectionIndex = i            	
	        	Next
	        	'UPGRADE_NOTE: Object mvar_objMergedTraceEvents().objNextState may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
	        	mergedEvents(mergedEvents.Count).objNextState = Nothing		
       		End If        	
        End If
	End Sub        
    
    Public Sub ShowMergedTrace(eventsFound As SignifEvents)
    	If eventsFound IsNot Nothing Then
    		If eventsFound.Count > 0 Then
    			InitializeNextState(eventsFound)
	        	Me.addEventsToDataGridView()
	        	
	        	If (Me.DataGridView1.Rows.Count > 0) Then
	        		me.ListingClockToolStripMenuItem.Enabled=True
	        		me.AllPatternsToolStripMenuItem.Enabled=True
	        		Me.HideDuplicatesToolStripMenuItem.Enabled=True
	        		Me.KgsToLbsToolStripMenuItem.Enabled=True
	        	Else
	        		Me.AllPatternsToolStripMenuItem.Enabled=False
	        		me.ListingClockToolStripMenuItem.Enabled=False
	        		Me.HideDuplicatesToolStripMenuItem.Enabled=False
	        		Me.KgsToLbsToolStripMenuItem.Enabled=False        		
	        		MessageService.ShowInfo("No events found thus no data to display.","No events found")
	        	End If	
	        Else
        		MessageService.ShowInfo("No events found thus no data to display.","No events found")
    		End If       
        End If        
    End Sub
    
    
    Public Sub addEventsToDataGridView()    	
    	Dim logevents As New LogEvents()
    	m_eventsFound.DicEventValues = m_parserEValues
    	logevents = m_eventsFound.ListAllEvents(m_perfConfigData.Kgs)    	
    	m_logEventsForExport = logevents
    	Me.DataGridView1.Rows.Clear()    
    	Dim eFound As List(Of LogEvent) = logevents.GetEvents()
    	Dim cnt As Integer = 0
    	For Each logevent As LogEvent In eFound
    		If logevent.Data <> Nothing Then
    			If logevent.Data.Equals("empty row") Then
    				Me.DataGridView1.Rows.Add("")	
    				Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count -1).DefaultCellStyle.BackColor = Color.LightGray
    			End If    		   			   			
    		Else
    			Dim data(8) As String
				data(0) = logevent.RelTime.ToString()
				data(1) = logevent.Datetime
	            data(2) = logevent.Millisec.ToString()
	            data(3) = logevent.Source
	            data(4) = logevent.Lineno.ToString()
	            data(5) = logevent.Events
	            data(6) = logevent.Data
	            data(7) = logevent.ColIndex.ToString()
	            data(8) = logevent.RawEvent
	            Me.DataGridView1.Rows.Add(data)		
	            cnt+=1
    		End If   		    		
    	Next   	
    	Me.toolStripStatusLabel1.Text = String.Format("{0:n0}", cnt) + " events found..."
    End Sub
    
    Dim frmlogAnalSearch As formLogAnalSearch
    
    Public Function AllPatterns() As LogEventsSummary 
    	m_Templates = New CTemplates
        'm_Templates.Initialize(g_sDICTIONARY_DIR & "\LogAnal.ini")
        m_Templates.Initialize(New ExtendedStreamReader(New FileStream(m_perfConfigData.DictionaryPath & "\LogAnal.ini",FileMode.Open,FileAccess.Read,FileShare.ReadWrite),System.Text.Encoding.Default))
        
        m_Templates.PatternMatch(m_eventsFound, Me)
        Dim di2 As New DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\PerfCheck\reports")
        If Not di2.Exists Then
        	di2.Create()
        End If
        
        m_Templates.cmdMakeCSVFiles(di2.FullName & "\AllPatterns", True)
        m_Templates.AddPerfMeasuresData(m_Templates.TotalPatterns, m_Templates.Patterns)

        Return m_Templates.Report()
        
    End Function      
    
    
    Private Sub AllPatternsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllPatternsToolStripMenuItem.Click
    	If frmlogAnalSearch IsNot Nothing Then
    		frmlogAnalSearch.Close()
    	End If
    	frmlogAnalSearch = New formLogAnalSearch(m_eventsFound, AllPatterns(), m_perfConfigData, m_Templates)	            	    	
    	Subscribe(frmlogAnalSearch)
    	frmlogAnalSearch.Show()	    
    End Sub    
    

    Private Sub ExportMergeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportMergeToolStripMenuItem.Click
        ExportMergeEvents(m_perfConfigData.DiagFilesPath, m_eventsFound)
    End Sub
    
    Public Sub ExportMergeEvents(diagDir As String, allEventsFound As SignifEvents)    	
    	If allEventsFound Is Nothing Then
    		MessageService.ShowWarning("There is no data to be exported")
        	return
    	End If    
    	allEventsFound.DicEventValues = Me.ParserEValues()
    	Dim logEvents As LogEvents = allEventsFound.ListAllEvents()
        if logEvents.GetEvents().Count <= 0 Then
        	MessageService.ShowWarning("There is no data to be exported")
        	return
        End If
        Dim efc As New ExportFileController()
        efc.AllMergedEvents(diagDir, logEvents)        
        

    End Sub

    Private Sub FindToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindToolStripMenuItem.Click
        formSearchString.ShowDialog()
        If (formSearchString.SearchOK) Then
            do_find(formSearchString.SearchText)
        End If
    End Sub
    
    Public Function do_find(ByRef SearchString As String, Optional nextFind as Boolean = False) As Boolean
    Dim bFound As Boolean
    Dim row As Integer
    Dim col as Integer
    	Try
        	
        	bFound = False        	
        	
        	If Not nextFind Then
        		Me.getSearchItems(SearchString)
        		currSearchIndex = getSearchStartingPoint()        		
        	End If
        
        	If Me.lst_SearchItems.Count > 0 And me.currSearchIndex < me.lst_SearchItems.Count Then
        		row = Integer.Parse(Me.lst_SearchItems.Item(currSearchIndex).Split(",")(0))
	        	col = Integer.Parse(me.lst_SearchItems.Item(currSearchIndex).Split(",")(1))
	        	Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(row).Cells(col)
	        	Me.DataGridView1.Focus()
	        	bFound = True
        	Else
	        	bFound = False
        	End If
        
        	If (Not bFound) Then
           	MessageService.ShowWarning("End of File Reached")
        	End If
        Catch ex As Exception
        	MessageService.ShowError(ex.Message, "Error in " + Me.GetType().Name + ":" + System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
     Return bFound 
        
    End Function
    
    
    Private Sub getSearchItems(SearchString as String)
    	Dim counter As Integer, counter2 As Integer
    	lst_SearchItems = new List(Of String)
    	For counter = 0 To Me.DataGridView1.Rows.Count -1
        	For counter2 = 0 To Me.DataGridView1.Columns.Count -2
        		If Me.DataGridView1.Rows(counter).Cells(counter2).Value <> Nothing Then
        			If Me.DataGridView1.Rows(counter).Cells(counter2).Value.ToString().ToLower().Contains(SearchString.ToLower()) Then
        				'Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(counter).Cells(counter2)
 						'Me.DataGridView1.Focus()
 						lst_SearchItems.Add(counter.ToString() +","+ counter2.ToString())
        			End If
        		End If
        	Next
        Next
    End Sub
    
    Private Function getSearchStartingPoint()
    	
    	'PRECONDITION 1: The string to find should be found at least once
    	If lst_SearchItems.Count.Equals(0) Then
    		Return 0
    	End If
    	
    	'PRECONDITION 2: Current index selected should not be beyond the last search item
    	If Me.DataGridView1.CurrentRow.Index > Integer.Parse(Me.lst_SearchItems.Item(Me.lst_SearchItems.Count-1).Split(",")(0)) Then
    		Return Me.lst_SearchItems.Count + 1
    	End If
    	    	
    	'PROCESS 1: Traverse search list and find the search index nearest the current selected row
    	Dim counter As Integer, nRowValSearchList As Integer, nCurrentSelectedRow = Me.DataGridView1.CurrentRow.Index
    	
    	For counter = 0 To Me.DataGridView1.Rows.Count -1
    		If counter >= Me.lst_SearchItems.Count Then
    			return 0
    		End If
    		
    		Dim s As String() = Me.lst_SearchItems.Item(counter).Split(",")
    		
    		If s.Length > 0 Then
    			nRowValSearchList = Integer.Parse(s(0))
	    		If nRowValSearchList > nCurrentSelectedRow Then
	    			Exit For
	 			End If
    		End If
    		
    	Next
    	
    	return counter
    	
    End Function

    Private Sub TemplateDirectoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TemplateDirectoryToolStripMenuItem.Click
        Dim FolderBrowserDialog1 As New FolderBrowserDialog
        FolderBrowserDialog1.Description = "Select a Template Directory"
        FolderBrowserDialog1.SelectedPath = m_perfConfigData.DictionaryPath
        FolderBrowserDialog1.ShowNewFolderButton = False

        If (FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            MessageService.ShowInfo("Template Directory now: " + FolderBrowserDialog1.SelectedPath, "Current Template Directory")
            m_perfConfigData.DictionaryPath = FolderBrowserDialog1.SelectedPath
            Me.SaveToReg()
        End If
        
    End Sub

    Sub FindAgainToolStripMenuItemClick(sender As Object, e As EventArgs)
    	currSearchIndex = getSearchStartingPoint()
    	Me.do_find("", True)
    End Sub
    
    Public Sub KgsToLbs()
    	setKgsToLbs()
'    	m_tHideDuplicates = New Thread(AddressOf showProgress)
'    	m_tHideDuplicates.Start()
    	me.DataGridView1.Rows.Clear()
    	Me.ShowMergedTrace(m_eventsFound)
'    	m_tHideDuplicates.Abort()
    	
    End Sub
    
    Public Sub setKgsToLbs()
    	If Me.KgsToLbsToolStripMenuItem.Checked Then
    		Me.KgsToLbsToolStripMenuItem.Checked = False
    		m_perfConfigData.Kgs = False
    	Else
    		Me.KgsToLbsToolStripMenuItem.Checked = True
    		m_perfConfigData.Kgs = True
    	End If
    End Sub
    
    Sub KgsToLbsToolStripMenuItemClick(sender As Object, e As EventArgs)
    	KgsToLbs()
    End Sub
    
    Public Sub HideDuplicates()
	    	setHideDuplicates()
'	    	m_tHideDuplicates = New Thread(AddressOf showProgress)
'	    	m_tHideDuplicates.Start()
	    	me.DataGridView1.Rows.Clear()
	    	Me.ShowMergedTrace(m_eventsFound)
'	    	m_tHideDuplicates.Abort()
    End Sub
    
    Public Sub setHideDuplicates()
    	If Me.HideDuplicatesToolStripMenuItem.Checked Then
    		Me.HideDuplicatesToolStripMenuItem.Checked = False
    		g_bSupressDuplicates = False
    	Else
    		Me.HideDuplicatesToolStripMenuItem.Checked = True
    		g_bSupressDuplicates = True
    	End If
    End Sub
    
    Sub HideDuplicatesToolStripMenuItemClick(sender As Object, e As EventArgs)
    	HideDuplicates()    	
    End Sub
  
'	Private Sub showProgress()
'		formProgress.ShowDialog()
'	End Sub
	
    Sub ExportsummaryreportClick(sender As Object, e As EventArgs)
    	ExportSummaryReportToCSV(m_perfConfigData.DictionaryPath, m_perfConfigData.DiagFilesPath, m_eventsFound)
        'me.ExportSummaryReportToCSV(g_sDICTIONARY_DIR, g_sINITIAL_DIRECTORY)
    End Sub
    
    'Public Sub ExportSummaryReportToCSV(dictionaryPath As String, diagPath As String, eventsCount As Integer)
    Public Sub ExportSummaryReportToCSV(dictionaryPath As String, diagPath As String, eventsFound As SignifEvents)
    	If eventsFound Is Nothing Then
        	MessageService.ShowWarning("There is no data to be exported")
        	return
    	End If
    	If eventsFound.Count <= 0 Then
    		MessageService.ShowWarning("There is no data to be exported")
        	return	    	
    	End If
    	Dim efc As New ExportFileController()
	    efc.SummaryReport(dictionaryPath, diagPath, eventsFound)		
    	
    	
    End Sub
    
    Public Sub CopyToolStripMenuItemClick(sender As Object, e As EventArgs)
    	Try
	    	Dim data As new System.Text.StringBuilder()
	    	Dim i as Integer
	    	
    		Dim j As Integer = Me.DataGridView1.SelectedRows.Count
			Do Until j = 0
				j -= 1
				For i = 0 To Me.DataGridView1.Columns.Count -3
		    		If i > 0 Then
		    			If Me.DataGridView1.SelectedRows.Item(j).Cells(i).Value <> Nothing Then
		    				data.Append(", " + Me.DataGridView1.SelectedRows.Item(j).Cells(i).Value)
		    			End If
		    		Else
		    			data.Append(Me.DataGridView1.SelectedRows.Item(j).Cells(i).Value)
		    		End If
	    		Next
    			data.Append(Environment.NewLine)
			Loop
	    	
	    	Clipboard.SetDataObject(data.ToString())
	    	
    	Catch ex As Exception
    		MessageService.ShowWarning("There is no data to be copied","No Data")
    	End Try
    	
    End Sub
    
    Sub AboutToolStripMenuItemClick(sender As Object, e As EventArgs)
    	aboutTheTool.ShowDialog()
    End Sub
    
    Public Sub Subscribe(fls As formLogAnalSearch)
		AddHandler fls.selectMDetail, New formLogAnalSearch.MeasurementDetailEventHandler(AddressOf SelectEventRow)
    End Sub
    
    Public Sub RemoveSubscription(fls As formLogAnalSearch)
		RemoveHandler fls.selectMDetail, New formLogAnalSearch.MeasurementDetailEventHandler(AddressOf SelectEventRow)
	End Sub
	
	Public Sub SelectEventRow(sender As Object, e As MeasurementDetailEventArgs)
		Dim cnt As Integer = 0
		For cnt = 0 To DataGridView1.Rows.Count -1
			If Me.DataGridView1.Rows(cnt).Cells(7).Value IsNot Nothing Then 
				If Me.DataGridView1.Rows(cnt).Cells(7).Value.ToString().Equals(e.Index.ToString()) Then
					Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(cnt).Cells(0)
	        		Me.DataGridView1.Focus()	
				End If				
			End If
		Next
	End Sub    
    
    Sub datagridView_doubleclickEvent(sender As Object, e As DataGridViewCellEventArgs)    	
    	Dim data As String = DataGridView1.SelectedRows(0).Cells(1).Value.ToString() + DataGridView1.SelectedRows(0).Cells(2).Value.ToString() + "`" + DataGridView1.SelectedRows(0).Cells(8).Value.ToString()    	    	
    	Dim lfc As New LogFileForm(data, m_perfConfigData)
    	lfc.Show()    	    	
    End Sub
    
    Public Function AutoDetectTemplate(diagPath As String) As Boolean
	    Dim systermInfoController As New SysTermInfoController()
	    Dim systermInfo As New SysTermInfo()
	    Dim isFound As Boolean = False
	    Dim adkVersion As String
	    'Dim traceList As String
	    Dim dirPath As String
	    Dim tempPath As String = m_perfConfigData.DictionaryPath
	    Dim tracelist As String = tempPath + "\LogAnalTraceList.txt" 
	    
	    If File.Exists(tracelist) Then
	    
		    Dim indexToSplit As Integer = tempPath.IndexOf("\config")
		    dirPath = tempPath.Substring(0,indexToSplit) + "\config"
	    
		    If File.Exists(diagPath + "\SummaryInfo.dat") Then
		    	
		    
		    	systermInfoController.getSystemInfo(New ExtendedStreamReader(New FileStream(diagPath + "\SummaryInfo.dat",FileMode.Open,FileAccess.Read, FileShare.ReadWrite), System.Text.Encoding.Default),systermInfo)
	
			    If Directory.Exists(dirPath) Then
			    	Try
			    		For Each foldername As String In Directory.GetDirectories(dirPath)	
			    			traceList = foldername + "\LogAnalTraceList.txt"
			    			adkVersion = systermInfoController.getTemplateADKVersion(New ExtendedStreamReader(New FileStream(traceList,FileMode.Open,FileAccess.Read,FileShare.ReadWrite), System.Text.Encoding.Default))
			    			If systermInfo.Adk.Equals(adkVersion) Then
			    				m_perfConfigData.DictionaryPath = foldername
			    				isFound = True
			    			   	Exit For
			    			End If
			    		Next
			    	Catch ex As Exception
			    		MessageService.ShowError(ex.ToString())
			    	End Try
			    	
			    	If Not isFound Then
			    		MessageService.ShowWarning("ADK is not supported. Please choose a template to use.")
			    		m_perfConfigData.AutoDetectTemplate = False
			    		autoDetectTemplatesToolStripMenuItem.Checked = m_perfConfigData.AutoDetectTemplate
			    		TemplateDirectoryToolStripMenuItem.Enabled = True
			    		TemplateDirectoryToolStripMenuItem.PerformClick()
			    	End If
			    	
			    Else
			    	MessageService.ShowError("Could not find location : " + dirPath,"Error in " + Me.GetType().Name + ":" + System.Reflection.MethodBase.GetCurrentMethod.Name) 
			    End If
		    
		    	
		    Else
		    	MessageService.ShowError("Could not find SummaryInfo.dat " + "at " + diagPath,"Error in " + Me.GetType().Name + ":" + System.Reflection.MethodBase.GetCurrentMethod.Name)
		    End If
	    Else
	    		MessageService.ShowError("Cannot find file: " + tracelist + Environment.NewLine + "Check if you set the right directory for the dictionary files.", "File not found.")
            	m_perfConfigData.AutoDetectTemplate = False
            	autoDetectTemplatesToolStripMenuItem.Checked = m_perfConfigData.AutoDetectTemplate
            	TemplateDirectoryToolStripMenuItem.Enabled = True
            	SaveAutoDetectToReg(m_perfConfigData.AutoDetectTemplate)
		End If
	    	Return isFound
    End Function
    
    Sub AutoDetectTemplatesToolStripMenuItemClick(sender As Object, e As EventArgs)   
    	
    	If Me.autoDetectTemplatesToolStripMenuItem.Checked Then
    		Me.autoDetectTemplatesToolStripMenuItem.Checked = False
    		TemplateDirectoryToolStripMenuItem.Enabled = True
    		m_perfConfigData.AutoDetectTemplate = False
    	Else
    		Me.autoDetectTemplatesToolStripMenuItem.Checked = True
    		TemplateDirectoryToolStripMenuItem.Enabled = False
    		m_perfConfigData.AutoDetectTemplate = True
    	End If
		SaveAutoDetectToReg(m_perfConfigData.AutoDetectTemplate)
    End Sub
    
    Public Sub SaveAutoDetectToReg(flag As Boolean)
    	Dim rkey As RegistryKey = Registry.CurrentUser.CreateSubKey(m_perfConfigData.Subkey, RegistryKeyPermissionCheck.ReadWriteSubTree)
    	rkey.SetValue("AutoDetectTemplate",flag)
    End Sub
End Class	

'End Namespace