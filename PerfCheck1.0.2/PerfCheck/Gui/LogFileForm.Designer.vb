'
' Created by SharpDevelop.
' User: mc185104
' Date: 8/7/2012
' Time: 9:05 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Partial Class LogFileForm
	Inherits System.Windows.Forms.Form
	
	''' <summary>
	''' Designer variable used to keep track of non-visual components.
	''' </summary>
	Private components As System.ComponentModel.IContainer
	
	''' <summary>
	''' Disposes resources used by the form.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If components IsNot Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub
	
	''' <summary>
	''' This method is required for Windows Forms designer support.
	''' Do not change the method contents inside the source code editor. The Forms designer might
	''' not be able to load this method if it was changed manually.
	''' </summary>
	Private Sub InitializeComponent()
		Me.richTextBox1 = New System.Windows.Forms.RichTextBox()
		Me.SuspendLayout
		'
		'richTextBox1
		'
		Me.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.richTextBox1.Location = New System.Drawing.Point(0, 0)
		Me.richTextBox1.Name = "richTextBox1"
		Me.richTextBox1.Size = New System.Drawing.Size(707, 535)
		Me.richTextBox1.TabIndex = 0
		Me.richTextBox1.Text = ""
		Me.richTextBox1.WordWrap = false
		'
		'LogFileForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(707, 535)
		Me.Controls.Add(Me.richTextBox1)
		Me.Name = "LogFileForm"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Log File"
		AddHandler Load, AddressOf Me.LogFileFormLoad
		Me.ResumeLayout(false)
	End Sub
	Private richTextBox1 As System.Windows.Forms.RichTextBox
End Class
