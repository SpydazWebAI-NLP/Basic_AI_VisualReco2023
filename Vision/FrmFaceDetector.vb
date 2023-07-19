Imports System.Drawing
Imports System.Windows.Forms
Imports Basic_AI_VisualReco2023.Imaging.AI_Object_Detector
Imports Basic_AI_VisualReco2023.Imaging.AI_Object_Detector.ObjectDetector
Imports Basic_AI_VisualReco2023.Imaging.AI_Object_Detector.ObjectDetector.HaarDetector

Public Class Frm_FaceDetector

    Private Detector As ObjectDetector.HaarDetector

    '--------------------------------------------------------------------------
    ' HaarCascadeClassifierTEST > Form1.vb
    '--------------------------------------------------------------------------
    ' Huseyin Atasoy
    ' huseyin@atasoyweb.net
    ' www.atasoyweb.net
    ' July 2012
    '--------------------------------------------------------------------------
    ' Copyright 2012 Huseyin Atasoy
    '
    ' Licensed under the Apache License, Version 2.0 (the "License");
    ' you may not use this file except in compliance with the License.
    ' You may obtain a copy of the License at
    '
    '     http://www.apache.org/licenses/LICENSE-2.0
    '
    ' Unless required by applicable law or agreed to in writing, software
    ' distributed under the License is distributed on an "AS IS" BASIS,
    ' WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    ' See the License for the specific language governing permissions and
    ' limitations under the License.
    '--------------------------------------------------------------------------
    Private SelectedBitmap As Bitmap

    Public Sub Detect(ByRef Pict As PictureBox)
        If Detector Is Nothing Then
            LoadXml()
        End If
        'Detection Parameters
        Dim MaxDetCount As Integer = Integer.MaxValue
        Dim MinNRectCount As Integer = 0
        Dim FirstScale As Single = Detector.Size2Scale(100)
        Dim MaxScale As Single = Detector.Size2Scale(200)
        Dim ScaleMult As Single = 1.1
        Dim SizeMultForNesRectCon As Single = 0.3
        Dim SlidingRatio As Single = 0.2
        Dim Pen As New Pen(Brushes.Red, 4)
        Dim DetectorParameters As New DetectionParams(MaxDetCount, MinNRectCount, FirstScale, MaxScale, ScaleMult, SizeMultForNesRectCon, SlidingRatio, Pen)

        Dim Bmp As Bitmap = SelectedBitmap.Clone

        Dim Start As DateTime = Now
        Dim Results As DResults = Detector.DETECT(Bmp, DetectorParameters)
        Dim Elapsed As TimeSpan = Now - Start

        Pict.Image = Bmp

    End Sub

    Public Sub LoadDetections()
        ComboBoxDetections.Items.Add("Standard")

        ComboBoxDetections.SelectedIndex = 0
        ComboBoxDetections.Items.Add("frontalface_alt")
        ComboBoxDetections.Items.Add("frontalface_alt2")
        ComboBoxDetections.Items.Add("frontalface_default")
        ComboBoxDetections.Items.Add("profileface")
        ComboBoxDetections.Items.Add("eye")
        ComboBoxDetections.Items.Add("Eye_tree_eyeglasses")
        ComboBoxDetections.Items.Add("frontalcatface")
        ComboBoxDetections.Items.Add("frontalcatface_extended")
        ComboBoxDetections.Items.Add("fullbody")
        ComboBoxDetections.Items.Add("lowerbody")
        ComboBoxDetections.Items.Add("smile")
        ComboBoxDetections.Items.Add("lefteye_2splits")
        ComboBoxDetections.Items.Add("righteye_2splits")
        ComboBoxDetections.Items.Add("licence_plate_rus_16stages")
        ComboBoxDetections.Items.Add("russian_plate_number")
        ComboBoxDetections.Items.Add("upperbody")

    End Sub

    Public Sub LoadXml()

        Dim XMLDoc As New Xml.XmlDocument

        Select Case ComboBoxDetections.SelectedItem.ToString
            Case "eye"
                XMLDoc.LoadXml(My.Resources.Front_eyes)
            Case "frontalface_alt"
                XMLDoc.LoadXml(My.Resources.Xhaarcascade_frontalface_alt)
            Case "frontalface_default"
                XMLDoc.LoadXml(My.Resources.haarcascade_frontalface_default)
            Case "profileface"
                XMLDoc.LoadXml(My.Resources.haarcascade_profileface)
            Case "eye_tree_eyeglasses"
                XMLDoc.LoadXml(My.Resources.haarcascade_eye_tree_eyeglasses)
            Case "CatDetector"
                XMLDoc.LoadXml(My.Resources.mycatdetector)
            Case "DogDetector"
                XMLDoc.LoadXml(My.Resources.mydogdetector)
            Case "fullbody"
                XMLDoc.LoadXml(My.Resources.haarcascade_fullbody)
            Case "lowerbody"
                XMLDoc.LoadXml(My.Resources.haarcascade_lowerbody)
            Case "smile"
                XMLDoc.LoadXml(My.Resources.haarcascade_smile)
            Case "lefteye_2splits"
                XMLDoc.LoadXml(My.Resources.left_ear)
            Case "right ear"
                XMLDoc.LoadXml(My.Resources.right_ear)
            Case "eye"
                XMLDoc.LoadXml(My.Resources.Front_eyes)
            Case "Mouth"
                XMLDoc.LoadXml(My.Resources.mouth)
            Case "upperbody"
                XMLDoc.LoadXml(My.Resources.haarcascade_upperbody)
            Case "Standard"
                XMLDoc.LoadXml(My.Resources.Xhaarcascade_frontalface_alt)
        End Select

        Detector = New HaarDetector(XMLDoc)

    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Dim OFDialog As New OpenFileDialog()
        Try
            OFDialog.Filter = "Images|*.tiff;*.jpg;*.jpeg;*.png;*.gif;*.bmp"
            OFDialog.FilterIndex = 0
            OFDialog.FileName = ""
            If Not OFDialog.ShowDialog() = DialogResult.OK Then
                Return
            End If
        Catch
            Return
        End Try

        SelectedBitmap = New Bitmap(OFDialog.FileName)
        PictureBox1.Image = SelectedBitmap.Clone

        btnDetect.Enabled = True
        ' ButtonGO.Enabled = True
    End Sub

    Private Sub btnDetect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetect.Click
        If Detector Is Nothing Then
            LoadXml()
        End If

        Dim MaxDetCount As Integer = Integer.MaxValue
        Dim MinNRectCount As Integer = nudMinNRectCount.Value
        Dim FirstScale As Single = Detector.Size2Scale(nudMinSize.Value)
        Dim MaxScale As Single = Detector.Size2Scale(nudMaxSize.Value)
        Dim ScaleMult As Single = nudScaleMult.Value
        Dim SizeMultForNesRectCon As Single = nudSizeMultForNesRectCon.Value
        Dim SlidingRatio As Single = nudSlidingRatio.Value
        Dim Pen As New Pen(Brushes.Red, nudLineWidth.Value)
        Dim DetectorParameters As New DetectionParams(MaxDetCount, MinNRectCount, FirstScale, MaxScale, ScaleMult, SizeMultForNesRectCon, SlidingRatio, Pen)

        Dim Bmp As Bitmap = SelectedBitmap.Clone

        Dim Start As DateTime = Now
        Dim Results As DResults = Detector.DETECT(Bmp, DetectorParameters)
        Dim Elapsed As TimeSpan = Now - Start

        PictureBox1.Image = Bmp
        lblInfo.Text = Results.SearchedSubRegionCount & " subregions were searched and " & Results.NOfObjects & " object(s) were detected in " & Math.Round(Elapsed.TotalMilliseconds, 3).ToString & " milliseconds."
    End Sub

    Private Sub ButtonGO_Click(sender As Object, e As EventArgs) Handles ButtonGO.Click
        Dim Start As DateTime = Now
        LoadXml()
        lblInfo.Text = "XML cascade parsed in " & Math.Round((Now - Start).TotalMilliseconds, 3).ToString & " milliseconds."
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '    LoadXml()
        LoadDetections()

    End Sub

End Class