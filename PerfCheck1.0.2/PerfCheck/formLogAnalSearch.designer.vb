'Namespace PerfCheck	
	
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formLogAnalSearch
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
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    	Me.components = New System.ComponentModel.Container()
    	Dim dataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    	Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    	Me.DataGridView1 = New System.Windows.Forms.DataGridView()
    	Me.Measure = New System.Windows.Forms.DataGridViewTextBoxColumn()
    	Me.Count = New System.Windows.Forms.DataGridViewTextBoxColumn()
    	Me.Minimum = New System.Windows.Forms.DataGridViewTextBoxColumn()
    	Me.Maximum = New System.Windows.Forms.DataGridViewTextBoxColumn()
    	Me.Average = New System.Windows.Forms.DataGridViewTextBoxColumn()
    	Me.Std_Dev = New System.Windows.Forms.DataGridViewTextBoxColumn()
    	CType(Me.DataGridView1,System.ComponentModel.ISupportInitialize).BeginInit
    	Me.SuspendLayout
    	'
    	'DataGridView1
    	'
    	Me.DataGridView1.AllowUserToAddRows = false
    	Me.DataGridView1.AllowUserToDeleteRows = false
    	Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    	Me.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
    	Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    	Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Measure, Me.Count, Me.Minimum, Me.Maximum, Me.Average, Me.Std_Dev})
    	Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
    	Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
    	Me.DataGridView1.Margin = New System.Windows.Forms.Padding(1)
    	Me.DataGridView1.Name = "DataGridView1"
    	Me.DataGridView1.ReadOnly = true
    	dataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    	Me.DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1
    	Me.DataGridView1.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    	Me.DataGridView1.RowTemplate.Height = 18
    	Me.DataGridView1.Size = New System.Drawing.Size(784, 746)
    	Me.DataGridView1.TabIndex = 0
    	'
    	'Measure
    	'
    	Me.Measure.HeaderText = "Measure"
    	Me.Measure.Name = "Measure"
    	Me.Measure.ReadOnly = true
    	Me.Measure.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
    	Me.Measure.Width = 78
    	'
    	'Count
    	'
    	Me.Count.HeaderText = "Count"
    	Me.Count.Name = "Count"
    	Me.Count.ReadOnly = true
    	Me.Count.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
    	Me.Count.Width = 60
    	'
    	'Minimum
    	'
    	Me.Minimum.HeaderText = "Minimum"
    	Me.Minimum.Name = "Minimum"
    	Me.Minimum.ReadOnly = true
    	Me.Minimum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
    	Me.Minimum.Width = 82
    	'
    	'Maximum
    	'
    	Me.Maximum.HeaderText = "Maximum"
    	Me.Maximum.Name = "Maximum"
    	Me.Maximum.ReadOnly = true
    	Me.Maximum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
    	Me.Maximum.Width = 86
    	'
    	'Average
    	'
    	Me.Average.HeaderText = "Average"
    	Me.Average.Name = "Average"
    	Me.Average.ReadOnly = true
    	Me.Average.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
    	Me.Average.Width = 76
    	'
    	'Std_Dev
    	'
    	Me.Std_Dev.HeaderText = "Std Dev"
    	Me.Std_Dev.Name = "Std_Dev"
    	Me.Std_Dev.ReadOnly = true
    	Me.Std_Dev.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
    	Me.Std_Dev.Width = 73
    	'
    	'formLogAnalSearch
    	'
    	Me.AutoScaleDimensions = New System.Drawing.SizeF(10!, 19!)
    	Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    	Me.BackColor = System.Drawing.SystemColors.Control
    	Me.ClientSize = New System.Drawing.Size(784, 746)
    	Me.Controls.Add(Me.DataGridView1)
    	Me.Cursor = System.Windows.Forms.Cursors.Default
    	Me.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    	Me.Location = New System.Drawing.Point(4, 23)
    	Me.Margin = New System.Windows.Forms.Padding(4)
    	Me.Name = "formLogAnalSearch"
    	Me.RightToLeft = System.Windows.Forms.RightToLeft.No
    	Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    	Me.Text = "Pattern Search Results"
    	AddHandler FormClosing, AddressOf Me.formClosing_Event
    	AddHandler Load, AddressOf Me.FormLogAnalSearchLoad
    	CType(Me.DataGridView1,System.ComponentModel.ISupportInitialize).EndInit
    	Me.ResumeLayout(false)
    End Sub
    Public WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Private Measure As System.Windows.Forms.DataGridViewTextBoxColumn
    Private Count As System.Windows.Forms.DataGridViewTextBoxColumn
    Private Minimum As System.Windows.Forms.DataGridViewTextBoxColumn
    Private Maximum As System.Windows.Forms.DataGridViewTextBoxColumn
    Private Average As System.Windows.Forms.DataGridViewTextBoxColumn
    Private Std_Dev As System.Windows.Forms.DataGridViewTextBoxColumn
#End Region
End Class
'End Namespace