<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmSelectDiag
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
	Public WithEvents txtProgFgnd1 As System.Windows.Forms.TextBox
	Public WithEvents Drive1 As Microsoft.VisualBasic.Compatibility.VB6.DriveListBox
	Public WithEvents Dir1 As Microsoft.VisualBasic.Compatibility.VB6.DirListBox
	Public WithEvents btnParseLogFiles As System.Windows.Forms.Button
	Public WithEvents _ChkLogs_0 As System.Windows.Forms.CheckBox
	Public WithEvents _ChkLogs_1 As System.Windows.Forms.CheckBox
	Public WithEvents _ChkLogs_2 As System.Windows.Forms.CheckBox
	Public WithEvents _ChkLogs_3 As System.Windows.Forms.CheckBox
	Public WithEvents _ChkLogs_4 As System.Windows.Forms.CheckBox
	Public WithEvents _ChkLogs_5 As System.Windows.Forms.CheckBox
	Public WithEvents _ChkLogs_7 As System.Windows.Forms.CheckBox
	Public WithEvents _ChkLogs_6 As System.Windows.Forms.CheckBox
	Public WithEvents _ChkLogs_8 As System.Windows.Forms.CheckBox
	Public WithEvents _ChkLogs_9 As System.Windows.Forms.CheckBox
	Public WithEvents _ChkLogs_10 As System.Windows.Forms.CheckBox
	Public WithEvents _ChkLogs_11 As System.Windows.Forms.CheckBox
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents txtLogFile As System.Windows.Forms.TextBox
	Public WithEvents txtProgBkg1 As System.Windows.Forms.TextBox
	Public WithEvents chkUnicode As System.Windows.Forms.CheckBox
	Public WithEvents CancelButton_Renamed As System.Windows.Forms.Button
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents ChkLogs As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSelectDiag))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.txtProgFgnd1 = New System.Windows.Forms.TextBox
		Me.Drive1 = New Microsoft.VisualBasic.Compatibility.VB6.DriveListBox
		Me.Dir1 = New Microsoft.VisualBasic.Compatibility.VB6.DirListBox
		Me.btnParseLogFiles = New System.Windows.Forms.Button
		Me.Frame1 = New System.Windows.Forms.GroupBox
		Me._ChkLogs_0 = New System.Windows.Forms.CheckBox
		Me._ChkLogs_1 = New System.Windows.Forms.CheckBox
		Me._ChkLogs_2 = New System.Windows.Forms.CheckBox
		Me._ChkLogs_3 = New System.Windows.Forms.CheckBox
		Me._ChkLogs_4 = New System.Windows.Forms.CheckBox
		Me._ChkLogs_5 = New System.Windows.Forms.CheckBox
		Me._ChkLogs_7 = New System.Windows.Forms.CheckBox
		Me._ChkLogs_6 = New System.Windows.Forms.CheckBox
		Me._ChkLogs_8 = New System.Windows.Forms.CheckBox
		Me._ChkLogs_9 = New System.Windows.Forms.CheckBox
		Me._ChkLogs_10 = New System.Windows.Forms.CheckBox
		Me._ChkLogs_11 = New System.Windows.Forms.CheckBox
		Me.txtLogFile = New System.Windows.Forms.TextBox
		Me.txtProgBkg1 = New System.Windows.Forms.TextBox
		Me.chkUnicode = New System.Windows.Forms.CheckBox
		Me.CancelButton_Renamed = New System.Windows.Forms.Button
		Me.Label1 = New System.Windows.Forms.Label
		Me.ChkLogs = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(components)
		Me.Frame1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.ChkLogs, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Specify a Diag Directory"
		Me.ClientSize = New System.Drawing.Size(402, 363)
		Me.Location = New System.Drawing.Point(184, 250)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmSelectDiag"
		Me.txtProgFgnd1.AutoSize = False
		Me.txtProgFgnd1.BackColor = System.Drawing.Color.FromARGB(255, 128, 0)
		Me.txtProgFgnd1.Size = New System.Drawing.Size(121, 25)
		Me.txtProgFgnd1.Location = New System.Drawing.Point(16, 256)
		Me.txtProgFgnd1.TabIndex = 2
		Me.txtProgFgnd1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtProgFgnd1.AcceptsReturn = True
		Me.txtProgFgnd1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtProgFgnd1.CausesValidation = True
		Me.txtProgFgnd1.Enabled = True
		Me.txtProgFgnd1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtProgFgnd1.HideSelection = True
		Me.txtProgFgnd1.ReadOnly = False
		Me.txtProgFgnd1.Maxlength = 0
		Me.txtProgFgnd1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtProgFgnd1.MultiLine = False
		Me.txtProgFgnd1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtProgFgnd1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtProgFgnd1.TabStop = True
		Me.txtProgFgnd1.Visible = True
		Me.txtProgFgnd1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtProgFgnd1.Name = "txtProgFgnd1"
		Me.Drive1.Size = New System.Drawing.Size(145, 21)
		Me.Drive1.Location = New System.Drawing.Point(8, 224)
		Me.Drive1.TabIndex = 20
		Me.Drive1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Drive1.BackColor = System.Drawing.SystemColors.Window
		Me.Drive1.CausesValidation = True
		Me.Drive1.Enabled = True
		Me.Drive1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Drive1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Drive1.TabStop = True
		Me.Drive1.Visible = True
		Me.Drive1.Name = "Drive1"
		Me.Dir1.Size = New System.Drawing.Size(249, 186)
		Me.Dir1.Location = New System.Drawing.Point(8, 32)
		Me.Dir1.TabIndex = 19
		Me.Dir1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Dir1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Dir1.BackColor = System.Drawing.SystemColors.Window
		Me.Dir1.CausesValidation = True
		Me.Dir1.Enabled = True
		Me.Dir1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Dir1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Dir1.TabStop = True
		Me.Dir1.Visible = True
		Me.Dir1.Name = "Dir1"
		Me.btnParseLogFiles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnParseLogFiles.Text = "Parse Log Files"
		Me.btnParseLogFiles.Enabled = False
		Me.btnParseLogFiles.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnParseLogFiles.Size = New System.Drawing.Size(97, 25)
		Me.btnParseLogFiles.Location = New System.Drawing.Point(264, 296)
		Me.btnParseLogFiles.TabIndex = 18
		Me.btnParseLogFiles.BackColor = System.Drawing.SystemColors.Control
		Me.btnParseLogFiles.CausesValidation = True
		Me.btnParseLogFiles.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnParseLogFiles.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnParseLogFiles.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnParseLogFiles.TabStop = True
		Me.btnParseLogFiles.Name = "btnParseLogFiles"
		Me.Frame1.Text = "Log Files To Merge"
		Me.Frame1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Frame1.Size = New System.Drawing.Size(129, 225)
		Me.Frame1.Location = New System.Drawing.Point(264, 32)
		Me.Frame1.TabIndex = 5
		Me.Frame1.BackColor = System.Drawing.SystemColors.Control
		Me.Frame1.Enabled = True
		Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame1.Visible = True
		Me.Frame1.Name = "Frame1"
		Me._ChkLogs_0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._ChkLogs_0.Size = New System.Drawing.Size(114, 17)
		Me._ChkLogs_0.Location = New System.Drawing.Point(8, 24)
		Me._ChkLogs_0.TabIndex = 17
		Me._ChkLogs_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._ChkLogs_0.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me._ChkLogs_0.BackColor = System.Drawing.SystemColors.Control
		Me._ChkLogs_0.Text = ""
		Me._ChkLogs_0.CausesValidation = True
		Me._ChkLogs_0.Enabled = True
		Me._ChkLogs_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._ChkLogs_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._ChkLogs_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._ChkLogs_0.Appearance = System.Windows.Forms.Appearance.Normal
		Me._ChkLogs_0.TabStop = True
		Me._ChkLogs_0.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._ChkLogs_0.Visible = True
		Me._ChkLogs_0.Name = "_ChkLogs_0"
		Me._ChkLogs_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._ChkLogs_1.Size = New System.Drawing.Size(114, 17)
		Me._ChkLogs_1.Location = New System.Drawing.Point(8, 40)
		Me._ChkLogs_1.TabIndex = 16
		Me._ChkLogs_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._ChkLogs_1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me._ChkLogs_1.BackColor = System.Drawing.SystemColors.Control
		Me._ChkLogs_1.Text = ""
		Me._ChkLogs_1.CausesValidation = True
		Me._ChkLogs_1.Enabled = True
		Me._ChkLogs_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._ChkLogs_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._ChkLogs_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._ChkLogs_1.Appearance = System.Windows.Forms.Appearance.Normal
		Me._ChkLogs_1.TabStop = True
		Me._ChkLogs_1.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._ChkLogs_1.Visible = True
		Me._ChkLogs_1.Name = "_ChkLogs_1"
		Me._ChkLogs_2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._ChkLogs_2.Size = New System.Drawing.Size(114, 17)
		Me._ChkLogs_2.Location = New System.Drawing.Point(8, 56)
		Me._ChkLogs_2.TabIndex = 15
		Me._ChkLogs_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._ChkLogs_2.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me._ChkLogs_2.BackColor = System.Drawing.SystemColors.Control
		Me._ChkLogs_2.Text = ""
		Me._ChkLogs_2.CausesValidation = True
		Me._ChkLogs_2.Enabled = True
		Me._ChkLogs_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._ChkLogs_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._ChkLogs_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._ChkLogs_2.Appearance = System.Windows.Forms.Appearance.Normal
		Me._ChkLogs_2.TabStop = True
		Me._ChkLogs_2.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._ChkLogs_2.Visible = True
		Me._ChkLogs_2.Name = "_ChkLogs_2"
		Me._ChkLogs_3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._ChkLogs_3.Size = New System.Drawing.Size(114, 17)
		Me._ChkLogs_3.Location = New System.Drawing.Point(8, 72)
		Me._ChkLogs_3.TabIndex = 14
		Me._ChkLogs_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._ChkLogs_3.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me._ChkLogs_3.BackColor = System.Drawing.SystemColors.Control
		Me._ChkLogs_3.Text = ""
		Me._ChkLogs_3.CausesValidation = True
		Me._ChkLogs_3.Enabled = True
		Me._ChkLogs_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me._ChkLogs_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._ChkLogs_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._ChkLogs_3.Appearance = System.Windows.Forms.Appearance.Normal
		Me._ChkLogs_3.TabStop = True
		Me._ChkLogs_3.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._ChkLogs_3.Visible = True
		Me._ChkLogs_3.Name = "_ChkLogs_3"
		Me._ChkLogs_4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._ChkLogs_4.Size = New System.Drawing.Size(114, 17)
		Me._ChkLogs_4.Location = New System.Drawing.Point(8, 88)
		Me._ChkLogs_4.TabIndex = 13
		Me._ChkLogs_4.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._ChkLogs_4.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me._ChkLogs_4.BackColor = System.Drawing.SystemColors.Control
		Me._ChkLogs_4.Text = ""
		Me._ChkLogs_4.CausesValidation = True
		Me._ChkLogs_4.Enabled = True
		Me._ChkLogs_4.ForeColor = System.Drawing.SystemColors.ControlText
		Me._ChkLogs_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._ChkLogs_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._ChkLogs_4.Appearance = System.Windows.Forms.Appearance.Normal
		Me._ChkLogs_4.TabStop = True
		Me._ChkLogs_4.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._ChkLogs_4.Visible = True
		Me._ChkLogs_4.Name = "_ChkLogs_4"
		Me._ChkLogs_5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._ChkLogs_5.Size = New System.Drawing.Size(114, 17)
		Me._ChkLogs_5.Location = New System.Drawing.Point(8, 104)
		Me._ChkLogs_5.TabIndex = 12
		Me._ChkLogs_5.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._ChkLogs_5.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me._ChkLogs_5.BackColor = System.Drawing.SystemColors.Control
		Me._ChkLogs_5.Text = ""
		Me._ChkLogs_5.CausesValidation = True
		Me._ChkLogs_5.Enabled = True
		Me._ChkLogs_5.ForeColor = System.Drawing.SystemColors.ControlText
		Me._ChkLogs_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._ChkLogs_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._ChkLogs_5.Appearance = System.Windows.Forms.Appearance.Normal
		Me._ChkLogs_5.TabStop = True
		Me._ChkLogs_5.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._ChkLogs_5.Visible = True
		Me._ChkLogs_5.Name = "_ChkLogs_5"
		Me._ChkLogs_7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._ChkLogs_7.Size = New System.Drawing.Size(114, 17)
		Me._ChkLogs_7.Location = New System.Drawing.Point(8, 136)
		Me._ChkLogs_7.TabIndex = 11
		Me._ChkLogs_7.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._ChkLogs_7.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me._ChkLogs_7.BackColor = System.Drawing.SystemColors.Control
		Me._ChkLogs_7.Text = ""
		Me._ChkLogs_7.CausesValidation = True
		Me._ChkLogs_7.Enabled = True
		Me._ChkLogs_7.ForeColor = System.Drawing.SystemColors.ControlText
		Me._ChkLogs_7.Cursor = System.Windows.Forms.Cursors.Default
		Me._ChkLogs_7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._ChkLogs_7.Appearance = System.Windows.Forms.Appearance.Normal
		Me._ChkLogs_7.TabStop = True
		Me._ChkLogs_7.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._ChkLogs_7.Visible = True
		Me._ChkLogs_7.Name = "_ChkLogs_7"
		Me._ChkLogs_6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._ChkLogs_6.Size = New System.Drawing.Size(114, 17)
		Me._ChkLogs_6.Location = New System.Drawing.Point(8, 120)
		Me._ChkLogs_6.TabIndex = 10
		Me._ChkLogs_6.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._ChkLogs_6.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me._ChkLogs_6.BackColor = System.Drawing.SystemColors.Control
		Me._ChkLogs_6.Text = ""
		Me._ChkLogs_6.CausesValidation = True
		Me._ChkLogs_6.Enabled = True
		Me._ChkLogs_6.ForeColor = System.Drawing.SystemColors.ControlText
		Me._ChkLogs_6.Cursor = System.Windows.Forms.Cursors.Default
		Me._ChkLogs_6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._ChkLogs_6.Appearance = System.Windows.Forms.Appearance.Normal
		Me._ChkLogs_6.TabStop = True
		Me._ChkLogs_6.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._ChkLogs_6.Visible = True
		Me._ChkLogs_6.Name = "_ChkLogs_6"
		Me._ChkLogs_8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._ChkLogs_8.Size = New System.Drawing.Size(114, 17)
		Me._ChkLogs_8.Location = New System.Drawing.Point(8, 152)
		Me._ChkLogs_8.TabIndex = 9
		Me._ChkLogs_8.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._ChkLogs_8.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me._ChkLogs_8.BackColor = System.Drawing.SystemColors.Control
		Me._ChkLogs_8.Text = ""
		Me._ChkLogs_8.CausesValidation = True
		Me._ChkLogs_8.Enabled = True
		Me._ChkLogs_8.ForeColor = System.Drawing.SystemColors.ControlText
		Me._ChkLogs_8.Cursor = System.Windows.Forms.Cursors.Default
		Me._ChkLogs_8.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._ChkLogs_8.Appearance = System.Windows.Forms.Appearance.Normal
		Me._ChkLogs_8.TabStop = True
		Me._ChkLogs_8.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._ChkLogs_8.Visible = True
		Me._ChkLogs_8.Name = "_ChkLogs_8"
		Me._ChkLogs_9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._ChkLogs_9.Size = New System.Drawing.Size(114, 17)
		Me._ChkLogs_9.Location = New System.Drawing.Point(8, 168)
		Me._ChkLogs_9.TabIndex = 8
		Me._ChkLogs_9.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._ChkLogs_9.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me._ChkLogs_9.BackColor = System.Drawing.SystemColors.Control
		Me._ChkLogs_9.Text = ""
		Me._ChkLogs_9.CausesValidation = True
		Me._ChkLogs_9.Enabled = True
		Me._ChkLogs_9.ForeColor = System.Drawing.SystemColors.ControlText
		Me._ChkLogs_9.Cursor = System.Windows.Forms.Cursors.Default
		Me._ChkLogs_9.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._ChkLogs_9.Appearance = System.Windows.Forms.Appearance.Normal
		Me._ChkLogs_9.TabStop = True
		Me._ChkLogs_9.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._ChkLogs_9.Visible = True
		Me._ChkLogs_9.Name = "_ChkLogs_9"
		Me._ChkLogs_10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._ChkLogs_10.Size = New System.Drawing.Size(114, 17)
		Me._ChkLogs_10.Location = New System.Drawing.Point(8, 184)
		Me._ChkLogs_10.TabIndex = 7
		Me._ChkLogs_10.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._ChkLogs_10.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me._ChkLogs_10.BackColor = System.Drawing.SystemColors.Control
		Me._ChkLogs_10.Text = ""
		Me._ChkLogs_10.CausesValidation = True
		Me._ChkLogs_10.Enabled = True
		Me._ChkLogs_10.ForeColor = System.Drawing.SystemColors.ControlText
		Me._ChkLogs_10.Cursor = System.Windows.Forms.Cursors.Default
		Me._ChkLogs_10.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._ChkLogs_10.Appearance = System.Windows.Forms.Appearance.Normal
		Me._ChkLogs_10.TabStop = True
		Me._ChkLogs_10.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._ChkLogs_10.Visible = True
		Me._ChkLogs_10.Name = "_ChkLogs_10"
		Me._ChkLogs_11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._ChkLogs_11.Size = New System.Drawing.Size(114, 17)
		Me._ChkLogs_11.Location = New System.Drawing.Point(8, 200)
		Me._ChkLogs_11.TabIndex = 6
		Me._ChkLogs_11.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._ChkLogs_11.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me._ChkLogs_11.BackColor = System.Drawing.SystemColors.Control
		Me._ChkLogs_11.Text = ""
		Me._ChkLogs_11.CausesValidation = True
		Me._ChkLogs_11.Enabled = True
		Me._ChkLogs_11.ForeColor = System.Drawing.SystemColors.ControlText
		Me._ChkLogs_11.Cursor = System.Windows.Forms.Cursors.Default
		Me._ChkLogs_11.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._ChkLogs_11.Appearance = System.Windows.Forms.Appearance.Normal
		Me._ChkLogs_11.TabStop = True
		Me._ChkLogs_11.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._ChkLogs_11.Visible = True
		Me._ChkLogs_11.Name = "_ChkLogs_11"
		Me.txtLogFile.AutoSize = False
		Me.txtLogFile.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtLogFile.Size = New System.Drawing.Size(241, 25)
		Me.txtLogFile.Location = New System.Drawing.Point(16, 296)
		Me.txtLogFile.TabIndex = 4
		Me.txtLogFile.AcceptsReturn = True
		Me.txtLogFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtLogFile.BackColor = System.Drawing.SystemColors.Window
		Me.txtLogFile.CausesValidation = True
		Me.txtLogFile.Enabled = True
		Me.txtLogFile.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtLogFile.HideSelection = True
		Me.txtLogFile.ReadOnly = False
		Me.txtLogFile.Maxlength = 0
		Me.txtLogFile.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtLogFile.MultiLine = False
		Me.txtLogFile.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtLogFile.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtLogFile.TabStop = True
		Me.txtLogFile.Visible = True
		Me.txtLogFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtLogFile.Name = "txtLogFile"
		Me.txtProgBkg1.AutoSize = False
		Me.txtProgBkg1.BackColor = System.Drawing.SystemColors.Menu
		Me.txtProgBkg1.Size = New System.Drawing.Size(241, 25)
		Me.txtProgBkg1.Location = New System.Drawing.Point(16, 256)
		Me.txtProgBkg1.TabIndex = 3
		Me.txtProgBkg1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtProgBkg1.AcceptsReturn = True
		Me.txtProgBkg1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtProgBkg1.CausesValidation = True
		Me.txtProgBkg1.Enabled = True
		Me.txtProgBkg1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtProgBkg1.HideSelection = True
		Me.txtProgBkg1.ReadOnly = False
		Me.txtProgBkg1.Maxlength = 0
		Me.txtProgBkg1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtProgBkg1.MultiLine = False
		Me.txtProgBkg1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtProgBkg1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtProgBkg1.TabStop = True
		Me.txtProgBkg1.Visible = True
		Me.txtProgBkg1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtProgBkg1.Name = "txtProgBkg1"
		Me.chkUnicode.Text = "Unicode"
		Me.chkUnicode.Size = New System.Drawing.Size(65, 17)
		Me.chkUnicode.Location = New System.Drawing.Point(176, 224)
		Me.chkUnicode.TabIndex = 1
		Me.chkUnicode.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkUnicode.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkUnicode.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkUnicode.BackColor = System.Drawing.SystemColors.Control
		Me.chkUnicode.CausesValidation = True
		Me.chkUnicode.Enabled = True
		Me.chkUnicode.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkUnicode.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkUnicode.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkUnicode.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkUnicode.TabStop = True
		Me.chkUnicode.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkUnicode.Visible = True
		Me.chkUnicode.Name = "chkUnicode"
		Me.CancelButton_Renamed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CancelButton_Renamed.Text = "Cancel"
		Me.CancelButton_Renamed.Size = New System.Drawing.Size(97, 25)
		Me.CancelButton_Renamed.Location = New System.Drawing.Point(264, 328)
		Me.CancelButton_Renamed.TabIndex = 0
		Me.CancelButton_Renamed.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CancelButton_Renamed.BackColor = System.Drawing.SystemColors.Control
		Me.CancelButton_Renamed.CausesValidation = True
		Me.CancelButton_Renamed.Enabled = True
		Me.CancelButton_Renamed.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CancelButton_Renamed.Cursor = System.Windows.Forms.Cursors.Default
		Me.CancelButton_Renamed.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CancelButton_Renamed.TabStop = True
		Me.CancelButton_Renamed.Name = "CancelButton_Renamed"
		Me.Label1.Text = "Trace File Directory"
		Me.Label1.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Size = New System.Drawing.Size(193, 25)
		Me.Label1.Location = New System.Drawing.Point(48, 8)
		Me.Label1.TabIndex = 21
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(txtProgFgnd1)
		Me.Controls.Add(Drive1)
		Me.Controls.Add(Dir1)
		Me.Controls.Add(btnParseLogFiles)
		Me.Controls.Add(Frame1)
		Me.Controls.Add(txtLogFile)
		Me.Controls.Add(txtProgBkg1)
		Me.Controls.Add(chkUnicode)
		Me.Controls.Add(CancelButton_Renamed)
		Me.Controls.Add(Label1)
		Me.Frame1.Controls.Add(_ChkLogs_0)
		Me.Frame1.Controls.Add(_ChkLogs_1)
		Me.Frame1.Controls.Add(_ChkLogs_2)
		Me.Frame1.Controls.Add(_ChkLogs_3)
		Me.Frame1.Controls.Add(_ChkLogs_4)
		Me.Frame1.Controls.Add(_ChkLogs_5)
		Me.Frame1.Controls.Add(_ChkLogs_7)
		Me.Frame1.Controls.Add(_ChkLogs_6)
		Me.Frame1.Controls.Add(_ChkLogs_8)
		Me.Frame1.Controls.Add(_ChkLogs_9)
		Me.Frame1.Controls.Add(_ChkLogs_10)
		Me.Frame1.Controls.Add(_ChkLogs_11)
		Me.ChkLogs.SetIndex(_ChkLogs_0, CType(0, Short))
		Me.ChkLogs.SetIndex(_ChkLogs_1, CType(1, Short))
		Me.ChkLogs.SetIndex(_ChkLogs_2, CType(2, Short))
		Me.ChkLogs.SetIndex(_ChkLogs_3, CType(3, Short))
		Me.ChkLogs.SetIndex(_ChkLogs_4, CType(4, Short))
		Me.ChkLogs.SetIndex(_ChkLogs_5, CType(5, Short))
		Me.ChkLogs.SetIndex(_ChkLogs_7, CType(7, Short))
		Me.ChkLogs.SetIndex(_ChkLogs_6, CType(6, Short))
		Me.ChkLogs.SetIndex(_ChkLogs_8, CType(8, Short))
		Me.ChkLogs.SetIndex(_ChkLogs_9, CType(9, Short))
		Me.ChkLogs.SetIndex(_ChkLogs_10, CType(10, Short))
		Me.ChkLogs.SetIndex(_ChkLogs_11, CType(11, Short))
		CType(Me.ChkLogs, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Frame1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class