'Namespace PerfCheck
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _	
Partial Class FormDiagOpen
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
    	Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
    	Me.OK_Button = New System.Windows.Forms.Button()
    	Me.Cancel_Button = New System.Windows.Forms.Button()
    	Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
    	Me.txtLogFile = New System.Windows.Forms.TextBox()
    	Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    	Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
    	Me.lststatus = New System.Windows.Forms.ListBox()
    	Me.txtdiagname = New System.Windows.Forms.TextBox()
    	Me.groupBox2 = New System.Windows.Forms.GroupBox()
    	Me.TableLayoutPanel1.SuspendLayout
    	Me.GroupBox1.SuspendLayout
    	Me.groupBox2.SuspendLayout
    	Me.SuspendLayout
    	'
    	'TableLayoutPanel1
    	'
    	Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
    	Me.TableLayoutPanel1.ColumnCount = 2
    	Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50!))
    	Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50!))
    	Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
    	Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
    	Me.TableLayoutPanel1.Location = New System.Drawing.Point(277, 274)
    	Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
    	Me.TableLayoutPanel1.RowCount = 1
    	Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50!))
    	Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
    	Me.TableLayoutPanel1.TabIndex = 0
    	'
    	'OK_Button
    	'
    	Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
    	Me.OK_Button.Location = New System.Drawing.Point(3, 3)
    	Me.OK_Button.Name = "OK_Button"
    	Me.OK_Button.Size = New System.Drawing.Size(67, 23)
    	Me.OK_Button.TabIndex = 0
    	Me.OK_Button.Text = "OK"
    	'
    	'Cancel_Button
    	'
    	Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
    	Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
    	Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
    	Me.Cancel_Button.Name = "Cancel_Button"
    	Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
    	Me.Cancel_Button.TabIndex = 1
    	Me.Cancel_Button.Text = "Cancel"
    	'
    	'ProgressBar1
    	'
    	Me.ProgressBar1.Location = New System.Drawing.Point(6, 262)
    	Me.ProgressBar1.Name = "ProgressBar1"
    	Me.ProgressBar1.Size = New System.Drawing.Size(234, 23)
    	Me.ProgressBar1.TabIndex = 2
    	'
    	'txtLogFile
    	'
    	Me.txtLogFile.Location = New System.Drawing.Point(6, 239)
    	Me.txtLogFile.Name = "txtLogFile"
    	Me.txtLogFile.Size = New System.Drawing.Size(234, 20)
    	Me.txtLogFile.TabIndex = 3
    	'
    	'GroupBox1
    	'
    	Me.GroupBox1.Controls.Add(Me.CheckedListBox1)
    	Me.GroupBox1.Location = New System.Drawing.Point(271, 12)
    	Me.GroupBox1.Name = "GroupBox1"
    	Me.GroupBox1.Size = New System.Drawing.Size(151, 246)
    	Me.GroupBox1.TabIndex = 5
    	Me.GroupBox1.TabStop = false
    	Me.GroupBox1.Text = "Log Files To Merge"

    	'
    	'CheckedListBox1
    	'
    	Me.CheckedListBox1.CheckOnClick = true
    	Me.CheckedListBox1.FormattingEnabled = true
    	Me.CheckedListBox1.Location = New System.Drawing.Point(9, 19)
    	Me.CheckedListBox1.Name = "CheckedListBox1"
    	Me.CheckedListBox1.Size = New System.Drawing.Size(136, 214)
    	Me.CheckedListBox1.TabIndex = 6
    	AddHandler Me.CheckedListBox1.SelectedIndexChanged, AddressOf Me.checkedlistbox_selectedindexchanged
    	'
    	'lststatus
    	'
    	Me.lststatus.FormattingEnabled = true
    	Me.lststatus.Location = New System.Drawing.Point(6, 47)
    	Me.lststatus.Name = "lststatus"
    	Me.lststatus.Size = New System.Drawing.Size(234, 173)
    	Me.lststatus.TabIndex = 6
    	'
    	'txtdiagname
    	'
    	Me.txtdiagname.Location = New System.Drawing.Point(6, 9)
    	Me.txtdiagname.Multiline = true
    	Me.txtdiagname.Name = "txtdiagname"
    	Me.txtdiagname.Size = New System.Drawing.Size(234, 26)
    	Me.txtdiagname.TabIndex = 7
    	'
    	'groupBox2
    	'
    	Me.groupBox2.Controls.Add(Me.lststatus)
    	Me.groupBox2.Controls.Add(Me.txtdiagname)
    	Me.groupBox2.Controls.Add(Me.ProgressBar1)
    	Me.groupBox2.Controls.Add(Me.txtLogFile)
    	Me.groupBox2.Location = New System.Drawing.Point(2, 15)
    	Me.groupBox2.Name = "groupBox2"
    	Me.groupBox2.Size = New System.Drawing.Size(253, 288)
    	Me.groupBox2.TabIndex = 8
    	Me.groupBox2.TabStop = false
    	'
    	'FormDiagOpen
    	'
    	Me.AcceptButton = Me.OK_Button
    	Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
    	Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    	Me.CancelButton = Me.Cancel_Button
    	Me.ClientSize = New System.Drawing.Size(435, 315)
    	Me.Controls.Add(Me.groupBox2)
    	Me.Controls.Add(Me.GroupBox1)
    	Me.Controls.Add(Me.TableLayoutPanel1)
    	Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    	Me.MaximizeBox = false
    	Me.MinimizeBox = false
    	Me.Name = "FormDiagOpen"
    	Me.ShowInTaskbar = false
    	Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    	Me.Text = "FormDiagOpen"
    	Me.TableLayoutPanel1.ResumeLayout(false)
    	Me.GroupBox1.ResumeLayout(false)
    	Me.groupBox2.ResumeLayout(false)
    	Me.groupBox2.PerformLayout
    	Me.ResumeLayout(false)
    End Sub
    Private groupBox2 As System.Windows.Forms.GroupBox
    Private txtdiagname As System.Windows.Forms.TextBox
    Public lststatus As System.Windows.Forms.ListBox
    Public WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Public WithEvents OK_Button As System.Windows.Forms.Button
    Public WithEvents Cancel_Button As System.Windows.Forms.Button
    Public WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Public WithEvents txtLogFile As System.Windows.Forms.TextBox
    Public WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox

End Class
'End Namespace