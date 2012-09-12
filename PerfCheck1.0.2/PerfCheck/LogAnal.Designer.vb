<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmLogAnal
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
	Public WithEvents List1 As System.Windows.Forms.ListBox
	Public WithEvents File As Microsoft.VisualBasic.Compatibility.VB6.ToolStripMenuItemArray
	Public WithEvents Tools As Microsoft.VisualBasic.Compatibility.VB6.ToolStripMenuItemArray
	Public WithEvents OpenMergedTraceFile As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents SaveAsMergedTraceFile As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents OpenDiagFile As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Export As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents _File_1 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Cut As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Copy As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Paste As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Find As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents FindAgain As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Edit As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents SearchForPatterns As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents AllPatterns As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents ListingClockControl As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents Options As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuHideDuplicates As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents KgsToLbs As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents _Tools_2 As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmLogAnal))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.List1 = New System.Windows.Forms.ListBox
		Me.File = New Microsoft.VisualBasic.Compatibility.VB6.ToolStripMenuItemArray(components)
		Me.Tools = New Microsoft.VisualBasic.Compatibility.VB6.ToolStripMenuItemArray(components)
		Me.MainMenu1 = New System.Windows.Forms.MenuStrip
		Me._File_1 = New System.Windows.Forms.ToolStripMenuItem
		Me.OpenMergedTraceFile = New System.Windows.Forms.ToolStripMenuItem
		Me.SaveAsMergedTraceFile = New System.Windows.Forms.ToolStripMenuItem
		Me.OpenDiagFile = New System.Windows.Forms.ToolStripMenuItem
		Me.Export = New System.Windows.Forms.ToolStripMenuItem
		Me.Edit = New System.Windows.Forms.ToolStripMenuItem
		Me.Cut = New System.Windows.Forms.ToolStripMenuItem
		Me.Copy = New System.Windows.Forms.ToolStripMenuItem
		Me.Paste = New System.Windows.Forms.ToolStripMenuItem
		Me.Find = New System.Windows.Forms.ToolStripMenuItem
		Me.FindAgain = New System.Windows.Forms.ToolStripMenuItem
		Me._Tools_2 = New System.Windows.Forms.ToolStripMenuItem
		Me.SearchForPatterns = New System.Windows.Forms.ToolStripMenuItem
		Me.AllPatterns = New System.Windows.Forms.ToolStripMenuItem
		Me.ListingClockControl = New System.Windows.Forms.ToolStripMenuItem
		Me.Options = New System.Windows.Forms.ToolStripMenuItem
		Me.mnuHideDuplicates = New System.Windows.Forms.ToolStripMenuItem
		Me.KgsToLbs = New System.Windows.Forms.ToolStripMenuItem
		Me.MainMenu1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.File, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Tools, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Text = "Log File Analysis"
		Me.ClientSize = New System.Drawing.Size(939, 563)
		Me.Location = New System.Drawing.Point(11, 57)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmLogAnal"
		Me.List1.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.List1.Size = New System.Drawing.Size(905, 539)
		Me.List1.Location = New System.Drawing.Point(8, 8)
		Me.List1.TabIndex = 0
		Me.List1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.List1.BackColor = System.Drawing.SystemColors.Window
		Me.List1.CausesValidation = True
		Me.List1.Enabled = True
		Me.List1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.List1.IntegralHeight = True
		Me.List1.Cursor = System.Windows.Forms.Cursors.Default
		Me.List1.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.List1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.List1.Sorted = False
		Me.List1.TabStop = True
		Me.List1.Visible = True
		Me.List1.MultiColumn = False
		Me.List1.Name = "List1"
		Me._File_1.Name = "_File_1"
		Me._File_1.Text = "File"
		Me._File_1.Checked = False
		Me._File_1.Enabled = True
		Me._File_1.Visible = True
		Me.OpenMergedTraceFile.Name = "OpenMergedTraceFile"
		Me.OpenMergedTraceFile.Text = "Open Merged Trace File"
		Me.OpenMergedTraceFile.Checked = False
		Me.OpenMergedTraceFile.Enabled = True
		Me.OpenMergedTraceFile.Visible = True
		Me.SaveAsMergedTraceFile.Name = "SaveAsMergedTraceFile"
		Me.SaveAsMergedTraceFile.Text = "SaveAs Merged Trace File"
		Me.SaveAsMergedTraceFile.Checked = False
		Me.SaveAsMergedTraceFile.Enabled = True
		Me.SaveAsMergedTraceFile.Visible = True
		Me.OpenDiagFile.Name = "OpenDiagFile"
		Me.OpenDiagFile.Text = "Open Diag File"
		Me.OpenDiagFile.Checked = False
		Me.OpenDiagFile.Enabled = True
		Me.OpenDiagFile.Visible = True
		Me.Export.Name = "Export"
		Me.Export.Text = "Export"
		Me.Export.Checked = False
		Me.Export.Enabled = True
		Me.Export.Visible = True
		Me.Edit.Name = "Edit"
		Me.Edit.Text = "Edit"
		Me.Edit.Checked = False
		Me.Edit.Enabled = True
		Me.Edit.Visible = True
		Me.Cut.Name = "Cut"
		Me.Cut.Text = "Cut"
		Me.Cut.Checked = False
		Me.Cut.Enabled = True
		Me.Cut.Visible = True
		Me.Copy.Name = "Copy"
		Me.Copy.Text = "Copy"
		Me.Copy.Checked = False
		Me.Copy.Enabled = True
		Me.Copy.Visible = True
		Me.Paste.Name = "Paste"
		Me.Paste.Text = "Paste"
		Me.Paste.Checked = False
		Me.Paste.Enabled = True
		Me.Paste.Visible = True
		Me.Find.Name = "Find"
		Me.Find.Text = "Find"
		Me.Find.ShortcutKeys = CType(System.Windows.Forms.Keys.Control or System.Windows.Forms.Keys.F, System.Windows.Forms.Keys)
		Me.Find.Checked = False
		Me.Find.Enabled = True
		Me.Find.Visible = True
		Me.FindAgain.Name = "FindAgain"
		Me.FindAgain.Text = "Find Again"
		Me.FindAgain.ShortcutKeys = CType(System.Windows.Forms.Keys.F3, System.Windows.Forms.Keys)
		Me.FindAgain.Checked = False
		Me.FindAgain.Enabled = True
		Me.FindAgain.Visible = True
		Me._Tools_2.Name = "_Tools_2"
		Me._Tools_2.Text = "Tools"
		Me._Tools_2.Checked = False
		Me._Tools_2.Enabled = True
		Me._Tools_2.Visible = True
		Me.SearchForPatterns.Name = "SearchForPatterns"
		Me.SearchForPatterns.Text = "Search For Patterns"
		Me.SearchForPatterns.Checked = False
		Me.SearchForPatterns.Enabled = True
		Me.SearchForPatterns.Visible = True
		Me.AllPatterns.Name = "AllPatterns"
		Me.AllPatterns.Text = "All Patterns"
		Me.AllPatterns.Checked = False
		Me.AllPatterns.Enabled = True
		Me.AllPatterns.Visible = True
		Me.ListingClockControl.Name = "ListingClockControl"
		Me.ListingClockControl.Text = "Listing Clock Control..."
		Me.ListingClockControl.Checked = False
		Me.ListingClockControl.Enabled = True
		Me.ListingClockControl.Visible = True
		Me.Options.Name = "Options"
		Me.Options.Text = "Options..."
		Me.Options.Enabled = False
		Me.Options.Checked = False
		Me.Options.Visible = True
		Me.mnuHideDuplicates.Name = "mnuHideDuplicates"
		Me.mnuHideDuplicates.Text = "Hide Duplicates"
		Me.mnuHideDuplicates.Checked = True
		Me.mnuHideDuplicates.Enabled = True
		Me.mnuHideDuplicates.Visible = True
		Me.KgsToLbs.Name = "KgsToLbs"
		Me.KgsToLbs.Text = "Kgs to Lbs"
		Me.KgsToLbs.Checked = True
		Me.KgsToLbs.Enabled = True
		Me.KgsToLbs.Visible = True
		Me.Controls.Add(List1)
		Me.File.SetIndex(_File_1, CType(1, Short))
		Me.Tools.SetIndex(_Tools_2, CType(2, Short))
		CType(Me.Tools, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.File, System.ComponentModel.ISupportInitialize).EndInit()
		MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem(){Me._File_1, Me.Edit, Me._Tools_2})
		_File_1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.OpenMergedTraceFile, Me.SaveAsMergedTraceFile, Me.OpenDiagFile, Me.Export})
		Edit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.Cut, Me.Copy, Me.Paste, Me.Find, Me.FindAgain})
		_Tools_2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.SearchForPatterns, Me.AllPatterns, Me.ListingClockControl, Me.Options, Me.mnuHideDuplicates, Me.KgsToLbs})
		Me.Controls.Add(MainMenu1)
		Me.MainMenu1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class