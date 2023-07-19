Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class VisionTabs
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VisionTabs))
        Me.VisonTabControl = New System.Windows.Forms.TabControl()
        Me.TabPageVisionReco = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.PictureBox_Preview = New System.Windows.Forms.PictureBox()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.GroupBoxIdentificationDatabase = New System.Windows.Forms.GroupBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.PB_Capture = New System.Windows.Forms.PictureBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.PB_TARGET = New System.Windows.Forms.PictureBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.PB_DETECT = New System.Windows.Forms.PictureBox()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer5 = New System.Windows.Forms.SplitContainer()
        Me.ComboBox_Devices = New System.Windows.Forms.ComboBox()
        Me.Label_SelectCamera = New System.Windows.Forms.Label()
        Me.ComboBox_FrameSize = New System.Windows.Forms.ComboBox()
        Me.Label_SelectCaptureSize = New System.Windows.Forms.Label()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.chb1 = New System.Windows.Forms.CheckBox()
        Me.opt4 = New System.Windows.Forms.RadioButton()
        Me.opt3 = New System.Windows.Forms.RadioButton()
        Me.Op2 = New System.Windows.Forms.RadioButton()
        Me.opt1 = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lMovements = New System.Windows.Forms.TextBox()
        Me.Button_Save = New System.Windows.Forms.Button()
        Me.Button_Connect = New System.Windows.Forms.Button()
        Me.ButtonDetectNose = New System.Windows.Forms.Button()
        Me.ButtonDetectSmile = New System.Windows.Forms.Button()
        Me.ButtonAll = New System.Windows.Forms.Button()
        Me.ButtonEyes = New System.Windows.Forms.Button()
        Me.ButtonDetectEars = New System.Windows.Forms.Button()
        Me.ButtonDetectFace = New System.Windows.Forms.Button()
        Me.SplitContainer6 = New System.Windows.Forms.SplitContainer()
        Me.LabelMatches = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox_ImageDir = New System.Windows.Forms.TextBox()
        Me.Label_FaceDatabaseLocation = New System.Windows.Forms.Label()
        Me.ToolStripCamRecoControl = New System.Windows.Forms.ToolStrip()
        Me.ButtonBrowser = New System.Windows.Forms.ToolStripButton()
        Me.ButtonLoad = New System.Windows.Forms.ToolStripButton()
        Me.ButtonReload = New System.Windows.Forms.ToolStripButton()
        Me.ButtonSearch = New System.Windows.Forms.ToolStripButton()
        Me.ButtonAddToDb = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.AllowedErrors = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ImageCount = New System.Windows.Forms.NumericUpDown()
        Me.ButtonAdd = New System.Windows.Forms.Button()
        Me.Label_ImageSize = New System.Windows.Forms.Label()
        Me.Label_ImageSaved = New System.Windows.Forms.Label()
        Me.VisonTabControl.SuspendLayout()
        Me.TabPageVisionReco.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        CType(Me.PictureBox_Preview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.GroupBoxIdentificationDatabase.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.PB_Capture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        CType(Me.PB_TARGET, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.PB_DETECT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer4.Panel1.SuspendLayout()
        Me.SplitContainer4.Panel2.SuspendLayout()
        Me.SplitContainer4.SuspendLayout()
        CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer5.Panel1.SuspendLayout()
        Me.SplitContainer5.Panel2.SuspendLayout()
        Me.SplitContainer5.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        CType(Me.SplitContainer6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer6.Panel1.SuspendLayout()
        Me.SplitContainer6.Panel2.SuspendLayout()
        Me.SplitContainer6.SuspendLayout()
        Me.ToolStripCamRecoControl.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.AllowedErrors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ImageCount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'VisonTabControl
        '
        Me.VisonTabControl.Controls.Add(Me.TabPageVisionReco)
        Me.VisonTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VisonTabControl.Font = New System.Drawing.Font("Comic Sans MS", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VisonTabControl.Location = New System.Drawing.Point(0, 0)
        Me.VisonTabControl.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.VisonTabControl.Name = "VisonTabControl"
        Me.VisonTabControl.SelectedIndex = 0
        Me.VisonTabControl.Size = New System.Drawing.Size(1835, 639)
        Me.VisonTabControl.TabIndex = 0
        '
        'TabPageVisionReco
        '
        Me.TabPageVisionReco.Controls.Add(Me.SplitContainer1)
        Me.TabPageVisionReco.Location = New System.Drawing.Point(4, 23)
        Me.TabPageVisionReco.Name = "TabPageVisionReco"
        Me.TabPageVisionReco.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageVisionReco.Size = New System.Drawing.Size(1827, 612)
        Me.TabPageVisionReco.TabIndex = 18
        Me.TabPageVisionReco.Text = "Visual Recognition"
        Me.TabPageVisionReco.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox4)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1821, 606)
        Me.SplitContainer1.SplitterDistance = 651
        Me.SplitContainer1.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Black
        Me.GroupBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox4.Controls.Add(Me.GroupBox12)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox4.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox4.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox4.Size = New System.Drawing.Size(651, 606)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Camera Preview Window"
        '
        'GroupBox12
        '
        Me.GroupBox12.BackColor = System.Drawing.Color.Black
        Me.GroupBox12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox12.Controls.Add(Me.PictureBox_Preview)
        Me.GroupBox12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox12.Font = New System.Drawing.Font("Comic Sans MS", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox12.ForeColor = System.Drawing.Color.White
        Me.GroupBox12.Location = New System.Drawing.Point(3, 21)
        Me.GroupBox12.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox12.Size = New System.Drawing.Size(645, 583)
        Me.GroupBox12.TabIndex = 7
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "Visual Input"
        '
        'PictureBox_Preview
        '
        Me.PictureBox_Preview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox_Preview.Location = New System.Drawing.Point(3, 19)
        Me.PictureBox_Preview.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PictureBox_Preview.Name = "PictureBox_Preview"
        Me.PictureBox_Preview.Size = New System.Drawing.Size(639, 562)
        Me.PictureBox_Preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox_Preview.TabIndex = 6
        Me.PictureBox_Preview.TabStop = False
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.GroupBoxIdentificationDatabase)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer2.Size = New System.Drawing.Size(1166, 606)
        Me.SplitContainer2.SplitterDistance = 276
        Me.SplitContainer2.TabIndex = 0
        '
        'GroupBoxIdentificationDatabase
        '
        Me.GroupBoxIdentificationDatabase.BackColor = System.Drawing.Color.Black
        Me.GroupBoxIdentificationDatabase.Controls.Add(Me.GroupBox6)
        Me.GroupBoxIdentificationDatabase.Controls.Add(Me.GroupBox8)
        Me.GroupBoxIdentificationDatabase.Controls.Add(Me.GroupBox5)
        Me.GroupBoxIdentificationDatabase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxIdentificationDatabase.Font = New System.Drawing.Font("Acidic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxIdentificationDatabase.ForeColor = System.Drawing.Color.White
        Me.GroupBoxIdentificationDatabase.Location = New System.Drawing.Point(0, 0)
        Me.GroupBoxIdentificationDatabase.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBoxIdentificationDatabase.Name = "GroupBoxIdentificationDatabase"
        Me.GroupBoxIdentificationDatabase.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBoxIdentificationDatabase.Size = New System.Drawing.Size(1166, 276)
        Me.GroupBoxIdentificationDatabase.TabIndex = 1
        Me.GroupBoxIdentificationDatabase.TabStop = False
        Me.GroupBoxIdentificationDatabase.Text = "Identifcation Database"
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupBox6.Controls.Add(Me.PB_Capture)
        Me.GroupBox6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.ForeColor = System.Drawing.Color.White
        Me.GroupBox6.Location = New System.Drawing.Point(313, 22)
        Me.GroupBox6.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox6.Size = New System.Drawing.Size(540, 250)
        Me.GroupBox6.TabIndex = 3
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Captured"
        '
        'PB_Capture
        '
        Me.PB_Capture.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PB_Capture.Location = New System.Drawing.Point(4, 19)
        Me.PB_Capture.Margin = New System.Windows.Forms.Padding(4)
        Me.PB_Capture.Name = "PB_Capture"
        Me.PB_Capture.Size = New System.Drawing.Size(532, 227)
        Me.PB_Capture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PB_Capture.TabIndex = 2
        Me.PB_Capture.TabStop = False
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.Color.Black
        Me.GroupBox8.Controls.Add(Me.GroupBox9)
        Me.GroupBox8.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox8.ForeColor = System.Drawing.Color.White
        Me.GroupBox8.Location = New System.Drawing.Point(853, 22)
        Me.GroupBox8.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox8.Size = New System.Drawing.Size(309, 250)
        Me.GroupBox8.TabIndex = 1
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Search"
        '
        'GroupBox9
        '
        Me.GroupBox9.BackColor = System.Drawing.Color.Lime
        Me.GroupBox9.Controls.Add(Me.PB_TARGET)
        Me.GroupBox9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox9.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox9.Location = New System.Drawing.Point(4, 22)
        Me.GroupBox9.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox9.Size = New System.Drawing.Size(301, 224)
        Me.GroupBox9.TabIndex = 2
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Target"
        '
        'PB_TARGET
        '
        Me.PB_TARGET.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PB_TARGET.Location = New System.Drawing.Point(4, 27)
        Me.PB_TARGET.Margin = New System.Windows.Forms.Padding(4)
        Me.PB_TARGET.Name = "PB_TARGET"
        Me.PB_TARGET.Size = New System.Drawing.Size(293, 193)
        Me.PB_TARGET.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PB_TARGET.TabIndex = 1
        Me.PB_TARGET.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Black
        Me.GroupBox5.Controls.Add(Me.GroupBox7)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox5.ForeColor = System.Drawing.Color.White
        Me.GroupBox5.Location = New System.Drawing.Point(4, 22)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox5.Size = New System.Drawing.Size(309, 250)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Detect"
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.Color.Red
        Me.GroupBox7.Controls.Add(Me.PB_DETECT)
        Me.GroupBox7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox7.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(4, 22)
        Me.GroupBox7.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox7.Size = New System.Drawing.Size(301, 224)
        Me.GroupBox7.TabIndex = 2
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Detected"
        '
        'PB_DETECT
        '
        Me.PB_DETECT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PB_DETECT.Location = New System.Drawing.Point(4, 27)
        Me.PB_DETECT.Margin = New System.Windows.Forms.Padding(4)
        Me.PB_DETECT.Name = "PB_DETECT"
        Me.PB_DETECT.Size = New System.Drawing.Size(293, 193)
        Me.PB_DETECT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PB_DETECT.TabIndex = 1
        Me.PB_DETECT.TabStop = False
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.SplitContainer4)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.SplitContainer6)
        Me.SplitContainer3.Size = New System.Drawing.Size(1166, 326)
        Me.SplitContainer3.SplitterDistance = 639
        Me.SplitContainer3.TabIndex = 0
        '
        'SplitContainer4
        '
        Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer4.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer4.Name = "SplitContainer4"
        Me.SplitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer4.Panel1
        '
        Me.SplitContainer4.Panel1.Controls.Add(Me.SplitContainer5)
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.BackColor = System.Drawing.Color.Black
        Me.SplitContainer4.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SplitContainer4.Panel2.Controls.Add(Me.lblInfo)
        Me.SplitContainer4.Panel2.Controls.Add(Me.GroupBox10)
        Me.SplitContainer4.Panel2.Controls.Add(Me.Button_Save)
        Me.SplitContainer4.Panel2.Controls.Add(Me.Button_Connect)
        Me.SplitContainer4.Panel2.Controls.Add(Me.ButtonDetectNose)
        Me.SplitContainer4.Panel2.Controls.Add(Me.ButtonDetectSmile)
        Me.SplitContainer4.Panel2.Controls.Add(Me.ButtonAll)
        Me.SplitContainer4.Panel2.Controls.Add(Me.ButtonEyes)
        Me.SplitContainer4.Panel2.Controls.Add(Me.ButtonDetectEars)
        Me.SplitContainer4.Panel2.Controls.Add(Me.ButtonDetectFace)
        Me.SplitContainer4.Size = New System.Drawing.Size(639, 326)
        Me.SplitContainer4.SplitterDistance = 166
        Me.SplitContainer4.TabIndex = 0
        '
        'SplitContainer5
        '
        Me.SplitContainer5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer5.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer5.Name = "SplitContainer5"
        Me.SplitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer5.Panel1
        '
        Me.SplitContainer5.Panel1.BackColor = System.Drawing.Color.Black
        Me.SplitContainer5.Panel1.BackgroundImage = Global.Basic_AI_VisualReco2023.My.Resources.Resources.BackGround_Bar
        Me.SplitContainer5.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SplitContainer5.Panel1.Controls.Add(Me.ComboBox_Devices)
        Me.SplitContainer5.Panel1.Controls.Add(Me.Label_SelectCamera)
        '
        'SplitContainer5.Panel2
        '
        Me.SplitContainer5.Panel2.BackColor = System.Drawing.Color.Black
        Me.SplitContainer5.Panel2.BackgroundImage = Global.Basic_AI_VisualReco2023.My.Resources.Resources.BackGround_Bar
        Me.SplitContainer5.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SplitContainer5.Panel2.Controls.Add(Me.ComboBox_FrameSize)
        Me.SplitContainer5.Panel2.Controls.Add(Me.Label_SelectCaptureSize)
        Me.SplitContainer5.Size = New System.Drawing.Size(639, 166)
        Me.SplitContainer5.SplitterDistance = 80
        Me.SplitContainer5.TabIndex = 0
        '
        'ComboBox_Devices
        '
        Me.ComboBox_Devices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBox_Devices.FormattingEnabled = True
        Me.ComboBox_Devices.Location = New System.Drawing.Point(0, 16)
        Me.ComboBox_Devices.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ComboBox_Devices.Name = "ComboBox_Devices"
        Me.ComboBox_Devices.Size = New System.Drawing.Size(639, 22)
        Me.ComboBox_Devices.TabIndex = 17
        '
        'Label_SelectCamera
        '
        Me.Label_SelectCamera.AutoSize = True
        Me.Label_SelectCamera.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label_SelectCamera.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label_SelectCamera.Location = New System.Drawing.Point(0, 0)
        Me.Label_SelectCamera.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_SelectCamera.Name = "Label_SelectCamera"
        Me.Label_SelectCamera.Size = New System.Drawing.Size(85, 16)
        Me.Label_SelectCamera.TabIndex = 16
        Me.Label_SelectCamera.Text = "Select Camera"
        '
        'ComboBox_FrameSize
        '
        Me.ComboBox_FrameSize.Dock = System.Windows.Forms.DockStyle.Top
        Me.ComboBox_FrameSize.FormattingEnabled = True
        Me.ComboBox_FrameSize.Location = New System.Drawing.Point(0, 16)
        Me.ComboBox_FrameSize.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ComboBox_FrameSize.Name = "ComboBox_FrameSize"
        Me.ComboBox_FrameSize.Size = New System.Drawing.Size(639, 22)
        Me.ComboBox_FrameSize.TabIndex = 17
        '
        'Label_SelectCaptureSize
        '
        Me.Label_SelectCaptureSize.AutoSize = True
        Me.Label_SelectCaptureSize.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label_SelectCaptureSize.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label_SelectCaptureSize.Location = New System.Drawing.Point(0, 0)
        Me.Label_SelectCaptureSize.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_SelectCaptureSize.Name = "Label_SelectCaptureSize"
        Me.Label_SelectCaptureSize.Size = New System.Drawing.Size(112, 16)
        Me.Label_SelectCaptureSize.TabIndex = 16
        Me.Label_SelectCaptureSize.Text = "Select Capture size"
        '
        'lblInfo
        '
        Me.lblInfo.BackColor = System.Drawing.Color.Black
        Me.lblInfo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblInfo.Font = New System.Drawing.Font("Consolas", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.ForeColor = System.Drawing.Color.White
        Me.lblInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblInfo.Location = New System.Drawing.Point(0, 125)
        Me.lblInfo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(433, 31)
        Me.lblInfo.TabIndex = 34
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.chb1)
        Me.GroupBox10.Controls.Add(Me.opt4)
        Me.GroupBox10.Controls.Add(Me.opt3)
        Me.GroupBox10.Controls.Add(Me.Op2)
        Me.GroupBox10.Controls.Add(Me.opt1)
        Me.GroupBox10.Controls.Add(Me.Label6)
        Me.GroupBox10.Controls.Add(Me.lMovements)
        Me.GroupBox10.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox10.ForeColor = System.Drawing.SystemColors.ButtonShadow
        Me.GroupBox10.Location = New System.Drawing.Point(433, 0)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(206, 156)
        Me.GroupBox10.TabIndex = 16
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "FX"
        '
        'chb1
        '
        Me.chb1.AutoSize = True
        Me.chb1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.chb1.Location = New System.Drawing.Point(3, 94)
        Me.chb1.Margin = New System.Windows.Forms.Padding(4)
        Me.chb1.Name = "chb1"
        Me.chb1.Size = New System.Drawing.Size(200, 20)
        Me.chb1.TabIndex = 36
        Me.chb1.Text = "Add Motion Sensors"
        Me.chb1.UseVisualStyleBackColor = True
        '
        'opt4
        '
        Me.opt4.AutoSize = True
        Me.opt4.Location = New System.Drawing.Point(100, 56)
        Me.opt4.Margin = New System.Windows.Forms.Padding(4)
        Me.opt4.Name = "opt4"
        Me.opt4.Size = New System.Drawing.Size(78, 20)
        Me.opt4.TabIndex = 35
        Me.opt4.TabStop = True
        Me.opt4.Text = "Infra &Red"
        Me.opt4.UseVisualStyleBackColor = True
        '
        'opt3
        '
        Me.opt3.AutoSize = True
        Me.opt3.Location = New System.Drawing.Point(100, 21)
        Me.opt3.Margin = New System.Windows.Forms.Padding(4)
        Me.opt3.Name = "opt3"
        Me.opt3.Size = New System.Drawing.Size(75, 20)
        Me.opt3.TabIndex = 34
        Me.opt3.TabStop = True
        Me.opt3.Text = "&Grayscale"
        Me.opt3.UseVisualStyleBackColor = True
        '
        'Op2
        '
        Me.Op2.AutoSize = True
        Me.Op2.Location = New System.Drawing.Point(17, 21)
        Me.Op2.Margin = New System.Windows.Forms.Padding(4)
        Me.Op2.Name = "Op2"
        Me.Op2.Size = New System.Drawing.Size(63, 20)
        Me.Op2.TabIndex = 32
        Me.Op2.TabStop = True
        Me.Op2.Text = "&Normal"
        Me.Op2.UseVisualStyleBackColor = True
        '
        'opt1
        '
        Me.opt1.AutoSize = True
        Me.opt1.Location = New System.Drawing.Point(17, 53)
        Me.opt1.Margin = New System.Windows.Forms.Padding(4)
        Me.opt1.Name = "opt1"
        Me.opt1.Size = New System.Drawing.Size(58, 20)
        Me.opt1.TabIndex = 33
        Me.opt1.TabStop = True
        Me.opt1.Text = "&Invert"
        Me.opt1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label6.Location = New System.Drawing.Point(3, 114)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 16)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Movement"
        '
        'lMovements
        '
        Me.lMovements.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lMovements.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lMovements.Location = New System.Drawing.Point(3, 130)
        Me.lMovements.Margin = New System.Windows.Forms.Padding(4)
        Me.lMovements.Name = "lMovements"
        Me.lMovements.Size = New System.Drawing.Size(200, 23)
        Me.lMovements.TabIndex = 30
        '
        'Button_Save
        '
        Me.Button_Save.BackgroundImage = Global.Basic_AI_VisualReco2023.My.Resources.Resources.BackGround_Workspace
        Me.Button_Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Save.ForeColor = System.Drawing.Color.Black
        Me.Button_Save.Location = New System.Drawing.Point(241, 54)
        Me.Button_Save.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button_Save.Name = "Button_Save"
        Me.Button_Save.Size = New System.Drawing.Size(72, 36)
        Me.Button_Save.TabIndex = 15
        Me.Button_Save.Text = "Capture"
        Me.Button_Save.UseVisualStyleBackColor = True
        '
        'Button_Connect
        '
        Me.Button_Connect.BackgroundImage = Global.Basic_AI_VisualReco2023.My.Resources.Resources.BackGround_Workspace
        Me.Button_Connect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Connect.ForeColor = System.Drawing.Color.Black
        Me.Button_Connect.Location = New System.Drawing.Point(241, 14)
        Me.Button_Connect.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button_Connect.Name = "Button_Connect"
        Me.Button_Connect.Size = New System.Drawing.Size(72, 39)
        Me.Button_Connect.TabIndex = 14
        Me.Button_Connect.Text = "Connect"
        Me.Button_Connect.UseVisualStyleBackColor = True
        '
        'ButtonDetectNose
        '
        Me.ButtonDetectNose.BackColor = System.Drawing.Color.Black
        Me.ButtonDetectNose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonDetectNose.Enabled = False
        Me.ButtonDetectNose.ForeColor = System.Drawing.Color.Lime
        Me.ButtonDetectNose.Location = New System.Drawing.Point(85, 54)
        Me.ButtonDetectNose.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonDetectNose.Name = "ButtonDetectNose"
        Me.ButtonDetectNose.Size = New System.Drawing.Size(69, 36)
        Me.ButtonDetectNose.TabIndex = 11
        Me.ButtonDetectNose.Text = "N&ose"
        Me.ButtonDetectNose.UseVisualStyleBackColor = False
        '
        'ButtonDetectSmile
        '
        Me.ButtonDetectSmile.BackColor = System.Drawing.Color.Black
        Me.ButtonDetectSmile.BackgroundImage = CType(resources.GetObject("ButtonDetectSmile.BackgroundImage"), System.Drawing.Image)
        Me.ButtonDetectSmile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonDetectSmile.Enabled = False
        Me.ButtonDetectSmile.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonDetectSmile.Location = New System.Drawing.Point(9, 54)
        Me.ButtonDetectSmile.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonDetectSmile.Name = "ButtonDetectSmile"
        Me.ButtonDetectSmile.Size = New System.Drawing.Size(71, 36)
        Me.ButtonDetectSmile.TabIndex = 12
        Me.ButtonDetectSmile.Text = "S&mile"
        Me.ButtonDetectSmile.UseVisualStyleBackColor = False
        '
        'ButtonAll
        '
        Me.ButtonAll.BackColor = System.Drawing.Color.Black
        Me.ButtonAll.BackgroundImage = CType(resources.GetObject("ButtonAll.BackgroundImage"), System.Drawing.Image)
        Me.ButtonAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonAll.Enabled = False
        Me.ButtonAll.ForeColor = System.Drawing.Color.White
        Me.ButtonAll.Location = New System.Drawing.Point(160, 54)
        Me.ButtonAll.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonAll.Name = "ButtonAll"
        Me.ButtonAll.Size = New System.Drawing.Size(59, 36)
        Me.ButtonAll.TabIndex = 13
        Me.ButtonAll.Text = "A&ll"
        Me.ButtonAll.UseVisualStyleBackColor = False
        '
        'ButtonEyes
        '
        Me.ButtonEyes.BackColor = System.Drawing.Color.Black
        Me.ButtonEyes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonEyes.Enabled = False
        Me.ButtonEyes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonEyes.Location = New System.Drawing.Point(85, 14)
        Me.ButtonEyes.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonEyes.Name = "ButtonEyes"
        Me.ButtonEyes.Size = New System.Drawing.Size(69, 36)
        Me.ButtonEyes.TabIndex = 8
        Me.ButtonEyes.Text = "E&yes"
        Me.ButtonEyes.UseVisualStyleBackColor = False
        '
        'ButtonDetectEars
        '
        Me.ButtonDetectEars.BackColor = System.Drawing.Color.Black
        Me.ButtonDetectEars.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonDetectEars.Enabled = False
        Me.ButtonDetectEars.ForeColor = System.Drawing.Color.Fuchsia
        Me.ButtonDetectEars.Location = New System.Drawing.Point(160, 14)
        Me.ButtonDetectEars.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonDetectEars.Name = "ButtonDetectEars"
        Me.ButtonDetectEars.Size = New System.Drawing.Size(59, 36)
        Me.ButtonDetectEars.TabIndex = 9
        Me.ButtonDetectEars.Text = "E&ars"
        Me.ButtonDetectEars.UseVisualStyleBackColor = False
        '
        'ButtonDetectFace
        '
        Me.ButtonDetectFace.BackColor = System.Drawing.Color.Black
        Me.ButtonDetectFace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonDetectFace.Enabled = False
        Me.ButtonDetectFace.ForeColor = System.Drawing.Color.Red
        Me.ButtonDetectFace.Location = New System.Drawing.Point(8, 14)
        Me.ButtonDetectFace.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonDetectFace.Name = "ButtonDetectFace"
        Me.ButtonDetectFace.Size = New System.Drawing.Size(72, 36)
        Me.ButtonDetectFace.TabIndex = 10
        Me.ButtonDetectFace.Text = "F&ace"
        Me.ButtonDetectFace.UseVisualStyleBackColor = False
        '
        'SplitContainer6
        '
        Me.SplitContainer6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer6.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer6.Name = "SplitContainer6"
        Me.SplitContainer6.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer6.Panel1
        '
        Me.SplitContainer6.Panel1.BackColor = System.Drawing.Color.Black
        Me.SplitContainer6.Panel1.BackgroundImage = Global.Basic_AI_VisualReco2023.My.Resources.Resources.BackGround_Bar
        Me.SplitContainer6.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SplitContainer6.Panel1.Controls.Add(Me.LabelMatches)
        Me.SplitContainer6.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer6.Panel1.Controls.Add(Me.TextBox_ImageDir)
        Me.SplitContainer6.Panel1.Controls.Add(Me.Label_FaceDatabaseLocation)
        Me.SplitContainer6.Panel1.Controls.Add(Me.ToolStripCamRecoControl)
        Me.SplitContainer6.Panel1.Controls.Add(Me.GroupBox3)
        '
        'SplitContainer6.Panel2
        '
        Me.SplitContainer6.Panel2.BackColor = System.Drawing.Color.Black
        Me.SplitContainer6.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SplitContainer6.Panel2.Controls.Add(Me.ButtonAdd)
        Me.SplitContainer6.Panel2.Controls.Add(Me.Label_ImageSize)
        Me.SplitContainer6.Panel2.Controls.Add(Me.Label_ImageSaved)
        Me.SplitContainer6.Size = New System.Drawing.Size(523, 326)
        Me.SplitContainer6.SplitterDistance = 162
        Me.SplitContainer6.TabIndex = 0
        '
        'LabelMatches
        '
        Me.LabelMatches.AutoSize = True
        Me.LabelMatches.Location = New System.Drawing.Point(364, 65)
        Me.LabelMatches.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelMatches.Name = "LabelMatches"
        Me.LabelMatches.Size = New System.Drawing.Size(0, 16)
        Me.LabelMatches.TabIndex = 34
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label3.Location = New System.Drawing.Point(0, 65)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 16)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "File Count : "
        '
        'TextBox_ImageDir
        '
        Me.TextBox_ImageDir.Dock = System.Windows.Forms.DockStyle.Top
        Me.TextBox_ImageDir.Location = New System.Drawing.Point(0, 43)
        Me.TextBox_ImageDir.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_ImageDir.Name = "TextBox_ImageDir"
        Me.TextBox_ImageDir.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.TextBox_ImageDir.Size = New System.Drawing.Size(323, 22)
        Me.TextBox_ImageDir.TabIndex = 30
        '
        'Label_FaceDatabaseLocation
        '
        Me.Label_FaceDatabaseLocation.AutoSize = True
        Me.Label_FaceDatabaseLocation.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label_FaceDatabaseLocation.Location = New System.Drawing.Point(0, 27)
        Me.Label_FaceDatabaseLocation.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_FaceDatabaseLocation.Name = "Label_FaceDatabaseLocation"
        Me.Label_FaceDatabaseLocation.Size = New System.Drawing.Size(135, 16)
        Me.Label_FaceDatabaseLocation.TabIndex = 29
        Me.Label_FaceDatabaseLocation.Text = "Face Database Location"
        '
        'ToolStripCamRecoControl
        '
        Me.ToolStripCamRecoControl.BackColor = System.Drawing.Color.Black
        Me.ToolStripCamRecoControl.BackgroundImage = Global.Basic_AI_VisualReco2023.My.Resources.Resources.BackGround_Bar
        Me.ToolStripCamRecoControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStripCamRecoControl.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStripCamRecoControl.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonBrowser, Me.ButtonLoad, Me.ButtonReload, Me.ButtonSearch, Me.ButtonAddToDb})
        Me.ToolStripCamRecoControl.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripCamRecoControl.Name = "ToolStripCamRecoControl"
        Me.ToolStripCamRecoControl.Size = New System.Drawing.Size(323, 27)
        Me.ToolStripCamRecoControl.TabIndex = 28
        Me.ToolStripCamRecoControl.Text = "ToolStrip1"
        '
        'ButtonBrowser
        '
        Me.ButtonBrowser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButtonBrowser.Image = Global.Basic_AI_VisualReco2023.My.Resources.Resources.APP_icon_fileopen
        Me.ButtonBrowser.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonBrowser.Name = "ButtonBrowser"
        Me.ButtonBrowser.Size = New System.Drawing.Size(24, 24)
        Me.ButtonBrowser.Text = "Browse"
        '
        'ButtonLoad
        '
        Me.ButtonLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButtonLoad.Image = Global.Basic_AI_VisualReco2023.My.Resources.Resources.APP_icon_editundo
        Me.ButtonLoad.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonLoad.Name = "ButtonLoad"
        Me.ButtonLoad.Size = New System.Drawing.Size(24, 24)
        Me.ButtonLoad.Text = "Load"
        '
        'ButtonReload
        '
        Me.ButtonReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButtonReload.Image = Global.Basic_AI_VisualReco2023.My.Resources.Resources.APP_icon_editredo
        Me.ButtonReload.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonReload.Name = "ButtonReload"
        Me.ButtonReload.Size = New System.Drawing.Size(24, 24)
        Me.ButtonReload.Text = "Reload"
        '
        'ButtonSearch
        '
        Me.ButtonSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButtonSearch.Image = Global.Basic_AI_VisualReco2023.My.Resources.Resources.APP_icon_search
        Me.ButtonSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonSearch.Name = "ButtonSearch"
        Me.ButtonSearch.Size = New System.Drawing.Size(24, 24)
        Me.ButtonSearch.Text = "Search"
        '
        'ButtonAddToDb
        '
        Me.ButtonAddToDb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButtonAddToDb.Image = Global.Basic_AI_VisualReco2023.My.Resources.Resources.APP_icon_User
        Me.ButtonAddToDb.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonAddToDb.Name = "ButtonAddToDb"
        Me.ButtonAddToDb.Size = New System.Drawing.Size(24, 24)
        Me.ButtonAddToDb.Text = "Add to DB"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GroupBox2)
        Me.GroupBox3.Controls.Add(Me.GroupBox1)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupBox3.Location = New System.Drawing.Point(323, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(200, 162)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Parameters"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.AllowedErrors)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(3, 18)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(194, 63)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Allowed Errors"
        '
        'AllowedErrors
        '
        Me.AllowedErrors.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AllowedErrors.Location = New System.Drawing.Point(3, 18)
        Me.AllowedErrors.Margin = New System.Windows.Forms.Padding(5, 7, 5, 7)
        Me.AllowedErrors.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.AllowedErrors.Name = "AllowedErrors"
        Me.AllowedErrors.Size = New System.Drawing.Size(188, 22)
        Me.AllowedErrors.TabIndex = 12
        Me.AllowedErrors.Tag = "Error rate"
        Me.AllowedErrors.Value = New Decimal(New Integer() {340, 0, 0, 0})
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ImageCount)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 102)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(194, 57)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DetectedImages"
        '
        'ImageCount
        '
        Me.ImageCount.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImageCount.Location = New System.Drawing.Point(3, 18)
        Me.ImageCount.Margin = New System.Windows.Forms.Padding(4)
        Me.ImageCount.Name = "ImageCount"
        Me.ImageCount.Size = New System.Drawing.Size(188, 22)
        Me.ImageCount.TabIndex = 16
        '
        'ButtonAdd
        '
        Me.ButtonAdd.BackColor = System.Drawing.SystemColors.Desktop
        Me.ButtonAdd.BackgroundImage = CType(resources.GetObject("ButtonAdd.BackgroundImage"), System.Drawing.Image)
        Me.ButtonAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonAdd.Dock = System.Windows.Forms.DockStyle.Left
        Me.ButtonAdd.Enabled = False
        Me.ButtonAdd.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ButtonAdd.Location = New System.Drawing.Point(0, 0)
        Me.ButtonAdd.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonAdd.Name = "ButtonAdd"
        Me.ButtonAdd.Size = New System.Drawing.Size(124, 114)
        Me.ButtonAdd.TabIndex = 31
        Me.ButtonAdd.Text = "Use Image"
        Me.ButtonAdd.UseVisualStyleBackColor = False
        '
        'Label_ImageSize
        '
        Me.Label_ImageSize.AutoSize = True
        Me.Label_ImageSize.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label_ImageSize.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_ImageSize.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label_ImageSize.Location = New System.Drawing.Point(0, 114)
        Me.Label_ImageSize.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_ImageSize.Name = "Label_ImageSize"
        Me.Label_ImageSize.Size = New System.Drawing.Size(98, 23)
        Me.Label_ImageSize.TabIndex = 30
        Me.Label_ImageSize.Text = "Image Size"
        '
        'Label_ImageSaved
        '
        Me.Label_ImageSaved.AutoSize = True
        Me.Label_ImageSaved.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label_ImageSaved.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_ImageSaved.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label_ImageSaved.Location = New System.Drawing.Point(0, 137)
        Me.Label_ImageSaved.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_ImageSaved.Name = "Label_ImageSaved"
        Me.Label_ImageSaved.Size = New System.Drawing.Size(138, 23)
        Me.Label_ImageSaved.TabIndex = 29
        Me.Label_ImageSaved.Text = "Image Saved As"
        '
        'VisionTabs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1835, 639)
        Me.Controls.Add(Me.VisonTabControl)
        Me.Font = New System.Drawing.Font("Comic Sans MS", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "VisionTabs"
        Me.Text = "VisionTabs"
        Me.VisonTabControl.ResumeLayout(False)
        Me.TabPageVisionReco.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox12.ResumeLayout(False)
        CType(Me.PictureBox_Preview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.GroupBoxIdentificationDatabase.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.PB_Capture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        CType(Me.PB_TARGET, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        CType(Me.PB_DETECT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.SplitContainer4.Panel1.ResumeLayout(False)
        Me.SplitContainer4.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer4.ResumeLayout(False)
        Me.SplitContainer5.Panel1.ResumeLayout(False)
        Me.SplitContainer5.Panel1.PerformLayout()
        Me.SplitContainer5.Panel2.ResumeLayout(False)
        Me.SplitContainer5.Panel2.PerformLayout()
        CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer5.ResumeLayout(False)
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.SplitContainer6.Panel1.ResumeLayout(False)
        Me.SplitContainer6.Panel1.PerformLayout()
        Me.SplitContainer6.Panel2.ResumeLayout(False)
        Me.SplitContainer6.Panel2.PerformLayout()
        CType(Me.SplitContainer6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer6.ResumeLayout(False)
        Me.ToolStripCamRecoControl.ResumeLayout(False)
        Me.ToolStripCamRecoControl.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.AllowedErrors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.ImageCount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents VisonTabControl As TabControl
    Friend WithEvents TabPageVisionReco As TabPage
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents GroupBoxIdentificationDatabase As GroupBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents PB_Capture As PictureBox
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents PB_TARGET As PictureBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents PB_DETECT As PictureBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents GroupBox12 As GroupBox
    Friend WithEvents PictureBox_Preview As PictureBox
    Friend WithEvents SplitContainer3 As SplitContainer
    Friend WithEvents SplitContainer4 As SplitContainer
    Friend WithEvents SplitContainer5 As SplitContainer
    Friend WithEvents ComboBox_Devices As ComboBox
    Friend WithEvents Label_SelectCamera As Label
    Friend WithEvents ComboBox_FrameSize As ComboBox
    Friend WithEvents Label_SelectCaptureSize As Label
    Friend WithEvents Button_Save As Button
    Friend WithEvents Button_Connect As Button
    Friend WithEvents ButtonDetectNose As Button
    Friend WithEvents ButtonDetectSmile As Button
    Friend WithEvents ButtonAll As Button
    Friend WithEvents ButtonEyes As Button
    Friend WithEvents ButtonDetectEars As Button
    Friend WithEvents ButtonDetectFace As Button
    Friend WithEvents SplitContainer6 As SplitContainer
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox_ImageDir As TextBox
    Friend WithEvents Label_FaceDatabaseLocation As Label
    Friend WithEvents ToolStripCamRecoControl As ToolStrip
    Friend WithEvents ButtonBrowser As ToolStripButton
    Friend WithEvents ButtonLoad As ToolStripButton
    Friend WithEvents ButtonReload As ToolStripButton
    Friend WithEvents ButtonSearch As ToolStripButton
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents AllowedErrors As NumericUpDown
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ImageCount As NumericUpDown
    Friend WithEvents ButtonAdd As Button
    Friend WithEvents Label_ImageSize As Label
    Friend WithEvents Label_ImageSaved As Label
    Friend WithEvents LabelMatches As Label
    Friend WithEvents GroupBox10 As GroupBox
    Friend WithEvents chb1 As CheckBox
    Friend WithEvents opt4 As RadioButton
    Friend WithEvents opt3 As RadioButton
    Friend WithEvents Op2 As RadioButton
    Friend WithEvents opt1 As RadioButton
    Friend WithEvents Label6 As Label
    Friend WithEvents lMovements As TextBox
    Friend WithEvents lblInfo As Label
    Friend WithEvents ButtonAddToDb As ToolStripButton
End Class
