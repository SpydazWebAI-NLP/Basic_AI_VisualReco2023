Imports System.Drawing
Imports System.Windows.Forms
Imports Basic_AI_VisualReco2023.HardwareSystemInterfaces.Camera
Imports Basic_AI_VisualReco2023.Imaging
Imports Basic_AI_VisualReco2023.Imaging.AI_Picture_Matcher

Public Class VisionTabs
    Private WithEvents cam As New DSCamCapture
    Dim appPath As String = My.Application.Info.DirectoryPath
    Private CompareFile As String = ""
    Dim fName As String = ""
    Private FoldersLoaded As Boolean = False
    Private ImageALoaded As Boolean = False
    Dim MyPicturesFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
    Private Picmatcher As New FindImageMatch

    ''' <summary>
    ''' DETECT FACE IN BOX
    ''' </summary>
    ''' <param name="pb"></param>
    ''' <returns></returns>
    Public Function DO_DETECT(ByRef pb As PictureBox) As PictureBox
        'Load And Capture Device
        pb = Pic_SYS.Detectface(pb)
        If FoundImages.Count > 0 Then
            pb.Image = FoundImages(0)
            pb.SizeMode = PictureBoxSizeMode.StretchImage
        Else
            '  DO_DETECT
        End If
        Return pb
    End Function

    Public Sub LoadDatabaseFolder(ByRef Path As String)
        Dim Count As Integer = Picmatcher.GetFiles(Path)
        FoldersLoaded = True
        If FoldersLoaded = True Then
            Label3.Text = "Files loaded :" & Count
        End If
    End Sub

    Public Function Search(ByRef pb As PictureBox) As PictureBox
        Dim Bmp1 As Bitmap
        Bmp1 = pb.Image.Clone()
        Dim foundErrors As Integer = 0
        Dim found As Boolean = False
        Dim FoundImage As New Bitmap(Bmp1)
        found = Picmatcher.CompareImagesFiles(Bmp1, Picmatcher.Files, AllowedErrors.Value, foundErrors, FoundImage)
        If found = True Then
            PB_DETECT.Image = FoundImage
            PB_DETECT.SizeMode = PictureBoxSizeMode.StretchImage
            LabelMatches.Text = "Match Found"
        Else
            LabelMatches.Text = "Match Not Found"
        End If
        Return pb
    End Function

    Private Sub Button_Connect_Click(sender As Object, e As EventArgs) Handles Button_Connect.Click
        If Not cam.IsConnected Then
            Dim si As Integer = ComboBox_FrameSize.SelectedIndex
            Dim SelectedSize As DSCamCapture.FrameSizes = CType(si, DSCamCapture.FrameSizes)
            If cam.ConnectToDevice(ComboBox_Devices.SelectedIndex, 15, PictureBox_Preview.ClientSize, SelectedSize, PictureBox_Preview.Handle) Then
                cam.Start()
                Button_Connect.Text = "Disconnect"

                ButtonDetectFace.Enabled = True
                ButtonDetectSmile.Enabled = True
                ButtonEyes.Enabled = True
                ButtonDetectNose.Enabled = True
                ButtonDetectEars.Enabled = True
                ButtonAll.Enabled = True
            End If
        Else
            cam.Dispose()
            Button_Connect.Text = "Connect"
        End If
        Button_Save.Enabled = cam.IsConnected
        ComboBox_Devices.Enabled = Not cam.IsConnected
        ComboBox_FrameSize.Enabled = Not cam.IsConnected
    End Sub

    Private Sub Button_Save_Click(sender As Object, e As EventArgs) Handles Button_Save.Click
        If Not IO.Directory.Exists(MyPicturesFolder) Then IO.Directory.CreateDirectory(MyPicturesFolder)
        fName = Now.ToString.Replace("/", "-").Replace(":", "-").Replace(" ", "_") & ".jpg"
        Dim SaveAs As String = IO.Path.Combine(MyPicturesFolder, fName)
        cam.SaveCurrentFrame(SaveAs, Drawing.Imaging.ImageFormat.Jpeg)
        ButtonAdd.Enabled = True
    End Sub

    Private Sub ButtonAdd_Click(sender As Object, e As EventArgs) Handles ButtonAdd.Click
        PB_TARGET.Image = PB_Capture.Image

        CompareFile = Application.StartupPath & "\images\DataFaces\Temp.Jpg"
    End Sub

    Private Sub ButtonAddToDb_Click(sender As Object, e As EventArgs) Handles ButtonAddToDb.Click
        QuickSave(PB_Capture, Application.StartupPath & "\images\DataFaces\Temp.Jpg")
    End Sub

    Private Sub ButtonAll_Click(sender As Object, e As EventArgs) Handles ButtonAll.Click
        PictureBox_Preview = DetectItemfromVideobox(PictureBox_Preview, "All")
        If FoundImages.Count > 0 Then
            PB_Capture.Image = FoundImages(FoundImages.Count - 1)
            ImageCount.Maximum = FoundImages.Count
            ImageCount.Minimum = 1
            ImageCount.Value = FoundImages.Count
            PB_Capture.SizeMode = PictureBoxSizeMode.StretchImage
            lblInfo.Text = DetectionResults.SearchedSubRegionCount & " subregions were searched and " & DetectionResults.NOfObjects & " object(s) were detected: "
            ButtonSearch.Enabled = True
            ButtonAdd.Enabled = True
            ButtonDetectFace.Enabled = False
            ButtonDetectSmile.Enabled = False
            Button_Connect.Enabled = False
            ButtonAll.Enabled = False
            ButtonEyes.Enabled = False
            ButtonDetectFace.Enabled = False
            Button_Save.Enabled = True
        Else
            ImageCount.Maximum = 0
            ImageCount.Minimum = 0
            ImageCount.Value = 0
            lblInfo.Text = DetectionResults.SearchedSubRegionCount & " subregions were searched and " & DetectionResults.NOfObjects & " object(s) were detected: "
            PB_Capture = Pic_SYS.SetPictureBox(PB_Capture)
        End If
    End Sub

    Private Sub ButtonBrowser_Click(sender As Object, e As EventArgs) Handles ButtonBrowser.Click
        Dim Fdialog As New FolderBrowserDialog
        Fdialog.ShowDialog()
        Dim Folder As String = Fdialog.SelectedPath
        TextBox_ImageDir.Text = Folder
        LoadDatabaseFolder(TextBox_ImageDir.Text)
    End Sub

    Private Sub ButtonDetectEars_Click(sender As Object, e As EventArgs) Handles ButtonDetectEars.Click
        PictureBox_Preview = DetectItemfromVideobox(PictureBox_Preview, "Ears")
        If FoundImages IsNot Nothing Then
            If FoundImages.Count > 0 Then
                PB_Capture.Image = FoundImages(FoundImages.Count - 1)
                ImageCount.Maximum = FoundImages.Count
                ImageCount.Minimum = 1
                ImageCount.Value = FoundImages.Count
                PB_Capture.SizeMode = PictureBoxSizeMode.StretchImage
                lblInfo.Text = DetectionResults.SearchedSubRegionCount & " subregions were searched and " & DetectionResults.NOfObjects & " object(s) were detected: "
                ButtonSearch.Enabled = True
                ButtonAdd.Enabled = True
                ButtonDetectFace.Enabled = False
                ButtonDetectSmile.Enabled = False
                Button_Connect.Enabled = False
                ButtonEyes.Enabled = False
                ButtonAll.Enabled = False
                ButtonDetectNose.Enabled = False
                ButtonDetectSmile.Enabled = False
                Button_Save.Enabled = True
            Else
                ImageCount.Maximum = 0
                ImageCount.Minimum = 0
                ImageCount.Value = 0
                lblInfo.Text = DetectionResults.SearchedSubRegionCount & " subregions were searched and " & DetectionResults.NOfObjects & " object(s) were detected: "
                PB_Capture = Pic_SYS.SetPictureBox(PB_Capture)
            End If
        Else
            ImageCount.Maximum = 0
            ImageCount.Minimum = 0
            ImageCount.Value = 0
            lblInfo.Text = DetectionResults.SearchedSubRegionCount & " subregions were searched and " & DetectionResults.NOfObjects & " object(s) were detected: "
            PB_Capture = Pic_SYS.SetPictureBox(PB_Capture)
        End If
    End Sub

    Private Sub ButtonDetectFace_Click(sender As Object, e As EventArgs) Handles ButtonDetectFace.Click
        PictureBox_Preview = DetectItemfromVideobox(PictureBox_Preview, "Face")
        If FoundImages.Count > 0 Then
            PB_Capture.Image = FoundImages(FoundImages.Count - 1)
            ImageCount.Maximum = FoundImages.Count
            ImageCount.Minimum = 1
            ImageCount.Value = FoundImages.Count
            PB_Capture.SizeMode = PictureBoxSizeMode.StretchImage
            lblInfo.Text = DetectionResults.SearchedSubRegionCount & " subregions were searched and " & DetectionResults.NOfObjects & " object(s) were detected: "
            ButtonSearch.Enabled = True
            ButtonAdd.Enabled = True
            ButtonDetectFace.Enabled = False
            ButtonDetectSmile.Enabled = False
            ButtonAll.Enabled = False
            ButtonEyes.Enabled = False
            Button_Connect.Enabled = False
            ButtonDetectEars.Enabled = False
            Button_Save.Enabled = True
        Else
            ImageCount.Maximum = 0
            ImageCount.Minimum = 0
            ImageCount.Value = 0
            lblInfo.Text = DetectionResults.SearchedSubRegionCount & " subregions were searched and " & DetectionResults.NOfObjects & " object(s) were detected: "
            PB_Capture = Pic_SYS.SetPictureBox(PB_Capture)
        End If
    End Sub

    Private Sub ButtonDetectNose_Click(sender As Object, e As EventArgs) Handles ButtonDetectNose.Click
        PictureBox_Preview = DetectItemfromVideobox(PictureBox_Preview, "Nose")
        If FoundImages IsNot Nothing Then
            If FoundImages.Count > 0 Then
                PB_Capture.Image = FoundImages(FoundImages.Count - 1)
                ImageCount.Maximum = FoundImages.Count
                ImageCount.Minimum = 1
                ImageCount.Value = FoundImages.Count
                PB_Capture.SizeMode = PictureBoxSizeMode.StretchImage
                lblInfo.Text = DetectionResults.SearchedSubRegionCount & " subregions were searched and " & DetectionResults.NOfObjects & " object(s) were detected: "
                ButtonSearch.Enabled = True
                ButtonAdd.Enabled = True
                ButtonDetectFace.Enabled = False
                ButtonDetectSmile.Enabled = False
                Button_Connect.Enabled = False
                ButtonEyes.Enabled = False
                ButtonAll.Enabled = False
                ButtonDetectNose.Enabled = False
                ButtonDetectSmile.Enabled = False
                Button_Save.Enabled = True
            Else
                ImageCount.Maximum = 0
                ImageCount.Minimum = 0
                ImageCount.Value = 0
                lblInfo.Text = DetectionResults.SearchedSubRegionCount & " subregions were searched and " & DetectionResults.NOfObjects & " object(s) were detected: "
                PB_Capture = Pic_SYS.SetPictureBox(PB_Capture)
            End If
        Else
            ImageCount.Maximum = 0
            ImageCount.Minimum = 0
            ImageCount.Value = 0
            lblInfo.Text = DetectionResults.SearchedSubRegionCount & " subregions were searched and " & DetectionResults.NOfObjects & " object(s) were detected: "
            PB_Capture = Pic_SYS.SetPictureBox(PB_Capture)
        End If
    End Sub

    Private Sub ButtonDetectSmile_Click(sender As Object, e As EventArgs) Handles ButtonDetectSmile.Click
        PictureBox_Preview = DetectItemfromVideobox(PictureBox_Preview, "Smile")
        If FoundImages IsNot Nothing Then
            If FoundImages.Count > 0 Then
                PB_Capture.Image = FoundImages(FoundImages.Count - 1)
                ImageCount.Maximum = FoundImages.Count
                ImageCount.Minimum = 1
                ImageCount.Value = FoundImages.Count
                PB_Capture.SizeMode = PictureBoxSizeMode.StretchImage
                lblInfo.Text = DetectionResults.SearchedSubRegionCount & " subregions were searched and " & DetectionResults.NOfObjects & " object(s) were detected: "
                ButtonSearch.Enabled = True
                ButtonAdd.Enabled = True
                ButtonDetectFace.Enabled = False
                ButtonDetectSmile.Enabled = False
                Button_Connect.Enabled = False
                ButtonEyes.Enabled = False
                ButtonAll.Enabled = False
                ButtonDetectSmile.Enabled = False
                Button_Save.Enabled = True
            Else
                ImageCount.Maximum = 0
                ImageCount.Minimum = 0
                ImageCount.Value = 0
                lblInfo.Text = DetectionResults.SearchedSubRegionCount & " subregions were searched and " & DetectionResults.NOfObjects & " object(s) were detected: "
                PB_Capture = Pic_SYS.SetPictureBox(PB_Capture)
            End If
        Else
            ImageCount.Maximum = 0
            ImageCount.Minimum = 0
            ImageCount.Value = 0
            lblInfo.Text = DetectionResults.SearchedSubRegionCount & " subregions were searched and " & DetectionResults.NOfObjects & " object(s) were detected: "
            PB_Capture = Pic_SYS.SetPictureBox(PB_Capture)
        End If

    End Sub

    Private Sub ButtonEyes_Click(sender As Object, e As EventArgs) Handles ButtonEyes.Click
        PictureBox_Preview = DetectItemfromVideobox(PictureBox_Preview, "Eyes")
        If FoundImages IsNot Nothing Then
            If FoundImages.Count > 0 Then
                PB_Capture.Image = FoundImages(FoundImages.Count - 1)
                ImageCount.Maximum = FoundImages.Count
                ImageCount.Minimum = 1
                ImageCount.Value = FoundImages.Count
                PB_Capture.SizeMode = PictureBoxSizeMode.StretchImage
                lblInfo.Text = DetectionResults.SearchedSubRegionCount & " subregions were searched and " & DetectionResults.NOfObjects & " object(s) were detected: "
                ButtonSearch.Enabled = True
                ButtonAdd.Enabled = True
                ButtonDetectFace.Enabled = False
                ButtonDetectSmile.Enabled = False
                ButtonEyes.Enabled = False
                Button_Connect.Enabled = False
                Button_Save.Enabled = True
                ButtonDetectEars.Enabled = False
            Else
                ImageCount.Maximum = 0
                ImageCount.Minimum = 0
                ImageCount.Value = 0
                lblInfo.Text = DetectionResults.SearchedSubRegionCount & " subregions were searched and " & DetectionResults.NOfObjects & " object(s) were detected: "
                PB_Capture = Pic_SYS.SetPictureBox(PB_Capture)
            End If
        Else
            ImageCount.Maximum = 0
            ImageCount.Minimum = 0
            ImageCount.Value = 0
            lblInfo.Text = DetectionResults.SearchedSubRegionCount & " subregions were searched and " & DetectionResults.NOfObjects & " object(s) were detected: "
            PB_Capture = Pic_SYS.SetPictureBox(PB_Capture)
        End If
    End Sub

    Private Sub ButtonSearch_Click(sender As Object, e As EventArgs) Handles ButtonSearch.Click
        PB_DETECT = Pic_SYS.SetPictureBox(PB_DETECT)
        PB_TARGET.Image = PB_Capture.Image
        PB_TARGET = Search(PB_TARGET)
    End Sub

    Private Sub cam_FrameSaved(capImage As Bitmap, imgPath As String) Handles cam.FrameSaved
        PB_Capture.Image = New Bitmap(capImage)
        Label_ImageSaved.Text = "Saved - " & IO.Path.GetFileName(imgPath)
        Label_ImageSize.Text = "Size - " & PB_Capture.Image.Size.ToString

    End Sub

    Private Sub chb1_CheckedChanged(sender As Object, e As EventArgs) Handles chb1.CheckedChanged
        'lMovements.Text = DetectMovement()
    End Sub

    Private Sub ComboBox_Devices_DropDown(sender As Object, e As EventArgs) Handles ComboBox_Devices.DropDown
        ComboBox_Devices.Items.Clear()
        ComboBox_Devices.Items.AddRange(cam.GetCaptureDevices)
        Button_Connect.Enabled = (ComboBox_Devices.Items.Count > 0)
        If ComboBox_Devices.SelectedIndex = -1 And ComboBox_Devices.Items.Count > 0 Then ComboBox_Devices.SelectedIndex = 0
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        cam.Dispose()
    End Sub

#Region "Face Reco"

    Private Sub ImageCount_ValueChanged(sender As Object, e As EventArgs) Handles ImageCount.ValueChanged
        If ImageCount.Value <> 0 Then

            PB_Capture.Image = FoundImages(ImageCount.Value - 1)
            PB_TARGET.Image = FoundImages(ImageCount.Value - 1)
            PB_DETECT = Pic_SYS.SetPictureBox(PB_DETECT)
        Else
            PB_DETECT = Pic_SYS.SetPictureBox(PB_DETECT)
        End If
    End Sub

    Private Sub Op2_CheckedChanged(sender As Object, e As EventArgs) Handles Op2.CheckedChanged
        PictureBox_Preview.Image = PictureBox_Preview.Image
    End Sub

    Private Sub opt3_CheckedChanged(sender As Object, e As EventArgs) Handles opt3.CheckedChanged
        PictureBox_Preview.Image = GrayScalePicture()
    End Sub

    Private Sub opt4_CheckedChanged(sender As Object, e As EventArgs) Handles opt4.CheckedChanged
        PictureBox_Preview.Image = SephiaRed()
    End Sub

    Private Sub PictureBox_Preview_SizeChanged(sender As Object, e As EventArgs) Handles PictureBox_Preview.SizeChanged
        cam.ResizeWindow(0, 0, PictureBox_Preview.ClientSize.Width, PictureBox_Preview.ClientSize.Height)
    End Sub

    Private Sub TabPageVisionReco_ControlAdded(sender As Object, e As ControlEventArgs) Handles TabPageVisionReco.ControlAdded
        TextBox_ImageDir.Text = Application.StartupPath & "\images\DataFaces"
        LoadDatabaseFolder(TextBox_ImageDir.Text)
        ComboBox_Devices.Items.AddRange(cam.GetCaptureDevices)
        If ComboBox_Devices.Items.Count > 0 Then ComboBox_Devices.SelectedIndex = 0

        For Each sz As String In [Enum].GetNames(GetType(DSCamCapture.FrameSizes))
            ComboBox_FrameSize.Items.Add(sz.Replace("s", ""))
        Next
        If ComboBox_FrameSize.Items.Count > 2 Then ComboBox_FrameSize.SelectedIndex = 2

        Button_Connect.Enabled = (ComboBox_Devices.Items.Count > 0)
        Button_Save.Enabled = False

        'PB_Capture = Pic_SYS.OpenFile(PB_Capture)
        PB_TARGET.Image = PB_Capture.Image
        ImageALoaded = True
        ButtonSearch.Enabled = True
    End Sub

#End Region

End Class