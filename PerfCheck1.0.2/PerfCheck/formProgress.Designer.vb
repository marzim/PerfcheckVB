'
' Created by SharpDevelop.
' User: tf185022
' Date: 6/19/2012
' Time: 5:09 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Partial Class formProgress
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
		Me.progressBar1 = New System.Windows.Forms.ProgressBar
		Me.labelProcessing = New System.Windows.Forms.Label
		Me.SuspendLayout
		'
		'progressBar1
		'
		Me.progressBar1.Location = New System.Drawing.Point(12, 35)
		Me.progressBar1.Name = "progressBar1"
		Me.progressBar1.Size = New System.Drawing.Size(268, 23)
		Me.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
		Me.progressBar1.TabIndex = 0
		'
		'labelProcessing
		'
		Me.labelProcessing.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.labelProcessing.ImageAlign = System.Drawing.ContentAlignment.TopLeft
		Me.labelProcessing.Location = New System.Drawing.Point(12, 9)
		Me.labelProcessing.Name = "labelProcessing"
		Me.labelProcessing.Size = New System.Drawing.Size(100, 23)
		Me.labelProcessing.TabIndex = 1
		Me.labelProcessing.Text = "Please wait..."
		Me.labelProcessing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'formProgress
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(289, 67)
		Me.Controls.Add(Me.labelProcessing)
		Me.Controls.Add(Me.progressBar1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
		Me.MaximizeBox = false
		Me.Name = "formProgress"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Progress"
		Me.ResumeLayout(false)
	End Sub
	Private labelProcessing As System.Windows.Forms.Label
	Private progressBar1 As System.Windows.Forms.ProgressBar
End Class
