Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCompare
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCompare))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.AllowedErrors = New System.Windows.Forms.NumericUpDown()
        Me.ButtonCompareImage = New System.Windows.Forms.Button()
        Me.ButtonKirsh = New System.Windows.Forms.Button()
        Me.ButtonPrewitt = New System.Windows.Forms.Button()
        Me.ButtonSobel = New System.Windows.Forms.Button()
        Me.ButtonVerticalEdges = New System.Windows.Forms.Button()
        Me.ButtonHorizontalEdges = New System.Windows.Forms.Button()
        Me.ButtonGreyScale = New System.Windows.Forms.Button()
        Me.ButtonEdgeEnhance = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.FilterB = New System.Windows.Forms.CheckBox()
        Me.ButtonOpenCompareImageB = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.FilterA = New System.Windows.Forms.CheckBox()
        Me.ButtonOpenCompareImageA = New System.Windows.Forms.Button()
        Me.InputCompareImageB = New System.Windows.Forms.PictureBox()
        Me.InputCompareImageA = New System.Windows.Forms.PictureBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.ButtonSaveImage = New System.Windows.Forms.Button()
        Me.LabelDisplayMatch = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OutputImage = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.AllowedErrors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.InputCompareImageB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InputCompareImageA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        CType(Me.OutputImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.GroupBox1.BackgroundImage = Global.Basic_AI_VisualReco2023.My.Resources.Resources.Console_B
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GroupBox1.Location = New System.Drawing.Point(15, 19)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(10)
        Me.GroupBox1.Size = New System.Drawing.Size(940, 603)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Image Recognition"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox2.BackgroundImage = Global.Basic_AI_VisualReco2023.My.Resources.Resources.BackGround_BluPrint
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.ButtonKirsh)
        Me.GroupBox2.Controls.Add(Me.ButtonPrewitt)
        Me.GroupBox2.Controls.Add(Me.ButtonSobel)
        Me.GroupBox2.Controls.Add(Me.ButtonVerticalEdges)
        Me.GroupBox2.Controls.Add(Me.ButtonHorizontalEdges)
        Me.GroupBox2.Controls.Add(Me.ButtonGreyScale)
        Me.GroupBox2.Controls.Add(Me.ButtonEdgeEnhance)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(734, 29)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Size = New System.Drawing.Size(196, 564)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Filters"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Black
        Me.GroupBox4.BackgroundImage = Global.Basic_AI_VisualReco2023.My.Resources.Resources.Console_C
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.AllowedErrors)
        Me.GroupBox4.Controls.Add(Me.ButtonCompareImage)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox4.ForeColor = System.Drawing.Color.White
        Me.GroupBox4.Location = New System.Drawing.Point(4, 416)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(188, 143)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Compare"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 38)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Allowed " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Errors"
        '
        'AllowedErrors
        '
        Me.AllowedErrors.Location = New System.Drawing.Point(116, 104)
        Me.AllowedErrors.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.AllowedErrors.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.AllowedErrors.Name = "AllowedErrors"
        Me.AllowedErrors.Size = New System.Drawing.Size(60, 26)
        Me.AllowedErrors.TabIndex = 3
        '
        'ButtonCompareImage
        '
        Me.ButtonCompareImage.BackColor = System.Drawing.Color.Black
        Me.ButtonCompareImage.BackgroundImage = Global.Basic_AI_VisualReco2023.My.Resources.Resources.BackGround_BluPrint
        Me.ButtonCompareImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonCompareImage.ForeColor = System.Drawing.Color.White
        Me.ButtonCompareImage.Location = New System.Drawing.Point(13, 31)
        Me.ButtonCompareImage.Name = "ButtonCompareImage"
        Me.ButtonCompareImage.Size = New System.Drawing.Size(135, 56)
        Me.ButtonCompareImage.TabIndex = 0
        Me.ButtonCompareImage.Text = "CompareImage"
        Me.ButtonCompareImage.UseVisualStyleBackColor = False
        '
        'ButtonKirsh
        '
        Me.ButtonKirsh.BackColor = System.Drawing.Color.Black
        Me.ButtonKirsh.BackgroundImage = CType(resources.GetObject("ButtonKirsh.BackgroundImage"), System.Drawing.Image)
        Me.ButtonKirsh.ForeColor = System.Drawing.Color.White
        Me.ButtonKirsh.Location = New System.Drawing.Point(17, 244)
        Me.ButtonKirsh.Name = "ButtonKirsh"
        Me.ButtonKirsh.Size = New System.Drawing.Size(135, 34)
        Me.ButtonKirsh.TabIndex = 0
        Me.ButtonKirsh.Text = "Kirsh"
        Me.ButtonKirsh.UseVisualStyleBackColor = False
        '
        'ButtonPrewitt
        '
        Me.ButtonPrewitt.BackColor = System.Drawing.Color.Black
        Me.ButtonPrewitt.BackgroundImage = CType(resources.GetObject("ButtonPrewitt.BackgroundImage"), System.Drawing.Image)
        Me.ButtonPrewitt.ForeColor = System.Drawing.Color.White
        Me.ButtonPrewitt.Location = New System.Drawing.Point(17, 346)
        Me.ButtonPrewitt.Name = "ButtonPrewitt"
        Me.ButtonPrewitt.Size = New System.Drawing.Size(135, 34)
        Me.ButtonPrewitt.TabIndex = 0
        Me.ButtonPrewitt.Text = "Prewitt"
        Me.ButtonPrewitt.UseVisualStyleBackColor = False
        '
        'ButtonSobel
        '
        Me.ButtonSobel.BackColor = System.Drawing.Color.Black
        Me.ButtonSobel.BackgroundImage = CType(resources.GetObject("ButtonSobel.BackgroundImage"), System.Drawing.Image)
        Me.ButtonSobel.ForeColor = System.Drawing.Color.White
        Me.ButtonSobel.Location = New System.Drawing.Point(17, 295)
        Me.ButtonSobel.Name = "ButtonSobel"
        Me.ButtonSobel.Size = New System.Drawing.Size(135, 34)
        Me.ButtonSobel.TabIndex = 0
        Me.ButtonSobel.Text = "Sobel"
        Me.ButtonSobel.UseVisualStyleBackColor = False
        '
        'ButtonVerticalEdges
        '
        Me.ButtonVerticalEdges.BackColor = System.Drawing.Color.Black
        Me.ButtonVerticalEdges.BackgroundImage = CType(resources.GetObject("ButtonVerticalEdges.BackgroundImage"), System.Drawing.Image)
        Me.ButtonVerticalEdges.ForeColor = System.Drawing.Color.White
        Me.ButtonVerticalEdges.Location = New System.Drawing.Point(17, 193)
        Me.ButtonVerticalEdges.Name = "ButtonVerticalEdges"
        Me.ButtonVerticalEdges.Size = New System.Drawing.Size(135, 34)
        Me.ButtonVerticalEdges.TabIndex = 0
        Me.ButtonVerticalEdges.Text = "VerticalEdges"
        Me.ButtonVerticalEdges.UseVisualStyleBackColor = False
        '
        'ButtonHorizontalEdges
        '
        Me.ButtonHorizontalEdges.BackColor = System.Drawing.Color.Black
        Me.ButtonHorizontalEdges.BackgroundImage = CType(resources.GetObject("ButtonHorizontalEdges.BackgroundImage"), System.Drawing.Image)
        Me.ButtonHorizontalEdges.ForeColor = System.Drawing.Color.White
        Me.ButtonHorizontalEdges.Location = New System.Drawing.Point(17, 142)
        Me.ButtonHorizontalEdges.Name = "ButtonHorizontalEdges"
        Me.ButtonHorizontalEdges.Size = New System.Drawing.Size(135, 34)
        Me.ButtonHorizontalEdges.TabIndex = 0
        Me.ButtonHorizontalEdges.Text = "HorizontalEdges"
        Me.ButtonHorizontalEdges.UseVisualStyleBackColor = False
        '
        'ButtonGreyScale
        '
        Me.ButtonGreyScale.BackColor = System.Drawing.Color.Black
        Me.ButtonGreyScale.BackgroundImage = CType(resources.GetObject("ButtonGreyScale.BackgroundImage"), System.Drawing.Image)
        Me.ButtonGreyScale.ForeColor = System.Drawing.Color.White
        Me.ButtonGreyScale.Location = New System.Drawing.Point(17, 91)
        Me.ButtonGreyScale.Name = "ButtonGreyScale"
        Me.ButtonGreyScale.Size = New System.Drawing.Size(135, 34)
        Me.ButtonGreyScale.TabIndex = 0
        Me.ButtonGreyScale.Text = "GreyScale"
        Me.ButtonGreyScale.UseVisualStyleBackColor = False
        '
        'ButtonEdgeEnhance
        '
        Me.ButtonEdgeEnhance.BackColor = System.Drawing.Color.Black
        Me.ButtonEdgeEnhance.BackgroundImage = CType(resources.GetObject("ButtonEdgeEnhance.BackgroundImage"), System.Drawing.Image)
        Me.ButtonEdgeEnhance.ForeColor = System.Drawing.Color.White
        Me.ButtonEdgeEnhance.Location = New System.Drawing.Point(17, 40)
        Me.ButtonEdgeEnhance.Name = "ButtonEdgeEnhance"
        Me.ButtonEdgeEnhance.Size = New System.Drawing.Size(135, 34)
        Me.ButtonEdgeEnhance.TabIndex = 0
        Me.ButtonEdgeEnhance.Text = "EdgeEnhance"
        Me.ButtonEdgeEnhance.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox3.BackgroundImage = Global.Basic_AI_VisualReco2023.My.Resources.Resources.Console_C
        Me.GroupBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox3.Controls.Add(Me.GroupBox6)
        Me.GroupBox3.Controls.Add(Me.GroupBox5)
        Me.GroupBox3.Controls.Add(Me.InputCompareImageB)
        Me.GroupBox3.Controls.Add(Me.InputCompareImageA)
        Me.GroupBox3.ForeColor = System.Drawing.Color.White
        Me.GroupBox3.Location = New System.Drawing.Point(20, 33)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox3.Size = New System.Drawing.Size(697, 534)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Compare"
        '
        'GroupBox6
        '
        Me.GroupBox6.BackgroundImage = CType(resources.GetObject("GroupBox6.BackgroundImage"), System.Drawing.Image)
        Me.GroupBox6.Controls.Add(Me.FilterB)
        Me.GroupBox6.Controls.Add(Me.ButtonOpenCompareImageB)
        Me.GroupBox6.ForeColor = System.Drawing.Color.White
        Me.GroupBox6.Location = New System.Drawing.Point(382, 339)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(304, 121)
        Me.GroupBox6.TabIndex = 3
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "ImageB"
        '
        'FilterB
        '
        Me.FilterB.AutoSize = True
        Me.FilterB.BackgroundImage = CType(resources.GetObject("FilterB.BackgroundImage"), System.Drawing.Image)
        Me.FilterB.Location = New System.Drawing.Point(6, 86)
        Me.FilterB.Name = "FilterB"
        Me.FilterB.Size = New System.Drawing.Size(103, 23)
        Me.FilterB.TabIndex = 3
        Me.FilterB.Text = "ApplyFilter"
        Me.FilterB.UseVisualStyleBackColor = True
        '
        'ButtonOpenCompareImageB
        '
        Me.ButtonOpenCompareImageB.BackgroundImage = CType(resources.GetObject("ButtonOpenCompareImageB.BackgroundImage"), System.Drawing.Image)
        Me.ButtonOpenCompareImageB.Location = New System.Drawing.Point(6, 34)
        Me.ButtonOpenCompareImageB.Name = "ButtonOpenCompareImageB"
        Me.ButtonOpenCompareImageB.Size = New System.Drawing.Size(163, 34)
        Me.ButtonOpenCompareImageB.TabIndex = 2
        Me.ButtonOpenCompareImageB.Text = "OpenImage"
        Me.ButtonOpenCompareImageB.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.BackgroundImage = CType(resources.GetObject("GroupBox5.BackgroundImage"), System.Drawing.Image)
        Me.GroupBox5.Controls.Add(Me.FilterA)
        Me.GroupBox5.Controls.Add(Me.ButtonOpenCompareImageA)
        Me.GroupBox5.ForeColor = System.Drawing.Color.White
        Me.GroupBox5.Location = New System.Drawing.Point(70, 339)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(308, 121)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "ImageA"
        '
        'FilterA
        '
        Me.FilterA.AutoSize = True
        Me.FilterA.BackgroundImage = CType(resources.GetObject("FilterA.BackgroundImage"), System.Drawing.Image)
        Me.FilterA.Location = New System.Drawing.Point(6, 86)
        Me.FilterA.Name = "FilterA"
        Me.FilterA.Size = New System.Drawing.Size(103, 23)
        Me.FilterA.TabIndex = 4
        Me.FilterA.Text = "ApplyFilter"
        Me.FilterA.UseVisualStyleBackColor = True
        '
        'ButtonOpenCompareImageA
        '
        Me.ButtonOpenCompareImageA.BackgroundImage = CType(resources.GetObject("ButtonOpenCompareImageA.BackgroundImage"), System.Drawing.Image)
        Me.ButtonOpenCompareImageA.Location = New System.Drawing.Point(6, 34)
        Me.ButtonOpenCompareImageA.Name = "ButtonOpenCompareImageA"
        Me.ButtonOpenCompareImageA.Size = New System.Drawing.Size(163, 34)
        Me.ButtonOpenCompareImageA.TabIndex = 3
        Me.ButtonOpenCompareImageA.Text = "OpenImage"
        Me.ButtonOpenCompareImageA.UseVisualStyleBackColor = True
        '
        'InputCompareImageB
        '
        Me.InputCompareImageB.BackColor = System.Drawing.SystemColors.Info
        Me.InputCompareImageB.Location = New System.Drawing.Point(382, 63)
        Me.InputCompareImageB.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.InputCompareImageB.Name = "InputCompareImageB"
        Me.InputCompareImageB.Size = New System.Drawing.Size(304, 268)
        Me.InputCompareImageB.TabIndex = 0
        Me.InputCompareImageB.TabStop = False
        '
        'InputCompareImageA
        '
        Me.InputCompareImageA.BackColor = System.Drawing.SystemColors.Info
        Me.InputCompareImageA.Location = New System.Drawing.Point(70, 63)
        Me.InputCompareImageA.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.InputCompareImageA.Name = "InputCompareImageA"
        Me.InputCompareImageA.Size = New System.Drawing.Size(308, 268)
        Me.InputCompareImageA.TabIndex = 0
        Me.InputCompareImageA.TabStop = False
        '
        'GroupBox7
        '
        Me.GroupBox7.BackgroundImage = Global.Basic_AI_VisualReco2023.My.Resources.Resources.Console_A
        Me.GroupBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox7.Controls.Add(Me.GroupBox8)
        Me.GroupBox7.Controls.Add(Me.Label1)
        Me.GroupBox7.Controls.Add(Me.OutputImage)
        Me.GroupBox7.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox7.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GroupBox7.Location = New System.Drawing.Point(925, 0)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(617, 638)
        Me.GroupBox7.TabIndex = 1
        Me.GroupBox7.TabStop = False
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox8.BackgroundImage = Global.Basic_AI_VisualReco2023.My.Resources.Resources.Console_A
        Me.GroupBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox8.Controls.Add(Me.ButtonSaveImage)
        Me.GroupBox8.Controls.Add(Me.LabelDisplayMatch)
        Me.GroupBox8.Location = New System.Drawing.Point(147, 511)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(351, 76)
        Me.GroupBox8.TabIndex = 2
        Me.GroupBox8.TabStop = False
        '
        'ButtonSaveImage
        '
        Me.ButtonSaveImage.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ButtonSaveImage.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ButtonSaveImage.Location = New System.Drawing.Point(105, 9)
        Me.ButtonSaveImage.Name = "ButtonSaveImage"
        Me.ButtonSaveImage.Size = New System.Drawing.Size(131, 34)
        Me.ButtonSaveImage.TabIndex = 3
        Me.ButtonSaveImage.Text = "SaveImage"
        Me.ButtonSaveImage.UseVisualStyleBackColor = False
        '
        'LabelDisplayMatch
        '
        Me.LabelDisplayMatch.AutoSize = True
        Me.LabelDisplayMatch.Font = New System.Drawing.Font("Comic Sans MS", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDisplayMatch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LabelDisplayMatch.Location = New System.Drawing.Point(102, 46)
        Me.LabelDisplayMatch.Name = "LabelDisplayMatch"
        Me.LabelDisplayMatch.Size = New System.Drawing.Size(134, 16)
        Me.LabelDisplayMatch.TabIndex = 4
        Me.LabelDisplayMatch.Text = "The image is a Match"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(63, -2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(233, 38)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "The difference between images" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " are shown in the display window"
        '
        'OutputImage
        '
        Me.OutputImage.BackColor = System.Drawing.SystemColors.Info
        Me.OutputImage.Location = New System.Drawing.Point(102, 49)
        Me.OutputImage.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.OutputImage.Name = "OutputImage"
        Me.OutputImage.Size = New System.Drawing.Size(452, 443)
        Me.OutputImage.TabIndex = 0
        Me.OutputImage.TabStop = False
        '
        'FrmCompare
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BackgroundImage = Global.Basic_AI_VisualReco2023.My.Resources.Resources.BackGround_BluPrint
        Me.ClientSize = New System.Drawing.Size(1542, 638)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Comic Sans MS", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "FrmCompare"
        Me.Text = "FrmCompare"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.AllowedErrors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.InputCompareImageB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InputCompareImageA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        CType(Me.OutputImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents InputCompareImageB As System.Windows.Forms.PictureBox
    Friend WithEvents InputCompareImageA As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonKirsh As System.Windows.Forms.Button
    Friend WithEvents ButtonPrewitt As System.Windows.Forms.Button
    Friend WithEvents ButtonSobel As System.Windows.Forms.Button
    Friend WithEvents ButtonVerticalEdges As System.Windows.Forms.Button
    Friend WithEvents ButtonHorizontalEdges As System.Windows.Forms.Button
    Friend WithEvents ButtonGreyScale As System.Windows.Forms.Button
    Friend WithEvents ButtonEdgeEnhance As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents FilterB As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonOpenCompareImageB As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents FilterA As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonOpenCompareImageA As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonSaveImage As System.Windows.Forms.Button
    Friend WithEvents LabelDisplayMatch As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OutputImage As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents AllowedErrors As NumericUpDown
    Friend WithEvents ButtonCompareImage As Button
End Class
