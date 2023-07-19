<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_FaceDetector
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_FaceDetector))
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.nudMinNRectCount = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nudMinSize = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.nudMaxSize = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.nudScaleMult = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.nudSizeMultForNesRectCon = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.nudSlidingRatio = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.nudLineWidth = New System.Windows.Forms.NumericUpDown()
        Me.btnDetect = New System.Windows.Forms.Button()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.ComboBoxDetections = New System.Windows.Forms.ComboBox()
        Me.ButtonGO = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMinNRectCount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMinSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMaxSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudScaleMult, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudSizeMultForNesRectCon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudSlidingRatio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudLineWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnBrowse
        '
        Me.btnBrowse.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnBrowse.Location = New System.Drawing.Point(454, 335)
        Me.btnBrowse.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(100, 33)
        Me.btnBrowse.TabIndex = 0
        Me.btnBrowse.Text = "Browse..."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(83, 43)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(359, 325)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'nudMinNRectCount
        '
        Me.nudMinNRectCount.Location = New System.Drawing.Point(676, 18)
        Me.nudMinNRectCount.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.nudMinNRectCount.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudMinNRectCount.Name = "nudMinNRectCount"
        Me.nudMinNRectCount.Size = New System.Drawing.Size(60, 26)
        Me.nudMinNRectCount.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.nudMinNRectCount, resources.GetString("nudMinNRectCount.ToolTip"))
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(451, 18)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(217, 30)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Min neighbor rectangle count:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(451, 56)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(217, 30)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Min size of searched object:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nudMinSize
        '
        Me.nudMinSize.Location = New System.Drawing.Point(676, 56)
        Me.nudMinSize.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.nudMinSize.Maximum = New Decimal(New Integer() {640, 0, 0, 0})
        Me.nudMinSize.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudMinSize.Name = "nudMinSize"
        Me.nudMinSize.Size = New System.Drawing.Size(60, 26)
        Me.nudMinSize.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.nudMinSize, resources.GetString("nudMinSize.ToolTip"))
        Me.nudMinSize.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(451, 94)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(217, 30)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Max size of searched object:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nudMaxSize
        '
        Me.nudMaxSize.Location = New System.Drawing.Point(676, 94)
        Me.nudMaxSize.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.nudMaxSize.Maximum = New Decimal(New Integer() {640, 0, 0, 0})
        Me.nudMaxSize.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudMaxSize.Name = "nudMaxSize"
        Me.nudMaxSize.Size = New System.Drawing.Size(60, 26)
        Me.nudMaxSize.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.nudMaxSize, resources.GetString("nudMaxSize.ToolTip"))
        Me.nudMaxSize.Value = New Decimal(New Integer() {200, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(451, 132)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(217, 30)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Scale multiplier:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nudScaleMult
        '
        Me.nudScaleMult.DecimalPlaces = 2
        Me.nudScaleMult.Increment = New Decimal(New Integer() {5, 0, 0, 131072})
        Me.nudScaleMult.Location = New System.Drawing.Point(676, 132)
        Me.nudScaleMult.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.nudScaleMult.Maximum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.nudScaleMult.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudScaleMult.Name = "nudScaleMult"
        Me.nudScaleMult.Size = New System.Drawing.Size(60, 26)
        Me.nudScaleMult.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.nudScaleMult, resources.GetString("nudScaleMult.ToolTip"))
        Me.nudScaleMult.Value = New Decimal(New Integer() {11, 0, 0, 65536})
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(451, 170)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(217, 30)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Nested rectangle size multiplier:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nudSizeMultForNesRectCon
        '
        Me.nudSizeMultForNesRectCon.DecimalPlaces = 2
        Me.nudSizeMultForNesRectCon.Increment = New Decimal(New Integer() {5, 0, 0, 131072})
        Me.nudSizeMultForNesRectCon.Location = New System.Drawing.Point(676, 170)
        Me.nudSizeMultForNesRectCon.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.nudSizeMultForNesRectCon.Name = "nudSizeMultForNesRectCon"
        Me.nudSizeMultForNesRectCon.Size = New System.Drawing.Size(60, 26)
        Me.nudSizeMultForNesRectCon.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.nudSizeMultForNesRectCon, resources.GetString("nudSizeMultForNesRectCon.ToolTip"))
        Me.nudSizeMultForNesRectCon.Value = New Decimal(New Integer() {3, 0, 0, 65536})
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(451, 208)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(217, 30)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Sliding Ratio:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nudSlidingRatio
        '
        Me.nudSlidingRatio.DecimalPlaces = 1
        Me.nudSlidingRatio.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.nudSlidingRatio.Location = New System.Drawing.Point(676, 208)
        Me.nudSlidingRatio.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.nudSlidingRatio.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudSlidingRatio.Minimum = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.nudSlidingRatio.Name = "nudSlidingRatio"
        Me.nudSlidingRatio.Size = New System.Drawing.Size(60, 26)
        Me.nudSlidingRatio.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.nudSlidingRatio, resources.GetString("nudSlidingRatio.ToolTip"))
        Me.nudSlidingRatio.Value = New Decimal(New Integer() {2, 0, 0, 65536})
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(451, 246)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(217, 30)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Rectangle line width:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nudLineWidth
        '
        Me.nudLineWidth.Location = New System.Drawing.Point(676, 246)
        Me.nudLineWidth.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.nudLineWidth.Maximum = New Decimal(New Integer() {8, 0, 0, 0})
        Me.nudLineWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudLineWidth.Name = "nudLineWidth"
        Me.nudLineWidth.Size = New System.Drawing.Size(60, 26)
        Me.nudLineWidth.TabIndex = 14
        Me.nudLineWidth.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'btnDetect
        '
        Me.btnDetect.Enabled = False
        Me.btnDetect.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnDetect.Location = New System.Drawing.Point(568, 335)
        Me.btnDetect.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnDetect.Name = "btnDetect"
        Me.btnDetect.Size = New System.Drawing.Size(100, 33)
        Me.btnDetect.TabIndex = 16
        Me.btnDetect.Text = "Detect"
        Me.btnDetect.UseVisualStyleBackColor = True
        '
        'lblInfo
        '
        Me.lblInfo.BackColor = System.Drawing.Color.Transparent
        Me.lblInfo.ForeColor = System.Drawing.Color.Ivory
        Me.lblInfo.Location = New System.Drawing.Point(12, 374)
        Me.lblInfo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(724, 27)
        Me.lblInfo.TabIndex = 17
        '
        'ComboBoxDetections
        '
        Me.ComboBoxDetections.FormattingEnabled = True
        Me.ComboBoxDetections.Location = New System.Drawing.Point(454, 290)
        Me.ComboBoxDetections.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxDetections.Name = "ComboBoxDetections"
        Me.ComboBoxDetections.Size = New System.Drawing.Size(282, 27)
        Me.ComboBoxDetections.TabIndex = 18
        '
        'ButtonGO
        '
        Me.ButtonGO.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ButtonGO.Location = New System.Drawing.Point(676, 335)
        Me.ButtonGO.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ButtonGO.Name = "ButtonGO"
        Me.ButtonGO.Size = New System.Drawing.Size(63, 33)
        Me.ButtonGO.TabIndex = 16
        Me.ButtonGO.Text = "Load"
        Me.ButtonGO.UseVisualStyleBackColor = True
        '
        'Frm_FaceDetector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImage = Global.Basic_AI_VisualReco2023.My.Resources.Resources.Console_C
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(752, 407)
        Me.Controls.Add(Me.ComboBoxDetections)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.ButtonGO)
        Me.Controls.Add(Me.btnDetect)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.nudLineWidth)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.nudSlidingRatio)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.nudSizeMultForNesRectCon)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.nudScaleMult)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.nudMaxSize)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.nudMinSize)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.nudMinNRectCount)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnBrowse)
        Me.Font = New System.Drawing.Font("Comic Sans MS", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.Name = "Frm_FaceDetector"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HAAR Detector"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMinNRectCount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMinSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMaxSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudScaleMult, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudSizeMultForNesRectCon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudSlidingRatio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudLineWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents nudMinNRectCount As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents nudMinSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents nudMaxSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents nudScaleMult As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents nudSizeMultForNesRectCon As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents nudSlidingRatio As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents nudLineWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnDetect As System.Windows.Forms.Button
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents ComboBoxDetections As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonGO As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
