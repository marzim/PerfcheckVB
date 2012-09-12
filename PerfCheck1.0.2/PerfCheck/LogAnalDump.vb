Option Strict Off
Option Explicit On
Friend Class frmLogAnalDump
	Inherits System.Windows.Forms.Form
	
	'UPGRADE_WARNING: Event frmLogAnalDump.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub frmLogAnalDump_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		List1.Height = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Me.Height) - 500)
		List1.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.Width) - 200)
	End Sub
End Class