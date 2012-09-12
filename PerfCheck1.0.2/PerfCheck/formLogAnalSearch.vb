Option Strict Off
Option Explicit On
'Namespace PerfCheck
Public Class formLogAnalSearch
    Inherits System.Windows.Forms.Form
    
    Private _frm As formMeasurementDetail
    
    Dim eventsFound As New SignifEvents()
    Dim logeventssummary As New LogEventsSummary()
    Dim perfConfigData As PerfConfigData
    Dim ctemplates As CTemplates
    Public Sub New(_eventsFound As SignifEvents, _ls As LogEventsSummary, _ 
    	_pCD As PerfConfigData, _ct As CTemplates)
    	eventsFound = _eventsFound
    	logeventssummary = _ls
    	perfConfigData = _pCD
    	ctemplates = _ct
    	
    	InitializeComponent()
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
    	loadMeasurementDetails(sender)
    End Sub    
    
    Public Sub loadMeasurementDetails(sender As Object)
    	If eventsFound Is Nothing Then
    		Throw New ArgumentNullException("loadMeasurementDetails")
    	End If
    	
    	Try
    		Dim dg As DataGridView, sMeasure As String, nRow As Integer, r(5) As String
	        
	        dg = sender
	        If (dg.CurrentCell.Value = "") Then
	        	MessageService.ShowWarning("Double click measurement row to see details")
	        	
	        Else
	            nRow = dg.CurrentCellAddress.Y
	            sMeasure = dg.Item(0, nRow).Value
	            Dim objPattern As CPattern = ctemplates.Patterns.Item(sMeasure)	            		    
	            
	            _frm = New formMeasurementDetail()		        
	            _frm.Cpattern = objPattern
	            _frm.SMeasure = sMeasure
	            _frm.DiagPath = perfConfigData.DiagFilesPath
	            _frm.EventsFound = eventsFound
	            _frm.LoadMeasurementDetails()
	            Subscribe(_frm)
		        _frm.Show()
		        _frm.Focus()
	        End If
    	Catch ex As Exception
    		MessageService.ShowWarning(ex.Message,"Warning in DataGridview1 CellDoubleClick")    		
    	End Try
        
    End Sub
    
    Sub FormLogAnalSearchLoad(sender As Object, e As EventArgs)
    	Me.Text += "    (" + perfConfigData.DiagFilesPath + ")"
    	populateAllSearchGrid()
    End Sub
    
    Public Sub populateAllSearchGrid()
    	For Each logeventsummary As LogEventSummary In logeventssummary.GetEvents()    		    		
    		DataGridView1.Rows.Add(logeventsummary.Values)
    		ColorThreadsHold(logeventsummary)
    	Next    	    	
    End Sub
    
    Private Sub ColorThreadsHold(ByVal logeventsummary As LogEventSummary)
    	Dim cnt As Integer = 0
    	For cnt = 0 To logeventsummary.Flag.Count - 1
    		If logeventsummary.Flag.Item(cnt) > 0 And logeventsummary.Flag.Item(cnt) < 1000 Then    				
				If logeventsummary.Flag.Item(cnt) = 1 Then
					DataGridView1.Item(logeventsummary.Col.Item(cnt), DataGridView1.Rows.Count -1).Style.BackColor = Color.Yellow
				Else 
					DataGridView1.Item(logeventsummary.Col.Item(cnt), DataGridView1.Rows.Count -1).Style.BackColor = Color.PaleVioletRed
				End If	    			
    		End If			
    		If logeventsummary.Flag.Item(cnt) = 1000 Then
    			DataGridView1.Item(0, DataGridView1.Rows.Count -1).Style.ForeColor = Color.Red
    		End If
    	Next   	
    End Sub
    
    Public Sub Subscribe(fmd As formMeasurementDetail)
		AddHandler fmd.selectMDetail, New formMeasurementDetail.MeasurementDetailEventHandler(AddressOf SelectEventRow)
    End Sub
    
    Public Sub RemoveSubscription(fmd As formMeasurementDetail)
    	RemoveHandler fmd.selectMDetail, New formMeasurementDetail.MeasurementDetailEventHandler(AddressOf SelectEventRow)
    End Sub
    
    Public Sub SelectEventRow(sender As Object, e As MeasurementDetailEventArgs)    	
    	[RaiseEvent](Me, New MeasurementDetailEventArgs(e.Index))
    End Sub
    
    Public Delegate Sub MeasurementDetailEventHandler(sender As Object, e As MeasurementDetailEventArgs)
    
	Public Event selectMDetail As MeasurementDetailEventHandler

	Protected Sub [RaiseEvent](sender As Object, e As MeasurementDetailEventArgs)
		RaiseEvent selectMDetail(sender, e)					
	End Sub			
    
    Sub formClosing_Event(sender As Object, e As FormClosingEventArgs)    	
    	If _frm IsNot Nothing Then
    		RemoveSubscription(_frm)	
    	End If    	
    End Sub
End Class
'End Namespace