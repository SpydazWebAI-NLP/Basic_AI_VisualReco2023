Imports System.Drawing
Imports System.Windows.Forms
Imports Basic_AI_VisualReco2023.Imaging
Imports Basic_AI_VisualReco2023.Imaging.AI_Object_Detector
Imports Basic_AI_VisualReco2023.Imaging.AI_Object_Detector.ObjectDetector
Imports Basic_AI_VisualReco2023.Imaging.AI_Object_Detector.ObjectDetector.HaarDetector

Public Class FrmVisualSensor
    Private Detector As ObjectDetector.HaarDetector

    Dim SelectedBitmap As Bitmap

    ''' <summary>
    ''' Using Detector(FACE)
    ''' </summary>
    Public Sub Detect(ByRef pbox As PictureBox)
        Dim XMLDoc As New Xml.XmlDocument
        If Detector Is Nothing Then
            'Load
            XMLDoc.LoadXml(My.Resources.Xhaarcascade_frontalface_alt)
            Detector = New HaarDetector(XMLDoc)
        End If

        SelectedBitmap = New Bitmap(pbox.Image)

        'Detection Parameters
        Dim MaxDetCount As Integer = Integer.MaxValue
        Dim MinNRectCount As Integer = 0
        Dim FirstScale As Single = Detector.Size2Scale(100)
        Dim MaxScale As Single = Detector.Size2Scale(200)
        Dim ScaleMult As Single = 1.1
        Dim SizeMultForNesRectCon As Single = 0.3
        Dim SlidingRatio As Single = 0.1
        Dim Pen As New Pen(Brushes.Red, 4)
        Dim DetectorParameters As New DetectionParams(MaxDetCount, MinNRectCount, FirstScale, MaxScale, ScaleMult, SizeMultForNesRectCon, SlidingRatio, Pen)

        ' Dim Bmp As Bitmap = ConvertPixelformat(SelectedBitmap.Clone)
        Dim Bmp As Bitmap = SelectedBitmap.Clone

        Dim Start As DateTime = Now
        Dim Results As DResults = Detector.DETECT(Bmp, DetectorParameters)
        Dim Elapsed As TimeSpan = Now - Start
        lblInfo.Text = Results.SearchedSubRegionCount & " subregions were searched and " & Results.NOfObjects & " object(s) were detected in " & Math.Round(Elapsed.TotalMilliseconds, 3).ToString & " milliseconds."

        pbox.Image = Bmp
        pbox.Refresh()
    End Sub

    Public Sub StartDetect()
        On Error Resume Next

        Dim data As IDataObject
        Dim bmap As Image

        '
        ' Copy image to clipboard
        '
        SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0)

        '
        ' Get image from clipboard and convert it to a bitmap
        '
        data = Clipboard.GetDataObject()
        If data.GetDataPresent(GetType(System.Drawing.Bitmap)) Then
            bmap = CType(data.GetData(GetType(System.Drawing.Bitmap)), Image)

            'Stop Device Capture
            ClosePreviewWindow()
            pView.Image = New Bitmap(bmap)
            pView.Refresh()
            Detect(pView)
            data = Nothing
        Else

        End If

    End Sub

    Private Sub ButtonDetect_Click(sender As Object, e As EventArgs) Handles ButtonDetect.Click
        StartDetect()
    End Sub

    'Set Object To Default Value
    Private Sub ClearAllObject()
        On Error Resume Next
        opt2.Checked = True
        lst1.Items.Clear()
        lst1.Refresh()
        pView.BackColor = Color.Black
        pView.BackgroundImageLayout = ImageLayout.Stretch
        pView.Image = Nothing
        pView.SizeMode = PictureBoxSizeMode.StretchImage
        pView.Refresh()

        cmd1.Enabled = True
        cmd2.Enabled = False
        cmd3.Enabled = False
        'Load Device List
        Call LoadDeviceList()
    End Sub

    Private Sub ClosePreviewWindow()
        On Error Resume Next
        '
        ' Disconnect from device
        '
        SendMessage(hHwnd, WM_CAP_DRIVER_DISCONNECT, iDevice, 0)

        '
        ' close window
        '

        DestroyWindow(hHwnd)

        cmd1.Enabled = True
        cmd2.Enabled = False
        cmd3.Enabled = False

        pView.Image = Nothing
        pView.SizeMode = PictureBoxSizeMode.StretchImage
        pView.BackColor = Color.Black
        pView.BackgroundImage = Nothing
        pView.BackgroundImageLayout = ImageLayout.None
        pView.Refresh()

    End Sub

    Private Sub cmd1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd1.Click
        On Error Resume Next
        'Device
        iDevice = lst1.SelectedIndex
        'Load And Capture Device
        OpenPreviewWindow()
        lMovements.Text = 0
        Timer1.Enabled = True
    End Sub

    Private Sub cmd2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd2.Click
        On Error Resume Next
        'Stop Device Capture
        ClosePreviewWindow()
    End Sub

    Private Sub cmd3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd3.Click
        On Error Resume Next

        Dim data As IDataObject
        Dim bmap As Image

        '
        ' Copy image to clipboard
        '
        SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0)

        '
        ' Get image from clipboard and convert it to a bitmap
        '
        data = Clipboard.GetDataObject()
        If data.GetDataPresent(GetType(System.Drawing.Bitmap)) Then
            bmap = CType(data.GetData(GetType(System.Drawing.Bitmap)), Image)

            'Stop Device Capture
            ClosePreviewWindow()
            pView.Image = New Bitmap(bmap)

            'Set Button
            cmd3.Enabled = False
            cmd2.Enabled = False
            cmd1.Enabled = True

            'Set Save Dialog
            sfdImages.FileName = ""
            sfdImages.Title = "Save Picture"
            sfdImages.Filter = "Bitmap|*.bmp|Jpeg|*.jpg|GIF|*.gif|PNG|*.png"

            'If File Name Not Equal "" then Save The File
            If sfdImages.ShowDialog = DialogResult.OK Then
                Select Case Microsoft.VisualBasic.Right$(sfdImages.FileName, 3)
                    Case Is = "bmp"
                        bmap.Save(sfdImages.FileName, Drawing.Imaging.ImageFormat.Bmp)
                    Case Is = "jpg"
                        bmap.Save(sfdImages.FileName, Drawing.Imaging.ImageFormat.Jpeg)
                    Case Is = "gif"
                        bmap.Save(sfdImages.FileName, Drawing.Imaging.ImageFormat.Gif)
                    Case Is = "png"
                        bmap.Save(sfdImages.FileName, Drawing.Imaging.ImageFormat.Png)
                End Select
            End If

        End If

        data = Nothing
    End Sub

    Private Function ConvertPixelformat(ByRef Bmp As Bitmap) As Bitmap

        ' Create a Bitmap object from a file.
        Dim myBitmap As New Bitmap(Bmp)

        ' Clone a portion of the Bitmap object.
        Dim cloneRect As New Rectangle(0, 0, Bmp.Width, Bmp.Height)
        Dim format As Drawing.Imaging.PixelFormat = Drawing.Imaging.PixelFormat.Format32bppArgb
        Dim cloneBitmap As Bitmap = myBitmap.Clone(cloneRect, format)

        Return cloneBitmap
    End Function

    'If Form Closed
    Private Sub Form1_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        On Error Resume Next
        'If Played the Stopped
        If cmd2.Enabled Then
            ClosePreviewWindow()
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        'Load Object Value TO Default
        ClearAllObject()
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.DoubleClick
        GroupBox2.Height = If(GroupBox2.Height = 77, 22, 77)
    End Sub

    Private Sub GroupBox5_Enter(sender As Object, e As EventArgs) Handles GroupBox5.DoubleClick
        GroupBox5.Height = If(GroupBox5.Height = 53, 22, 53)
    End Sub

    'Load Webcam Device List
    Private Sub LoadDeviceList()
        On Error Resume Next
        Dim strName As String = Space(100)
        Dim strVer As String = Space(100)
        Dim bReturn As Boolean
        Dim x As Integer = 0

        Do
            bReturn = capGetDriverDescriptionA(x, strName, 100, strVer, 100)
            If bReturn Then
                lst1.Items.Add(strName.Trim)
            End If

            x += 1
            Application.DoEvents()
        Loop Until bReturn = False

    End Sub

    'Open View
    Private Sub OpenPreviewWindow()
        On Error Resume Next

        Dim iHeight As Integer = pView.Height
        Dim iWidth As Integer = pView.Width

        '
        ' Open Preview window in picturebox
        '
        hHwnd = capCreateCaptureWindowA(iDevice, WS_VISIBLE Or WS_CHILD, 0, 0, 640,
            480, pView.Handle.ToInt32, 0)

        '
        ' Connect to device
        '
        If SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, iDevice, 0) Then
            '
            'Set the preview scale
            '
            SendMessage(hHwnd, WM_CAP_SET_SCALE, True, 0)

            '
            'Set the preview rate in milliseconds
            '
            SendMessage(hHwnd, WM_CAP_SET_PREVIEWRATE, 66, 0)

            '
            'Start previewing the image from the camera
            '
            SendMessage(hHwnd, WM_CAP_SET_PREVIEW, True, 0)

            '
            ' Resize window to fit in picturebox
            '
            SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, pView.Width, pView.Height,
                    SWP_NOMOVE Or SWP_NOZORDER)

            cmd1.Enabled = False
            cmd2.Enabled = True
            cmd3.Enabled = True
            ButtonDetect.Enabled = True
        Else
            '
            ' Error connecting to device close window
            '
            DestroyWindow(hHwnd)

            cmd1.Enabled = True
            cmd2.Enabled = False
            cmd3.Enabled = False
            ButtonDetect.Enabled = False
            pView.Image = Nothing
            pView.SizeMode = PictureBoxSizeMode.StretchImage
            pView.BackColor = Color.Black
            pView.BackgroundImage = Nothing
            pView.BackgroundImageLayout = ImageLayout.None
            pView.Refresh()

        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lMovements.Text = DetectMovement()
        Application.DoEvents()

        If opt1.Checked = True Then
            pView.Image = InvertPicturesFromCapturedWindow()
        End If
        If opt2.Checked = True Then
            pView.Image = pView.Image
        End If
        If opt3.Checked = True Then
            pView.Image = GrayScalePicture()
        End If
        If opt4.Checked = True Then
            pView.Image = SephiaRed()
        End If

    End Sub

End Class