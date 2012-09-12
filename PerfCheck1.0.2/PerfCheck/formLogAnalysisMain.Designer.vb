
'Namespace PerfCheck
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _	
Partial Class formLogAnalysisMain
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
    	Me.DiagOpenDialog = New System.Windows.Forms.OpenFileDialog()
    	Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
    	Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    	Me.OpenDiagFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    	Me.ExportMergeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    	Me.exportsummaryreport = New System.Windows.Forms.ToolStripMenuItem()
    	Me.TemplateDirectoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    	Me.autoDetectTemplatesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    	Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    	Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    	Me.FindToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    	Me.FindAgainToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    	Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    	Me.AllPatternsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    	Me.ListingClockToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    	Me.KgsToLbsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    	Me.HideDuplicatesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    	Me.helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    	Me.aboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    	Me.DirectoryEntry1 = New System.DirectoryServices.DirectoryEntry()
    	Me.DataGridView1 = New System.Windows.Forms.DataGridView()
    	Me.Rel_Time = New System.Windows.Forms.DataGridViewTextBoxColumn()
    	Me._Date = New System.Windows.Forms.DataGridViewTextBoxColumn()
    	Me.milliSec = New System.Windows.Forms.DataGridViewTextBoxColumn()
    	Me.Source = New System.Windows.Forms.DataGridViewTextBoxColumn()
    	Me.LineNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
    	Me.EventName = New System.Windows.Forms.DataGridViewTextBoxColumn()
    	Me._Data = New System.Windows.Forms.DataGridViewTextBoxColumn()
    	Me.CollectionIndex = New System.Windows.Forms.DataGridViewTextBoxColumn()
    	Me.rawEvent = New System.Windows.Forms.DataGridViewTextBoxColumn()
    	Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
    	Me.toolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
    	Me.MenuStrip1.SuspendLayout
    	CType(Me.DataGridView1,System.ComponentModel.ISupportInitialize).BeginInit
    	Me.statusStrip1.SuspendLayout
    	Me.SuspendLayout
    	'
    	'DiagOpenDialog
    	'
    	Me.DiagOpenDialog.FileName = "DiagOpenDialog"
    	'
    	'MenuStrip1
    	'
    	Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.helpToolStripMenuItem})
    	Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
    	Me.MenuStrip1.Name = "MenuStrip1"
    	Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(1, 1, 0, 1)
    	Me.MenuStrip1.Size = New System.Drawing.Size(701, 24)
    	Me.MenuStrip1.TabIndex = 0
    	Me.MenuStrip1.Text = "MenuStrip1"
    	'
    	'FileToolStripMenuItem
    	'
    	Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenDiagFileToolStripMenuItem, Me.ExportMergeToolStripMenuItem, Me.exportsummaryreport, Me.TemplateDirectoryToolStripMenuItem, Me.autoDetectTemplatesToolStripMenuItem})
    	Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
    	Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 22)
    	Me.FileToolStripMenuItem.Text = "File"
    	'
    	'OpenDiagFileToolStripMenuItem
    	'
    	Me.OpenDiagFileToolStripMenuItem.Name = "OpenDiagFileToolStripMenuItem"
    	Me.OpenDiagFileToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O),System.Windows.Forms.Keys)
    	Me.OpenDiagFileToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
    	Me.OpenDiagFileToolStripMenuItem.Text = "Open Diag File"
    	'
    	'ExportMergeToolStripMenuItem
    	'
    	Me.ExportMergeToolStripMenuItem.Name = "ExportMergeToolStripMenuItem"
    	Me.ExportMergeToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
    	Me.ExportMergeToolStripMenuItem.Text = "Export Merged Events"
    	'
    	'exportsummaryreport
    	'
    	Me.exportsummaryreport.Name = "exportsummaryreport"
    	Me.exportsummaryreport.Size = New System.Drawing.Size(189, 22)
    	Me.exportsummaryreport.Text = "Export Summary Report"
    	AddHandler Me.exportsummaryreport.Click, AddressOf Me.ExportsummaryreportClick
    	'
    	'TemplateDirectoryToolStripMenuItem
    	'
    	Me.TemplateDirectoryToolStripMenuItem.Enabled = false
    	Me.TemplateDirectoryToolStripMenuItem.Name = "TemplateDirectoryToolStripMenuItem"
    	Me.TemplateDirectoryToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
    	Me.TemplateDirectoryToolStripMenuItem.Text = "Template Directory"
    	'
    	'autoDetectTemplatesToolStripMenuItem
    	'
    	Me.autoDetectTemplatesToolStripMenuItem.Checked = true
    	Me.autoDetectTemplatesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
    	Me.autoDetectTemplatesToolStripMenuItem.Name = "autoDetectTemplatesToolStripMenuItem"
    	Me.autoDetectTemplatesToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
    	Me.autoDetectTemplatesToolStripMenuItem.Text = "Auto Detect Template"
    	AddHandler Me.autoDetectTemplatesToolStripMenuItem.Click, AddressOf Me.AutoDetectTemplatesToolStripMenuItemClick
    	'
    	'EditToolStripMenuItem
    	'
    	Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenuItem, Me.FindToolStripMenuItem, Me.FindAgainToolStripMenuItem})
    	Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
    	Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 22)
    	Me.EditToolStripMenuItem.Text = "Edit"
    	'
    	'CopyToolStripMenuItem
    	'
    	Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
    	Me.CopyToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C),System.Windows.Forms.Keys)
    	Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
    	Me.CopyToolStripMenuItem.Text = "Copy"
    	AddHandler Me.CopyToolStripMenuItem.Click, AddressOf Me.CopyToolStripMenuItemClick
    	'
    	'FindToolStripMenuItem
    	'
    	Me.FindToolStripMenuItem.Name = "FindToolStripMenuItem"
    	Me.FindToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F),System.Windows.Forms.Keys)
    	Me.FindToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
    	Me.FindToolStripMenuItem.Text = "Find"
    	'
    	'FindAgainToolStripMenuItem
    	'
    	Me.FindAgainToolStripMenuItem.Name = "FindAgainToolStripMenuItem"
    	Me.FindAgainToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3
    	Me.FindAgainToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
    	Me.FindAgainToolStripMenuItem.Text = "Find Again"
    	AddHandler Me.FindAgainToolStripMenuItem.Click, AddressOf Me.FindAgainToolStripMenuItemClick
    	'
    	'ToolsToolStripMenuItem
    	'
    	Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AllPatternsToolStripMenuItem, Me.ListingClockToolStripMenuItem, Me.KgsToLbsToolStripMenuItem, Me.HideDuplicatesToolStripMenuItem})
    	Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
    	Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(44, 22)
    	Me.ToolsToolStripMenuItem.Text = "Tools"
    	'
    	'AllPatternsToolStripMenuItem
    	'
    	Me.AllPatternsToolStripMenuItem.Enabled = false
    	Me.AllPatternsToolStripMenuItem.Name = "AllPatternsToolStripMenuItem"
    	Me.AllPatternsToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
    	Me.AllPatternsToolStripMenuItem.Text = "All Patterns"
    	'
    	'ListingClockToolStripMenuItem
    	'
    	Me.ListingClockToolStripMenuItem.Enabled = false
    	Me.ListingClockToolStripMenuItem.Name = "ListingClockToolStripMenuItem"
    	Me.ListingClockToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
    	Me.ListingClockToolStripMenuItem.Text = "Listing Clock..."
    	'
    	'KgsToLbsToolStripMenuItem
    	'
    	Me.KgsToLbsToolStripMenuItem.Enabled = false
    	Me.KgsToLbsToolStripMenuItem.Name = "KgsToLbsToolStripMenuItem"
    	Me.KgsToLbsToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
    	Me.KgsToLbsToolStripMenuItem.Text = "KgsToLbs"
    	AddHandler Me.KgsToLbsToolStripMenuItem.Click, AddressOf Me.KgsToLbsToolStripMenuItemClick
    	'
    	'HideDuplicatesToolStripMenuItem
    	'
    	Me.HideDuplicatesToolStripMenuItem.Enabled = false
    	Me.HideDuplicatesToolStripMenuItem.Name = "HideDuplicatesToolStripMenuItem"
    	Me.HideDuplicatesToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
    	Me.HideDuplicatesToolStripMenuItem.Text = "HideDuplicates"
    	AddHandler Me.HideDuplicatesToolStripMenuItem.Click, AddressOf Me.HideDuplicatesToolStripMenuItemClick
    	'
    	'helpToolStripMenuItem
    	'
    	Me.helpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.aboutToolStripMenuItem})
    	Me.helpToolStripMenuItem.Name = "helpToolStripMenuItem"
    	Me.helpToolStripMenuItem.Size = New System.Drawing.Size(40, 22)
    	Me.helpToolStripMenuItem.Text = "Help"
    	'
    	'aboutToolStripMenuItem
    	'
    	Me.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem"
    	Me.aboutToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
    	Me.aboutToolStripMenuItem.Text = "About"
    	AddHandler Me.aboutToolStripMenuItem.Click, AddressOf Me.AboutToolStripMenuItemClick
    	'
    	'DataGridView1
    	'
    	Me.DataGridView1.AllowUserToAddRows = false
    	Me.DataGridView1.AllowUserToDeleteRows = false
    	Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
    	Me.DataGridView1.ColumnHeadersHeight = 24
    	Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
    	Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Rel_Time, Me._Date, Me.milliSec, Me.Source, Me.LineNo, Me.EventName, Me._Data, Me.CollectionIndex, Me.rawEvent})
    	Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
    	Me.DataGridView1.Location = New System.Drawing.Point(0, 24)
    	Me.DataGridView1.Margin = New System.Windows.Forms.Padding(1)
    	Me.DataGridView1.Name = "DataGridView1"
    	Me.DataGridView1.ReadOnly = true
    	Me.DataGridView1.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    	Me.DataGridView1.RowTemplate.Height = 16
    	Me.DataGridView1.RowTemplate.ReadOnly = true
    	Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    	Me.DataGridView1.Size = New System.Drawing.Size(701, 478)
    	Me.DataGridView1.TabIndex = 2
    	AddHandler Me.DataGridView1.CellDoubleClick, AddressOf Me.datagridView_doubleclickEvent
    	'
    	'Rel_Time
    	'
    	Me.Rel_Time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
    	Me.Rel_Time.HeaderText = "Rel Time"
    	Me.Rel_Time.Name = "Rel_Time"
    	Me.Rel_Time.ReadOnly = true
    	'
    	'_Date
    	'
    	Me._Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
    	Me._Date.HeaderText = "Date Time"
    	Me._Date.Name = "_Date"
    	Me._Date.ReadOnly = true
    	'
    	'milliSec
    	'
    	Me.milliSec.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
    	Me.milliSec.HeaderText = "MilliSec"
    	Me.milliSec.Name = "milliSec"
    	Me.milliSec.ReadOnly = true
    	'
    	'Source
    	'
    	Me.Source.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
    	Me.Source.HeaderText = "Source"
    	Me.Source.Name = "Source"
    	Me.Source.ReadOnly = true
    	'
    	'LineNo
    	'
    	Me.LineNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
    	Me.LineNo.HeaderText = "LineNo"
    	Me.LineNo.Name = "LineNo"
    	Me.LineNo.ReadOnly = true
    	'
    	'EventName
    	'
    	Me.EventName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
    	Me.EventName.HeaderText = "Event Name"
    	Me.EventName.Name = "EventName"
    	Me.EventName.ReadOnly = true
    	'
    	'_Data
    	'
    	Me._Data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
    	Me._Data.HeaderText = "Data"
    	Me._Data.Name = "_Data"
    	Me._Data.ReadOnly = true
    	Me._Data.Visible = false
    	'
    	'CollectionIndex
    	'
    	Me.CollectionIndex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
    	Me.CollectionIndex.HeaderText = "CollectionIndex"
    	Me.CollectionIndex.Name = "CollectionIndex"
    	Me.CollectionIndex.ReadOnly = true
    	Me.CollectionIndex.Visible = false
    	'
    	'rawEvent
    	'
    	Me.rawEvent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
    	Me.rawEvent.HeaderText = "Raw Event"
    	Me.rawEvent.Name = "rawEvent"
    	Me.rawEvent.ReadOnly = true
    	Me.rawEvent.Visible = false
    	'
    	'statusStrip1
    	'
    	Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripStatusLabel1})
    	Me.statusStrip1.Location = New System.Drawing.Point(0, 502)
    	Me.statusStrip1.Name = "statusStrip1"
    	Me.statusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 3, 0)
    	Me.statusStrip1.Size = New System.Drawing.Size(701, 22)
    	Me.statusStrip1.TabIndex = 3
    	Me.statusStrip1.Text = "Ready"
    	'
    	'toolStripStatusLabel1
    	'
    	Me.toolStripStatusLabel1.Name = "toolStripStatusLabel1"
    	Me.toolStripStatusLabel1.Size = New System.Drawing.Size(38, 17)
    	Me.toolStripStatusLabel1.Text = "Ready"
    	'
    	'formLogAnalysisMain
    	'
    	Me.AutoScaleDimensions = New System.Drawing.SizeF(10!, 20!)
    	Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    	Me.ClientSize = New System.Drawing.Size(701, 524)
    	Me.Controls.Add(Me.DataGridView1)
    	Me.Controls.Add(Me.statusStrip1)
    	Me.Controls.Add(Me.MenuStrip1)
    	Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    	Me.MainMenuStrip = Me.MenuStrip1
    	Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
    	Me.Name = "formLogAnalysisMain"
    	Me.Text = "SSCO Log File Analysis Utility"
    	Me.MenuStrip1.ResumeLayout(false)
    	Me.MenuStrip1.PerformLayout
    	CType(Me.DataGridView1,System.ComponentModel.ISupportInitialize).EndInit
    	Me.statusStrip1.ResumeLayout(false)
    	Me.statusStrip1.PerformLayout
    	Me.ResumeLayout(false)
    	Me.PerformLayout
    End Sub
    Private toolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Private statusStrip1 As System.Windows.Forms.StatusStrip
    Private autoDetectTemplatesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private rawEvent As System.Windows.Forms.DataGridViewTextBoxColumn
    Private aboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private helpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private exportsummaryreport As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents DiagOpenDialog As System.Windows.Forms.OpenFileDialog
    Public WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Public WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents OpenDiagFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ExportMergeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents FindToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents FindAgainToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents AllPatternsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ListingClockToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents DirectoryEntry1 As System.DirectoryServices.DirectoryEntry
    Public WithEvents KgsToLbsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents HideDuplicatesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents TemplateDirectoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Private Rel_Time As System.Windows.Forms.DataGridViewTextBoxColumn
    Private _Date As System.Windows.Forms.DataGridViewTextBoxColumn
    Private milliSec As System.Windows.Forms.DataGridViewTextBoxColumn
    Private Source As System.Windows.Forms.DataGridViewTextBoxColumn
    Private LineNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Private EventName As System.Windows.Forms.DataGridViewTextBoxColumn
    Private _Data As System.Windows.Forms.DataGridViewTextBoxColumn
    Private CollectionIndex As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
'End Namespace