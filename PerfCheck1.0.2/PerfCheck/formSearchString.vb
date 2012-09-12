Option Strict Off
Option Explicit On
'Namespace PerfCheck
Public Class formSearchString
    Inherits System.Windows.Forms.Form

    Private gSearchText As String
    Private gSearchOK As Boolean


    Private Sub formSearchString_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        gSearchOK = False
        me.txtSearchText.SelectAll()
        me.txtSearchText.Focus()
    End Sub

    Public ReadOnly Property SearchText() As String
        Get
            SearchText = gSearchText
        End Get
    End Property

    Public ReadOnly Property SearchOK() As Boolean
        Get
            SearchOK = gSearchOK
        End Get
    End Property

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        gSearchText = txtSearchText.Text
        gSearchOK = True
        Me.Hide()

    End Sub

    Private Sub CancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyCancelButton.Click
        Me.Hide()

    End Sub  
    
    
    Sub txtsearch_keydown(sender As Object, e As KeyEventArgs)
    	If e.KeyCode = Keys.Enter Then
    		me.OKButton_Click(Nothing, Nothing)
    	End If
    	
    	If e.KeyCode = Keys.Escape Then
    		me.Close()
    	End If
    End Sub
End Class
'End Namespace