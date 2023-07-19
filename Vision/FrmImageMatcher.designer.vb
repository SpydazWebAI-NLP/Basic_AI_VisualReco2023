<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImageMatcher
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmImageMatcher))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.ButtonOpenImageB = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.ButtonOpenImageA = New System.Windows.Forms.Button()
        Me.InputImageB = New System.Windows.Forms.PictureBox()
        Me.InputImageA = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.AllowedErrors = New System.Windows.Forms.NumericUpDown()
        Me.ButtonCompareImage = New System.Windows.Forms.Button()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.InputImageB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InputImageA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.AllowedErrors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Black
        Me.GroupBox3.BackgroundImage = Global.Basic_AI_VisualReco2023.My.Resources.Resources.Console_C
        Me.GroupBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox3.Controls.Add(Me.GroupBox6)
        Me.GroupBox3.Controls.Add(Me.GroupBox5)
        Me.GroupBox3.Controls.Add(Me.InputImageB)
        Me.GroupBox3.Controls.Add(Me.InputImageA)
        Me.GroupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox3.ForeColor = System.Drawing.Color.White
        Me.GroupBox3.Location = New System.Drawing.Point(13, 17)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.GroupBox3.Size = New System.Drawing.Size(697, 531)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Compare"
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox6.BackgroundImage = Global.Basic_AI_VisualReco2023.My.Resources.Resources.Console_A
        Me.GroupBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox6.Controls.Add(Me.ButtonOpenImageB)
        Me.GroupBox6.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupBox6.Location = New System.Drawing.Point(383, 381)
        Me.GroupBox6.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox6.Size = New System.Drawing.Size(304, 108)
        Me.GroupBox6.TabIndex = 3
        Me.GroupBox6.TabStop = False
        '
        'ButtonOpenImageB
        '
        Me.ButtonOpenImageB.BackColor = System.Drawing.Color.Black
        Me.ButtonOpenImageB.BackgroundImage = Global.Basic_AI_VisualReco2023.My.Resources.Resources.App_Texturex16
        Me.ButtonOpenImageB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonOpenImageB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonOpenImageB.Image = CType(resources.GetObject("ButtonOpenImageB.Image"), System.Drawing.Image)
        Me.ButtonOpenImageB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonOpenImageB.Location = New System.Drawing.Point(70, 40)
        Me.ButtonOpenImageB.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButtonOpenImageB.Name = "ButtonOpenImageB"
        Me.ButtonOpenImageB.Size = New System.Drawing.Size(175, 48)
        Me.ButtonOpenImageB.TabIndex = 2
        Me.ButtonOpenImageB.Text = "OpenFolder"
        Me.ButtonOpenImageB.UseVisualStyleBackColor = False
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox5.BackgroundImage = Global.Basic_AI_VisualReco2023.My.Resources.Resources.Console_A
        Me.GroupBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox5.Controls.Add(Me.ButtonOpenImageA)
        Me.GroupBox5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupBox5.Location = New System.Drawing.Point(70, 381)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox5.Size = New System.Drawing.Size(308, 108)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        '
        'ButtonOpenImageA
        '
        Me.ButtonOpenImageA.BackColor = System.Drawing.Color.Black
        Me.ButtonOpenImageA.BackgroundImage = Global.Basic_AI_VisualReco2023.My.Resources.Resources.App_Texturex16
        Me.ButtonOpenImageA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonOpenImageA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonOpenImageA.Image = CType(resources.GetObject("ButtonOpenImageA.Image"), System.Drawing.Image)
        Me.ButtonOpenImageA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonOpenImageA.Location = New System.Drawing.Point(70, 40)
        Me.ButtonOpenImageA.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButtonOpenImageA.Name = "ButtonOpenImageA"
        Me.ButtonOpenImageA.Size = New System.Drawing.Size(175, 48)
        Me.ButtonOpenImageA.TabIndex = 3
        Me.ButtonOpenImageA.Text = "OpenImage"
        Me.ButtonOpenImageA.UseVisualStyleBackColor = False
        '
        'InputImageB
        '
        Me.InputImageB.BackColor = System.Drawing.SystemColors.Info
        Me.InputImageB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.InputImageB.Location = New System.Drawing.Point(383, 53)
        Me.InputImageB.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.InputImageB.Name = "InputImageB"
        Me.InputImageB.Size = New System.Drawing.Size(304, 318)
        Me.InputImageB.TabIndex = 0
        Me.InputImageB.TabStop = False
        '
        'InputImageA
        '
        Me.InputImageA.BackColor = System.Drawing.SystemColors.Info
        Me.InputImageA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.InputImageA.Location = New System.Drawing.Point(70, 53)
        Me.InputImageA.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.InputImageA.Name = "InputImageA"
        Me.InputImageA.Size = New System.Drawing.Size(308, 318)
        Me.InputImageA.TabIndex = 0
        Me.InputImageA.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox2.BackgroundImage = Global.Basic_AI_VisualReco2023.My.Resources.Resources.BackGround_BluPrint
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(718, 17)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.GroupBox2.Size = New System.Drawing.Size(206, 531)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Controls"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 124)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 19)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "File Count : "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(41, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 19)
        Me.Label1.TabIndex = 2
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.SteelBlue
        Me.GroupBox4.BackgroundImage = Global.Basic_AI_VisualReco2023.My.Resources.Resources.App_Texturex16
        Me.GroupBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.AllowedErrors)
        Me.GroupBox4.Controls.Add(Me.ButtonCompareImage)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox4.Location = New System.Drawing.Point(4, 355)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox4.Size = New System.Drawing.Size(198, 170)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Compare"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 19)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Allowed Errors"
        '
        'AllowedErrors
        '
        Me.AllowedErrors.Location = New System.Drawing.Point(64, 116)
        Me.AllowedErrors.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.AllowedErrors.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.AllowedErrors.Name = "AllowedErrors"
        Me.AllowedErrors.Size = New System.Drawing.Size(60, 26)
        Me.AllowedErrors.TabIndex = 3
        '
        'ButtonCompareImage
        '
        Me.ButtonCompareImage.BackColor = System.Drawing.Color.Black
        Me.ButtonCompareImage.Enabled = False
        Me.ButtonCompareImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCompareImage.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ButtonCompareImage.Image = Global.Basic_AI_VisualReco2023.My.Resources.Resources.Console_Left
        Me.ButtonCompareImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonCompareImage.Location = New System.Drawing.Point(10, 37)
        Me.ButtonCompareImage.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButtonCompareImage.Name = "ButtonCompareImage"
        Me.ButtonCompareImage.Size = New System.Drawing.Size(179, 40)
        Me.ButtonCompareImage.TabIndex = 0
        Me.ButtonCompareImage.Text = "CompareImage"
        Me.ButtonCompareImage.UseVisualStyleBackColor = False
        '
        'FrmImageMatcher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BackgroundImage = Global.Basic_AI_VisualReco2023.My.Resources.Resources.BackGround_BluPrint
        Me.ClientSize = New System.Drawing.Size(947, 569)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Font = New System.Drawing.Font("Comic Sans MS", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmImageMatcher"
        Me.Text = "Image Matcher"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.InputImageB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InputImageA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.AllowedErrors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonOpenImageB As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonOpenImageA As System.Windows.Forms.Button
    Friend WithEvents InputImageB As System.Windows.Forms.PictureBox
    Friend WithEvents InputImageA As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents AllowedErrors As System.Windows.Forms.NumericUpDown
    Friend WithEvents ButtonCompareImage As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
