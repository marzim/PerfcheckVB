'Namespace PerfCheck
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _	
Partial Class formListClkCtrl
#Region "Windows Form Designer generated code "
    <System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
        If Disposing Then
            If Not components Is Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents List1 As System.Windows.Forms.CheckedListBox
    Public WithEvents CancelButton_Renamed As System.Windows.Forms.Button
    Public WithEvents OKButton As System.Windows.Forms.Button
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    	Me.components = New System.ComponentModel.Container()
    	Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    	Me.List1 = New System.Windows.Forms.CheckedListBox()
    	Me.CancelButton_Renamed = New System.Windows.Forms.Button()
    	Me.OKButton = New System.Windows.Forms.Button()
    	Me.chkAll = New System.Windows.Forms.CheckBox()
    	Me.SuspendLayout
    	'
    	'List1
    	'
    	Me.List1.BackColor = System.Drawing.SystemColors.Window
    	Me.List1.CheckOnClick = true
    	Me.List1.Cursor = System.Windows.Forms.Cursors.Default
    	Me.List1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    	Me.List1.ForeColor = System.Drawing.SystemColors.WindowText
    	Me.List1.Location = New System.Drawing.Point(8, 6)
    	Me.List1.Name = "List1"
    	Me.List1.RightToLeft = System.Windows.Forms.RightToLeft.No
    	Me.List1.Size = New System.Drawing.Size(193, 109)
    	Me.List1.TabIndex = 2
    	AddHandler Me.List1.SelectedIndexChanged, AddressOf Me.List1SelectedIndexChanged
    	'
    	'CancelButton_Renamed
    	'
    	Me.CancelButton_Renamed.BackColor = System.Drawing.SystemColors.Control
    	Me.CancelButton_Renamed.Cursor = System.Windows.Forms.Cursors.Default
    	Me.CancelButton_Renamed.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    	Me.CancelButton_Renamed.ForeColor = System.Drawing.SystemColors.ControlText
    	Me.CancelButton_Renamed.Location = New System.Drawing.Point(120, 151)
    	Me.CancelButton_Renamed.Name = "CancelButton_Renamed"
    	Me.CancelButton_Renamed.RightToLeft = System.Windows.Forms.RightToLeft.No
    	Me.CancelButton_Renamed.Size = New System.Drawing.Size(81, 18)
    	Me.CancelButton_Renamed.TabIndex = 1
    	Me.CancelButton_Renamed.Text = "Cancel"
    	Me.CancelButton_Renamed.UseVisualStyleBackColor = false
    	AddHandler Me.CancelButton_Renamed.Click, AddressOf Me.CancelButton_RenamedClick
    	'
    	'OKButton
    	'
    	Me.OKButton.BackColor = System.Drawing.SystemColors.Control
    	Me.OKButton.Cursor = System.Windows.Forms.Cursors.Default
    	Me.OKButton.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    	Me.OKButton.ForeColor = System.Drawing.SystemColors.ControlText
    	Me.OKButton.Location = New System.Drawing.Point(8, 151)
    	Me.OKButton.Name = "OKButton"
    	Me.OKButton.RightToLeft = System.Windows.Forms.RightToLeft.No
    	Me.OKButton.Size = New System.Drawing.Size(81, 18)
    	Me.OKButton.TabIndex = 0
    	Me.OKButton.Text = "OK"
    	Me.OKButton.UseVisualStyleBackColor = false
    	'
    	'chkAll
    	'
    	Me.chkAll.Location = New System.Drawing.Point(8, 129)
    	Me.chkAll.Name = "chkAll"
    	Me.chkAll.Size = New System.Drawing.Size(89, 14)
    	Me.chkAll.TabIndex = 3
    	Me.chkAll.Text = "Check All"
    	Me.chkAll.UseVisualStyleBackColor = true
    	AddHandler Me.chkAll.CheckedChanged, AddressOf Me.CheckBox1CheckedChanged
    	'
    	'formListClkCtrl
    	'
    	Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 14!)
    	Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    	Me.BackColor = System.Drawing.SystemColors.Control
    	Me.ClientSize = New System.Drawing.Size(207, 190)
    	Me.Controls.Add(Me.chkAll)
    	Me.Controls.Add(Me.List1)
    	Me.Controls.Add(Me.CancelButton_Renamed)
    	Me.Controls.Add(Me.OKButton)
    	Me.Cursor = System.Windows.Forms.Cursors.Default
    	Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    	Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    	Me.Location = New System.Drawing.Point(184, 250)
    	Me.MaximizeBox = false
    	Me.MinimizeBox = false
    	Me.Name = "formListClkCtrl"
    	Me.RightToLeft = System.Windows.Forms.RightToLeft.No
    	Me.ShowInTaskbar = false
    	Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    	Me.Text = "Listing Clock Reset Events"
    	Me.ResumeLayout(false)
    End Sub
    Public chkAll As System.Windows.Forms.CheckBox
#End Region
End Class
'End Namespace