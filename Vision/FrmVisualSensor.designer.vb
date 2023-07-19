Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmVisualSensor
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmVisualSensor))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.pView = New System.Windows.Forms.PictureBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.opt2 = New System.Windows.Forms.RadioButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lMovements = New System.Windows.Forms.TextBox()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.ButtonDetect = New System.Windows.Forms.Button()
        Me.cmd3 = New System.Windows.Forms.Button()
        Me.cmd2 = New System.Windows.Forms.Button()
        Me.cmd1 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lst1 = New System.Windows.Forms.ListBox()
        Me.sfdImages = New System.Windows.Forms.SaveFileDialog()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.opt4 = New System.Windows.Forms.RadioButton()
        Me.opt3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.opt1 = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.pView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.GroupBox1.BackgroundImage = Global.Basic_AI_VisualReco2023.My.Resources.Resources.BackGround_BluPrint
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Comic Sans MS", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(670, 429)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Input Sensors"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackgroundImage = Global.Basic_AI_VisualReco2023.My.Resources.Resources.BackGround_BluPrint
        Me.GroupBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox3.Controls.Add(Me.pView)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GroupBox3.Location = New System.Drawing.Point(2, 35)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.Size = New System.Drawing.Size(666, 267)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Visual Input"
        '
        'pView
        '
        Me.pView.BackColor = System.Drawing.Color.Transparent
        Me.pView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pView.Location = New System.Drawing.Point(2, 17)
        Me.pView.Margin = New System.Windows.Forms.Padding(2)
        Me.pView.Name = "pView"
        Me.pView.Size = New System.Drawing.Size(662, 248)
        Me.pView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pView.TabIndex = 3
        Me.pView.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.BackgroundImage = Global.Basic_AI_VisualReco2023.My.Resources.Resources.BackGround_BluPrint
        Me.GroupBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox5.Controls.Add(Me.opt2)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox5.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GroupBox5.Location = New System.Drawing.Point(2, 302)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox5.Size = New System.Drawing.Size(666, 18)
        Me.GroupBox5.TabIndex = 5
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Graphics Effect"
        '
        'opt2
        '
        Me.opt2.AutoSize = True
        Me.opt2.Checked = True
        Me.opt2.Location = New System.Drawing.Point(6, 17)
        Me.opt2.Margin = New System.Windows.Forms.Padding(2)
        Me.opt2.Name = "opt2"
        Me.opt2.Size = New System.Drawing.Size(64, 20)
        Me.opt2.TabIndex = 7
        Me.opt2.TabStop = True
        Me.opt2.Text = "&Normal"
        Me.opt2.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.BackgroundImage = Global.Basic_AI_VisualReco2023.My.Resources.Resources.BackGround_BluPrint
        Me.GroupBox4.Controls.Add(Me.opt4)
        Me.GroupBox4.Controls.Add(Me.opt3)
        Me.GroupBox4.Controls.Add(Me.RadioButton1)
        Me.GroupBox4.Controls.Add(Me.opt1)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.lMovements)
        Me.GroupBox4.Controls.Add(Me.lblInfo)
        Me.GroupBox4.Controls.Add(Me.ButtonDetect)
        Me.GroupBox4.Controls.Add(Me.cmd3)
        Me.GroupBox4.Controls.Add(Me.cmd2)
        Me.GroupBox4.Controls.Add(Me.cmd1)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox4.ForeColor = System.Drawing.SystemColors.Control
        Me.GroupBox4.Location = New System.Drawing.Point(2, 320)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox4.Size = New System.Drawing.Size(666, 107)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Main Control"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(556, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Movement"
        '
        'lMovements
        '
        Me.lMovements.Location = New System.Drawing.Point(556, 36)
        Me.lMovements.Name = "lMovements"
        Me.lMovements.Size = New System.Drawing.Size(100, 22)
        Me.lMovements.TabIndex = 19
        '
        'lblInfo
        '
        Me.lblInfo.BackColor = System.Drawing.Color.Black
        Me.lblInfo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblInfo.Font = New System.Drawing.Font("Consolas", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.ForeColor = System.Drawing.Color.White
        Me.lblInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblInfo.Location = New System.Drawing.Point(2, 76)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(662, 29)
        Me.lblInfo.TabIndex = 18
        '
        'ButtonDetect
        '
        Me.ButtonDetect.BackColor = System.Drawing.SystemColors.Desktop
        Me.ButtonDetect.BackgroundImage = CType(resources.GetObject("ButtonDetect.BackgroundImage"), System.Drawing.Image)
        Me.ButtonDetect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonDetect.Enabled = False
        Me.ButtonDetect.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ButtonDetect.Location = New System.Drawing.Point(228, 16)
        Me.ButtonDetect.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonDetect.Name = "ButtonDetect"
        Me.ButtonDetect.Size = New System.Drawing.Size(69, 29)
        Me.ButtonDetect.TabIndex = 7
        Me.ButtonDetect.Text = "D&etect"
        Me.ButtonDetect.UseVisualStyleBackColor = False
        '
        'cmd3
        '
        Me.cmd3.BackColor = System.Drawing.SystemColors.Desktop
        Me.cmd3.BackgroundImage = CType(resources.GetObject("cmd3.BackgroundImage"), System.Drawing.Image)
        Me.cmd3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmd3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.cmd3.Location = New System.Drawing.Point(154, 16)
        Me.cmd3.Margin = New System.Windows.Forms.Padding(2)
        Me.cmd3.Name = "cmd3"
        Me.cmd3.Size = New System.Drawing.Size(69, 29)
        Me.cmd3.TabIndex = 7
        Me.cmd3.Text = "S&ave"
        Me.cmd3.UseVisualStyleBackColor = False
        '
        'cmd2
        '
        Me.cmd2.BackColor = System.Drawing.SystemColors.Desktop
        Me.cmd2.BackgroundImage = CType(resources.GetObject("cmd2.BackgroundImage"), System.Drawing.Image)
        Me.cmd2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmd2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.cmd2.Location = New System.Drawing.Point(81, 16)
        Me.cmd2.Margin = New System.Windows.Forms.Padding(2)
        Me.cmd2.Name = "cmd2"
        Me.cmd2.Size = New System.Drawing.Size(69, 29)
        Me.cmd2.TabIndex = 6
        Me.cmd2.Text = "&Stop"
        Me.cmd2.UseVisualStyleBackColor = False
        '
        'cmd1
        '
        Me.cmd1.BackColor = System.Drawing.SystemColors.Desktop
        Me.cmd1.BackgroundImage = CType(resources.GetObject("cmd1.BackgroundImage"), System.Drawing.Image)
        Me.cmd1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmd1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.cmd1.Location = New System.Drawing.Point(8, 16)
        Me.cmd1.Margin = New System.Windows.Forms.Padding(2)
        Me.cmd1.Name = "cmd1"
        Me.cmd1.Size = New System.Drawing.Size(69, 29)
        Me.cmd1.TabIndex = 5
        Me.cmd1.Text = "&Capture"
        Me.cmd1.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackgroundImage = Global.Basic_AI_VisualReco2023.My.Resources.Resources.BackGround_BluPrint
        Me.GroupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox2.Controls.Add(Me.lst1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GroupBox2.Location = New System.Drawing.Point(2, 17)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(666, 18)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Select Webcam"
        '
        'lst1
        '
        Me.lst1.BackColor = System.Drawing.SystemColors.Info
        Me.lst1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lst1.FormattingEnabled = True
        Me.lst1.ItemHeight = 14
        Me.lst1.Location = New System.Drawing.Point(2, 17)
        Me.lst1.Margin = New System.Windows.Forms.Padding(2)
        Me.lst1.Name = "lst1"
        Me.lst1.Size = New System.Drawing.Size(662, 0)
        Me.lst1.TabIndex = 0
        '
        'Timer1
        '
        '
        'opt4
        '
        Me.opt4.AutoSize = True
        Me.opt4.Location = New System.Drawing.Point(403, 42)
        Me.opt4.Name = "opt4"
        Me.opt4.Size = New System.Drawing.Size(79, 20)
        Me.opt4.TabIndex = 24
        Me.opt4.TabStop = True
        Me.opt4.Text = "Infra &Red"
        Me.opt4.UseVisualStyleBackColor = True
        '
        'opt3
        '
        Me.opt3.AutoSize = True
        Me.opt3.Location = New System.Drawing.Point(403, 20)
        Me.opt3.Name = "opt3"
        Me.opt3.Size = New System.Drawing.Size(76, 20)
        Me.opt3.TabIndex = 23
        Me.opt3.TabStop = True
        Me.opt3.Text = "&Grayscale"
        Me.opt3.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(336, 20)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(64, 20)
        Me.RadioButton1.TabIndex = 21
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "&Normal"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'opt1
        '
        Me.opt1.AutoSize = True
        Me.opt1.Location = New System.Drawing.Point(336, 42)
        Me.opt1.Name = "opt1"
        Me.opt1.Size = New System.Drawing.Size(59, 20)
        Me.opt1.TabIndex = 22
        Me.opt1.TabStop = True
        Me.opt1.Text = "&Invert"
        Me.opt1.UseVisualStyleBackColor = True
        '
        'FrmVisualSensor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Basic_AI_VisualReco2023.My.Resources.Resources.BackGround_BluPrint
        Me.ClientSize = New System.Drawing.Size(670, 429)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MinimumSize = New System.Drawing.Size(250, 203)
        Me.Name = "FrmVisualSensor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Visual Sensor"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.pView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lst1 As ListBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents cmd3 As Button
    Friend WithEvents cmd2 As Button
    Friend WithEvents cmd1 As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents pView As PictureBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents opt2 As RadioButton
    Friend WithEvents sfdImages As SaveFileDialog
    Friend WithEvents lblInfo As Label
    Friend WithEvents ButtonDetect As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents lMovements As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents opt4 As RadioButton
    Friend WithEvents opt3 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents opt1 As RadioButton
End Class
