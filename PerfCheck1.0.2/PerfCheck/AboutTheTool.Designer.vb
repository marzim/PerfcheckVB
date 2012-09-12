'
' Created by SharpDevelop.
' User: kj185009
' Date: 6/25/2012
' Time: 1:14 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Partial Class AboutTheTool
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutTheTool))
		Me.label1 = New System.Windows.Forms.Label()
		Me.lblCopyRight = New System.Windows.Forms.Label()
		Me.btnCloseAbout = New System.Windows.Forms.Button()
		Me.pictureBox1 = New System.Windows.Forms.PictureBox()
		Me.label3 = New System.Windows.Forms.Label()
		Me.lblVersion = New System.Windows.Forms.Label()
		CType(Me.pictureBox1,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'label1
		'
		Me.label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.label1.Location = New System.Drawing.Point(2, 137)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(78, 23)
		Me.label1.TabIndex = 1
		Me.label1.Text = "Version:"
		Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblCopyRight
		'
		Me.lblCopyRight.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblCopyRight.Location = New System.Drawing.Point(2, 174)
		Me.lblCopyRight.Name = "lblCopyRight"
		Me.lblCopyRight.Size = New System.Drawing.Size(285, 30)
		Me.lblCopyRight.TabIndex = 4
		Me.lblCopyRight.Text = "Copyright @ 2012 NCR-Cebu Development Center All Rights Reserved"
		Me.lblCopyRight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'btnCloseAbout
		'
		Me.btnCloseAbout.DialogResult = System.Windows.Forms.DialogResult.Ignore
		Me.btnCloseAbout.ImageAlign = System.Drawing.ContentAlignment.TopRight
		Me.btnCloseAbout.Location = New System.Drawing.Point(358, 189)
		Me.btnCloseAbout.Name = "btnCloseAbout"
		Me.btnCloseAbout.Size = New System.Drawing.Size(75, 23)
		Me.btnCloseAbout.TabIndex = 5
		Me.btnCloseAbout.Text = "OK"
		Me.btnCloseAbout.UseVisualStyleBackColor = true
		AddHandler Me.btnCloseAbout.Click, AddressOf Me.BtnCloseAboutClick
		'
		'pictureBox1
		'
		Me.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
		Me.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.pictureBox1.Image = CType(resources.GetObject("pictureBox1.Image"),System.Drawing.Image)
		Me.pictureBox1.Location = New System.Drawing.Point(0, 0)
		Me.pictureBox1.Name = "pictureBox1"
		Me.pictureBox1.Size = New System.Drawing.Size(455, 90)
		Me.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
		Me.pictureBox1.TabIndex = 7
		Me.pictureBox1.TabStop = false
		'
		'label3
		'
		Me.label3.Font = New System.Drawing.Font("Tahoma", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.label3.ImageAlign = System.Drawing.ContentAlignment.TopLeft
		Me.label3.Location = New System.Drawing.Point(0, 102)
		Me.label3.Name = "label3"
		Me.label3.Size = New System.Drawing.Size(433, 23)
		Me.label3.TabIndex = 8
		Me.label3.Text = "SSCO Application Performance Assessment Tool"
		Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblVersion
		'
		Me.lblVersion.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblVersion.Location = New System.Drawing.Point(59, 137)
		Me.lblVersion.Name = "lblVersion"
		Me.lblVersion.Size = New System.Drawing.Size(85, 23)
		Me.lblVersion.TabIndex = 9
		Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'AboutTheTool
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ClientSize = New System.Drawing.Size(443, 224)
		Me.Controls.Add(Me.lblVersion)
		Me.Controls.Add(Me.label3)
		Me.Controls.Add(Me.pictureBox1)
		Me.Controls.Add(Me.btnCloseAbout)
		Me.Controls.Add(Me.lblCopyRight)
		Me.Controls.Add(Me.label1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "AboutTheTool"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "About PerfCheck Tool"
		CType(Me.pictureBox1,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
	End Sub
	Private lblVersion As System.Windows.Forms.Label
	Private label3 As System.Windows.Forms.Label
	Private pictureBox1 As System.Windows.Forms.PictureBox
	Private btnCloseAbout As System.Windows.Forms.Button
	Private lblCopyRight As System.Windows.Forms.Label
	Private label1 As System.Windows.Forms.Label
End Class
