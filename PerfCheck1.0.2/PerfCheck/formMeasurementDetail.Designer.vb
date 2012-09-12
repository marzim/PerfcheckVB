'Namespace PerfCheck
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _	
Partial Class formMeasurementDetail
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
    	Dim dataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    	Dim dataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    	Me.dgMeasureDetails = New System.Windows.Forms.DataGridView()
    	Me.DateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
    	Me.Milliseconds = New System.Windows.Forms.DataGridViewTextBoxColumn()
    	Me.LineNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
    	Me.Duration = New System.Windows.Forms.DataGridViewTextBoxColumn()
    	Me.CollectionIndex = New System.Windows.Forms.DataGridViewTextBoxColumn()
    	Me.Cancel_Button = New System.Windows.Forms.Button()
    	Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
    	Me.tableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
    	Me.exclusionEventsTextBox = New System.Windows.Forms.TextBox()
    	Me.eventPatternTextBox = New System.Windows.Forms.TextBox()
    	Me.reportMeasureLabel = New System.Windows.Forms.Label()
    	Me.exclusionEventsLabel = New System.Windows.Forms.Label()
    	Me.reportMeasureTextBox = New System.Windows.Forms.TextBox()
    	Me.eventPatternLabel = New System.Windows.Forms.Label()
    	CType(Me.dgMeasureDetails,System.ComponentModel.ISupportInitialize).BeginInit
    	Me.TableLayoutPanel1.SuspendLayout
    	Me.tableLayoutPanel2.SuspendLayout
    	Me.SuspendLayout
    	'
    	'dgMeasureDetails
    	'
    	Me.dgMeasureDetails.AllowUserToAddRows = false
    	Me.dgMeasureDetails.AllowUserToDeleteRows = false
    	Me.dgMeasureDetails.AllowUserToResizeRows = false
    	Me.dgMeasureDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
    	    	    	Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
    	Me.dgMeasureDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
    	dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    	dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
    	dataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    	dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
    	dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    	dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    	dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    	Me.dgMeasureDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1
    	Me.dgMeasureDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    	Me.dgMeasureDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DateTime, Me.Milliseconds, Me.LineNo, Me.Duration, Me.CollectionIndex})
    	dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    	dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
    	dataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    	dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
    	dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
    	dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    	dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    	Me.dgMeasureDetails.DefaultCellStyle = dataGridViewCellStyle2
    	Me.dgMeasureDetails.Location = New System.Drawing.Point(21, 131)
    	Me.dgMeasureDetails.Name = "dgMeasureDetails"
    	Me.dgMeasureDetails.ReadOnly = true
    	Me.dgMeasureDetails.Size = New System.Drawing.Size(636, 419)
    	Me.dgMeasureDetails.TabIndex = 1
    	'
    	'DateTime
    	'
    	Me.DateTime.HeaderText = "Date Time"
    	Me.DateTime.Name = "DateTime"
    	Me.DateTime.ReadOnly = true
    	'
    	'Milliseconds
    	'
    	Me.Milliseconds.HeaderText = "MilliSeconds"
    	Me.Milliseconds.Name = "Milliseconds"
    	Me.Milliseconds.ReadOnly = true
    	'
    	'LineNo
    	'
    	Me.LineNo.HeaderText = "Line Number"
    	Me.LineNo.Name = "LineNo"
    	Me.LineNo.ReadOnly = true
    	'
    	'Duration
    	'
    	Me.Duration.HeaderText = "Duration"
    	Me.Duration.Name = "Duration"
    	Me.Duration.ReadOnly = true
    	'
    	'CollectionIndex
    	'
    	Me.CollectionIndex.HeaderText = "CollectionIndex"
    	Me.CollectionIndex.Name = "CollectionIndex"
    	Me.CollectionIndex.ReadOnly = true
    	Me.CollectionIndex.Visible = false
    	'
    	'Cancel_Button
    	'
    	Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
    	Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
    	Me.Cancel_Button.Location = New System.Drawing.Point(5, 3)
    	Me.Cancel_Button.Name = "Cancel_Button"
    	Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
    	Me.Cancel_Button.TabIndex = 1
    	Me.Cancel_Button.Text = "Cancel"
    	'
    	'TableLayoutPanel1
    	'
    	Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
    	Me.TableLayoutPanel1.ColumnCount = 1
    	Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50!))
    	Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 0, 0)
    	Me.TableLayoutPanel1.Location = New System.Drawing.Point(586, 567)
    	Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
    	Me.TableLayoutPanel1.RowCount = 1
    	Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50!))
    	Me.TableLayoutPanel1.Size = New System.Drawing.Size(78, 29)
    	Me.TableLayoutPanel1.TabIndex = 0
    	'
    	'tableLayoutPanel2
    	'
    	Me.tableLayoutPanel2.ColumnCount = 2
    	Me.tableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.30189!))
    	Me.tableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.69811!))
    	Me.tableLayoutPanel2.Controls.Add(Me.exclusionEventsTextBox, 1, 2)
    	Me.tableLayoutPanel2.Controls.Add(Me.eventPatternTextBox, 1, 1)
    	Me.tableLayoutPanel2.Controls.Add(Me.reportMeasureLabel, 0, 0)
    	Me.tableLayoutPanel2.Controls.Add(Me.exclusionEventsLabel, 0, 2)
    	Me.tableLayoutPanel2.Controls.Add(Me.reportMeasureTextBox, 1, 0)
    	Me.tableLayoutPanel2.Controls.Add(Me.eventPatternLabel, 0, 1)
    	Me.tableLayoutPanel2.Location = New System.Drawing.Point(18, 13)
    	Me.tableLayoutPanel2.Name = "tableLayoutPanel2"
    	Me.tableLayoutPanel2.RowCount = 3
    	Me.tableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
    	Me.tableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
    	Me.tableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
    	Me.tableLayoutPanel2.Size = New System.Drawing.Size(696, 112)
    	Me.tableLayoutPanel2.TabIndex = 2
    	'
    	'exclusionEventsTextBox
    	'
    	Me.exclusionEventsTextBox.Cursor = System.Windows.Forms.Cursors.Default
    	Me.exclusionEventsTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    	Me.exclusionEventsTextBox.Location = New System.Drawing.Point(199, 77)
    	Me.exclusionEventsTextBox.Name = "exclusionEventsTextBox"
    	Me.exclusionEventsTextBox.ReadOnly = true
    	Me.exclusionEventsTextBox.Size = New System.Drawing.Size(437, 24)
    	Me.exclusionEventsTextBox.TabIndex = 5
    	'
    	'eventPatternTextBox
    	'
    	Me.eventPatternTextBox.Cursor = System.Windows.Forms.Cursors.Default
    	Me.eventPatternTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    	Me.eventPatternTextBox.Location = New System.Drawing.Point(199, 40)
    	Me.eventPatternTextBox.Name = "eventPatternTextBox"
    	Me.eventPatternTextBox.ReadOnly = true
    	Me.eventPatternTextBox.Size = New System.Drawing.Size(437, 24)
    	Me.eventPatternTextBox.TabIndex = 4
    	'
    	'reportMeasureLabel
    	'
    	Me.reportMeasureLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    	Me.reportMeasureLabel.Location = New System.Drawing.Point(3, 0)
    	Me.reportMeasureLabel.Name = "reportMeasureLabel"
    	Me.reportMeasureLabel.Size = New System.Drawing.Size(190, 37)
    	Me.reportMeasureLabel.TabIndex = 1
    	Me.reportMeasureLabel.Text = "Report Measure:"
    	Me.reportMeasureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    	'
    	'exclusionEventsLabel
    	'
    	Me.exclusionEventsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    	Me.exclusionEventsLabel.Location = New System.Drawing.Point(3, 74)
    	Me.exclusionEventsLabel.Name = "exclusionEventsLabel"
    	Me.exclusionEventsLabel.Size = New System.Drawing.Size(190, 38)
    	Me.exclusionEventsLabel.TabIndex = 3
    	Me.exclusionEventsLabel.Text = "Exclusion Events:"
    	Me.exclusionEventsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    	'
    	'reportMeasureTextBox
    	'
    	Me.reportMeasureTextBox.Cursor = System.Windows.Forms.Cursors.Default
    	Me.reportMeasureTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    	Me.reportMeasureTextBox.Location = New System.Drawing.Point(199, 3)
    	Me.reportMeasureTextBox.Name = "reportMeasureTextBox"
    	Me.reportMeasureTextBox.ReadOnly = true
    	Me.reportMeasureTextBox.Size = New System.Drawing.Size(437, 24)
    	Me.reportMeasureTextBox.TabIndex = 0
    	'
    	'eventPatternLabel
    	'
    	Me.eventPatternLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    	Me.eventPatternLabel.Location = New System.Drawing.Point(3, 37)
    	Me.eventPatternLabel.Name = "eventPatternLabel"
    	Me.eventPatternLabel.Size = New System.Drawing.Size(190, 37)
    	Me.eventPatternLabel.TabIndex = 2
    	Me.eventPatternLabel.Text = "Event Pattern:"
    	Me.eventPatternLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    	'
    	'formMeasurementDetail
    	'
    	Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
    	Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    	Me.CancelButton = Me.Cancel_Button
    	Me.ClientSize = New System.Drawing.Size(679, 608)
    	Me.Controls.Add(Me.tableLayoutPanel2)
    	Me.Controls.Add(Me.dgMeasureDetails)
    	Me.Controls.Add(Me.TableLayoutPanel1)
    	Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    	Me.MaximizeBox = false
    	Me.MinimizeBox = false
    	Me.Name = "formMeasurementDetail"
    	Me.ShowInTaskbar = false
    	Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    	Me.Text = "Measurement Details"

    	CType(Me.dgMeasureDetails,System.ComponentModel.ISupportInitialize).EndInit
    	Me.TableLayoutPanel1.ResumeLayout(false)
    	Me.tableLayoutPanel2.ResumeLayout(false)
    	Me.tableLayoutPanel2.PerformLayout
    	Me.ResumeLayout(false)
    End Sub
    Public reportMeasureTextBox As System.Windows.Forms.TextBox
    Private exclusionEventsLabel As System.Windows.Forms.Label
    Private reportMeasureLabel As System.Windows.Forms.Label
    Private eventPatternLabel As System.Windows.Forms.Label
    Public eventPatternTextBox As System.Windows.Forms.TextBox
    Public exclusionEventsTextBox As System.Windows.Forms.TextBox
    Private tableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Public WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Public WithEvents Cancel_Button As System.Windows.Forms.Button
    Public WithEvents dgMeasureDetails As System.Windows.Forms.DataGridView
    Public WithEvents DateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents Milliseconds As System.Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents LineNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents Duration As System.Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents CollectionIndex As System.Windows.Forms.DataGridViewTextBoxColumn

    
    Sub ReportMeasureTextBoxTextChanged(sender As Object, e As EventArgs)
    	
    End Sub
End Class
'End Namespace