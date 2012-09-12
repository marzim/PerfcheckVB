Option Strict Off
Option Explicit On

Imports Microsoft.Win32
Imports System.Threading
Imports System.Windows.Forms

'Namespace PerfCheck
Public Class formListClkCtrl
    Inherits System.Windows.Forms.Form

	Dim lstClk As New List(Of String)
	Private m_loadListingClock As Thread
	Private m_checkAllOnLoadState As CheckState
'	Private m_resetClock As Boolean = False
'	
'	Public ReadOnly Property ResetClock() As Boolean
'		Get
'			Return m_resetClock
'		End Get
'	End Property
	Private m_checkAllOnLastState As CheckState
	
    Private Sub CancelButton_Renamed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CancelButton_Renamed.Click
    	DialogResult = DialogResult.Cancel
    	Me.Close()
    End Sub
    
    Public Sub LoadFrmListClkCtrl()
    	
    	Dim i, j As Integer
        List1.Items.Clear()
        For i = 0 To g_nTotalNameCount - 1
            'determine insert location
            Dim bAdded As Boolean = False
            Dim nOriginalItemCount As Integer = List1.Items.Count()
            For j = 0 To nOriginalItemCount - 1
                If (List1.Items(j).ToString > gStateNames(i + 1)) Then
                    List1.Items.Insert(j, gStateNames(i + 1))
                    bAdded = True
                    Exit For
                End If
            Next
            If (Not bAdded) Then List1.Items.Add(gStateNames(i + 1))
            '            List1.Items.Insert(i, gStateNames(i + 1))
            ' end of experiment...

        Next
        Array.Resize(g_nTimeResetIndexes,List1.Items.Count) 'resize the array g_ng_nTimeResetIndexes with the current number of listing clock events
        Dim statename As String, statecode As Integer, listidx As Integer
        For j = 0 To g_nTimeResetEvents - 1
            statecode = g_nTimeResetIndexes(j)
            statename = StateCode2Name(statecode)
            listidx = List1.Items.IndexOf(statename)
            List1.SetItemChecked(listidx, True)
            
        Next
		GetLstClock()
		SetListClockEventsFromReg()
		m_checkAllOnLoadState = chkAll.CheckState
		
    End Sub
    	
    Private Sub frmListClkCtrl_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Me.LoadFrmListClkCtrl()
    End Sub
    
    Public Sub ResetListingClockEvents()
    	Dim i As Integer, statecode As Integer
        g_nTimeResetEvents = 0
        me.lstClk = new List(Of String)
        For i = 0 To List1.Items.Count - 1
            If (List1.GetItemChecked(i)) Then
                statecode = StateName2Code(List1.Items(i).ToString(), False)  'store code of state
                g_nTimeResetIndexes(g_nTimeResetEvents) = statecode
                g_nTimeResetEvents = g_nTimeResetEvents + 1
                me.lstClk.Add(List1.Items(i).ToString())
            End If
        Next
        Me.SetLstClock()
'		m_loadListingClock = New Thread(AddressOf showProgress)
'		m_loadListingClock.Start()		
'		m_loadListingClock.Abort()
		'm_resetClock = True
		Me.Close()
    End Sub
    
    Private Sub OKButton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OKButton.Click
		DialogResult = DialogResult.OK
		ResetListingClockEvents()
		
    End Sub
    
    Sub GetLstClock()
    	Dim vValue as String = ""
    	Const userRoot As String = "HKEY_CURRENT_USER"
        Const subkey As String = "LogAnal\Settings"
        Const keyName As String = userRoot & "\" & subkey

        vValue = Registry.GetValue(keyName, "LstClock", vValue)
        For Each s As String In vValue.Split(",")
        	me.lstClk.Add(s)
        Next
    End Sub
    
    Sub SetListClockEventsFromReg()
    	Dim i As Integer = 0
    	Dim ctr As Integer = 0
    	For Each s As String In Me.lstClk
    		for i = 0 to Me.List1.Items.Count -1
    			If s.Equals(me.List1.Items(i).ToString()) Then
    				Me.List1.SetItemChecked(i, True)
    				'ctr = ctr + 1
    			End If
    		Next
    	Next
    	'If(ctr = List1.Items.Count) Then
    		'chkAll.CheckState = CheckState.Checked
    	'End If
    	
    End Sub
    
    Sub SetLstClock()
    	Dim vValue as String = ""
    	For Each s As String In Me.lstClk
    		If vValue.Length > 0 Then
    			vValue += "," + s
    		Else
    			vValue = s
    		End If
    	Next
    	
    	Const userRoot As String = "HKEY_CURRENT_USER"
        Const subkey As String = "LogAnal\Settings"
        Const keyName As String = userRoot & "\" & subkey

    	Registry.SetValue(keyName, "LstClock", vValue)
    End Sub
    
'    Private Sub showProgress()
'		formProgress.showDialog()
'	End Sub
    
    Sub List1SelectedIndexChanged(sender As Object, e As EventArgs)
    	If(chkAll.CheckState = CheckState.Checked) Then
    		chkAll.CheckState = CheckState.Indeterminate
    	Else 
    		If chkAll.CheckState = CheckState.Indeterminate Then
    		
	    		Dim checkCounter As Integer = 0
	    		Dim i As Integer
	    		
	    		For i = 0 To Me.List1.Items.Count - 1 
	    			If(Me.List1.GetItemChecked(i) = True) Then
	    				checkCounter = checkCounter + 1
	    			End If
	    		Next
	    		If(checkCounter = Me.List1.Items.Count) Then
	    			chkAll.CheckState = CheckState.Checked
	    		ElseIf checkCounter = 0 Then
	    			chkAll.CheckState = CheckState.Unchecked
	    		Else
	    			chkAll.Checked = CheckState.Indeterminate
	    		End If
	    		
	    	End If	
    			
    	End If
    	'm_checkAllOnLastState = chkAll.CheckState
    End Sub
    
    Sub CheckBox1CheckedChanged(sender As Object, e As EventArgs)
    	If chkAll.Checked = True Then
    		CheckAllListingClock()
    	Else
    		UnCheckAllListingClock()
		End If
    End Sub
    
    Sub CheckAllListingClock()
    	Dim i as Integer = 0
    	For i = 0 To Me.List1.Items.Count -1
    		Me.List1.SetItemChecked(i,True)
    	Next
    End Sub
    
    Sub UnCheckAllListingClock()
    	Dim i as Integer = 0
    	For i = 0 To Me.List1.Items.Count -1
    		Me.List1.SetItemChecked(i,False)
    	Next
    End Sub
    
    Public Function LoadLastState() As CheckState
    	Return  m_checkAllOnLoadState
    End Function
    
    Sub CancelButton_RenamedClick(sender As Object, e As EventArgs)
	   chkAll.CheckState = LoadLastState()
    End Sub
    
End Class
'End Namespace