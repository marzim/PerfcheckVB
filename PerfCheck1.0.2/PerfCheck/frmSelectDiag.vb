Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmSelectDiag
	Inherits System.Windows.Forms.Form
	
	Dim m_nFileSize, m_nBytesRead As Integer
	Dim m_sLogFiles(g_nNUMBER_CHECK_BOXES_ON_FORM) As String
	Dim m_cFormat(g_nNUMBER_CHECK_BOXES_ON_FORM) As String
	Dim m_sINITIAL_DIRECTORY As String
	
	Public Sub SetLogFiles(ByRef i As Short, ByRef s As String)
		m_sLogFiles(i) = s
	End Sub
	
	Public Function GetLogFiles(ByRef i As Short) As String
		GetLogFiles = m_sLogFiles(i)
	End Function
	
	Public Sub SetProgressBarLimit(ByRef n As Integer)
		m_nFileSize = n
	End Sub
	
	Public Sub UpdateProgressgBar(ByRef nBytes As Integer)
		If ((nBytes - m_nBytesRead) / m_nFileSize >= 0.02) Then
			txtProgFgnd1.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(txtProgBkg1.Width) * (nBytes / m_nFileSize))
			'If (nBytes > ProgressBar1. .Max) Then nBytes = ProgressBar1.Max
			'ProgressBar1.Value = nBytes
			m_nBytesRead = nBytes
			System.Windows.Forms.Application.DoEvents()
		End If
	End Sub
	
	Private Sub btnParseLogFiles_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnParseLogFiles.Click
		Dim objTraceEvents, objTempTraceEvents As SignifEvents
        'Dim objFile As Scripting.File
        'Dim fso As New Scripting.FileSystemObject
        Dim objfile, fso        'tom.
        objfile = CreateObject("Scripting.File")
        fso = CreateObject("Scripting.FileSystemObject")

		Dim i As Short
		
		g_bUnicodeDiagFiles = IIf(chkUnicode.CheckState = 0, False, True)
		frmLogAnal.List1.Items.Clear()
		' if a merged event list exists from a previous button press, release it
		'UPGRADE_NOTE: Object frmLogAnal.MergedTraceEvents may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		If (Not frmLogAnal.MergedTraceEvents Is Nothing) Then frmLogAnal.MergedTraceEvents = Nothing
		'if( not mvar_objMergedTraceEvents Is Nothing) Then Set mvar_objMergedTraceEvents = Nothing
		btnParseLogFiles.Enabled = False
		
		For i = 0 To g_nNUMBER_CHECK_BOXES_ON_FORM - 1
			If (ChkLogs(i).CheckState) Then
				txtLogFile.Text = Me.GetLogFiles(i)
				System.Windows.Forms.Application.DoEvents()
				objFile = fso.GetFile(Dir1.Path & "\" & Me.GetLogFiles(i))
				'            m_nFileSize = objFile.Size
				'            m_nBytesRead = 0                ' reset scroll bar byte counter
				'            txtProgFgnd1.Width = 1
				
				objTraceEvents = New SignifEvents
				objTraceEvents.DictionaryFileName = g_sDICTIONARY_DIR & "\" & Mid(Me.GetLogFiles(i), 1, InStr(1, Me.GetLogFiles(i), ".")) & "dictionary"
				objTraceEvents.SourceFileName = Dir1.Path & "\" & Me.GetLogFiles(i)
				objTraceEvents.ParentForm = Me
				'            objTraceEvents.ParseEvents Me.chkJapan.Value
				objTraceEvents.ParseEvents(g_bUnicodeDiagFiles, m_cFormat(i))
				
				If (objTraceEvents.Count > 0) Then
					
					If (frmLogAnal.MergedTraceEvents Is Nothing) Then
						frmLogAnal.MergedTraceEvents = objTraceEvents
					Else
						objTempTraceEvents = frmLogAnal.MergedTraceEvents
						frmLogAnal.MergedTraceEvents = New SignifEvents
						'UPGRADE_WARNING: Couldn't resolve default property of object frmLogAnal.MergedTraceEvents.Merge. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						frmLogAnal.MergedTraceEvents.Merge(objTempTraceEvents, objTraceEvents)
					End If
				End If
				'UPGRADE_NOTE: Object objTraceEvents may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				objTraceEvents = Nothing 'free both; keep merged only
				'UPGRADE_NOTE: Object objTempTraceEvents may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				objTempTraceEvents = Nothing 'free it.
			End If
		Next 
		
		btnParseLogFiles.Enabled = True
		'    btnSearch.Enabled = True
		txtLogFile.Text = " ** Load Complete **"
		g_sINITIAL_DIRECTORY = m_sINITIAL_DIRECTORY
		frmLogAnal.cmdShowMergedTrace_Click()
		Me.Hide()
	End Sub
	
	
	Private Sub chkJapan_Click()
		If (chkUnicode.CheckState = 0) Then
			g_bUnicodeDiagFiles = False
		Else
			g_bUnicodeDiagFiles = True
		End If
	End Sub
	
	Private Sub CancelButton_Renamed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CancelButton_Renamed.Click
		Me.Close()
	End Sub
	
	Private Sub Dir1_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Dir1.Change
		' Indexes 0-4 match the control array indexes
		Dim i As Short
		Dim bFoundOne As Boolean
		bFoundOne = False
		For i = 0 To g_nNUMBER_CHECK_BOXES_ON_FORM - 1
			bFoundOne = bFoundOne Or EnableLogCheckbox(i)
		Next 
		m_sINITIAL_DIRECTORY = Dir1.Path
		btnParseLogFiles.Enabled = bFoundOne
	End Sub
	Private Function EnableLogCheckbox(ByRef nCheckBox As Short) As Boolean
        ' Dim fso As New Scripting.FileSystemObject
        Dim fso     'tom.
        fso = CreateObject("Scripting.FileSystemObject")

		Dim i As Object
		If (fso.FileExists(Dir1.Path & "\" & m_sLogFiles(nCheckBox))) Then
			ChkLogs(nCheckBox).Enabled = True
			ChkLogs(nCheckBox).CheckState = System.Windows.Forms.CheckState.Checked
			EnableLogCheckbox = True
		Else
			ChkLogs(nCheckBox).Enabled = False
			ChkLogs(nCheckBox).CheckState = System.Windows.Forms.CheckState.Unchecked
		End If
	End Function
	
	
	Private Sub Drive1_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Drive1.SelectedIndexChanged
		Dir1.Path = Drive1.Drive
	End Sub
	
	Private Sub frmSelectDiag_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim j, i, k As Short
		Dim s, cc As String
		
		txtProgFgnd1.Width = VB6.TwipsToPixelsX(1)
		chkUnicode.CheckState = IIf(g_bUnicodeDiagFiles = True, 1, 0)
		'    ChDir ("c:\scot\LogAnal\")
		'    m_sDICTIONARY_DIR = CurDir("c:\scot\LogAnal\")
		
		'    m_sINITIAL_DIRECTORY = m_sDICTIONARY_DIR
		'    m_sINITIAL_DIRECTORY = "C:\Dev\atga.sase.sacomp_1\DpsCid\TestApps\LogAnal\"
		On Error GoTo NoLogList
		
		FileOpen(1, g_sDICTIONARY_DIR & "\LogAnalTraceList.txt", OpenMode.Input, OpenAccess.Read)
		i = 0
		Do While (i < g_nNUMBER_CHECK_BOXES_ON_FORM) And (Not EOF(1)) ' Loop until end of file.
			s = LineInput(1) ' read a line
			If (Len(s) > 0) And (VB.Left(s, 1) <> ";") Then
				j = InStr(1, s, "=")
				If (j >= 0) Then
					ChkLogs(i).Text = Trim(Mid(s, 1, j - 1))
					k = InStr(j, s, ",")
					If (k > 0) Then
						' there is a unicode/ascii tag to parse
						
						m_sLogFiles(i) = Trim(Mid(s, j + 1, k - j - 1))
						cc = UCase(Trim(Mid(s, k + 1)))
						m_cFormat(i) = VB.Left(cc, 1)
					Else
						m_sLogFiles(i) = Trim(Mid(s, j + 1))
					End If
					i = i + 1
				End If
			End If
		Loop 
		FileClose(1)
		m_sINITIAL_DIRECTORY = g_sINITIAL_DIRECTORY
		Dir1.Path = m_sINITIAL_DIRECTORY
		Exit Sub
		
NoLogList: 
		MsgBox("Open Failure on " & g_sDICTIONARY_DIR & "\LogAnalTraceList.txt", MsgBoxStyle.Critical, "Trace File List Error")
		Stop
	End Sub
End Class