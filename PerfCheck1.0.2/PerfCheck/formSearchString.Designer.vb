'Namespace PerfCheck
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _	
Partial Class formSearchString
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    	Me.Label1 = New System.Windows.Forms.Label()
    	Me.txtSearchText = New System.Windows.Forms.TextBox()
    	Me.OKButton = New System.Windows.Forms.Button()
    	Me.MyCancelButton = New System.Windows.Forms.Button()
    	Me.SuspendLayout
    	'
    	'Label1
    	'
    	Me.Label1.AutoSize = true
    	Me.Label1.Location = New System.Drawing.Point(27, 30)
    	Me.Label1.Name = "Label1"
    	Me.Label1.Size = New System.Drawing.Size(71, 13)
    	Me.Label1.TabIndex = 0
    	Me.Label1.Text = "Search String"
    	'
    	'txtSearchText
    	'
    	Me.txtSearchText.Location = New System.Drawing.Point(116, 27)
    	Me.txtSearchText.Name = "txtSearchText"
    	Me.txtSearchText.Size = New System.Drawing.Size(165, 20)
    	Me.txtSearchText.TabIndex = 1
    	Me.txtSearchText.Text = "*"
    	AddHandler Me.txtSearchText.KeyDown, AddressOf Me.txtsearch_keydown
    	'
    	'OKButton
    	'
    	Me.OKButton.Location = New System.Drawing.Point(133, 68)
    	Me.OKButton.Name = "OKButton"
    	Me.OKButton.Size = New System.Drawing.Size(74, 26)
    	Me.OKButton.TabIndex = 2
    	Me.OKButton.Text = "OK"
    	Me.OKButton.UseVisualStyleBackColor = true
    	'
    	'MyCancelButton
    	'
    	Me.MyCancelButton.Location = New System.Drawing.Point(213, 68)
    	Me.MyCancelButton.Name = "MyCancelButton"
    	Me.MyCancelButton.Size = New System.Drawing.Size(68, 26)
    	Me.MyCancelButton.TabIndex = 3
    	Me.MyCancelButton.Text = "Cancel"
    	Me.MyCancelButton.UseVisualStyleBackColor = true
    	'
    	'formSearchString
    	'
    	Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
    	Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    	Me.ClientSize = New System.Drawing.Size(300, 115)
    	Me.Controls.Add(Me.MyCancelButton)
    	Me.Controls.Add(Me.OKButton)
    	Me.Controls.Add(Me.txtSearchText)
    	Me.Controls.Add(Me.Label1)
    	Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    	Me.MaximizeBox = false
    	Me.MinimizeBox = false
    	Me.Name = "formSearchString"
    	Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    	Me.Text = "Enter Search String"
    	Me.ResumeLayout(false)
    	Me.PerformLayout
    End Sub
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents txtSearchText As System.Windows.Forms.TextBox
    Public WithEvents OKButton As System.Windows.Forms.Button
    Public WithEvents MyCancelButton As System.Windows.Forms.Button

End Class
'End  Namespace