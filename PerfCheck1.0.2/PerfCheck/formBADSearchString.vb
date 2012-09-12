Option Strict Off
Option Explicit On
Friend Class formSearchString
    Inherits System.Windows.Forms.Form

    Private gSearchText As String
    Private gSearchOK As Boolean

    Private Sub CancelButton_Renamed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CancelButton_Renamed.Click
        Me.Hide()
    End Sub

    Private Sub frmSearchString_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        gSearchOK = False
    End Sub

    Private Sub OKButton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OKButton.Click
        gSearchText = txtSearchText.Text
        gSearchOK = True
        Me.Hide()
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
End Class