Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System
Imports Microsoft.Win32


Friend Class frmLogAnal
	Inherits System.Windows.Forms.Form
	Const sVERSION As String = "1.0.0"
	'    Const nNUMBER_CHECK_BOXES_ON_FORM As Integer = 12
	Const nFILE_HISTORY_SIZE As Short = 4
	
	
	'    Dim m_sLogFiles(g_nNUMBER_CHECK_BOXES_ON_FORM) As String
	Dim Patterns As PatternNode
	Dim mvar_objMergedTraceEvents As SignifEvents
	'    Dim m_nFileSize As Long, m_nBytesRead As Long
	'    Dim icolor As Long
	Private m_Templates As CTemplates
    '	Dim m_sFileHistory(nFILE_HISTORY_SIZE) As String
	Dim m_bPreviousCheckBoxes(g_nNUMBER_CHECK_BOXES_ON_FORM) As Boolean
	
    '	Public Sub AddToDiagFileHistory(ByRef sFile As String)
    'Dim i, j As Short
    'Dim sNewList(nFILE_HISTORY_SIZE) As String

    '	For i = nFILE_HISTORY_SIZE - 1 To 1 Step -1
    '		m_sFileHistory(i) = m_sFileHistory(i - 1)
    '	Next 
    '	m_sFileHistory(0) = sFile

    '	End Sub

    Public Property MergedTraceEvents() As Object
        Get
            MergedTraceEvents = mvar_objMergedTraceEvents
        End Get
        Set(ByVal Value As Object)
            '    Dim mvar_objMergedTraceEvents As SignifEvents
            mvar_objMergedTraceEvents = Value
        End Set
    End Property

    Private Sub RestoreFromReg()
        '        Dim iRet As Integer
        Dim vValue As Object
        '        Dim i As Short
        '        Dim hKey As Integer
        '        Dim bExists As Boolean
        '        Dim sRegVersion As String

        Const userRoot As String = "HKEY_CURRENT_USER"
        Const subkey As String = "LogAnal\Settings"
        Const keyName As String = userRoot & "\" & subkey

        vValue = Registry.GetValue(keyName, "Version", sVERSION)
        If (sVERSION <> vValue) Then MsgBox("Version File Mismatch")

        g_sDICTIONARY_DIR = Registry.GetValue(keyName, "DictionaryDir", g_sDICTIONARY_DIR)
        g_sINITIAL_DIRECTORY = Registry.GetValue(keyName, "InitialDir", g_sINITIAL_DIRECTORY)


        '		iRet = CreateRegNode(Win.EROOTKEY.HKEY_CURRENT_USER, "Software\NCR\SCOT\CurrentVersion\LogAnal\Settings", hKey, bExists)
        '		If (0 = GetRegValue(hKey, "Version", vValue)) Then
        'UPGRADE_WARNING: Couldn't resolve default property of object vValue. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'If (sVERSION <> vValue) Then MsgBox("Version File Mismatch")
        'End If
        'UPGRADE_WARNING: Couldn't resolve default property of object vValue. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      If (0 = GetRegValue(hKey, "DictionaryDir", vValue)) Then g_sDICTIONARY_DIR = vValue
        'UPGRADE_WARNING: Couldn't resolve default property of object vValue. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '     If (0 = GetRegValue(hKey, "InitialDir", vValue)) Then g_sINITIAL_DIRECTORY = vValue
        '    g_sINITIAL_DIRECTORY = g_sDICTIONARY_DIR
        'UPGRADE_ISSUE: COM expression not supported: Module methods of COM objects. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="5D48BAC6-2CD4-45AD-B1CC-8E4A241CDB58"'
        '    Win.Registry.RegCloseKey(hKey)
        '   iRet = CreateRegNode(Win.EROOTKEY.HKEY_CURRENT_USER, "Software\NCR\SCOT\CurrentVersion\LogAnal\Recent File List", hKey, bExists)
        '  If (bExists) Then
        'For i = 0 To nFILE_HISTORY_SIZE - 1
        'UPGRADE_WARNING: Couldn't resolve default property of object vValue. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ' If (0 = GetRegValue(hKey, "File" & Str(i), vValue)) Then m_sFileHistory(i) = vValue
        'Next
        'UPGRADE_ISSUE: COM expression not supported: Module methods of COM objects. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="5D48BAC6-2CD4-45AD-B1CC-8E4A241CDB58"'
        'Win.Registry.RegCloseKey(hKey)
        'End If
    End Sub

    Private Sub SaveToReg()
        '		Dim hKey, iRet As Integer
        '		Dim bExists As Boolean
        '       Dim i As Short

        Const userRoot As String = "HKEY_CURRENT_USER"
        Const subkey As String = "LogAnal\Settings"
        Const keyName As String = userRoot & "\" & subkey

        Registry.SetValue(keyName, "Version", sVERSION)
        Registry.SetValue(keyName, "DictionaryDir", g_sDICTIONARY_DIR)
        Registry.SetValue(keyName, "InitialDir", g_sINITIAL_DIRECTORY)



        '		iRet = CreateRegNode(Win.EROOTKEY.HKEY_CURRENT_USER, "Software\NCR\SCOT\CurrentVersion\LogAnal\Settings", hKey, bExists)
        'CreateRegValue(sVERSION, hKey, "Version")
        'CreateRegValue(g_sDICTIONARY_DIR, hKey, "DictionaryDir")
        'CreateRegValue(g_sINITIAL_DIRECTORY, hKey, "InitialDir")
        ''UPGRADE_ISSUE: COM expression not supported: Module methods of COM objects. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="5D48BAC6-2CD4-45AD-B1CC-8E4A241CDB58"'
        'Win.Registry.RegCloseKey(hKey)

        '		m_sFileHistory(0) = "This is file 1"
        '		m_sFileHistory(1) = "c:\temp\program files\other shit here\x.crap"
        '		iRet = CreateRegNode(Win.EROOTKEY.HKEY_CURRENT_USER, "Software\NCR\SCOT\CurrentVersion\LogAnal\Recent File List", hKey, bExists)
        '		For i = 0 To nFILE_HISTORY_SIZE - 1
        'If (m_sFileHistory(i) <> "") Then
        'CreateRegValue(m_sFileHistory(i), hKey, "File" & Str(i))
        'End If
        'Next 
        'UPGRADE_ISSUE: COM expression not supported: Module methods of COM objects. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="5D48BAC6-2CD4-45AD-B1CC-8E4A241CDB58"'
        'Win.Registry.RegCloseKey(hKey)
    End Sub



    Public Sub cmdShowMergedTrace_Click()
        Dim i As Short
        ' Forward link the significant event collection
        For i = 1 To mvar_objMergedTraceEvents.Count - 1
            mvar_objMergedTraceEvents(i).objNextState = mvar_objMergedTraceEvents(i + 1)
        Next
        'UPGRADE_NOTE: Object mvar_objMergedTraceEvents().objNextState may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        mvar_objMergedTraceEvents((mvar_objMergedTraceEvents.Count)).objNextState = Nothing

        '       AddToDiagFileHistory(g_sINITIAL_DIRECTORY)
        mvar_objMergedTraceEvents.ListAll((Me.List1))
        '    frmLogAnalDump.Show 0, Me
    End Sub

    Public Sub AllPatterns_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles AllPatterns.Click

        m_Templates = New CTemplates
        m_Templates.Initialize("C:\scot\LogAnal\LogAnal.ini")
        m_Templates.PatternMatch(mvar_objMergedTraceEvents, Me)
        m_Templates.cmdMakeCSVFiles(g_sINITIAL_DIRECTORY & "\" & "AllPatterns", True)
        m_Templates.Report(True, (frmLogAnalSearch.List1))
        VB6.ShowForm(frmLogAnalSearch, 0, Me)
    End Sub


    Public Sub Export_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Export.Click
        Dim n As Integer
        Dim s1, s2 As String

        On Error GoTo NoOutput
        '    Open "c:\scot\bin\LogAnalDump.txt" For Output Access Write As #1
        FileOpen(1, g_sINITIAL_DIRECTORY & "\LogAnalDump.txt", OpenMode.Output, OpenAccess.Write)

        'g_sINITIAL_DIRECTORY
        For n = 1 To List1.Items.Count
            PrintLine(1, VB6.GetItemString(List1, n))
        Next

        FileClose(1)
        '    MsgBox "Created " & "c:\scot\bin\LogAnalDump.txt"
        MsgBox("Created " & g_sINITIAL_DIRECTORY & "\LogAnalDump.txt")
        Exit Sub

NoOutput:
        MsgBox("Failed to export to " & g_sINITIAL_DIRECTORY & "\LogAnalDump.txt")
        '    MsgBox "Failed to export to " & "c:\scot\bin\LogAnalDump.txt"

    End Sub

    Public Sub Find_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Find.Click
        frmSearchString.ShowDialog()
        If (frmSearchString.SearchOK) Then
            do_find((frmSearchString.SearchText))
        End If
    End Sub

    Public Sub FindAgain_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles FindAgain.Click
        do_find((frmSearchString.SearchText))
    End Sub

    Private Sub do_find(ByRef SearchString As String)
        Dim s As String
        Dim n, nStart As Short
        Dim bFound As Boolean
        bFound = False
        nStart = IIf(List1.SelectedIndex > 0, List1.SelectedIndex + 1, 1)
        For n = nStart To List1.Items.Count
            s = VB6.GetItemString(List1, n)
            If (InStr(1, s, SearchString) > 0) Then
                List1.SetSelected(n, True)
                bFound = True
                Exit For
            End If
        Next
        If (Not bFound) Then
            MsgBox("End of File Reached")
        End If
    End Sub
    Private Sub frmLogAnal_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        '    Dim i As Integer, j As Integer, s As String
        '    icolor = &HFF
        g_sDICTIONARY_DIR = "C:\Documents and Settings\te150000\My Documents\Tools\LogAnal\Dictionaries"
        g_sINITIAL_DIRECTORY = g_sDICTIONARY_DIR
        Global_Renamed.g_Kgs = Win.BOOL.APITRUE

        RestoreFromReg()

        '    txtProgFgnd1.Width = 1
        '    ChDir ("c:\scot\LogAnal\")
        '    m_sDICTIONARY_DIR = CurDir("c:\scot\LogAnal\")

        '    Dir1.Path = m_sINITIAL_DIRECTORY
        '    On Error GoTo NoLogList

        '    Open m_sDICTIONARY_DIR + "\LogAnalTraceList.txt" For Input Access Read As 1
        '    i = 0
        '    Do While (i < g_nNUMBER_CHECK_BOXES_ON_FORM) And (Not EOF(1)) ' Loop until end of file.
        '       Line Input #1, s   ' read a line
        '       If (Len(s) > 0) And (Left(s, 1) <> ";") Then
        '            j = InStr(1, s, "=")
        '            If (j >= 0) Then
        '                ChkLogs(i).Caption = Trim(Mid(s, 1, j - 1))
        '                frmSelectDiag.SetLogFiles i, Trim(Mid(s, j + 1))
        '                i = i + 1
        '            End If
        '        End If
        '    Loop
        '    Close #1

        '    Exit Sub

        'NoLogList:
        '    MsgBox "Open Failure on " + m_sDICTIONARY_DIR + "\LogAnalTraceList.txt", vbCritical, "Trace File List Error"
        '    Stop
    End Sub

    Private Sub LoadPatternTree_Click()
        Dim NodeName, s, Residue As String
        On Error GoTo NoPatternFile
        FileOpen(1, g_sDICTIONARY_DIR & "\pattern.tree", OpenMode.Input, OpenAccess.Read)

        Patterns = New PatternNode

        Do While Not EOF(1) ' Loop until end of file.
            s = LineInput(1) ' read a line
            If (Len(s) > 0) And (VB.Left(s, 1) <> ";") Then
                Patterns.NextNodeName(s, NodeName, Residue)
                Patterns.Add(NodeName, 1, Nothing, Residue)
            End If
        Loop
        FileClose(1) ' Close
        Exit Sub

NoPatternFile:
        MsgBox("Open Failure on " & g_sDICTIONARY_DIR & "\pattern.tree", MsgBoxStyle.Critical, "Search Pattern File Error")
        Stop
    End Sub

    'Private Sub btnSearch_Click()

    'End Sub

    Private Sub frmLogAnal_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        SaveToReg()
    End Sub

    Public Sub KgsToLbs_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles KgsToLbs.Click
        Global_Renamed.g_Kgs = Win.BOOL.APITRUE
    End Sub

    Public Sub ListingClockControl_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ListingClockControl.Click
        frmListClkCtrl.ShowDialog()
    End Sub

    Public Sub mnuHideDuplicates_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuHideDuplicates.Click
        g_bSupressDuplicates = False
        If (Me.mnuHideDuplicates.Checked = True) Then
            g_bSupressDuplicates = True
        End If
    End Sub

    Public Sub OpenDiagFile_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OpenDiagFile.Click
        VB6.ShowForm(frmSelectDiag, VB6.FormShowConstants.Modal, Me)
        '   cmdShowDump_Click
    End Sub

    Public Sub Options_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Options.Click
        VB6.ShowForm(frmOptions, VB6.FormShowConstants.Modal, Me)
    End Sub

    Public Sub SearchForPatterns_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SearchForPatterns.Click
        Dim i As Short
        Dim pNode As PatternNode
        Dim bRestart As Boolean
        LoadPatternTree_Click()
        bRestart = True
        ' reset stats from any previous run
        Patterns.ClearStats()

        While (Patterns.Search(mvar_objMergedTraceEvents, bRestart, (frmLogAnalSearch.List1)))
            bRestart = False
        End While
        Patterns.Report(True, (frmLogAnalSearch.List1))
        VB6.ShowForm(frmLogAnalSearch, 0, Me)
    End Sub
End Class