Imports System.Windows.Forms
'Namespace PerfCheck
Public Class formMeasurementDetail
	
	Private m_cpattern As CPattern
	
	Public WriteOnly Property Cpattern() As CPattern	
		Set
			m_cpattern = value
		End Set
	End Property
	
	Dim m_eventsFound As New SignifEvents()
	
	Public WriteOnly Property EventsFound() As SignifEvents
		Set
			m_eventsFound = value
		End Set
	End Property
	
	Private m_diagPath As String
	
	Public WriteOnly Property DiagPath() As String
		Set
			m_diagPath = value
		End Set
	End Property
	
	Private m_sMeasure As String
	
	Public WriteOnly Property SMeasure() As String
		Set
			m_sMeasure = value
		End Set
	End Property
	
	Private Sub dgMeasureDetails_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMeasureDetails.CellDoubleClick             
		Dim dg As DataGridView = sender
        If (dg.CurrentCell.Value = "") Then
        	MessageService.ShowWarning("Double click measurement row to see details")        	
        Else
            [RaiseEvent](Me, New MeasurementDetailEventArgs(dg.CurrentRow.Cells(4).Value  ))            
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.Close()
    End Sub    
  
    Sub FormMeasurementDetailLoad(sender As Object, e As EventArgs)
    	 
    End Sub
    
    Public Sub LoadMeasurementDetails()
    	reportMeasureTextBox.Text = m_sMeasure
		eventPatternTextBox.Text = m_cpattern.StateList
		exclusionEventsTextBox.Text = m_cpattern.ExclusionList
		Dim objPointer As CPatternPointer
		Dim objEvent As SignifEvent
		Dim r(5) As String
		Me.Text += "     " + m_diagPath
		dgMeasureDetails.Rows.Clear()
        If (Not m_cpattern Is Nothing) Then
            For Each objPointer In m_cpattern.PatternPointers
                objEvent = m_eventsFound(objPointer.CollectionIndex)
				
                r(0) = objEvent.TimeOfDay_Renamed
                r(1) = objEvent.TimeMs
                r(2) = objEvent.LineNo	                    
                r(3) = objPointer.TimeMs        'duration
                r(4) = objPointer.CollectionIndex
                dgMeasureDetails.Rows.Add(r)
                
                If objPointer.TimeMs > m_cpattern.DAvgLoLim And objPointer.TimeMs < m_cpattern.DAvgHiLim Then
                	dgMeasureDetails.Item(3,dgMeasureDetails.Rows.Count-1).Style.BackColor = Color.Yellow
                Else If objPointer.TimeMs > m_cpattern.DAvgHiLim Then
                	dgMeasureDetails.Item(3,dgMeasureDetails.Rows.Count-1).Style.BackColor = Color.PaleVioletRed
                End If
            Next
        End If
    End Sub    
    
    Public Delegate Sub MeasurementDetailEventHandler(sender As Object, e As MeasurementDetailEventArgs)
    
	Public Event selectMDetail As MeasurementDetailEventHandler

	Protected Sub [RaiseEvent](sender As Object, e As MeasurementDetailEventArgs)
		RaiseEvent selectMDetail(sender, e)					
	End Sub		    
End Class
'End Namespace