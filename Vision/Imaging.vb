Option Explicit On
Option Strict Off

Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Globalization
Imports System.Runtime.InteropServices
Imports System.Runtime.InteropServices.Marshal
Imports System.Windows.Forms
Imports System.Xml
Imports Basic_AI_VisualReco2023.Imaging.AI_Object_Detector.ObjectDetector
Imports Basic_AI_VisualReco2023.Imaging.AI_Object_Detector.ObjectDetector.HaarCascade
Imports Basic_AI_VisualReco2023.Imaging.AI_Object_Detector.ObjectDetector.HaarDetector

Namespace Imaging
    ''' <summary>
    '''  Basic Web cam
    ''' </summary>
    Public Module modWebcam

        'Open View
        ''' <summary>
        ''' OPEN CAMERA PREVIEW
        ''' </summary>
        ''' <param name="PB">PICTUREBOX </param>
        ''' <param name="iCameraDevice">DEVICE ID </param>
        ''' <returns></returns>
        Public Function OpenPreviewWindow(ByRef PB As PictureBox, ByRef iCameraDevice As Integer) As PictureBox
            On Error Resume Next

            Dim iHeight As Integer = PB.Height
            Dim iWidth As Integer = PB.Width

            '
            ' Open Preview window in picturebox
            '
            hHwnd = capCreateCaptureWindowA(iDevice, WS_VISIBLE Or WS_CHILD, 0, 0, 640,
            480, PB.Handle.ToInt32, 0)

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
                SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, PB.Width, PB.Height,
                    SWP_NOMOVE Or SWP_NOZORDER)
            Else
                '
                ' Error connecting to device close window
                '
                DestroyWindow(hHwnd)

                PB = SetPictureBox(PB)

            End If
            Return PB
        End Function

        'CLOSE VIEW
        ''' <summary>
        ''' CLOSE CAMERA VIEW
        ''' </summary>
        ''' <param name="PB">PICTUREBOX</param>
        ''' <returns></returns>
        Public Function ClosePreviewWindow(ByRef PB As PictureBox) As PictureBox
            On Error Resume Next
            '
            ' Disconnect from device
            '
            SendMessage(hHwnd, WM_CAP_DRIVER_DISCONNECT, iDevice, 0)

            '
            ' close window
            '

            DestroyWindow(hHwnd)

            PB = SetPictureBox(PB)
            Return PB
        End Function

        'Reset Box
        ''' <summary>
        ''' Reset the picturebox
        ''' </summary>
        ''' <param name="PB"></param>
        ''' <returns></returns>
        Public Function SetPictureBox(ByRef PB As PictureBox) As PictureBox
            PB.BackColor = Color.Black
            PB.BackgroundImageLayout = ImageLayout.Stretch
            PB.Image = Nothing
            PB.SizeMode = PictureBoxSizeMode.StretchImage
            PB.Refresh()
            Return PB
        End Function

        Public Function IntializeDefaultDevice(ByRef PB As PictureBox) As PictureBox
            PB = SetPictureBox(PB)

            Dim DeviceNames As List(Of String) = LoadDeviceList()

            Dim Idevice As Integer = 0
            If DeviceNames.Count > 0 Then
                PB = OpenPreviewWindow(PB, Idevice)
            Else

            End If

            Return PB
        End Function

        ''' <summary>
        ''' Names of devices available;
        ''' When selecting a device the corresponding record id is required 0 based
        ''' </summary>
        Public DeviceList As List(Of String) = LoadDeviceList()

        ''' <summary>
        ''' LOAD DEVICES as list of Names
        ''' To use devices when opening a preview window select ID number From 0+
        ''' </summary>
        ''' <returns></returns>
        Public Function LoadDeviceList() As List(Of String)
            On Error Resume Next
            Dim Devlist As New List(Of String)
            Dim strName As String = Space(100)
            Dim strVer As String = Space(100)
            Dim bReturn As Boolean
            Dim x As Integer = 0
            Do
                bReturn = capGetDriverDescriptionA(x, strName, 100, strVer, 100)
                If bReturn Then
                    Devlist.Add(strName.Trim)

                End If
                x += 1
                Application.DoEvents()
            Loop Until bReturn = False
            Return Devlist
        End Function

        Public Const WM_CAP As Short = &H400S

        Public Const WM_CAP_DRIVER_CONNECT As Integer = WM_CAP + 10
        Public Const WM_CAP_DRIVER_DISCONNECT As Integer = WM_CAP + 11
        Public Const WM_CAP_EDIT_COPY As Integer = WM_CAP + 30

        Public Const WM_CAP_SET_PREVIEW As Integer = WM_CAP + 50
        Public Const WM_CAP_SET_PREVIEWRATE As Integer = WM_CAP + 52
        Public Const WM_CAP_SET_SCALE As Integer = WM_CAP + 53
        Public Const WS_CHILD As Integer = &H40000000
        Public Const WS_VISIBLE As Integer = &H10000000
        Public Const SWP_NOMOVE As Short = &H2S
        Public Const SWP_NOSIZE As Short = 1
        Public Const SWP_NOZORDER As Short = &H4S
        Public Const HWND_BOTTOM As Short = 1

        Public iDevice As Integer = 0 ' Current device ID
        Public hHwnd As Integer ' Handle to preview window

        Public Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
    (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer,
    <MarshalAs(UnmanagedType.AsAny)> ByVal lParam As Object) As Integer

        Public Declare Function SetWindowPos Lib "user32" Alias "SetWindowPos" (ByVal hwnd As Integer,
    ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer,
    ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer

        Public Declare Function DestroyWindow Lib "user32" (ByVal hndw As Integer) As Boolean

        Public Declare Function capCreateCaptureWindowA Lib "avicap32.dll" _
    (ByVal lpszWindowName As String, ByVal dwStyle As Integer,
    ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer,
    ByVal nHeight As Short, ByVal hWndParent As Integer,
    ByVal nID As Integer) As Integer

        Public Declare Function capGetDriverDescriptionA Lib "avicap32.dll" (ByVal wDriver As Short,
    ByVal lpszName As String, ByVal cbName As Integer, ByVal lpszVer As String,
    ByVal cbVer As Integer) As Boolean
    End Module

    Public Class ImageWarpingFilters

        Public Shared Function OffsetFilterAbs(ByRef b As Bitmap, ByVal offset As Point(,)) As Boolean

            'absolute...

            ' takes an array of points called offset()
            ' and a bitmap in.
            ' The offset array has the same dimensions as the bitmap
            ' say that the first point stored in the offset array
            ' is (10,10).
            ' i.e. offset(0,0) stores point(10,10)
            ' we look at point (10,10) in the source bitmap, get the color
            ' and then set point(0,0) in the target bitmap.

            Dim bSrc As Bitmap = b.Clone

            Dim bmData As BitmapData = b.LockBits(New Rectangle(0, 0, b.Width, b.Height),
        ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)
            Dim bmDataSrc As BitmapData = bSrc.LockBits(New Rectangle(0, 0, bSrc.Width, bSrc.Height),
        ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb)

            Dim Scan0 As IntPtr = bmData.Scan0
            Dim SrcScan0 As IntPtr = bmDataSrc.Scan0

            Dim pixels(b.Width * b.Height - 1) As Integer
            Dim srcPixels(bSrc.Width * bSrc.Height - 1) As Integer

            Copy(Scan0, pixels, 0, pixels.Length)
            Copy(SrcScan0, srcPixels, 0, srcPixels.Length)

            bSrc.UnlockBits(bmDataSrc)
            bSrc.Dispose()

            Dim offsetx, offsety As Integer

            For y As Integer = 0 To b.Height - 1
                For x As Integer = 0 To b.Width - 1

                    offsetx = offset(x, y).X
                    offsety = offset(x, y).Y

                    'index could go out of range

                    If offsetx > 0 AndAlso offsetx < b.Width - 1 AndAlso offsety > 0 AndAlso offsety < b.Height - 1 Then
                        pixels(y * b.Width + x) = srcPixels(offsetx + (offsety * b.Width))
                    End If
                Next
            Next

            Copy(pixels, 0, Scan0, pixels.Length)
            b.UnlockBits(bmData)

            Return True

        End Function

        Public Shared Function OffsetFilter(ByRef b As Bitmap, ByVal offset As Point(,)) As Boolean

            ' similar to the function above, but the values in offset are
            ' relative to the index of offset. blurgh, by example:
            ' if the values in offset(10,10) are (2, -8) then you
            ' get the colors from (10 + 2, 10 - 8) and write them
            ' into (10,10)

            Dim bSrc As Bitmap = b.Clone

            Dim bmData As BitmapData = b.LockBits(New Rectangle(0, 0, b.Width, b.Height),
        ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)
            Dim bmDataSrc As BitmapData = bSrc.LockBits(New Rectangle(0, 0, bSrc.Width, bSrc.Height),
        ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb)

            Dim Scan0 As IntPtr = bmData.Scan0
            Dim SrcScan0 As IntPtr = bmDataSrc.Scan0

            Dim pixels(b.Width * b.Height - 1) As Integer
            Dim srcPixels(bSrc.Width * bSrc.Height - 1) As Integer

            Copy(Scan0, pixels, 0, pixels.Length)
            Copy(SrcScan0, srcPixels, 0, srcPixels.Length)

            bSrc.UnlockBits(bmDataSrc)
            bSrc.Dispose()

            Dim offsetx, offsety As Integer

            For y As Integer = 0 To b.Height - 1
                For x As Integer = 0 To b.Width - 1
                    ' random jitter can make the value go out of range
                    ' skip the test if your implementation keeps values in range...
                    offsetx = x + offset(x, y).X
                    offsety = y + offset(x, y).Y
                    If offsetx > 0 AndAlso offsetx < b.Width - 1 AndAlso offsety > 0 AndAlso offsety < b.Height - 1 Then
                        pixels(y * b.Width + x) = srcPixels(offsetx + (b.Width * offsety))
                    End If
                Next
            Next

            Copy(pixels, 0, Scan0, pixels.Length)
            b.UnlockBits(bmData)

            Return True
        End Function

        Public Structure FloatPoint
            Public X As Double
            Public Y As Double
        End Structure

        Public Shared Function OffsetFilterAntiAlias(ByRef b As Bitmap, ByVal fp As FloatPoint(,)) _
    As Boolean

            'this one is absolute, and uses the bilinear filter.

            Dim bSrc As Bitmap = b.Clone

            Dim bmData As BitmapData = b.LockBits(New Rectangle(0, 0, b.Width, b.Height),
        ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)
            Dim bmDataSrc As BitmapData = bSrc.LockBits(New Rectangle(0, 0, bSrc.Width, bSrc.Height),
        ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb)

            Dim stride As Integer = bmData.Stride
            Dim Scan0 As IntPtr = bmData.Scan0
            Dim SrcScan0 As IntPtr = bmDataSrc.Scan0

            Dim pixels(stride * b.Height - 1) As Byte
            Dim srcPixels(stride * bSrc.Height - 1) As Byte

            Copy(Scan0, pixels, 0, pixels.Length)
            Copy(SrcScan0, srcPixels, 0, srcPixels.Length)

            bSrc.UnlockBits(bmDataSrc)
            bSrc.Dispose()

            Dim xoffset, yoffset As Integer

            Dim fraction_x, fraction_y, one_minus_x, one_minus_y As Double

            Dim ceil_x, ceil_y, floor_x, floor_y As Integer
            Dim p1, p2 As Byte

            Dim color1, color2 As Byte

            For x As Integer = 0 To b.Width - 1
                For y As Integer = 0 To b.Height - 1

                    xoffset = fp(x, y).X
                    yoffset = fp(x, y).Y

                    ' Setup

                    floor_x = Math.Floor(xoffset)
                    floor_y = Math.Floor(yoffset)
                    ceil_x = floor_x + 1
                    ceil_y = floor_y + 1
                    fraction_x = xoffset - floor_x
                    fraction_y = yoffset - floor_y
                    one_minus_x = 1.0 - fraction_x
                    one_minus_y = 1.0 - fraction_y

                    If (floor_y >= 0 AndAlso ceil_y < b.Height AndAlso floor_x >= 0 _
                AndAlso ceil_x < b.Width) Then

                        'blue
                        color1 = srcPixels((floor_y * stride) + (floor_x * 4))
                        color2 = srcPixels((floor_y * stride) + (ceil_x * 4))
                        p1 = Convert.ToByte((one_minus_x * color1) + (fraction_x * color2))

                        color1 = srcPixels((ceil_y * stride) + (floor_x * 4))
                        color2 = srcPixels((ceil_y * stride) + (ceil_x * 4))
                        p2 = Convert.ToByte((one_minus_x * color1) + (fraction_x * color2))

                        pixels((y * stride) + (x * 4)) = Convert.ToByte((one_minus_y * p1) + (fraction_y * p2))

                        'green
                        color1 = srcPixels((floor_y * stride) + (floor_x * 4) + 1)
                        color2 = srcPixels((floor_y * stride) + (ceil_x * 4) + 1)
                        p1 = Convert.ToByte((one_minus_x * color1) + (fraction_x * color2))

                        color1 = srcPixels((ceil_y * stride) + (floor_x * 4) + 1)
                        color2 = srcPixels((ceil_y * stride) + (ceil_x * 4) + 1)
                        p2 = Convert.ToByte((one_minus_x * color1) + (fraction_x * color2))

                        pixels((y * stride) + (x * 4) + 1) = Convert.ToByte((one_minus_y * p1) + (fraction_y * p2))

                        'Red
                        color1 = srcPixels((floor_y * stride) + (floor_x * 4) + 2)
                        color2 = srcPixels((floor_y * stride) + (ceil_x * 4) + 2)
                        p1 = Convert.ToByte((one_minus_x * color1) + (fraction_x * color2))

                        color1 = srcPixels((ceil_y * stride) + (floor_x * 4) + 2)
                        color2 = srcPixels((ceil_y * stride) + (ceil_x * 4) + 2)
                        p2 = Convert.ToByte((one_minus_x * color1) + (fraction_x * color2))

                        pixels((y * stride) + (x * 4) + 2) = Convert.ToByte((one_minus_y * p1) + (fraction_y * p2))
                    End If
                Next
            Next
            Copy(pixels, 0, Scan0, pixels.Length)
            b.UnlockBits(bmData)
            Return True
        End Function

        Public Shared Function Flip(ByVal b As Bitmap, ByVal bHorz As Boolean, ByVal bVert As Boolean) _
    As Bitmap

            ' fill up a point array with the co-ords of the flipped points

            Dim ptFlip(b.Width, b.Height) As Point
            Dim nWidth As Integer = b.Width
            Dim nHeight As Integer = b.Height
            For x As Integer = 0 To nWidth - 1
                For y As Integer = 0 To nHeight - 1
                    ptFlip(x, y).X = If((bHorz), nWidth - (x + 1), x)
                    ptFlip(x, y).Y = If((bVert), nHeight - (y + 1), y)
                Next
            Next

            Dim result As Boolean = False
            result = OffsetFilterAbs(b, ptFlip) ' run bitmap b through the offset filter abs
            ' so that all of b's pixels get moved to the values we just stored in ptFlip.
            Do
                'waiting for calculation to finish before returning.
                For i = 1 To 100
                Next
            Loop Until result
            Return b

        End Function

        Public Shared Function RandomJitter(ByRef b As Bitmap, ByVal nDegree As Short) As Bitmap

            ' fill the point array up with random distaces
            ' between (-nDegree\2) and (+nDegree\2)

            Dim ptRandomJitter(b.Width, b.Height) As Point

            Dim nWidth As Integer = b.Width
            Dim nHeight As Integer = b.Height

            Dim newX, newY As Integer

            Dim nHalf As Short = CShort(Math.Floor(nDegree / 2))
            Dim rand As Random = New Random
            For x As Integer = 0 To nWidth - 1
                For y As Integer = 0 To nHeight - 1
                    newX = rand.Next(nDegree) - nHalf
                    If ((x + newX) > 0) AndAlso ((x + newX) < nWidth) Then
                        ptRandomJitter(x, y).X = newX
                    Else
                        ptRandomJitter(x, y).X = 0
                    End If
                    newY = rand.Next(nDegree) - nHalf

                    If ((y + newY) > 0) AndAlso ((y + newY) < nWidth) Then
                        ptRandomJitter(x, y).Y = newY
                    Else
                        ptRandomJitter(x, y).Y = 0
                    End If
                Next

            Next

            Dim result As Boolean = False
            ' we use the offset filter, so the point in b gets moved by the random
            ' distances we have put into ptRandomJitter
            result = OffsetFilter(b, ptRandomJitter)
            Do
                For i = 1 To 100
                Next
            Loop Until result

            Return b
        End Function

        Public Shared Function Swirl(ByVal b As Bitmap, ByVal fDegree As Double,
    ByVal bSmoothing As Boolean) As Bitmap

            ' complicated
            ' I've just translated it...

            Dim nWidth As Integer = b.Width
            Dim nHeight As Integer = b.Height

            Dim fp(nWidth, nHeight) As FloatPoint
            Dim pt(nWidth, nHeight) As Point

            Dim midl As New Point
            midl.X = nWidth / 2
            midl.Y = nHeight / 2

            Dim theta, radius, newx, newy As Double
            Dim trueX, trueY As Integer

            For x As Integer = 0 To nWidth - 1
                For y As Integer = 0 To nHeight - 1
                    trueX = x - midl.X
                    trueY = y - midl.Y
                    theta = Math.Atan2((trueY), (trueX))
                    radius = Math.Sqrt((trueX * trueX) + (trueY * trueY))
                    newx = midl.X + (radius * Math.Cos(theta + (fDegree * radius)))
                    If (newx > 0) AndAlso newx < (nWidth - 1) Then
                        fp(x, y).X = newx
                        pt(x, y).X = Convert.ToInt32(newx)
                    Else
                        fp(x, y).X = x
                        pt(x, y).X = x
                    End If
                    newy = midl.Y + (radius * Math.Sin(theta + (fDegree * radius)))
                    If (newy > 0) AndAlso newy < (nHeight - 1) Then
                        fp(x, y).Y = newy
                        pt(x, y).Y = Convert.ToInt32(newy)
                    Else
                        fp(x, y).Y = y
                        pt(x, y).Y = y
                    End If
                Next
            Next

            Dim result As Boolean = False

            If (bSmoothing) Then
                result = OffsetFilterAntiAlias(b, fp)
            Else
                result = OffsetFilterAbs(b, pt)
            End If

            Do
                For i = 1 To 100
                Next
            Loop Until result

            Return b

        End Function

        Public Shared Function Sphere(ByVal b As Bitmap, ByVal bSmoothing As Boolean) As Bitmap

            ' complicated
            ' I've just translated it...

            Dim nWidth As Integer = b.Width
            Dim nHeight As Integer = b.Height

            Dim fp(nWidth, nHeight) As FloatPoint
            Dim pt(nWidth, nHeight) As Point

            Dim midl As New Point
            midl.X = nWidth / 2
            midl.Y = nHeight / 2

            Dim theta, radius, newx, newy, newRadius As Double
            Dim trueX, trueY As Integer

            For x As Integer = 0 To nWidth - 1
                For y As Integer = 0 To nHeight - 1
                    trueX = x - midl.X
                    trueY = y - midl.Y
                    theta = Math.Atan2((trueY), (trueX))
                    radius = Math.Sqrt(trueX * trueX + trueY * trueY)
                    newRadius = radius * radius / (Math.Max(midl.X, midl.Y))
                    newx = midl.X + (newRadius * Math.Cos(theta))
                    If newx > 0 AndAlso newx < nWidth Then
                        fp(x, y).X = newx
                        pt(x, y).X = Convert.ToInt32(newx)
                    Else
                        fp(x, y).X = 0.0
                        fp(x, y).Y = 0.0
                        pt(0, 0).X = 0
                        pt(0, 0).Y = 0
                    End If
                    newy = midl.Y + (newRadius * Math.Sin(theta))
                    If newy > 0 AndAlso newy < nHeight AndAlso newx > 0 AndAlso newx < nWidth Then
                        fp(x, y).Y = newy
                        pt(x, y).Y = Convert.ToInt32(newy)
                    Else
                        fp(x, y).X = 0.0
                        fp(x, y).Y = 0.0
                        pt(x, y).X = 0
                        pt(x, y).Y = 0
                    End If
                Next
            Next

            Dim result As Boolean = False

            If (bSmoothing) Then
                result = OffsetFilterAbs(b, pt)
            Else
                result = OffsetFilterAntiAlias(b, fp)
            End If

            Do
                For i = 1 To 100
                Next
            Loop Until result

            Return b
        End Function

        Public Shared Function TimeWarp(ByVal b As Bitmap, ByVal factor As Byte,
    ByVal bSmoothing As Boolean) As Bitmap

            ' complicated
            ' I've just translated it...

            Dim nWidth As Integer = b.Width
            Dim nHeight As Integer = b.Height

            Dim fp(nWidth, nHeight) As FloatPoint
            Dim pt(nWidth, nHeight) As Point

            Dim midl As New Point
            midl.X = nWidth / 2
            midl.Y = nHeight / 2

            Dim theta, radius, newx, newy, newRadius As Double
            Dim trueX, trueY As Integer

            For x As Integer = 0 To nWidth - 1
                For y As Integer = 0 To nHeight - 1
                    trueX = x - midl.X
                    trueY = y - midl.Y
                    theta = Math.Atan2((trueY), (trueX))
                    radius = Math.Sqrt(trueX * trueX + trueY * trueY)
                    newRadius = Math.Sqrt(radius) * factor
                    newx = midl.X + (newRadius * Math.Cos(theta))
                    If newx > 0 AndAlso newx < nWidth Then
                        fp(x, y).X = newx
                        pt(x, y).X = Convert.ToInt32(newx)
                    Else
                        fp(x, y).X = 0.0
                        pt(0, 0).X = 0
                    End If
                    newy = midl.Y + (newRadius * Math.Sin(theta))
                    If newy > 0 AndAlso newy < nHeight Then
                        fp(x, y).Y = newy
                        pt(x, y).Y = Convert.ToInt32(newy)
                    Else
                        fp(x, y).Y = 0.0
                        pt(x, y).Y = 0
                    End If

                Next
            Next

            Dim result As Boolean = False

            result = If((bSmoothing), OffsetFilterAbs(b, pt), OffsetFilterAntiAlias(b, fp))

            Do
                For i = 1 To 100
                Next
            Loop Until result

            Return b

        End Function

        Public Shared Function Moire(ByVal b As Bitmap, ByVal fDegree As Double) As Bitmap

            ' complicated
            ' I've just translated it...

            Dim nWidth As Integer = b.Width
            Dim nHeight As Integer = b.Height

            Dim pt(nWidth, nHeight) As Point

            Dim midl As New Point
            midl.X = nWidth / 2
            midl.Y = nHeight / 2

            Dim theta, radius, newx, newy As Double
            Dim trueX, trueY As Integer

            For x As Integer = 0 To nWidth - 1
                For y As Integer = 0 To nHeight - 1
                    trueX = x - midl.X
                    trueY = y - midl.Y
                    theta = Math.Atan2((trueX), (trueY))
                    radius = Math.Sqrt((trueX * trueX) + (trueY * trueY))
                    newx = Convert.ToInt32(radius * Math.Sin(theta + (fDegree * radius)))

                    If newx > 0 AndAlso newx < nWidth Then
                        pt(x, y).X = Convert.ToInt32(newx)
                    Else
                        pt(0, 0).X = 0
                    End If
                    newy = Convert.ToInt32(radius * Math.Sin(theta + (fDegree * radius)))
                    If newy > 0 AndAlso newy < nHeight Then
                        pt(x, y).Y = Convert.ToInt32(newy)
                    Else
                        pt(x, y).Y = 0
                    End If

                Next
            Next

            Dim result As Boolean = False
            result = OffsetFilterAbs(b, pt)
            Do
                For i = 1 To 100
                Next
            Loop Until result
            Return b

        End Function

        Public Shared Function Water(ByVal b As Bitmap, ByVal nWave As Short,
    ByVal bSmoothing As Boolean) As Bitmap

            ' bit easier
            ' but, I've just translated it...

            Dim nWidth As Integer = b.Width
            Dim nHeight As Integer = b.Height
            Dim fp(nWidth, nHeight) As FloatPoint
            Dim pt(nWidth, nHeight) As Point

            Dim midl As New Point
            midl.X = nWidth / 2
            midl.Y = nHeight / 2

            Dim newx, newy, xo, yo As Double

            For x As Integer = 0 To nWidth - 1
                For y As Integer = 0 To nHeight - 1

                    xo = (nWave * Math.Sin(2.0 * Math.PI * (y / 128.0)))
                    yo = (nWave * Math.Cos((2.0 * Math.PI) * (x / 128.0)))
                    newx = (x + xo)
                    newy = (y + yo)

                    If newx > 0 AndAlso newx < nWidth Then
                        fp(x, y).X = newx
                        pt(x, y).X = Convert.ToInt32(newx)
                    Else
                        fp(x, y).X = 0.0
                        pt(x, y).X = 0
                    End If
                    If newy > 0 AndAlso newy < nHeight Then
                        fp(x, y).Y = newy
                        pt(x, y).Y = Convert.ToInt32(newy)
                    Else
                        fp(x, y).Y = 0.0
                        pt(x, y).Y = 0
                    End If
                Next
            Next

            Dim result As Boolean = False

            If (bSmoothing) Then
                result = OffsetFilterAbs(b, pt)
            Else
                result = OffsetFilterAntiAlias(b, fp)
            End If

            Do
                For i = 1 To 100
                Next
            Loop Until result

            Return b

        End Function

        Public Shared Function Pixelate(ByVal b As Bitmap, ByVal pixel As Short, ByVal bGrid As Boolean) As Bitmap

            'grid can look pretty weird as the color is variable on the grid lines
            'I thought it was borked for a while but it was my source image.
            'I'll leave it as it is, but you could use gdi to draw a grid instead.

            'This one stores the offset to the pixel in the top left corner of the
            ' current small square. The pixelate2 filter  calculates the
            ' average color of pixels in the small square.

            Dim nWidth As Integer = b.Width
            Dim nHeight As Integer = b.Height

            Dim pt(nWidth, nHeight) As Point

            Dim newx, newy As Integer

            For x As Integer = 0 To nWidth - 1
                For y As Integer = 0 To nHeight - 1

                    newx = pixel - (x Mod pixel)

                    If (bGrid AndAlso newx = pixel) Then
                        pt(x, y).X = -x
                    ElseIf (x + newx > 0 AndAlso x + newx < nWidth) Then
                        pt(x, y).X = newx
                    Else
                        pt(x, y).X = 0
                    End If

                    newy = pixel - y Mod pixel

                    If (bGrid AndAlso newy = pixel) Then
                        pt(x, y).Y = -y
                    ElseIf (y + newy > 0 AndAlso y + newy < nHeight) Then
                        pt(x, y).Y = newy
                    Else
                        pt(x, y).Y = 0
                    End If
                Next
            Next

            Dim result As Boolean = False
            result = OffsetFilter(b, pt)
            Do
                For i = 1 To 100
                Next

            Loop Until result
            Return b

        End Function

    End Class

    Public Class ImageFilters

        Public Shared Function Prewitt(ByRef Source As Bitmap) As Bitmap

            Dim prewittResult As New Bitmap(Source)

            Dim prewittX, prewittY, magnitude As Integer

            Dim neighbourList As ArrayList = New ArrayList

            For y As Integer = 0 To Source.Height - 1
                For x As Integer = 0 To Source.Width - 1
                    neighbourList.Clear()

                    neighbourList = getThreeNeighbourList(x, y, Source)

                    prewittX = getPrewittValue(neighbourList, "X")
                    prewittY = getPrewittValue(neighbourList, "Y")

                    magnitude = Math.Sqrt(Math.Pow(prewittX, 2) + Math.Pow(prewittY, 2))

                    If magnitude > 255 Then
                        magnitude = 255
                    End If

                    prewittResult.SetPixel(x, y, Color.FromArgb(magnitude, magnitude, magnitude))
                Next x
            Next y

            Return prewittResult
        End Function

        Public Shared Function Sobel(ByRef source As Bitmap) As Bitmap

            Dim sobelResult As New Bitmap(source)

            Dim sobelX, sobelY, magnitude As Integer

            Dim neighbourList As ArrayList = New ArrayList

            For y As Integer = 0 To source.Height - 1
                For x As Integer = 0 To source.Width - 1
                    neighbourList.Clear()

                    neighbourList = getThreeNeighbourList(x, y, source)

                    sobelX = getSobelValue(neighbourList, "X")
                    sobelY = getSobelValue(neighbourList, "Y")

                    magnitude = Math.Sqrt(Math.Pow(sobelX, 2) + Math.Pow(sobelY, 2))

                    If magnitude > 255 Then
                        magnitude = 255
                    End If

                    sobelResult.SetPixel(x, y, Color.FromArgb(magnitude, magnitude, magnitude))
                Next x
            Next y
            Return sobelResult
        End Function

        Private Shared Function getThreeNeighbourList(ByVal xPos As Integer, ByVal yPos As Integer, ByVal source As Bitmap) As ArrayList
            Dim neighbourList As ArrayList = New ArrayList

            Dim xStart, xFinish, yStart, yFinish As Integer

            Dim pixel As Integer

            xStart = xPos - 1
            xFinish = xPos + 1

            yStart = yPos - 1
            yFinish = yPos + 1

            For y As Integer = yStart To yFinish
                For x As Integer = xStart To xFinish
                    If (x < 0) Or (y < 0) Or (x > source.Width - 1) Or (y > source.Height - 1) Then
                        neighbourList.Add(0)
                    Else
                        pixel = source.GetPixel(x, y).R

                        neighbourList.Add(pixel)
                    End If
                Next x
            Next y

            Return neighbourList
        End Function

        Private Shared Function getSobelValue(ByVal neighbourList As ArrayList, ByVal maskType As String) As Integer
            Dim result As Integer = 0

            Dim sobelX As Integer(,) = {{-1, 0, 1}, {-2, 0, 2}, {-1, 0, 1}}
            Dim sobelY As Integer(,) = {{1, 2, 1}, {0, 0, 0}, {-1, -2, -1}}

            Dim count As Integer = 0

            If (maskType.Equals("X")) Then
                For y As Integer = 0 To 2
                    For x As Integer = 0 To 2
                        result = result + (sobelX(x, y) * Convert.ToInt16(neighbourList(count)))

                        count = count + 1
                    Next x
                Next y
            ElseIf (maskType.Equals("Y")) Then
                For y As Integer = 0 To 2
                    For x As Integer = 0 To 2
                        result = result + (sobelY(x, y) * Convert.ToInt16(neighbourList(count)))

                        count = count + 1
                    Next x
                Next y
            End If

            Return result
        End Function

        Private Shared Function getPrewittValue(ByVal neighbourList As ArrayList, ByVal maskType As String) As Integer
            Dim result As Integer = 0

            Dim prewittX As Integer(,) = {{-1, 0, 1}, {-1, 0, 1}, {-1, 0, 1}}
            Dim prewittY As Integer(,) = {{-1, -1, -1}, {0, 0, 0}, {1, 1, 1}}

            Dim count As Integer = 0

            If (maskType.Equals("X")) Then
                For y As Integer = 0 To 2
                    For x As Integer = 0 To 2
                        result = result + (prewittX(x, y) * Convert.ToInt16(neighbourList(count)))

                        count = count + 1
                    Next x
                Next y
            ElseIf (maskType.Equals("Y")) Then
                For y As Integer = 0 To 2
                    For x As Integer = 0 To 2
                        result = result + (prewittY(x, y) * Convert.ToInt16(neighbourList(count)))

                        count = count + 1
                    Next x
                Next y
            End If

            Return result
        End Function

        Public Const EDGE_DETECT_KIRSH As Short = 1
        Public Const EDGE_DETECT_PREWITT As Short = 2
        Public Const EDGE_DETECT_SOBEL As Short = 3

        Public Shared Function EdgeDetectConvolution(ByVal b As Bitmap, ByVal nType As Short,
    ByVal nThreshold As Byte) As Bitmap

            Dim filt As New convolutionFilters
            Dim m As New convolutionFilters.ConvMatrix
            Dim bTemp As Bitmap = b.Clone

            ' First we run the vertical version of whichever filter it is
            ' and store in one bitmap:

            Select Case nType
                Case EDGE_DETECT_SOBEL
                    m.SetAll(0)
                    m(0) = 1        '  1  0  -1
                    m(2) = -1       '  2  0  -2
                    m(3) = 2        '  1  0  -1
                    m(5) = -2
                    m(6) = 1
                    m(8) = -1
                    m.Offset = 0
                Case EDGE_DETECT_PREWITT
                    m.SetAll(0)
                    m(0) = -1       '  -1  0  1
                    m(2) = 1        '  -1  0  1
                    m(3) = -1       '  -1  0  1
                    m(5) = 1
                    m(6) = -1
                    m(8) = 1
                    m.Offset = 0
                Case EDGE_DETECT_KIRSH
                    m.SetAll(-3)
                    m(4) = 0        '  5  -3  -3
                    m(0) = 5        '  5   0  -3
                    m(3) = 5        '  5  -3  -3
                    m(6) = 5
                    m.Offset = 0
            End Select

            ' store in b..
            Dim result As Boolean = False
            result = filt.conv3x3(b, m)
            'wait for a result...
            'otherwise a big image can crash it (
            Do
                For i = 1 To 100

                Next
            Loop Until result

            ' Next run the horizontal version of the filter on the other bitmap
            ' which still has the virgin source image.

            Select Case nType
                Case EDGE_DETECT_SOBEL
                    m.SetAll(0)
                    m(0) = 1         '  1  2  1
                    m(1) = 2         '  0  0  0
                    m(2) = 1         ' -1 -2 -1
                    m(6) = -1
                    m(7) = -2
                    m(8) = -1
                    m.Offset = 0
                Case EDGE_DETECT_PREWITT
                    m.SetAll(0)
                    m(0) = 1          ' 1  1  1
                    m(1) = 1          ' 0  0  0
                    m(2) = 1          '-1 -1 -1
                    m(6) = -1
                    m(7) = -1
                    m(8) = -1
                    m.Offset = 0
                Case EDGE_DETECT_KIRSH
                    m.SetAll(-3)
                    m(4) = 0         ' -3 -3 -3
                    m(6) = 5         ' -3  0 -3
                    m(7) = 5         '  5  5  5
                    m(8) = 5
                    m.Offset = 0
            End Select
            result = False
            result = filt.conv3x3(bTemp, m)
            Do
                For i = 1 To 100

                Next
            Loop Until result

            ' now we merge the two bitmaps with pixel = sqrt(pixel1 * pixel1 + pixel2 * pixel2)

            ' Lock each image:
            Dim bmData As BitmapData = b.LockBits(New Rectangle(0, 0, b.Width, b.Height),
        ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)

            Dim bmData2 As BitmapData = bTemp.LockBits(New Rectangle(0, 0, b.Width, b.Height),
        ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)

            ' store the pointers to the start of the pixel data for each bitmap
            Dim scan0 As IntPtr = bmData.Scan0
            Dim scan02 As IntPtr = bmData2.Scan0

            ' arrays to hold the bitmaps color information:
            Dim pixels1(4 * b.Width * b.Height - 1) As Byte
            Dim pixels2(4 * bTemp.Width * bTemp.Height - 1) As Byte

            'fill the arrays
            Marshal.Copy(scan0, pixels1, 0, pixels1.Length)
            Marshal.Copy(scan02, pixels2, 0, pixels2.Length)

            'don't need bTemp as the array has the info
            'do need b as we are going to write to it and return it
            bTemp.UnlockBits(bmData2)
            bTemp.Dispose()

            Dim nPixel As Integer

            For i As Integer = 0 To pixels1.Length - 1
                ' calculate the new value
                nPixel = Convert.ToInt32(Math.Sqrt((pixels1(i) ^ 2) + (pixels2(i) ^ 2)))
                ' make sure it is in range
                If (nPixel < nThreshold) Then nPixel = nThreshold
                If (nPixel > 255) Then nPixel = 255
                ' write it back to the array
                pixels1(i) = Convert.ToByte(nPixel)
            Next

            'write the array back to the bitmap memory data
            Marshal.Copy(pixels1, 0, scan0, pixels1.Length)
            b.UnlockBits(bmData)
            Return b

        End Function

        Public Shared Function EdgeDetectDifference(ByVal b As Bitmap) As Bitmap

            'Keep a copy of the original to refer to
            Dim bSrc As Bitmap = b.Clone

            'lock bits
            Dim bmDataSrc As BitmapData = bSrc.LockBits(New Rectangle(0, 0, bSrc.Width, bSrc.Height),
        System.Drawing.Imaging.ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb)
            Dim bmData As BitmapData = b.LockBits(New Rectangle(0, 0, b.Width, b.Height),
        System.Drawing.Imaging.ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)

            'pointers to the start of the bitmap data
            Dim scan0 As IntPtr = bmData.Scan0
            Dim scan0Src As IntPtr = bmDataSrc.Scan0

            ' store the width of 1 row of pixels in memory
            Dim stride As Integer = bmData.Stride

            'arrays to hold the color values
            Dim pixelsSrc(stride * bSrc.Height - 1) As Byte
            Dim pixels(stride * b.Height - 1) As Byte

            'fill the arrays
            Marshal.Copy(scan0Src, pixelsSrc, 0, pixelsSrc.Length)
            Marshal.Copy(scan0, pixels, 0, pixels.Length)

            'don't need the srcBitmap as we have the data in the array now
            bSrc.UnlockBits(bmDataSrc)
            bSrc.Dispose()

            'store the max difference
            Dim maxDifference As Integer

            'and the current difference
            Dim currentDifference As Integer

            'and the test pixels colors
            Dim testColor1 As Integer
            Dim testcolor2 As Integer

            Dim index As Integer ' position in the array of pixel at (x,y) in the following loop

            ' we cant do the edges as pixels are compared with their surrounding pixels, so start at (1,1)
            ' instead of (0,0) and run up to width -2, height -2 (as it is 0-based)

            For y As Integer = 1 To b.Height - 2
                For x As Integer = 1 To b.Width - 2

                    For i As Integer = 0 To 2 'skips alpha which is the last byte (BGRA when using bytes)
                        'index of pixel at (x,y)
                        'stride is the number of bytes taken up by 1 row of pixels
                        '(4 * bitmap.width for this pixelformat), (other pixelformats get rounded up to nearest 4!)

                        index = (y * stride) + (x * 4) + i

                        'We move through each pixel
                        'and look at the surrounding pixel pairs:
                        '
                        '   0 1 2      \|/
                        '   3 4 5      -o-
                        '   6 7 8      /|\
                        '
                        'So current pixel is 4.
                        'we get the color difference between 0 and 8, 2 and 6, 3 and 5, 1 and 7
                        'we keep track of the biggest color difference.
                        'If all the pixels are very much the same then the difference is small
                        ' and the color we set 4 to at the end will tend towards black
                        'If there is a big difference then 4 will be set high
                        'If this occurs for all 3 bytes of color then it will tend towards white
                        ' and show as an edge.
                        '
                        ' 0 and 8
                        '0
                        testColor1 = pixelsSrc(index - stride - 4) ' 1 row up, 1 pixel left
                        '8
                        testcolor2 = pixelsSrc(index + stride + 4) ' 1 row down, 1 pixel right

                        'start by setting maxDifference. anything bigger will overwrite later
                        maxDifference = Math.Abs(testColor1 - testcolor2)

                        ' 1 and 7
                        ' 1
                        testColor1 = pixelsSrc(index - stride)  ' 1 row up
                        ' 7
                        testcolor2 = pixelsSrc(index + stride)  '1 row down
                        currentDifference = Math.Abs(testColor1 - testcolor2)
                        ' set max to current if current is bigger
                        maxDifference =
                    If(maxDifference > currentDifference, maxDifference, currentDifference)

                        ' 2 and 6
                        ' 2
                        testColor1 = pixelsSrc(index - stride + 4)  ' 1 row up, 1 pixel right
                        ' 6
                        testcolor2 = pixelsSrc(index + stride - 4) ' 1 row down, 1 pixel left
                        currentDifference = Math.Abs(testColor1 - testcolor2)
                        ' set max to current if current is bigger
                        maxDifference =
                    If(maxDifference > currentDifference, maxDifference, currentDifference)

                        ' 3 and 5
                        ' 3
                        testColor1 = pixelsSrc(index - 4)   ' 1 pixel left
                        ' 5
                        testcolor2 = pixelsSrc(index + 4) ' 1 pixel right
                        currentDifference = Math.Abs(testColor1 - testcolor2)
                        ' set max to current if current is bigger
                        maxDifference =
                    If(maxDifference > currentDifference, maxDifference, currentDifference)

                        'If the maxDifference is less than the threshold then zero it

                        If maxDifference < 0 Then maxDifference = 0

                        'Write the color component to the target bitmaps array
                        pixels(index) = maxDifference
                    Next
                Next
            Next

            Marshal.Copy(pixels, 0, scan0, pixels.Length)
            b.UnlockBits(bmData)

            Return b

        End Function

        Public Shared Function EdgeDetectHomogenity(ByVal b As Bitmap) As Bitmap

            'Keep a copy of the original to refer to
            Dim bSrc As Bitmap = b.Clone

            'lock bits
            Dim bmDataSrc As BitmapData = bSrc.LockBits(New Rectangle(0, 0, bSrc.Width, bSrc.Height),
        System.Drawing.Imaging.ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb)
            Dim bmData As BitmapData = b.LockBits(New Rectangle(0, 0, b.Width, b.Height),
        System.Drawing.Imaging.ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)

            'width of bitmap row in memory
            Dim stride As Integer = bmData.Stride

            'pointers to the start of the bitmap data
            Dim scan0Src As IntPtr = bmDataSrc.Scan0
            Dim scan0 As IntPtr = bmData.Scan0

            'Arrays to hold the bytes of color info
            Dim pixelsSrc(stride * bSrc.Height - 1) As Byte
            Dim pixels(stride * b.Height - 1) As Byte

            'copy data:
            Copy(scan0Src, pixelsSrc, 0, pixelsSrc.Length)
            Copy(scan0, pixels, 0, pixels.Length)

            'don't need the srcBitmap as we have the data in the array now
            bSrc.UnlockBits(bmDataSrc)
            bSrc.Dispose()

            'store position of current color component of the current pixel in the array
            Dim index As Integer

            'store the max difference
            Dim maxDifference As Byte

            'and the current difference
            Dim currentDifference As Byte

            'and the central pixels color value for this byte
            Dim col0 As Integer

            For y As Integer = 1 To b.Height - 2
                For x As Integer = 1 To b.Width - 2
                    'loop through the color bytes for a given pixel skipping alpha (BGRA when doing bytes)
                    For i As Integer = 0 To 2
                        'position of central pixel's byte in the array:
                        index = (y * stride) + (x * 4) + i
                        'central pixels color
                        col0 = pixelsSrc(index)

                        'Calculate the differences between col0 and the
                        ' corresponding byte in the pixel's 8 neighbours
                        'We want the largest difference so keep a running
                        ' highscore, and test each as against it as we go

                        ' pixel above and left is one stride up, 4 bytes back
                        ' start by setting the highscore
                        maxDifference = Math.Abs(col0 - pixelsSrc(index - stride - 4))

                        ' pixel above is one stride up----------------vvvvvvvvvvvvvv
                        currentDifference = Math.Abs(col0 - pixelsSrc(index - stride))

                        ' set the highest difference from the two so far.
                        maxDifference =
                    If(maxDifference > currentDifference, maxDifference, currentDifference)

                        'third one is the pixel above and right
                        currentDifference = Math.Abs(col0 - pixelsSrc(index - stride + 4))
                        maxDifference =
                    IIf(maxDifference > currentDifference, maxDifference, currentDifference)

                        'bug in c.g's version, he misses the MR and ML pixels and does
                        'TM and TB twice instead.

                        'fourth one is ML (middle row, left col)
                        currentDifference = Math.Abs(col0 - pixelsSrc(index - 4))
                        maxDifference =
                    IIf(maxDifference > currentDifference, maxDifference, currentDifference)

                        'MR
                        currentDifference = Math.Abs(col0 - pixelsSrc(index + 4))
                        maxDifference =
                    IIf(maxDifference > currentDifference, maxDifference, currentDifference)

                        'BL
                        currentDifference = Math.Abs(col0 - pixelsSrc(index + stride - 4))
                        maxDifference =
                    IIf(maxDifference > currentDifference, maxDifference, currentDifference)

                        'BM
                        currentDifference = Math.Abs(col0 - pixelsSrc(index + stride))
                        maxDifference =
                    IIf(maxDifference > currentDifference, maxDifference, currentDifference)

                        'BR
                        currentDifference = Math.Abs(col0 - pixelsSrc(index + stride + 4))
                        maxDifference =
                    IIf(maxDifference > currentDifference, maxDifference, currentDifference)

                        'phew.

                        'If the maxDifference is less than the threshold then zero it
                        If maxDifference < 0 Then maxDifference = 0

                        'Write the pixel to the targer bitmap
                        pixels(index) = maxDifference
                    Next

                Next
            Next

            'copy array back into bitmap
            Copy(pixels, 0, scan0, pixels.Length)
            b.UnlockBits(bmData)
            Return b

        End Function

        Public Shared Function EdgeDetectionHorizontal(ByVal b As Bitmap) As Bitmap

            ' make a copy of the source
            Dim bSrc As Bitmap = b.Clone

            ' Now its lockbits time again.
            ' Lock each image:
            Dim bmDataSrc As BitmapData = bSrc.LockBits(New Rectangle(0, 0, b.Width, b.Height),
        ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb)
            Dim bmData As BitmapData = b.LockBits(New Rectangle(0, 0, b.Width, b.Height),
        ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)

            ' stride is the width of a row in memory
            Dim stride As Integer = bmData.Stride

            ' store the pointers to the start of the pixel data for each bitmap
            Dim scan0Src As IntPtr = bmDataSrc.Scan0
            Dim scan0 As IntPtr = bmData.Scan0

            'arrays to hold the color values
            Dim pixelsSrc(stride * bSrc.Height - 1) As Byte
            Dim pixels(stride * b.Height - 1) As Byte

            'fill the arrays
            Marshal.Copy(scan0Src, pixelsSrc, 0, pixelsSrc.Length)
            Marshal.Copy(scan0, pixels, 0, pixels.Length)

            'don't need the srcBitmap as we have the data in the array now
            bSrc.UnlockBits(bmDataSrc)
            bSrc.Dispose()

            ' Sum the color values as we move through a grid
            Dim total As Integer

            ' The pixel we set is the one in the middle
            ' So when we put the grid in the top left corner of the bitmap
            '  we are setting pixel(3,1)
            ' This means that there will be 3 pixels untouched on the left and right edges
            '  and 1 untouched at the top and bottom edges.

            ' y loop:
            ' can't do the first row (row 0) so start at 1
            ' b.height is one to big when we start at 0, so remove 1 (b.height -1)
            ' and another -1 as we cant do the last row:
            For y As Integer = 1 To b.Height - 2

                ' x loop:
                ' we need to stop before the end of the row,
                ' to account for the width of the grid.
                ' looping through each pixel.

                For x As Integer = 0 To b.Width - 7

                    ' c.g.'s version starts at byte (9,2)
                    '
                    ' For the fisrt run through the loop he adds / subtracts the
                    '  color values of pixels like so:
                    '
                    '   (0,2) + (3,2) + (6,2) + (9,2) + (12,2) + (15,2) + (18,2)
                    ' - (0,0) - (3,0) - (6,0) - (9,0) - (12,0) - (15,0) - (18,0)
                    '
                    ' These are multiples of three as we want to get every third byte
                    '  so that it is the same color component. BGRBGRBGRBGRBGRBGRBGR
                    '                                          ^  ^  ^  ^  ^  ^  ^
                    ' which in effect is using this grid:
                    '
                    ' .----------------------------------.
                    ' | -1 | -1 | -1 | -1 | -1 | -1 | -1 |
                    ' |----------------------------------|
                    ' |  0 |  0 |  0 |  0 |  0 |  0 |  0 |
                    ' |----------------------------------|
                    ' |  1 |  1 |  1 |  1 |  1 |  1 |  1 |
                    ' '----------------------------------'
                    '
                    ' and moving it through each byte.
                    '
                    ' WE start by setting x,y to (0,1) = blue in the first pixel, second row
                    '
                    '
                    'loop though the B G and R
                    For colorByte As Integer = 0 To 2
                        '
                        ' yy loop:
                        ' rows in the 7x3 grid (missing out the middle row)
                        ' relative to the middle row:
                        For yy As Integer = -1 To 1 Step 2
                            ' xx loop:
                            ' across the cells in a 7x3 row
                            ' start at 0 so end at 6

                            For xx As Integer = 0 To 6

                                ' Read the color information:

                                ' Current position from scan0 (start of the bitmap memory):
                                Dim position As Integer
                                position = (y + yy) * stride ' add the number of rows down * width of row
                                position += (x + xx) * 4  ' add the cell position along the current row
                                position += colorByte ' and the current byte
                                Dim col1 As Integer = pixelsSrc(position)
                                ' now if we are in the top 7x3 row then yy  = -1
                                ' and we want to subtract the color value from the total
                                ' if we are in the bottom row then yy = 1
                                ' and we want to add the color value to the total
                                ' So
                                total = total + (yy * col1)
                            Next
                        Next

                        If total > 255 Then total = 255
                        If total < 0 Then total = 0
                        ' Now total has the value for the grid starting at (x,y)
                        '  The actual pixel we want to set is the one in the middle of
                        '  We are starting on line 1 anyway, so the y value is fine
                        '  but we need to bump x along by 3 pixels

                        pixels((y * stride) + ((x + 3) * 4) + colorByte) = total

                        ' reset the total for the next byte of color info:
                        ' (btw: interesting effect if you comment this out)
                        total = 0
                    Next
                Next
            Next

            Marshal.Copy(pixels, 0, scan0, pixels.Length)

            b.UnlockBits(bmData)

            Return b

        End Function

        Public Shared Function EdgeDetectionVertical(ByVal b As Bitmap) As Bitmap

            ' make a copy of the source
            Dim bSrc As Bitmap = b.Clone

            ' Now its lockbits time again.
            ' Lock each image:
            Dim bmDataSrc As BitmapData = bSrc.LockBits(New Rectangle(0, 0, b.Width, b.Height),
        ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb)
            Dim bmData As BitmapData = b.LockBits(New Rectangle(0, 0, b.Width, b.Height),
        ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)

            ' stride is the width of a row in memory
            Dim stride As Integer = bmData.Stride

            ' store the pointers to the start of the pixel data for each bitmap
            Dim scan0Src As IntPtr = bmDataSrc.Scan0
            Dim scan0 As IntPtr = bmData.Scan0

            'arrays to hold the color values
            Dim pixelsSrc(stride * bSrc.Height - 1) As Byte
            Dim pixels(stride * b.Height - 1) As Byte

            'fill the arrays
            Marshal.Copy(scan0Src, pixelsSrc, 0, pixelsSrc.Length)
            Marshal.Copy(scan0, pixels, 0, pixels.Length)

            'don't need the srcBitmap as we have the data in the array now
            bSrc.UnlockBits(bmDataSrc)
            bSrc.Dispose()

            ' Sum the color values as we move through a grid
            Dim total As Integer

            ' yy loop:
            ' first row is row 0
            ' can't do top 3 pixels so start at row 4 (y=3)
            ' can't do last 3 pixels so stop at height - 3
            ' first row is 0, so remove another 1 from height:
            For y As Integer = 3 To b.Height - 4

                ' xx loop:
                'looping through pixels in a row

                For x As Integer = 0 To b.Width - 3
                    For colorBytes As Integer = 0 To 2 ' loop through blue, green, red, skip alpha
                        '
                        '
                        ' this time the 7x3 grid looks like this:
                        '
                        ' .--------------.
                        ' | -1 |  0 |  1 |
                        ' |--------------|
                        ' | -1 |  0 |  1 |
                        ' |--------------|
                        ' | -1 |  0 |  1 |
                        ' |--------------|
                        ' | -1 |  0 |  1 |
                        ' |--------------|
                        ' | -1 |  0 |  1 |
                        ' |--------------|
                        ' | -1 |  0 |  1 |
                        ' |--------------|
                        ' | -1 |  0 |  1 |
                        ' '--------------'
                        '
                        ' We start by setting x,y to (0,3) = blue in the first pixel, fourth row
                        '
                        '
                        For yy As Integer = -3 To 3 ' rows in the 3x7 grid relative to our position
                            '                          in the fourth row

                            For xx As Integer = -1 To 1 Step 2
                                ' xx will loop -1, +1 but add 1 to it later
                                ' middle cells in row are 0 so we can skip them

                                ' Read the color information:

                                ' Current position from scan0 (start of the bitmap memory):
                                Dim position As Integer
                                ' add the number of rows down * width of row
                                position = (y + yy) * stride
                                ' add distance along the current row
                                ' xx needs to refer to 0 or 2 so add 1

                                position += (x + xx + 1) * 4
                                position += colorBytes
                                Dim col1 As Integer = pixelsSrc(position)
                                ' now if we are in the left 3x7 column then xx  = -1
                                ' and we want to subtract the color value from the total
                                ' if we are in the right column then xx = 1
                                ' and we want to add the color value to the total
                                ' So:
                                total = total + (xx * col1)
                            Next
                        Next

                        If total > 255 Then total = 255
                        If total < 0 Then total = 0
                        pixels((y * stride) + ((x + 1) * 4) + colorBytes) = total

                        ' reset the total for the next byte of color info:
                        ' (interesting effect if you comment this out)
                        total = 0
                    Next colorBytes
                Next x
            Next y

            Marshal.Copy(pixels, 0, scan0, pixels.Length)

            b.UnlockBits(bmData)

            Return b

        End Function

        ''' <summary>
        ''' see
        ''' http://www.gamedev.net/reference/articles/article2007.asp
        ''' This is algorithm1 - edge detection.
        ''' Here we get each pixels RGB
        ''' and the RGB for its R hand neighbour
        ''' and the RGB for its downstairs neighbour
        ''' We then calculate the COLOR DIFFERENCE
        ''' and if it is above a certain threshold we have an edge
        ''' if it is an edge we make it white
        ''' otherwise black.
        ''' </summary>
        ''' <param name="b"></param>
        ''' <param name="nThreshold"></param>
        ''' <returns></returns>
        Public Shared Function EdgeDetectionTwoPixelTest(ByVal b As Bitmap, ByVal nThreshold As Integer) As Bitmap

            ' Draw the new bitmap in this:
            Dim bTarget As New Bitmap(b.Width, b.Height)

            'set the background to black
            Dim g As Graphics = Graphics.FromImage(bTarget)
            g.Clear(Color.Black)
            g.Dispose()

            'lock bits
            Dim bmData As BitmapData = b.LockBits(New Rectangle(0, 0, b.Width, b.Height),
        System.Drawing.Imaging.ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)
            Dim bmTarget As BitmapData = bTarget.LockBits(New Rectangle(0, 0, bTarget.Width, bTarget.Height),
        System.Drawing.Imaging.ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)

            'width of bitmap row in memory
            Dim stride As Integer = bmData.Stride

            'pointers to the start of the bitmap data
            Dim scan0Src As IntPtr = bmData.Scan0
            Dim scan0Target As IntPtr = bmTarget.Scan0

            'arrays to hold the color values
            Dim pixelsSrc(stride * b.Height - 1) As Byte
            Dim pixelsTarget(stride * bTarget.Height - 1) As Byte

            'fill the arrays
            Marshal.Copy(scan0Src, pixelsSrc, 0, pixelsSrc.Length)
            Marshal.Copy(scan0Target, pixelsTarget, 0, pixelsTarget.Length)

            'don't need the srcBitmap as we have the data in the array now
            b.UnlockBits(bmData)
            b.Dispose()

            'store position of current pixel
            Dim position As Integer

            ' store the current pixels ARGB:
            Dim R0, G0, B0 As Integer
            ' R hand neighbour:
            Dim RRight, GRight, BRight As Integer
            ' Pixel Below:
            Dim RBelow, GBelow, BBelow As Integer

            'store the color difference between current pixel and R pixel
            Dim colorDifferenceR As Integer
            ' and the pixel below
            Dim colorDifferenceB As Integer

            For y As Integer = 0 To bTarget.Height - 2
                ' Get the first pixels RGB in the outer loop
                ' This will only happen at the start of a row, we get the other pixels R0, G0, B0 later

                B0 = pixelsSrc(y * stride)
                G0 = pixelsSrc((y * stride) + 1)
                R0 = pixelsSrc((y * stride) + 2)
                For x As Integer = 0 To bTarget.Width - 2

                    'position of current pixel's first byte:
                    position = (y * stride) + (x * 4)

                    'colors for the Right pixel
                    BRight = pixelsSrc(position + 4)
                    GRight = pixelsSrc(position + 5)
                    RRight = pixelsSrc(position + 6)

                    'colors for the pixel beneath
                    BBelow = pixelsSrc(position + stride)
                    GBelow = pixelsSrc(position + stride + 1)
                    RBelow = pixelsSrc(position + stride + 2)

                    colorDifferenceR =
                Math.Sqrt(((R0 - RRight) ^ 2) + ((G0 - GRight) ^ 2) + ((B0 - BRight) ^ 2))

                    colorDifferenceB =
                Math.Sqrt(((R0 - RBelow) ^ 2) + ((G0 - GBelow) ^ 2) + ((B0 - BBelow) ^ 2))

                    If colorDifferenceR > nThreshold OrElse colorDifferenceB > nThreshold Then
                        ' make the pixel white
                        pixelsTarget(position) = 255
                        pixelsTarget(position + 1) = 255
                        pixelsTarget(position + 2) = 255
                    End If

                    ' On the next pixel, its R0 is the current RR
                    ' so Set it now and we wont have to Get it later
                    R0 = RRight
                    G0 = GRight
                    B0 = BRight
                Next
            Next

            Marshal.Copy(pixelsTarget, 0, scan0Target, pixelsTarget.Length)
            bTarget.UnlockBits(bmTarget)
            Return bTarget

        End Function

        Public Shared Function EdgeEnhance(ByVal b As Bitmap, ByVal nThreshold As Integer) As Bitmap

            'Keep a copy of the original to refer to
            Dim bSrc As Bitmap = b.Clone

            'lock bits
            Dim bmData As BitmapData = b.LockBits(New Rectangle(0, 0, b.Width, b.Height),
        System.Drawing.Imaging.ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)
            Dim bmDataSrc As BitmapData = bSrc.LockBits(New Rectangle(0, 0, bSrc.Width, bSrc.Height),
        System.Drawing.Imaging.ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)

            'width of bitmap row in memory
            Dim stride As Integer = bmData.Stride

            'pointers to the start of the bitmap data
            Dim scan0 As IntPtr = bmData.Scan0
            Dim scan0Src As IntPtr = bmDataSrc.Scan0

            'arrays to hold the color values
            Dim pixelsSrc(stride * bSrc.Height - 1) As Byte
            Dim pixels(stride * b.Height - 1) As Byte

            'fill the arrays
            Marshal.Copy(scan0Src, pixelsSrc, 0, pixelsSrc.Length)
            Marshal.Copy(scan0, pixels, 0, pixels.Length)

            'don't need the srcBitmap as we have the data in the array now
            bSrc.UnlockBits(bmDataSrc)
            bSrc.Dispose()

            Dim index As Integer ' position in the array of pixel at (x,y) in the following loop

            'store the max difference
            Dim maxDifference As Byte

            'and the current difference
            Dim currentDifference As Byte

            'and the test pixels colors
            Dim testColor1 As Integer
            Dim testcolor2 As Integer

            For y As Integer = 1 To b.Height - 2
                For x As Integer = 1 To b.Width - 2
                    'Do loop through the color bytes for a given pixel
                    For i As Integer = 0 To 2
                        'position of central pixel's byte:
                        index = (y * stride) + (x * 4) + i

                        ' 0 and 8
                        '0
                        testColor1 = pixelsSrc(index - stride - 4) ' 1 row up, 1 pixel left
                        '8
                        testcolor2 = pixelsSrc(index + stride + 4) ' 1 row down, 1 pixel right

                        'start by setting maxDifference. anything bigger will overwrite later
                        maxDifference = Math.Abs(testColor1 - testcolor2)

                        ' 1 and 7
                        ' 1
                        testColor1 = pixelsSrc(index - stride)  ' 1 row up
                        ' 7
                        testcolor2 = pixelsSrc(index + stride)  '1 row down
                        currentDifference = Math.Abs(testColor1 - testcolor2)
                        ' set max to current if current is bigger
                        maxDifference =
                    IIf(maxDifference > currentDifference, maxDifference, currentDifference)

                        ' 2 and 6
                        ' 2
                        testColor1 = pixelsSrc(index - stride + 4)  ' 1 row up, 1 pixel right
                        ' 6
                        testcolor2 = pixelsSrc(index + stride - 4) ' 1 row down, 1 pixel left
                        currentDifference = Math.Abs(testColor1 - testcolor2)
                        ' set max to current if current is bigger
                        maxDifference =
                    If(maxDifference > currentDifference, maxDifference, currentDifference)

                        ' 3 and 5
                        ' 3
                        testColor1 = pixelsSrc(index - 4)   ' 1 pixel left
                        ' 5
                        testcolor2 = pixelsSrc(index + 4) ' 1 pixel right
                        currentDifference = Math.Abs(testColor1 - testcolor2)
                        ' set max to current if current is bigger
                        maxDifference =
                    If(maxDifference > currentDifference, maxDifference, currentDifference)
                        'Here is the difference.
                        'If maxDifference is bigger than the threshold, and bigger
                        ' than the original value of the central pixel
                        ' then set the pixel to maxDifference.

                        If maxDifference > nThreshold AndAlso maxDifference > pixelsSrc(index) Then
                            pixels(index) = maxDifference
                        End If

                    Next
                Next
            Next

            Marshal.Copy(pixels, 0, scan0, pixels.Length)
            b.UnlockBits(bmData)

            Return b

        End Function

        Public Shared Function ResizeLockbits(ByVal b As Bitmap,
    ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal bBilinear As Boolean) As Bitmap

            Dim bTemp As Bitmap = b.Clone
            b = New Bitmap(nWidth, nHeight, PixelFormat.Format32bppArgb)
            Dim nXFactor As Double = bTemp.Width / nWidth
            Dim nYFactor As Double = bTemp.Height / nHeight

            Dim bTempData As BitmapData = bTemp.LockBits _
        (New Rectangle(0, 0, bTemp.Width, bTemp.Height),
        ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb)

            Dim scan0Temp As IntPtr = bTempData.Scan0
            Dim strideTemp As Integer = bTempData.Stride ' these will vary as the sizes do

            Dim tempPixels(strideTemp * bTemp.Height - 1) As Byte
            Copy(scan0Temp, tempPixels, 0, tempPixels.Length)

            Dim bData As BitmapData = b.LockBits _
        (New Rectangle(0, 0, b.Width, b.Height),
        ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)

            Dim scan0b As IntPtr = bData.Scan0
            Dim strideb As Integer = bData.Stride

            Dim bPixels(strideb * b.Height - 1) As Byte
            Copy(scan0b, bPixels, 0, bPixels.Length)

            Dim position As Integer

            If Not bBilinear Then

                Dim alpha, red, green, blue As Byte
                Dim xTemp, yTemp As Integer

                For x As Integer = 0 To b.Width - 1
                    For y As Integer = 0 To b.Height - 1

                        'set the position in bTemp where we are grabbing the pixel
                        xTemp = Convert.ToInt32(Math.Floor(x * nXFactor))
                        yTemp = Convert.ToInt32(Math.Floor(y * nYFactor))
                        'position in btemp then is
                        position = (yTemp * strideTemp) + (xTemp * 4)
                        'get colors from btemp
                        blue = tempPixels(position)
                        green = tempPixels(position + 1)
                        red = tempPixels(position + 2)
                        alpha = tempPixels(position + 3)
                        'reset position to refer to the target bitmap location
                        position = (y * strideb) + (x * 4)
                        'write to b
                        bPixels(position) = blue
                        bPixels(position + 1) = green
                        bPixels(position + 2) = red
                        bPixels(position + 3) = alpha
                    Next
                Next
                bTemp.UnlockBits(bTempData)
                bTemp.Dispose()
                Copy(bPixels, 0, scan0b, bPixels.Length)
                b.UnlockBits(bData)

                Return b
            Else
                ' The Better Way:
                Dim fraction_x, fraction_y, one_minus_x, one_minus_y As Double
                Dim ceil_x, ceil_y, floor_x, floor_y As Integer
                'store ARGB info in these:
                Dim c1(4) As Integer
                Dim c2(4) As Integer
                Dim c3(4) As Integer
                Dim c4(4) As Integer
                Dim red, green, blue, alpha As Byte
                Dim b1, b2 As Byte
                For x As Integer = 0 To b.Width - 1
                    For y As Integer = 0 To b.Height - 1
                        'Setup
                        floor_x = Convert.ToInt32(Math.Floor(x * nXFactor))
                        floor_y = Convert.ToInt32(Math.Floor(y * nYFactor))
                        ceil_x = floor_x + 1
                        If (ceil_x >= bTemp.Width) Then ceil_x = floor_x
                        ceil_y = floor_y + 1
                        If (ceil_y >= bTemp.Height) Then ceil_y = floor_y
                        fraction_x = x * nXFactor - floor_x
                        fraction_y = y * nYFactor - floor_y
                        one_minus_x = 1.0 - fraction_x
                        one_minus_y = 1.0 - fraction_y

                        'ugly - we need the argb's for four pixels...
                        position = (floor_y * strideTemp) + (floor_x * 4)
                        c1(0) = tempPixels(position)
                        c1(1) = tempPixels(position + 1)
                        c1(2) = tempPixels(position + 2)
                        c1(3) = tempPixels(position + 3)
                        position = (floor_y * strideTemp) + (ceil_x * 4)
                        c2(0) = tempPixels(position)
                        c2(1) = tempPixels(position + 1)
                        c2(2) = tempPixels(position + 2)
                        c2(3) = tempPixels(position + 3)
                        position = (ceil_y * strideTemp) + (floor_x * 4)
                        c3(0) = tempPixels(position)
                        c3(1) = tempPixels(position + 1)
                        c3(2) = tempPixels(position + 2)
                        c3(3) = tempPixels(position + 3)
                        position = (ceil_y * strideTemp) + (ceil_x * 4)
                        c4(0) = tempPixels(position)
                        c4(1) = tempPixels(position + 1)
                        c4(2) = tempPixels(position + 2)
                        c4(3) = tempPixels(position + 3)

                        'Blue
                        b1 = Convert.ToByte(one_minus_x * c1(0) + fraction_x * c2(0))
                        b2 = Convert.ToByte(one_minus_x * c3(0) + fraction_x * c4(0))
                        blue = Convert.ToByte(one_minus_y * b1 + fraction_y * b2)
                        'Green
                        b1 = Convert.ToByte(one_minus_x * c1(1) + fraction_x * c2(1))
                        b2 = Convert.ToByte(one_minus_x * c3(1) + fraction_x * c4(1))
                        green = Convert.ToByte(one_minus_y * b1 + fraction_y * b2)
                        'Red
                        b1 = Convert.ToByte(one_minus_x * c1(2) + fraction_x * c2(2))
                        b2 = Convert.ToByte(one_minus_x * c3(2) + fraction_x * c4(2))
                        red = Convert.ToByte(one_minus_y * b1 + fraction_y * b2)
                        'Alpha ? unsure what to do.

                        b1 = Convert.ToByte(one_minus_x * c1(3) + fraction_x * c2(3))
                        b2 = Convert.ToByte(one_minus_x * c3(3) + fraction_x * c4(3))
                        alpha = Convert.ToByte(one_minus_y * b1 + fraction_y * b2)

                        position = (y * strideb) + (x * 4)
                        bPixels(position) = blue
                        bPixels(position + 1) = green
                        bPixels(position + 2) = red
                        bPixels(position + 3) = alpha
                    Next
                Next
                bTemp.UnlockBits(bTempData)
                bTemp.Dispose()
                Copy(bPixels, 0, scan0b, bPixels.Length)
                b.UnlockBits(bData)
                Return b
            End If

        End Function

        Public Class Pixelate2

            Public Shared Function ProcessImage(ByVal bm As Bitmap, ByVal squaresize As Integer) As Bitmap

                Dim x As Integer
                Dim y As Integer
                Dim red, green, blue, alpha As Byte

                Dim bmd As BitmapData = bm.LockBits(New Rectangle(0, 0, bm.Width, bm.Height),
         System.Drawing.Imaging.ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb)

                Dim pixels(bmd.Stride * bm.Height - 1) As Byte
                Copy(bmd.Scan0, pixels, 0, pixels.Length)

                For y = 0 To bmd.Height - 1 Step squaresize
                    For x = 0 To bmd.Width - 1 Step squaresize
                        Dim reds As New ArrayList
                        Dim greens As New ArrayList
                        Dim blues As New ArrayList
                        Dim alphas As New ArrayList
                        'from the starting pixel x,y
                        'GET color values for all the pixels in the
                        'square of squaresize
                        For yy As Integer = 0 To squaresize - 1
                            For xx As Integer = 0 To squaresize - 1
                                Dim thisPixelX As Integer = x + xx
                                Dim thisPixelY As Integer = y + yy
                                'with some squaresize values, x+xx can go outside the width of the image:
                                If thisPixelX < bm.Width AndAlso thisPixelY < bm.Height Then
                                    'get blue in pixel x + xx, y + yy
                                    blue = pixels((bmd.Stride * (y + yy)) + (4 * (x + xx)))
                                    blues.Add(blue)
                                    'get green in pixel x + xx, y + yy
                                    green = pixels((bmd.Stride * (y + yy)) + (4 * (x + xx)) + 1)
                                    greens.Add(green)
                                    'get red in pixel x + xx, y + yy
                                    red = pixels((bmd.Stride * (y + yy)) + (4 * (x + xx)) + 2)
                                    reds.Add(red)
                                    'get alpha in pixel (x+xx, y+yy)
                                    alpha = pixels((bmd.Stride * (y + yy)) + (4 * (x + xx)) + 3)
                                    alphas.Add(alpha)
                                End If
                            Next
                        Next
                        'average colors:
                        red = averageColor(reds)
                        green = averageColor(greens)
                        blue = averageColor(blues)
                        alpha = averageColor(alphas)
                        'from the starting pixel x,y
                        'SET color values for all the pixels in the
                        'square of squaresize to the average color...
                        For xx As Integer = 0 To squaresize - 1
                            For yy As Integer = 0 To squaresize - 1
                                Dim thisPixelX As Integer = x + xx
                                Dim thisPixelY As Integer = y + yy
                                If thisPixelX < bm.Width AndAlso thisPixelY < bm.Height Then
                                    'set blue in pixel x + xx, y + yy
                                    pixels((bmd.Stride * (y + yy)) + (4 * (x + xx))) = blue
                                    'set green in pixel x + xx, y + yy
                                    pixels((bmd.Stride * (y + yy)) + (4 * (x + xx)) + 1) = green
                                    'set red in pixel x + xx, y + yy
                                    pixels((bmd.Stride * (y + yy)) + (4 * (x + xx)) + 2) = red
                                    'set alpha
                                    pixels((bmd.Stride * (y + yy)) + (4 * (x + xx)) + 3) = alpha
                                End If
                            Next
                        Next
                    Next
                Next
                Copy(pixels, 0, bmd.Scan0, pixels.Length)
                bm.UnlockBits(bmd)
                Return bm

            End Function

            Public Shared Function averageColor(ByRef colorList As ArrayList) As Byte
                'loop through arraylist items
                'add up all the bytes
                'return the average
                Dim total As Integer
                For i As Integer = 0 To colorList.Count - 1
                    total += Convert.ToInt32(colorList(i))
                Next
                Return Convert.ToByte(total / colorList.Count)
            End Function

        End Class

        Private Class convolutionFilters

            ' the matrix class
            Public Class ConvMatrix

                Public Factor As Integer = 1
                Public Offset As Integer = 0

                'instead of all those integers, we'll use an array:
                Public grid(8) As Integer

                ' then we can get it in a for... next loop

                Sub New()
                    ' fill up with defaults
                    For i As Integer = 0 To 8
                        grid(i) = 0
                        grid(4) = 1
                    Next
                End Sub

                Public Sub SetAll(ByVal value As Integer)
                    'allows us to set all the  items in grid to the same value
                    For i As Integer = 0 To 8
                        grid(i) = value
                    Next
                End Sub

                Default Property item(ByVal index As Integer) As Integer
                    ' default property means we dont have to use the keyword "item"
                    ' lets us set the values at grid(value)
                    Get
                        Return grid(index)
                    End Get
                    Set(ByVal Value As Integer)
                        grid(index) = Value
                    End Set
                End Property

            End Class

            Private _grid As ConvMatrix ' for the property:

            ' Allow us to get a grid
            Public ReadOnly Property GetGrid() As ConvMatrix
                Get
                    Return _grid
                End Get
            End Property

            Sub New()
                _grid = New ConvMatrix
            End Sub

            Public Function conv3x3(ByVal b As Bitmap, ByVal m As ConvMatrix) As Boolean

                ' this will always be fairly slow as for each pixel we are reading 9 other pixels to get
                ' the final color value. The perpixel filters just read from one pixel.

                'avoid / by 0
                If m.Factor = 0 Then Return True

                ' We are moving through the bitmap, and changing pixels based on their surrounding
                '  pixels. This means that we need a copy of the source bitmap, so that we don't
                '  end up using pixels that we have changed (and so filter based on changed pixels)
                ' So here is a copy of the input bitmap:
                Dim bSrc As Bitmap = b.Clone

                ' So we want Two lockbits now. We lock the source bits
                Dim bmSrc As BitmapData =
         bSrc.LockBits(New Rectangle(0, 0, bSrc.Width, bSrc.Height),
         ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)

                ' And we lock the target bits
                Dim bmData As BitmapData =
         b.LockBits(New Rectangle(0, 0, b.Width, b.Height),
         ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)

                ' We need the pointers to the start of both images data:
                Dim Scan0 As IntPtr = bmData.Scan0
                Dim SrcScan0 As IntPtr = bmSrc.Scan0

                ' We are storing all the pixels as int32s in arrays:
                Dim pixels(b.Width * b.Height - 1) As Integer
                Dim pixelsSrc(b.Width * b.Height - 1) As Integer

                ' Marshal copy grabs the pixels
                Marshal.Copy(Scan0, pixels, 0, pixels.Length)
                Marshal.Copy(SrcScan0, pixelsSrc, 0, pixelsSrc.Length)

                ' keep a running total (more later)...
                Dim total(3) As Single ' store sum of the pixels read from the source

                Dim index As Integer

                Dim gridValueDivmFactor As Single
                Dim ninthOfOffset As Single = m.Offset / 9

                ' We are manipulating a pixel based on all its surrounding pixels
                '  the pixels on the edges don't have all the surrounding pixels
                '  so we skip them by staring these loops at 1 and ending at blah -2
                For y As Integer = 1 To b.Height - 2
                    For x As Integer = 1 To b.Width - 2

                        ' We have defined a 3x3 grid and we apply it to the pixels
                        ' around the current one: (E is current pixel)
                        '
                        ' pixels         grid
                        ' A B C          1 2 3
                        ' D E F   with   4 5 6
                        ' G H I          7 8 9
                        '
                        ' (this is not matrix multiplication)
                        '
                        ' We get: (A*1) + (B*2) + (C*3) + (D*4) + (E*5) + (F*6) + (G*7) + (H*8) + (I*9)
                        ' we then divide this by m.factor and add m.offset...
                        '
                        ' e.g. with the starting grid:
                        ' 000
                        ' 010
                        ' 000 we get the result E = the value of the central pixel so no change to the image
                        '
                        ' Our For ... Next loop puts the current pixel at (x,y)
                        ' This means we need to get the pixels in the following positions:
                        ' (x-1,y-1) ( x ,y-1) (x+1,y-1)
                        ' (x-1, y ) ( x , y ) (x+1, y )
                        ' (x-1,y+1) ( x ,y+1) (x+1,y+1)
                        '

                        ' Another loop
                        ' This one loops through a 3x3 grid:
                        For yy As Integer = -1 To +1
                            For xx As Integer = -1 To +1

                                ' the central pixel(x,y) is in the array at this index:
                                ' (y * b.Width) pixels in the rows above + x pixels in the current row
                                ' (y * b.width) + x

                                ' the yyxx for next loop gives us:    (-1,-1)  (0,-1) (1,-1)
                                '                                     (-1,0)   (0,0)  (1,0)
                                '                                     (-1,1)   (0,1)  (1,1)
                                '
                                'so... the locaion of the pixels in the loop is (x+xx,y+yy)
                                'and the position in the array is:
                                '
                                index = ((y + yy) * b.Width) + x + xx

                                'we want to total the argb of the current pixel * the grid value for its position
                                'we'll do the factor here too, and add on 1/9 of offset
                                'trying to keep the number of calculations in the loops to a minimum

                                gridValueDivmFactor = m.grid(((yy + 1) * 3) + (xx + 1)) / m.Factor

                                'ignore alpha, it messes up with some filters. will just set it to 255

                                'total(0) += (((pixelsSrc(index) >> 24) And &HFF) * gridValueDivmFactor) + ninthOfOffset
                                total(1) += (((pixelsSrc(index) >> 16) And &HFF) * gridValueDivmFactor) + ninthOfOffset
                                total(2) += (((pixelsSrc(index) >> 8) And &HFF) * gridValueDivmFactor) + ninthOfOffset
                                total(3) += ((pixelsSrc(index) And &HFF) * gridValueDivmFactor) + ninthOfOffset

                            Next
                        Next

                        For i As Integer = 0 To 3
                            If total(i) > 255 Then total(i) = 255
                            If total(i) < 0 Then total(i) = 0
                        Next

                        'finally we set the pixel in the destination bitmap

                        pixels(y * b.Width + x) = (255 << 24) _
                      Or (Convert.ToInt32(total(1)) << 16) _
                      Or (Convert.ToInt32(total(2)) << 8) _
                      Or Convert.ToInt32(total(3))

                        'reset total for next pixel
                        Array.Clear(total, 0, 4)

                    Next
                Next
                Marshal.Copy(pixels, 0, Scan0, pixels.Length)
                'unlock both bitmaps
                b.UnlockBits(bmData)
                bSrc.UnlockBits(bmSrc)

                Return True

            End Function

        End Class

        ''' <summary>
        ''' Remove the color from an image
        ''' Greys occur when R=G=B
        ''' You can use the average of R, G and B for the grey value
        ''' but you get better results with
        ''' grey value = (0.299 * red) + (0.587 * green) + (0.114 * blue)
        ''' which is just a weighted average.
        ''' </summary>
        ''' <param name="b"></param>
        ''' <returns></returns>
        Public Shared Function GreyScale(ByVal b As Bitmap) As Bitmap

            ' To get a color on the greyscale you need to have R = G = B
            '  you could avrage the R,G and B component of each pixels color
            '  and set them to that. But the boss (c.g) says we should set
            '  the R, G and B to:
            ' (0.299 * red) + (0.587 * green) + (0.114 * blue)

            Dim bmd As BitmapData =
        b.LockBits(New Rectangle(0, 0, b.Width, b.Height),
        System.Drawing.Imaging.ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)

            Dim scan0 As IntPtr = bmd.Scan0

            Dim alpha, red, green, blue As Integer

            Dim pixels(b.Width * b.Height - 1) As Integer
            Copy(scan0, pixels, 0, pixels.Length)

            'hold the grey value
            Dim grey As Integer

            ' loop through all pixels

            For i As Integer = 0 To pixels.Length - 1

                ' get the individual color components from the int 32
                ' say the color is A=255, R=100, G=200, B=144
                ' in hex that is: &HFF64C890
                ' in binary it is:
                ' 11111111 01100100 11001000 10010000
                ' as an example, to get the Red component we need to shift it right 2 bytes (16 bits):
                ' when you use the right shift operator, bits "drop off" the right end of the number:
                ' it becomes just: 11111111 01100100 or &HFF64
                ' we now need to prune off the high byte, for which we use bitwise AND:
                ' 11111111 01100100   &HFF64
                ' 00000000 11111111   &H00FF
                ' -------------------------- AND
                ' 00000000 01100100   &H0064
                '
                ' which is our value for red.
                '
                ' You could do it this way:

                ' dim c as color = color.fromargb(&HFF64C890)
                ' red = c.R
                ' alpha = c.A
                ' green = c.G
                ' blue = c.B

                ' but it is slow.

                alpha = (pixels(i) >> 24) And &HFF
                red = (pixels(i) >> 16) And &HFF
                green = (pixels(i) >> 8) And &HFF
                blue = pixels(i) And &HFF

                ' This is an optimised greyscale formula, it is supposed to look better for
                ' photos and such, there is not much difference with just averaging the colors.

                ' grey is an integer instead of byte as we are going to do << on the byte values.
                grey = Convert.ToInt32((0.299 * red) + (0.587 * green) + (0.114 * blue))
                ' alternative, averaging :
                ' Dim grey As Integer = convert.toint32(R) + convert.toint32(G) + convert.toint32(B )
                ' grey = grey / 3 ' integer division

                ' The recombination is the breakup in reverse.
                ' we binary shift A,R and G bits left
                ' and then bitwise OR the results

                pixels(i) = (255 << 24) _
            Or (grey << 16) _
            Or (grey << 8) _
            Or grey
            Next

            Copy(pixels, 0, scan0, pixels.Length)
            b.UnlockBits(bmd)

            Return b

        End Function

        ''' <summary>
        ''' For color we add an R/G/B level to the R/G/B for each pixel.
        ''' see "inverse" for comments on the way we are reading and writing the data
        ''' and an expanation of why we do what we do for the indexed colors.
        ''' </summary>
        ''' <param name="b"></param>
        ''' <param name="levelR"></param>
        ''' <param name="levelG"></param>
        ''' <param name="levelB"></param>
        ''' <returns></returns>
        Public Shared Function ColorFilter(ByVal b As Bitmap, ByVal levelR As Integer,
    ByVal levelG As Integer, ByVal levelB As Integer) As Bitmap

            'specify the same pixelformat as the bitmap
            Dim bmd As BitmapData =
        b.LockBits(New Rectangle(0, 0, b.Width, b.Height),
        System.Drawing.Imaging.ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)

            Dim scan0 As IntPtr = bmd.Scan0
            Dim pixels(b.Width * b.Height - 1) As Integer
            Copy(scan0, pixels, 0, pixels.Length)
            Dim alpha, red, green, blue As Integer

            ' loop through all pixels

            For i As Integer = 0 To pixels.Length - 1

                alpha = (pixels(i) >> 24) And &HFF
                red = (pixels(i) >> 16) And &HFF
                green = (pixels(i) >> 8) And &HFF
                blue = pixels(i) And &HFF

                ' Here we just add the level selected for each color.
                ' And check they don't go off the top
                red = red + levelR
                green = green + levelG
                blue = blue + levelB

                red = Math.Max(0, red)   ' get 0 or red whichever is bigger
                red = Math.Min(255, red) ' get 255 or red whichever is smaller
                ' so we wont have anything <0 or >255

                green = Math.Max(0, green)
                green = Math.Min(255, green)

                blue = Math.Max(0, blue)
                blue = Math.Min(255, blue)

                pixels(i) = (255 << 24) _
              Or (red << 16) _
              Or (green << 8) _
              Or blue

            Next

            Copy(pixels, 0, scan0, pixels.Length)
            ' unlock the bits.
            b.UnlockBits(bmd)
            Return b
        End Function

        ''' <summary>
        ''' Change the Contrast
        ''' see "inverse" for comments on the way we are reading and writing the data
        ''' and an expanation of why we do what we do for the indexed colors.
        ''' see "greyscale" for comments on splitting the color into A,R,G,B values
        ''' </summary>
        ''' <param name="b"></param>
        ''' <param name="level"></param>
        ''' <returns></returns>
        Public Shared Function Contrast(ByVal b As Bitmap, ByVal level As Integer) As Bitmap
            'specify the same pixelformat as the bitmap
            Dim bmd As BitmapData =
        b.LockBits(New Rectangle(0, 0, b.Width, b.Height),
        System.Drawing.Imaging.ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)

            Dim scan0 As IntPtr = bmd.Scan0

            ' This time we will copy each component into a byte array:
            Dim pixels(4 * (b.Width * b.Height - 1)) As Byte
            Copy(scan0, pixels, 0, pixels.Length)

            ' For the contrast we have used a trackbar that generates a number from -100 to 100
            ' We want a number from 0 to 4
            ' so add 100 to get numbers from 0 to 200
            ' divide by 100 to get numbers from 0 to 2
            ' square to get numbers from 0 to 4
            Dim mcontrast As Double
            mcontrast = ((level + 100) / 100) ^ 2

            ' The contrast algorithm uses a color value from 0 to 1
            ' Store it in this:
            Dim pixel As Double

            ' loop through all pixels

            For i As Integer = 0 To pixels.Length - 1

                ' turn it into a double between 0 and 1
                pixel = pixels(i) / 255.0
                ' pass it through the contrast algorithm
                pixel -= 0.5
                pixel *= mcontrast
                pixel += 0.5
                pixel *= 255

                ' clip anything that is out of range
                If pixel < 0 Then pixel = 0 Else If pixel > 255 Then pixel = 255

                ' write it back
                pixels(i) = Convert.ToByte(pixel)

            Next

            Copy(pixels, 0, scan0, pixels.Length)
            ' unlock the bits.
            b.UnlockBits(bmd)

            Return b
        End Function

        Public Shared Function ColorExtraction(ByRef b As Bitmap, ByVal searchColor As Color,
    ByVal tolerance As Integer) As Bitmap

            'lock bits
            Dim bmData As BitmapData = b.LockBits(New Rectangle(0, 0, b.Width, b.Height),
    System.Drawing.Imaging.ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)

            'width of bitmap row in memory
            Dim stride As Integer = bmData.Stride

            'pointers to the start of the bitmap data
            Dim scan0 As IntPtr = bmData.Scan0

            ' array to hold the colors
            Dim pixels(stride * b.Height - 1) As Byte
            Marshal.Copy(scan0, pixels, 0, pixels.Length)

            'store position of current pixel
            Dim position As Integer

            ' store the current pixels RGB:
            Dim R0, G0, B0 As Integer
            ' store the searchColors RGB
            Dim R1, G1, B1 As Integer
            R1 = searchColor.R
            G1 = searchColor.G
            B1 = searchColor.B

            'store the color difference between current pixel and  searchPixel
            Dim colorDifference As Integer

            For y As Integer = 0 To b.Height - 1
                For x As Integer = 0 To b.Width - 1
                    'position of current pixel's first byte:
                    position = (y * stride) + (x * 4)

                    B0 = pixels(position)
                    G0 = pixels(position + 1)
                    R0 = pixels(position + 2)
                    'calculate the color difference

                    colorDifference =
            Math.Sqrt(((R0 - R1) ^ 2) + ((G0 - G1) ^ 2) + ((B0 - B1) ^ 2))

                    'If the color is close enough, set it to the search color ( could just leave it if you wanted)
                    'if not set it to black

                    If colorDifference <= tolerance Then
                        ' set it to the search color
                        pixels(position) = Convert.ToByte(B1)
                        pixels(position + 1) = Convert.ToByte(G1)
                        pixels(position + 2) = Convert.ToByte(R1)
                    Else
                        ' set it to black
                        pixels(position) = Convert.ToByte(0)
                        pixels(position + 1) = Convert.ToByte(0)
                        pixels(position + 2) = Convert.ToByte(0)
                    End If
                Next
            Next
            Marshal.Copy(pixels, 0, scan0, pixels.Length)

            b.UnlockBits(bmData)

            Return b

        End Function

        ''' <summary>
        ''' Change the brightness
        ''' If you change each R, G, B by the same amount you alter the
        ''' brightness.
        ''' see "inverse" for comments on the way we are reading and writing the data
        ''' and an expanation of why we do what we do for the indexed colors.
        ''' see "greyscale" for comments on splitting the color into A,R,G,B values
        ''' </summary>
        ''' <param name="b"></param>
        ''' <param name="level"></param>
        ''' <returns></returns>
        Public Shared Function Brightness(ByVal b As Drawing.Bitmap, ByVal level As Integer) As Bitmap

            Dim bmd As BitmapData =
        b.LockBits(New Rectangle(0, 0, b.Width, b.Height),
        System.Drawing.Imaging.ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)

            Dim scan0 As IntPtr = bmd.Scan0

            Dim pixels(b.Width * b.Height - 1) As Integer

            Copy(scan0, pixels, 0, pixels.Length)

            Dim alpha, red, green, blue As Integer

            ' loop through all pixels

            For i As Integer = 0 To pixels.Length - 1

                alpha = (pixels(i) >> 24) And &HFF
                red = (pixels(i) >> 16) And &HFF
                green = (pixels(i) >> 8) And &HFF
                blue = pixels(i) And &HFF

                ' calculate the new values by adding the level the user has selected
                blue = blue + level
                green = green + level
                red = red + level

                ' clip anything that is out of range 0 to 255
                If blue < 0 Then blue = 0 Else If blue > 255 Then blue = 255
                If green < 0 Then green = 0 Else If green > 255 Then green = 255
                If red < 0 Then red = 0 Else If red > 255 Then red = 255

                pixels(i) = (255 << 24) _
                      Or (red << 16) _
                      Or (green << 8) _
                      Or blue

            Next

            Copy(pixels, 0, scan0, pixels.Length)
            b.UnlockBits(bmd)
            Return b
        End Function

        ''' <summary>
        '''   Invert all color in the image
        ''' </summary>
        ''' <param name="b"></param>
        ''' <returns></returns>
        Public Shared Function Inverse(ByVal b As Bitmap) As Bitmap

            ' 32 bit per pixel
            ' 1 byte per color component per pixel (A, R, G, B).
            ' we don't want to change the alpha as normal images would become invisible
            ' The lockbits method locks the bitmap in memory and it won't be garbage collected until unlocked
            ' We get a pointer called scan0 that is the address of the start of the data.
            ' The first 4 bytes are the color of the top left pixel in the bitmap
            ' I have been fussy about using 32bpp ARGB to ensure the image is laid out in a predictable way.
            ' It is also the easiest to use...

            Dim bmd As BitmapData =
        b.LockBits(New Rectangle(0, 0, b.Width, b.Height),
        System.Drawing.Imaging.ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)

            Dim scan0 As IntPtr = bmd.Scan0
            Dim stride As Integer = bmd.Stride

            ' Here's the speedier method.
            ' define an array to store each pixels color as an int32
            Dim pixels(b.Width * b.Height - 1) As Integer

            ' Old method used readbyte for each color component of each pixel in a loop.
            ' Instead we copy all the data at once into the array and work with that
            ' this is much faster. (almost as fast as using c#, lockbits, unsafe and pointers

            ' this is system.runtime.interopservices.marshall.copy
            Copy(scan0, pixels, 0, pixels.Length)

            ' loop through all pixels and invert

            For i As Integer = 0 To pixels.Length - 1

                ' calculate the inverse:
                pixels(i) = (Not pixels(i) And &HFFFFFF) Or (pixels(i) And &HFF000000)

            Next

            ' Copy the data back from the array to the locked memory
            Copy(pixels, 0, scan0, pixels.Length)

            ' finally we unlock the bits.
            b.UnlockBits(bmd)
            Return b

        End Function

    End Class

    Public Module ImageExtensions

        ' Returns an image object that is a screen shot of the current virtual screen.
        Public Function CaptureScreenImage() As Image

            ' Get virtual screen dimensions (for multiple monitors)
            Dim screenWidth As Integer = SystemInformation.VirtualScreen.Width

            Dim screenHeight As Integer = SystemInformation.VirtualScreen.Height

            Dim screenTop As Integer = SystemInformation.VirtualScreen.Top

            Dim screenLeft As Integer = SystemInformation.VirtualScreen.Left

            ' Setup a bitmap according to the virtual screen dimensions

            Dim Bitmap As Bitmap = New Bitmap(screenWidth, screenHeight)
            Dim g As Graphics = Graphics.FromImage(Bitmap)

            g.CopyFromScreen(screenLeft, screenTop, 0, 0, New Size(screenWidth, screenHeight))

            Return CType(Bitmap, Image)

        End Function

        ''' <summary>
        ''' Writes the contents of an embedded file resource embedded as Bytes to disk.
        ''' EG: My.Resources.DefBrainConcepts.FileSave(Application.StartupPath  "\DefBrainConcepts.ACCDB")
        ''' </summary>
        ''' <param name="BytesToWrite">Embedded resource Name</param>
        ''' <param name="FileName">    Save to file</param>
        ''' <remarks></remarks>
        <System.Runtime.CompilerServices.Extension()>
        Public Sub FileSave(ByVal BytesToWrite() As Byte, ByVal FileName As String)

            If IO.File.Exists(FileName) Then
                IO.File.Delete(FileName)
            End If

            Dim FileStream As New System.IO.FileStream(FileName, System.IO.FileMode.OpenOrCreate)
            Dim BinaryWriter As New System.IO.BinaryWriter(FileStream)

            BinaryWriter.Write(BytesToWrite)
            BinaryWriter.Close()
            FileStream.Close()
        End Sub

        <Runtime.CompilerServices.Extension()>
        Public Function OpenImageFile(ByRef Filename As String) As Bitmap
            Dim ofd As New OpenFileDialog

            ofd.Title = "Browse Image Files"

            ofd.DefaultExt = "bmp"

            ofd.Filter = "Image Files|*.bmp;*.jpg;*.png"

            If ofd.ShowDialog = DialogResult.OK Then
                Dim NewImage = New Bitmap(Filename)
                Return NewImage
            Else
                Return Nothing
            End If

        End Function

#Region "Picture Comparisons"

        ''' <summary>
        ''' Compare pictures to see if the are the same
        ''' </summary>
        ''' <param name="Img1">Main image</param>
        ''' <param name="img2">To be compared with</param>
        ''' <param name="Threshold">between 0-255 Tollerances </param>
        ''' <param name="DifImg">Difference Image Produces a set of
        ''' differences if the image is simular</param>
        ''' <returns>TRUE IF SAME(within Tollerance)FALSE IF DIFFERENT</returns>
        <Runtime.CompilerServices.Extension()>
        Public Function ComparePicture(ByRef Img1 As Bitmap, ByRef img2 As Bitmap, ByRef Threshold As Integer, ByRef DifImg As Bitmap, ByRef AllowedErrors As Integer) As Boolean

            ' Get the threshold.

            ' Load the images.
            Dim bmp1 As Bitmap = Img1
            Dim bmp2 As Bitmap = img2

            ' Make a difference image.
            Dim wid As Integer = Math.Min(bmp1.Width, bmp2.Width)
            Dim hgt As Integer = Math.Min(bmp1.Height, bmp2.Height)
            Dim bmp3 As New Bitmap(wid, hgt)

            ' Create the difference image.
            Dim are_identical As Boolean = True

            Dim color1, color2 As Color
            Dim eq_color As Color = Color.White
            Dim ne_color As Color = Color.Red
            Dim dr, dg, db, diff As Integer
            Dim Count As Integer = 0

            'Step thru Pixels
            For x As Integer = 0 To wid - 1
                For y As Integer = 0 To hgt - 1
                    'Pic A
                    color1 = bmp1.GetPixel(x, y)
                    'Pic B
                    color2 = bmp2.GetPixel(x, y)
                    'Subtract Pixel
                    dr = CInt(color1.R) - color2.R
                    dg = CInt(color1.G) - color2.G
                    db = CInt(color1.B) - color2.B
                    diff = dr * dr + dg * dg + db * db
                    If diff <= Threshold Then
                        bmp3.SetPixel(x, y, color1)
                    Else
                        Count += 1

                        bmp3.SetPixel(x, y, Color.DeepPink)
                        are_identical = False
                    End If
                Next y
            Next x

            ' Display the result.
            DifImg = bmp3
            If (bmp1.Width <> bmp2.Width) OrElse (bmp1.Height <>
        bmp2.Height) Then are_identical = False
            If Count < AllowedErrors = True Then are_identical = True
            If are_identical Then
                MessageBox.Show("The images are identical")
            Else
                MessageBox.Show("The images are different : There are " & Count & ": Differences")
            End If

            bmp1.Dispose()
            bmp2.Dispose()
            Return are_identical
        End Function

#End Region

#Region "Edge detection"

        Public Const EDGE_DETECT_KIRSH As Short = 1
        Public Const EDGE_DETECT_PREWITT As Short = 2
        Public Const EDGE_DETECT_SOBEL As Short = 3

        ''' <summary>
        '''
        ''' </summary>
        ''' <param name="b"></param>
        ''' <param name="EDGE_DETECTType">
        ''' EDGE_DETECT_KIRSH As Short = 1
        ''' EDGE_DETECT_PREWITT As Short = 2
        ''' EDGE_DETECT_SOBEL As Short = 3
        ''' </param>
        ''' <param name="nThreshold"></param>
        ''' <returns></returns>
        <Runtime.CompilerServices.Extension()>
        Public Function EdgeDetectConvolution(ByVal b As Bitmap, ByVal EDGE_DETECTType As Short,
    ByVal nThreshold As Byte) As Bitmap

            Dim filt As New convolutionFilters
            Dim m As New convolutionFilters.ConvMatrix
            Dim bTemp As Bitmap = b.Clone

            ' First we run the vertical version of whichever filter it is
            ' and store in one bitmap:

            Select Case EDGE_DETECTType
                Case EDGE_DETECT_SOBEL
                    m.SetAll(0)
                    m(0) = 1        '  1  0  -1
                    m(2) = -1       '  2  0  -2
                    m(3) = 2        '  1  0  -1
                    m(5) = -2
                    m(6) = 1
                    m(8) = -1
                    m.Offset = 0
                Case EDGE_DETECT_PREWITT
                    m.SetAll(0)
                    m(0) = -1       '  -1  0  1
                    m(2) = 1        '  -1  0  1
                    m(3) = -1       '  -1  0  1
                    m(5) = 1
                    m(6) = -1
                    m(8) = 1
                    m.Offset = 0
                Case EDGE_DETECT_KIRSH
                    m.SetAll(-3)
                    m(4) = 0        '  5  -3  -3
                    m(0) = 5        '  5   0  -3
                    m(3) = 5        '  5  -3  -3
                    m(6) = 5
                    m.Offset = 0
            End Select

            ' store in b..
            Dim result As Boolean = False
            result = filt.conv3x3(b, m)
            'wait for a result...
            'otherwise a big image can crash it (
            Do
                For i = 1 To 100

                Next
            Loop Until result

            ' Next run the horizontal version of the filter on the other bitmap
            ' which still has the virgin source image.

            Select Case EDGE_DETECTType
                Case EDGE_DETECT_SOBEL
                    m.SetAll(0)
                    m(0) = 1         '  1  2  1
                    m(1) = 2         '  0  0  0
                    m(2) = 1         ' -1 -2 -1
                    m(6) = -1
                    m(7) = -2
                    m(8) = -1
                    m.Offset = 0
                Case EDGE_DETECT_PREWITT
                    m.SetAll(0)
                    m(0) = 1          ' 1  1  1
                    m(1) = 1          ' 0  0  0
                    m(2) = 1          '-1 -1 -1
                    m(6) = -1
                    m(7) = -1
                    m(8) = -1
                    m.Offset = 0
                Case EDGE_DETECT_KIRSH
                    m.SetAll(-3)
                    m(4) = 0         ' -3 -3 -3
                    m(6) = 5         ' -3  0 -3
                    m(7) = 5         '  5  5  5
                    m(8) = 5
                    m.Offset = 0
            End Select
            result = False
            result = filt.conv3x3(bTemp, m)
            Do
                For i = 1 To 100

                Next
            Loop Until result

            ' now we merge the two bitmaps with pixel = sqrt(pixel1 * pixel1 + pixel2 * pixel2)

            ' Lock each image:
            Dim bmData As BitmapData = b.LockBits(New Rectangle(0, 0, b.Width, b.Height),
        ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)

            Dim bmData2 As BitmapData = bTemp.LockBits(New Rectangle(0, 0, b.Width, b.Height),
        ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)

            ' store the pointers to the start of the pixel data for each bitmap
            Dim scan0 As IntPtr = bmData.Scan0
            Dim scan02 As IntPtr = bmData2.Scan0

            ' arrays to hold the bitmaps color information:
            Dim pixels1(4 * b.Width * b.Height - 1) As Byte
            Dim pixels2(4 * bTemp.Width * bTemp.Height - 1) As Byte

            'fill the arrays
            Marshal.Copy(scan0, pixels1, 0, pixels1.Length)
            Marshal.Copy(scan02, pixels2, 0, pixels2.Length)

            'don't need bTemp as the array has the info
            'do need b as we are going to write to it and return it
            bTemp.UnlockBits(bmData2)
            bTemp.Dispose()

            Dim nPixel As Integer

            For i As Integer = 0 To pixels1.Length - 1
                ' calculate the new value
                nPixel = Convert.ToInt32(Math.Sqrt((pixels1(i) ^ 2) + (pixels2(i) ^ 2)))
                ' make sure it is in range
                If (nPixel < nThreshold) Then nPixel = nThreshold
                If (nPixel > 255) Then nPixel = 255
                ' write it back to the array
                pixels1(i) = Convert.ToByte(nPixel)
            Next

            'write the array back to the bitmap memory data
            Marshal.Copy(pixels1, 0, scan0, pixels1.Length)
            b.UnlockBits(bmData)
            Return b

        End Function

        <Runtime.CompilerServices.Extension()>
        Public Function EdgeDetectHomogenity(ByVal b As Bitmap) As Bitmap

            'Keep a copy of the original to refer to
            Dim bSrc As Bitmap = b.Clone

            'lock bits
            Dim bmDataSrc As BitmapData = bSrc.LockBits(New Rectangle(0, 0, bSrc.Width, bSrc.Height),
        System.Drawing.Imaging.ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb)
            Dim bmData As BitmapData = b.LockBits(New Rectangle(0, 0, b.Width, b.Height),
        System.Drawing.Imaging.ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)

            'width of bitmap row in memory
            Dim stride As Integer = bmData.Stride

            'pointers to the start of the bitmap data
            Dim scan0Src As IntPtr = bmDataSrc.Scan0
            Dim scan0 As IntPtr = bmData.Scan0

            'Arrays to hold the bytes of color info
            Dim pixelsSrc(stride * bSrc.Height - 1) As Byte
            Dim pixels(stride * b.Height - 1) As Byte

            'copy data:
            Copy(scan0Src, pixelsSrc, 0, pixelsSrc.Length)
            Copy(scan0, pixels, 0, pixels.Length)

            'don't need the srcBitmap as we have the data in the array now
            bSrc.UnlockBits(bmDataSrc)
            bSrc.Dispose()

            'store position of current color component of the current pixel in the array
            Dim index As Integer

            'store the max difference
            Dim maxDifference As Byte

            'and the current difference
            Dim currentDifference As Byte

            'and the central pixels color value for this byte
            Dim col0 As Integer

            For y As Integer = 1 To b.Height - 2
                For x As Integer = 1 To b.Width - 2
                    'loop through the color bytes for a given pixel skipping alpha (BGRA when doing bytes)
                    For i As Integer = 0 To 2
                        'position of central pixel's byte in the array:
                        index = (y * stride) + (x * 4) + i
                        'central pixels color
                        col0 = pixelsSrc(index)

                        'Calculate the differences between col0 and the
                        ' corresponding byte in the pixel's 8 neighbours
                        'We want the largest difference so keep a running
                        ' highscore, and test each as against it as we go

                        ' pixel above and left is one stride up, 4 bytes back
                        ' start by setting the highscore
                        maxDifference = Math.Abs(col0 - pixelsSrc(index - stride - 4))

                        ' pixel above is one stride up----------------vvvvvvvvvvvvvv
                        currentDifference = Math.Abs(col0 - pixelsSrc(index - stride))

                        ' set the highest difference from the two so far.
                        maxDifference =
                    IIf(maxDifference > currentDifference, maxDifference, currentDifference)

                        'third one is the pixel above and right
                        currentDifference = Math.Abs(col0 - pixelsSrc(index - stride + 4))
                        maxDifference =
                    If(maxDifference > currentDifference, maxDifference, currentDifference)

                        'bug in c.g's version, he misses the MR and ML pixels and does
                        'TM and TB twice instead.

                        'fourth one is ML (middle row, left col)
                        currentDifference = Math.Abs(col0 - pixelsSrc(index - 4))
                        maxDifference =
                    If(maxDifference > currentDifference, maxDifference, currentDifference)

                        'MR
                        currentDifference = Math.Abs(col0 - pixelsSrc(index + 4))
                        maxDifference =
                    If(maxDifference > currentDifference, maxDifference, currentDifference)

                        'BL
                        currentDifference = Math.Abs(col0 - pixelsSrc(index + stride - 4))
                        maxDifference =
                    If(maxDifference > currentDifference, maxDifference, currentDifference)

                        'BM
                        currentDifference = Math.Abs(col0 - pixelsSrc(index + stride))
                        maxDifference =
                    If(maxDifference > currentDifference, maxDifference, currentDifference)

                        'BR
                        currentDifference = Math.Abs(col0 - pixelsSrc(index + stride + 4))
                        maxDifference =
                    If(maxDifference > currentDifference, maxDifference, currentDifference)

                        'phew.

                        'If the maxDifference is less than the threshold then zero it
                        If maxDifference < 0 Then maxDifference = 0

                        'Write the pixel to the targer bitmap
                        pixels(index) = maxDifference
                    Next

                Next
            Next

            'copy array back into bitmap
            Copy(pixels, 0, scan0, pixels.Length)
            b.UnlockBits(bmData)
            Return b

        End Function

        <Runtime.CompilerServices.Extension()>
        Public Function EdgeDetectionHorizontal(ByVal b As Bitmap) As Bitmap

            ' make a copy of the source
            Dim bSrc As Bitmap = b.Clone

            ' Now its lockbits time again.
            ' Lock each image:
            Dim bmDataSrc As BitmapData = bSrc.LockBits(New Rectangle(0, 0, b.Width, b.Height),
        ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb)
            Dim bmData As BitmapData = b.LockBits(New Rectangle(0, 0, b.Width, b.Height),
        ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)

            ' stride is the width of a row in memory
            Dim stride As Integer = bmData.Stride

            ' store the pointers to the start of the pixel data for each bitmap
            Dim scan0Src As IntPtr = bmDataSrc.Scan0
            Dim scan0 As IntPtr = bmData.Scan0

            'arrays to hold the color values
            Dim pixelsSrc(stride * bSrc.Height - 1) As Byte
            Dim pixels(stride * b.Height - 1) As Byte

            'fill the arrays
            Marshal.Copy(scan0Src, pixelsSrc, 0, pixelsSrc.Length)
            Marshal.Copy(scan0, pixels, 0, pixels.Length)

            'don't need the srcBitmap as we have the data in the array now
            bSrc.UnlockBits(bmDataSrc)
            bSrc.Dispose()

            ' Sum the color values as we move through a grid
            Dim total As Integer

            ' The pixel we set is the one in the middle
            ' So when we put the grid in the top left corner of the bitmap
            '  we are setting pixel(3,1)
            ' This means that there will be 3 pixels untouched on the left and right edges
            '  and 1 untouched at the top and bottom edges.

            ' y loop:
            ' can't do the first row (row 0) so start at 1
            ' b.height is one to big when we start at 0, so remove 1 (b.height -1)
            ' and another -1 as we cant do the last row:
            For y As Integer = 1 To b.Height - 2

                ' x loop:
                ' we need to stop before the end of the row,
                ' to account for the width of the grid.
                ' looping through each pixel.

                For x As Integer = 0 To b.Width - 7

                    ' c.g.'s version starts at byte (9,2)
                    '
                    ' For the fisrt run through the loop he adds / subtracts the
                    '  color values of pixels like so:
                    '
                    '   (0,2) + (3,2) + (6,2) + (9,2) + (12,2) + (15,2) + (18,2)
                    ' - (0,0) - (3,0) - (6,0) - (9,0) - (12,0) - (15,0) - (18,0)
                    '
                    ' These are multiples of three as we want to get every third byte
                    '  so that it is the same color component. BGRBGRBGRBGRBGRBGRBGR
                    '                                          ^  ^  ^  ^  ^  ^  ^
                    ' which in effect is using this grid:
                    '
                    ' .----------------------------------.
                    ' | -1 | -1 | -1 | -1 | -1 | -1 | -1 |
                    ' |----------------------------------|
                    ' |  0 |  0 |  0 |  0 |  0 |  0 |  0 |
                    ' |----------------------------------|
                    ' |  1 |  1 |  1 |  1 |  1 |  1 |  1 |
                    ' '----------------------------------'
                    '
                    ' and moving it through each byte.
                    '
                    ' WE start by setting x,y to (0,1) = blue in the first pixel, second row
                    '
                    '
                    'loop though the B G and R
                    For colorByte As Integer = 0 To 2
                        '
                        ' yy loop:
                        ' rows in the 7x3 grid (missing out the middle row)
                        ' relative to the middle row:
                        For yy As Integer = -1 To 1 Step 2
                            ' xx loop:
                            ' across the cells in a 7x3 row
                            ' start at 0 so end at 6

                            For xx As Integer = 0 To 6

                                ' Read the color information:

                                ' Current position from scan0 (start of the bitmap memory):
                                Dim position As Integer
                                position = (y + yy) * stride ' add the number of rows down * width of row
                                position += (x + xx) * 4  ' add the cell position along the current row
                                position += colorByte ' and the current byte
                                Dim col1 As Integer = pixelsSrc(position)
                                ' now if we are in the top 7x3 row then yy  = -1
                                ' and we want to subtract the color value from the total
                                ' if we are in the bottom row then yy = 1
                                ' and we want to add the color value to the total
                                ' So
                                total = total + (yy * col1)
                            Next
                        Next

                        If total > 255 Then total = 255
                        If total < 0 Then total = 0
                        ' Now total has the value for the grid starting at (x,y)
                        '  The actual pixel we want to set is the one in the middle of
                        '  We are starting on line 1 anyway, so the y value is fine
                        '  but we need to bump x along by 3 pixels

                        pixels((y * stride) + ((x + 3) * 4) + colorByte) = total

                        ' reset the total for the next byte of color info:
                        ' (btw: interesting effect if you comment this out)
                        total = 0
                    Next
                Next
            Next

            Marshal.Copy(pixels, 0, scan0, pixels.Length)

            b.UnlockBits(bmData)

            Return b

        End Function

        <Runtime.CompilerServices.Extension()>
        Public Function EdgeDetectionVertical(ByVal b As Bitmap) As Bitmap

            ' make a copy of the source
            Dim bSrc As Bitmap = b.Clone

            ' Now its lockbits time again.
            ' Lock each image:
            Dim bmDataSrc As BitmapData = bSrc.LockBits(New Rectangle(0, 0, b.Width, b.Height),
        ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb)
            Dim bmData As BitmapData = b.LockBits(New Rectangle(0, 0, b.Width, b.Height),
        ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)

            ' stride is the width of a row in memory
            Dim stride As Integer = bmData.Stride

            ' store the pointers to the start of the pixel data for each bitmap
            Dim scan0Src As IntPtr = bmDataSrc.Scan0
            Dim scan0 As IntPtr = bmData.Scan0

            'arrays to hold the color values
            Dim pixelsSrc(stride * bSrc.Height - 1) As Byte
            Dim pixels(stride * b.Height - 1) As Byte

            'fill the arrays
            Marshal.Copy(scan0Src, pixelsSrc, 0, pixelsSrc.Length)
            Marshal.Copy(scan0, pixels, 0, pixels.Length)

            'don't need the srcBitmap as we have the data in the array now
            bSrc.UnlockBits(bmDataSrc)
            bSrc.Dispose()

            ' Sum the color values as we move through a grid
            Dim total As Integer

            ' yy loop:
            ' first row is row 0
            ' can't do top 3 pixels so start at row 4 (y=3)
            ' can't do last 3 pixels so stop at height - 3
            ' first row is 0, so remove another 1 from height:
            For y As Integer = 3 To b.Height - 4

                ' xx loop:
                'looping through pixels in a row

                For x As Integer = 0 To b.Width - 3
                    For colorBytes As Integer = 0 To 2 ' loop through blue, green, red, skip alpha
                        '
                        '
                        ' this time the 7x3 grid looks like this:
                        '
                        ' .--------------.
                        ' | -1 |  0 |  1 |
                        ' |--------------|
                        ' | -1 |  0 |  1 |
                        ' |--------------|
                        ' | -1 |  0 |  1 |
                        ' |--------------|
                        ' | -1 |  0 |  1 |
                        ' |--------------|
                        ' | -1 |  0 |  1 |
                        ' |--------------|
                        ' | -1 |  0 |  1 |
                        ' |--------------|
                        ' | -1 |  0 |  1 |
                        ' '--------------'
                        '
                        ' We start by setting x,y to (0,3) = blue in the first pixel, fourth row
                        '
                        '
                        For yy As Integer = -3 To 3 ' rows in the 3x7 grid relative to our position
                            '                          in the fourth row

                            For xx As Integer = -1 To 1 Step 2
                                ' xx will loop -1, +1 but add 1 to it later
                                ' middle cells in row are 0 so we can skip them

                                ' Read the color information:

                                ' Current position from scan0 (start of the bitmap memory):
                                Dim position As Integer
                                ' add the number of rows down * width of row
                                position = (y + yy) * stride
                                ' add distance along the current row
                                ' xx needs to refer to 0 or 2 so add 1

                                position += (x + xx + 1) * 4
                                position += colorBytes
                                Dim col1 As Integer = pixelsSrc(position)
                                ' now if we are in the left 3x7 column then xx  = -1
                                ' and we want to subtract the color value from the total
                                ' if we are in the right column then xx = 1
                                ' and we want to add the color value to the total
                                ' So:
                                total = total + (xx * col1)
                            Next
                        Next

                        If total > 255 Then total = 255
                        If total < 0 Then total = 0
                        pixels((y * stride) + ((x + 1) * 4) + colorBytes) = total

                        ' reset the total for the next byte of color info:
                        ' (interesting effect if you comment this out)
                        total = 0
                    Next colorBytes
                Next x
            Next y

            Marshal.Copy(pixels, 0, scan0, pixels.Length)

            b.UnlockBits(bmData)

            Return b

        End Function

        ''' <summary>
        ''' see
        ''' http://www.gamedev.net/reference/articles/article2007.asp
        ''' This is algorithm1 - edge detection.
        ''' Here we get each pixels RGB
        ''' and the RGB for its R hand neighbour
        ''' and the RGB for its downstairs neighbour
        ''' We then calculate the COLOR DIFFERENCE
        ''' and if it is above a certain threshold we have an edge
        ''' if it is an edge we make it white
        ''' otherwise black.
        ''' </summary>
        ''' <param name="b"></param>
        ''' <param name="nThreshold"></param>
        ''' <returns></returns>
        <Runtime.CompilerServices.Extension()>
        Public Function EdgeDetectionTwoPixelTest(ByVal b As Bitmap, ByVal nThreshold As Integer) As Bitmap

            ' Draw the new bitmap in this:
            Dim bTarget As New Bitmap(b.Width, b.Height)

            'set the background to black
            Dim g As Graphics = Graphics.FromImage(bTarget)
            g.Clear(Color.Black)
            g.Dispose()

            'lock bits
            Dim bmData As BitmapData = b.LockBits(New Rectangle(0, 0, b.Width, b.Height),
        System.Drawing.Imaging.ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)
            Dim bmTarget As BitmapData = bTarget.LockBits(New Rectangle(0, 0, bTarget.Width, bTarget.Height),
        System.Drawing.Imaging.ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)

            'width of bitmap row in memory
            Dim stride As Integer = bmData.Stride

            'pointers to the start of the bitmap data
            Dim scan0Src As IntPtr = bmData.Scan0
            Dim scan0Target As IntPtr = bmTarget.Scan0

            'arrays to hold the color values
            Dim pixelsSrc(stride * b.Height - 1) As Byte
            Dim pixelsTarget(stride * bTarget.Height - 1) As Byte

            'fill the arrays
            Marshal.Copy(scan0Src, pixelsSrc, 0, pixelsSrc.Length)
            Marshal.Copy(scan0Target, pixelsTarget, 0, pixelsTarget.Length)

            'don't need the srcBitmap as we have the data in the array now
            b.UnlockBits(bmData)
            b.Dispose()

            'store position of current pixel
            Dim position As Integer

            ' store the current pixels ARGB:
            Dim R0, G0, B0 As Integer
            ' R hand neighbour:
            Dim RRight, GRight, BRight As Integer
            ' Pixel Below:
            Dim RBelow, GBelow, BBelow As Integer

            'store the color difference between current pixel and R pixel
            Dim colorDifferenceR As Integer
            ' and the pixel below
            Dim colorDifferenceB As Integer

            For y As Integer = 0 To bTarget.Height - 2
                ' Get the first pixels RGB in the outer loop
                ' This will only happen at the start of a row, we get the other pixels R0, G0, B0 later

                B0 = pixelsSrc(y * stride)
                G0 = pixelsSrc((y * stride) + 1)
                R0 = pixelsSrc((y * stride) + 2)
                For x As Integer = 0 To bTarget.Width - 2

                    'position of current pixel's first byte:
                    position = (y * stride) + (x * 4)

                    'colors for the Right pixel
                    BRight = pixelsSrc(position + 4)
                    GRight = pixelsSrc(position + 5)
                    RRight = pixelsSrc(position + 6)

                    'colors for the pixel beneath
                    BBelow = pixelsSrc(position + stride)
                    GBelow = pixelsSrc(position + stride + 1)
                    RBelow = pixelsSrc(position + stride + 2)

                    colorDifferenceR =
                Math.Sqrt(((R0 - RRight) ^ 2) + ((G0 - GRight) ^ 2) + ((B0 - BRight) ^ 2))

                    colorDifferenceB =
                Math.Sqrt(((R0 - RBelow) ^ 2) + ((G0 - GBelow) ^ 2) + ((B0 - BBelow) ^ 2))

                    If colorDifferenceR > nThreshold OrElse colorDifferenceB > nThreshold Then
                        ' make the pixel white
                        pixelsTarget(position) = 255
                        pixelsTarget(position + 1) = 255
                        pixelsTarget(position + 2) = 255
                    End If

                    ' On the next pixel, its R0 is the current RR
                    ' so Set it now and we wont have to Get it later
                    R0 = RRight
                    G0 = GRight
                    B0 = BRight
                Next
            Next

            Marshal.Copy(pixelsTarget, 0, scan0Target, pixelsTarget.Length)
            bTarget.UnlockBits(bmTarget)
            Return bTarget

        End Function

        <Runtime.CompilerServices.Extension()>
        Public Function EdgeEnhance(ByVal b As Bitmap, ByVal nThreshold As Integer) As Bitmap

            'Keep a copy of the original to refer to
            Dim bSrc As Bitmap = b.Clone

            'lock bits
            Dim bmData As BitmapData = b.LockBits(New Rectangle(0, 0, b.Width, b.Height),
        System.Drawing.Imaging.ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)
            Dim bmDataSrc As BitmapData = bSrc.LockBits(New Rectangle(0, 0, bSrc.Width, bSrc.Height),
        System.Drawing.Imaging.ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)

            'width of bitmap row in memory
            Dim stride As Integer = bmData.Stride

            'pointers to the start of the bitmap data
            Dim scan0 As IntPtr = bmData.Scan0
            Dim scan0Src As IntPtr = bmDataSrc.Scan0

            'arrays to hold the color values
            Dim pixelsSrc(stride * bSrc.Height - 1) As Byte
            Dim pixels(stride * b.Height - 1) As Byte

            'fill the arrays
            Marshal.Copy(scan0Src, pixelsSrc, 0, pixelsSrc.Length)
            Marshal.Copy(scan0, pixels, 0, pixels.Length)

            'don't need the srcBitmap as we have the data in the array now
            bSrc.UnlockBits(bmDataSrc)
            bSrc.Dispose()

            Dim index As Integer ' position in the array of pixel at (x,y) in the following loop

            'store the max difference
            Dim maxDifference As Byte

            'and the current difference
            Dim currentDifference As Byte

            'and the test pixels colors
            Dim testColor1 As Integer
            Dim testcolor2 As Integer

            For y As Integer = 1 To b.Height - 2
                For x As Integer = 1 To b.Width - 2
                    'Do loop through the color bytes for a given pixel
                    For i As Integer = 0 To 2
                        'position of central pixel's byte:
                        index = (y * stride) + (x * 4) + i

                        ' 0 and 8
                        '0
                        testColor1 = pixelsSrc(index - stride - 4) ' 1 row up, 1 pixel left
                        '8
                        testcolor2 = pixelsSrc(index + stride + 4) ' 1 row down, 1 pixel right

                        'start by setting maxDifference. anything bigger will overwrite later
                        maxDifference = Math.Abs(testColor1 - testcolor2)

                        ' 1 and 7
                        ' 1
                        testColor1 = pixelsSrc(index - stride)  ' 1 row up
                        ' 7
                        testcolor2 = pixelsSrc(index + stride)  '1 row down
                        currentDifference = Math.Abs(testColor1 - testcolor2)
                        ' set max to current if current is bigger
                        maxDifference =
                    If(maxDifference > currentDifference, maxDifference, currentDifference)

                        ' 2 and 6
                        ' 2
                        testColor1 = pixelsSrc(index - stride + 4)  ' 1 row up, 1 pixel right
                        ' 6
                        testcolor2 = pixelsSrc(index + stride - 4) ' 1 row down, 1 pixel left
                        currentDifference = Math.Abs(testColor1 - testcolor2)
                        ' set max to current if current is bigger
                        maxDifference =
                    If(maxDifference > currentDifference, maxDifference, currentDifference)

                        ' 3 and 5
                        ' 3
                        testColor1 = pixelsSrc(index - 4)   ' 1 pixel left
                        ' 5
                        testcolor2 = pixelsSrc(index + 4) ' 1 pixel right
                        currentDifference = Math.Abs(testColor1 - testcolor2)
                        ' set max to current if current is bigger
                        maxDifference =
                    If(maxDifference > currentDifference, maxDifference, currentDifference)
                        'Here is the difference.
                        'If maxDifference is bigger than the threshold, and bigger
                        ' than the original value of the central pixel
                        ' then set the pixel to maxDifference.

                        If maxDifference > nThreshold AndAlso maxDifference > pixelsSrc(index) Then
                            pixels(index) = maxDifference
                        End If

                    Next
                Next
            Next

            Marshal.Copy(pixels, 0, scan0, pixels.Length)
            b.UnlockBits(bmData)

            Return b

        End Function

#End Region

#Region "Image filters"

        ''' <summary>
        ''' Change the brightness
        ''' If you change each R, G, B by the same amount you alter the
        ''' brightness.
        ''' see "inverse" for comments on the way we are reading and writing the data
        ''' and an expanation of why we do what we do for the indexed colors.
        ''' see "greyscale" for comments on splitting the color into A,R,G,B values
        ''' </summary>
        ''' <param name="b"></param>
        ''' <param name="level"></param>
        ''' <returns></returns>
        <Runtime.CompilerServices.Extension()>
        Public Function Brightness(ByVal b As Drawing.Bitmap, ByVal level As Integer) As Bitmap

            Dim bmd As BitmapData =
        b.LockBits(New Rectangle(0, 0, b.Width, b.Height),
        System.Drawing.Imaging.ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)

            Dim scan0 As IntPtr = bmd.Scan0

            Dim pixels(b.Width * b.Height - 1) As Integer

            Copy(scan0, pixels, 0, pixels.Length)

            Dim alpha, red, green, blue As Integer

            ' loop through all pixels

            For i As Integer = 0 To pixels.Length - 1

                alpha = (pixels(i) >> 24) And &HFF
                red = (pixels(i) >> 16) And &HFF
                green = (pixels(i) >> 8) And &HFF
                blue = pixels(i) And &HFF

                ' calculate the new values by adding the level the user has selected
                blue = blue + level
                green = green + level
                red = red + level

                ' clip anything that is out of range 0 to 255
                If blue < 0 Then blue = 0 Else If blue > 255 Then blue = 255
                If green < 0 Then green = 0 Else If green > 255 Then green = 255
                If red < 0 Then red = 0 Else If red > 255 Then red = 255

                pixels(i) = (255 << 24) _
                      Or (red << 16) _
                      Or (green << 8) _
                      Or blue

            Next

            Copy(pixels, 0, scan0, pixels.Length)
            b.UnlockBits(bmd)
            Return b
        End Function

        ''' <summary>
        ''' Remove Color from image
        ''' </summary>
        ''' <param name="b"></param>
        ''' <param name="searchColor"></param>
        ''' <returns></returns>
        <Runtime.CompilerServices.Extension()>
        Public Function ColorExtraction(ByRef b As Bitmap, ByVal searchColor As Color) As Bitmap
            'lock bits
            Dim bmData As BitmapData = b.LockBits(New Rectangle(0, 0, b.Width, b.Height),
    System.Drawing.Imaging.ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)

            'width of bitmap row in memory
            Dim stride As Integer = bmData.Stride

            'pointers to the start of the bitmap data
            Dim scan0 As IntPtr = bmData.Scan0

            ' array to hold the colors
            Dim pixels(stride * b.Height - 1) As Byte
            Marshal.Copy(scan0, pixels, 0, pixels.Length)

            'store position of current pixel
            Dim position As Integer

            ' store the current pixels RGB:
            Dim R0, G0, B0 As Integer
            ' store the searchColors RGB
            Dim R1, G1, B1 As Integer
            R1 = searchColor.R
            G1 = searchColor.G
            B1 = searchColor.B

            'store the color difference between current pixel and  searchPixel
            Dim colorDifference As Integer

            For y As Integer = 0 To b.Height - 1
                For x As Integer = 0 To b.Width - 1
                    'position of current pixel's first byte:
                    position = (y * stride) + (x * 4)

                    B0 = pixels(position)
                    G0 = pixels(position + 1)
                    R0 = pixels(position + 2)
                    'calculate the color difference

                    colorDifference =
            Math.Sqrt(((R0 - R1) ^ 2) + ((G0 - G1) ^ 2) + ((B0 - B1) ^ 2))

                    'If the color is close enough, set it to the search color ( could just leave it if you wanted)
                    'if not set it to black

                    If colorDifference <= 10 Then
                        ' set it to the search color
                        pixels(position) = Convert.ToByte(B1)
                        pixels(position + 1) = Convert.ToByte(G1)
                        pixels(position + 2) = Convert.ToByte(R1)
                    Else
                        ' set it to black
                        pixels(position) = Convert.ToByte(0)
                        pixels(position + 1) = Convert.ToByte(0)
                        pixels(position + 2) = Convert.ToByte(0)
                    End If
                Next
            Next
            Marshal.Copy(pixels, 0, scan0, pixels.Length)

            b.UnlockBits(bmData)

            Return b

        End Function

        ''' <summary>
        ''' Change the Contrast
        ''' see "inverse" for comments on the way we are reading and writing the data
        ''' and an expanation of why we do what we do for the indexed colors.
        ''' see "greyscale" for comments on splitting the color into A,R,G,B values
        ''' </summary>
        ''' <param name="b"></param>
        ''' <param name="level"></param>
        ''' <returns></returns>
        <Runtime.CompilerServices.Extension()>
        Public Function Contrast(ByVal b As Bitmap, ByVal level As Integer) As Bitmap
            'specify the same pixelformat as the bitmap
            Dim bmd As BitmapData =
        b.LockBits(New Rectangle(0, 0, b.Width, b.Height),
        System.Drawing.Imaging.ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)

            Dim scan0 As IntPtr = bmd.Scan0

            ' This time we will copy each component into a byte array:
            Dim pixels(4 * (b.Width * b.Height - 1)) As Byte
            Copy(scan0, pixels, 0, pixels.Length)

            ' For the contrast we have used a trackbar that generates a number from -100 to 100
            ' We want a number from 0 to 4
            ' so add 100 to get numbers from 0 to 200
            ' divide by 100 to get numbers from 0 to 2
            ' square to get numbers from 0 to 4
            Dim mcontrast As Double
            mcontrast = ((level + 100) / 100) ^ 2

            ' The contrast algorithm uses a color value from 0 to 1
            ' Store it in this:
            Dim pixel As Double

            ' loop through all pixels

            For i As Integer = 0 To pixels.Length - 1

                ' turn it into a double between 0 and 1
                pixel = pixels(i) / 255.0
                ' pass it through the contrast algorithm
                pixel -= 0.5
                pixel *= mcontrast
                pixel += 0.5
                pixel *= 255

                ' clip anything that is out of range
                If pixel < 0 Then pixel = 0 Else If pixel > 255 Then pixel = 255

                ' write it back
                pixels(i) = Convert.ToByte(pixel)

            Next

            Copy(pixels, 0, scan0, pixels.Length)
            ' unlock the bits.
            b.UnlockBits(bmd)

            Return b
        End Function

        ''' <summary>
        ''' For color we add an R/G/B level to the R/G/B for each pixel.
        ''' see "inverse" for comments on the way we are reading and writing the data
        ''' and an expanation of why we do what we do for the indexed colors.
        ''' </summary>
        ''' <param name="b"></param>
        ''' <param name="levelR"></param>
        ''' <param name="levelG"></param>
        ''' <param name="levelB"></param>
        ''' <returns></returns>
        <Runtime.CompilerServices.Extension()>
        Public Function ColorFilter(ByVal b As Bitmap, ByVal levelR As Integer,
    ByVal levelG As Integer, ByVal levelB As Integer) As Bitmap

            'specify the same pixelformat as the bitmap
            Dim bmd As BitmapData =
        b.LockBits(New Rectangle(0, 0, b.Width, b.Height),
        System.Drawing.Imaging.ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)

            Dim scan0 As IntPtr = bmd.Scan0
            Dim pixels(b.Width * b.Height - 1) As Integer
            Copy(scan0, pixels, 0, pixels.Length)
            Dim alpha, red, green, blue As Integer

            ' loop through all pixels

            For i As Integer = 0 To pixels.Length - 1

                alpha = (pixels(i) >> 24) And &HFF
                red = (pixels(i) >> 16) And &HFF
                green = (pixels(i) >> 8) And &HFF
                blue = pixels(i) And &HFF

                ' Here we just add the level selected for each color.
                ' And check they don't go off the top
                red = red + levelR
                green = green + levelG
                blue = blue + levelB

                red = Math.Max(0, red)   ' get 0 or red whichever is bigger
                red = Math.Min(255, red) ' get 255 or red whichever is smaller
                ' so we wont have anything <0 or >255

                green = Math.Max(0, green)
                green = Math.Min(255, green)

                blue = Math.Max(0, blue)
                blue = Math.Min(255, blue)

                pixels(i) = (255 << 24) _
              Or (red << 16) _
              Or (green << 8) _
              Or blue

            Next

            Copy(pixels, 0, scan0, pixels.Length)
            ' unlock the bits.
            b.UnlockBits(bmd)
            Return b
        End Function

        ''' <summary>
        ''' Remove the color from an image
        ''' Greys occur when R=G=B
        ''' You can use the average of R, G and B for the grey value
        ''' but you get better results with
        ''' grey value = (0.299 * red) + (0.587 * green) + (0.114 * blue)
        ''' which is just a weighted average.
        ''' </summary>
        ''' <param name="b"></param>
        ''' <returns></returns>
        <Runtime.CompilerServices.Extension()>
        Public Function GreyScale(ByVal b As Bitmap) As Bitmap

            ' To get a color on the greyscale you need to have R = G = B
            '  you could avrage the R,G and B component of each pixels color
            '  and set them to that. But the boss (c.g) says we should set
            '  the R, G and B to:
            ' (0.299 * red) + (0.587 * green) + (0.114 * blue)

            Dim bmd As BitmapData =
        b.LockBits(New Rectangle(0, 0, b.Width, b.Height),
        System.Drawing.Imaging.ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)

            Dim scan0 As IntPtr = bmd.Scan0

            Dim alpha, red, green, blue As Integer

            Dim pixels(b.Width * b.Height - 1) As Integer
            Copy(scan0, pixels, 0, pixels.Length)

            'hold the grey value
            Dim grey As Integer

            ' loop through all pixels

            For i As Integer = 0 To pixels.Length - 1

                ' get the individual color components from the int 32
                ' say the color is A=255, R=100, G=200, B=144
                ' in hex that is: &HFF64C890
                ' in binary it is:
                ' 11111111 01100100 11001000 10010000
                ' as an example, to get the Red component we need to shift it right 2 bytes (16 bits):
                ' when you use the right shift operator, bits "drop off" the right end of the number:
                ' it becomes just: 11111111 01100100 or &HFF64
                ' we now need to prune off the high byte, for which we use bitwise AND:
                ' 11111111 01100100   &HFF64
                ' 00000000 11111111   &H00FF
                ' -------------------------- AND
                ' 00000000 01100100   &H0064
                '
                ' which is our value for red.
                '
                ' You could do it this way:

                ' dim c as color = color.fromargb(&HFF64C890)
                ' red = c.R
                ' alpha = c.A
                ' green = c.G
                ' blue = c.B

                ' but it is slow.

                alpha = (pixels(i) >> 24) And &HFF
                red = (pixels(i) >> 16) And &HFF
                green = (pixels(i) >> 8) And &HFF
                blue = pixels(i) And &HFF

                ' This is an optimised greyscale formula, it is supposed to look better for
                ' photos and such, there is not much difference with just averaging the colors.

                ' grey is an integer instead of byte as we are going to do << on the byte values.
                grey = Convert.ToInt32((0.299 * red) + (0.587 * green) + (0.114 * blue))
                ' alternative, averaging :
                ' Dim grey As Integer = convert.toint32(R) + convert.toint32(G) + convert.toint32(B )
                ' grey = grey / 3 ' integer division

                ' The recombination is the breakup in reverse.
                ' we binary shift A,R and G bits left
                ' and then bitwise OR the results

                pixels(i) = (255 << 24) _
            Or (grey << 16) _
            Or (grey << 8) _
            Or grey
            Next

            Copy(pixels, 0, scan0, pixels.Length)
            b.UnlockBits(bmd)

            Return b

        End Function

        ''' <summary>
        '''   Invert all color in the image
        ''' </summary>
        ''' <param name="b"></param>
        ''' <returns></returns>
        <Runtime.CompilerServices.Extension()>
        Public Function Inverse(ByVal b As Bitmap) As Bitmap

            ' 32 bit per pixel
            ' 1 byte per color component per pixel (A, R, G, B).
            ' we don't want to change the alpha as normal images would become invisible
            ' The lockbits method locks the bitmap in memory and it won't be garbage collected until unlocked
            ' We get a pointer called scan0 that is the address of the start of the data.
            ' The first 4 bytes are the color of the top left pixel in the bitmap
            ' I have been fussy about using 32bpp ARGB to ensure the image is laid out in a predictable way.
            ' It is also the easiest to use...

            Dim bmd As BitmapData =
        b.LockBits(New Rectangle(0, 0, b.Width, b.Height),
        System.Drawing.Imaging.ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)

            Dim scan0 As IntPtr = bmd.Scan0
            Dim stride As Integer = bmd.Stride

            ' Here's the speedier method.
            ' define an array to store each pixels color as an int32
            Dim pixels(b.Width * b.Height - 1) As Integer

            ' Old method used readbyte for each color component of each pixel in a loop.
            ' Instead we copy all the data at once into the array and work with that
            ' this is much faster. (almost as fast as using c#, lockbits, unsafe and pointers

            ' this is system.runtime.interopservices.marshall.copy
            Copy(scan0, pixels, 0, pixels.Length)

            ' loop through all pixels and invert

            For i As Integer = 0 To pixels.Length - 1

                ' calculate the inverse:
                pixels(i) = (Not pixels(i) And &HFFFFFF) Or (pixels(i) And &HFF000000)

            Next

            ' Copy the data back from the array to the locked memory
            Copy(pixels, 0, scan0, pixels.Length)

            ' finally we unlock the bits.
            b.UnlockBits(bmd)
            Return b

        End Function

        <Runtime.CompilerServices.Extension()>
        Public Function ResizeLockbits(ByVal b As Bitmap,
    ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal bBilinear As Boolean) As Bitmap

            Dim bTemp As Bitmap = b.Clone
            b = New Bitmap(nWidth, nHeight, PixelFormat.Format32bppArgb)
            Dim nXFactor As Double = bTemp.Width / nWidth
            Dim nYFactor As Double = bTemp.Height / nHeight

            Dim bTempData As BitmapData = bTemp.LockBits _
        (New Rectangle(0, 0, bTemp.Width, bTemp.Height),
        ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb)

            Dim scan0Temp As IntPtr = bTempData.Scan0
            Dim strideTemp As Integer = bTempData.Stride ' these will vary as the sizes do

            Dim tempPixels(strideTemp * bTemp.Height - 1) As Byte
            Copy(scan0Temp, tempPixels, 0, tempPixels.Length)

            Dim bData As BitmapData = b.LockBits _
        (New Rectangle(0, 0, b.Width, b.Height),
        ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)

            Dim scan0b As IntPtr = bData.Scan0
            Dim strideb As Integer = bData.Stride

            Dim bPixels(strideb * b.Height - 1) As Byte
            Copy(scan0b, bPixels, 0, bPixels.Length)

            Dim position As Integer

            If Not bBilinear Then

                Dim alpha, red, green, blue As Byte
                Dim xTemp, yTemp As Integer

                For x As Integer = 0 To b.Width - 1
                    For y As Integer = 0 To b.Height - 1

                        'set the position in bTemp where we are grabbing the pixel
                        xTemp = Convert.ToInt32(Math.Floor(x * nXFactor))
                        yTemp = Convert.ToInt32(Math.Floor(y * nYFactor))
                        'position in btemp then is
                        position = (yTemp * strideTemp) + (xTemp * 4)
                        'get colors from btemp
                        blue = tempPixels(position)
                        green = tempPixels(position + 1)
                        red = tempPixels(position + 2)
                        alpha = tempPixels(position + 3)
                        'reset position to refer to the target bitmap location
                        position = (y * strideb) + (x * 4)
                        'write to b
                        bPixels(position) = blue
                        bPixels(position + 1) = green
                        bPixels(position + 2) = red
                        bPixels(position + 3) = alpha
                    Next
                Next
                bTemp.UnlockBits(bTempData)
                bTemp.Dispose()
                Copy(bPixels, 0, scan0b, bPixels.Length)
                b.UnlockBits(bData)

                Return b
            Else
                ' The Better Way:
                Dim fraction_x, fraction_y, one_minus_x, one_minus_y As Double
                Dim ceil_x, ceil_y, floor_x, floor_y As Integer
                'store ARGB info in these:
                Dim c1(4) As Integer
                Dim c2(4) As Integer
                Dim c3(4) As Integer
                Dim c4(4) As Integer
                Dim red, green, blue, alpha As Byte
                Dim b1, b2 As Byte
                For x As Integer = 0 To b.Width - 1
                    For y As Integer = 0 To b.Height - 1
                        'Setup
                        floor_x = Convert.ToInt32(Math.Floor(x * nXFactor))
                        floor_y = Convert.ToInt32(Math.Floor(y * nYFactor))
                        ceil_x = floor_x + 1
                        If (ceil_x >= bTemp.Width) Then ceil_x = floor_x
                        ceil_y = floor_y + 1
                        If (ceil_y >= bTemp.Height) Then ceil_y = floor_y
                        fraction_x = x * nXFactor - floor_x
                        fraction_y = y * nYFactor - floor_y
                        one_minus_x = 1.0 - fraction_x
                        one_minus_y = 1.0 - fraction_y

                        'ugly - we need the argb's for four pixels...
                        position = (floor_y * strideTemp) + (floor_x * 4)
                        c1(0) = tempPixels(position)
                        c1(1) = tempPixels(position + 1)
                        c1(2) = tempPixels(position + 2)
                        c1(3) = tempPixels(position + 3)
                        position = (floor_y * strideTemp) + (ceil_x * 4)
                        c2(0) = tempPixels(position)
                        c2(1) = tempPixels(position + 1)
                        c2(2) = tempPixels(position + 2)
                        c2(3) = tempPixels(position + 3)
                        position = (ceil_y * strideTemp) + (floor_x * 4)
                        c3(0) = tempPixels(position)
                        c3(1) = tempPixels(position + 1)
                        c3(2) = tempPixels(position + 2)
                        c3(3) = tempPixels(position + 3)
                        position = (ceil_y * strideTemp) + (ceil_x * 4)
                        c4(0) = tempPixels(position)
                        c4(1) = tempPixels(position + 1)
                        c4(2) = tempPixels(position + 2)
                        c4(3) = tempPixels(position + 3)

                        'Blue
                        b1 = Convert.ToByte(one_minus_x * c1(0) + fraction_x * c2(0))
                        b2 = Convert.ToByte(one_minus_x * c3(0) + fraction_x * c4(0))
                        blue = Convert.ToByte(one_minus_y * b1 + fraction_y * b2)
                        'Green
                        b1 = Convert.ToByte(one_minus_x * c1(1) + fraction_x * c2(1))
                        b2 = Convert.ToByte(one_minus_x * c3(1) + fraction_x * c4(1))
                        green = Convert.ToByte(one_minus_y * b1 + fraction_y * b2)
                        'Red
                        b1 = Convert.ToByte(one_minus_x * c1(2) + fraction_x * c2(2))
                        b2 = Convert.ToByte(one_minus_x * c3(2) + fraction_x * c4(2))
                        red = Convert.ToByte(one_minus_y * b1 + fraction_y * b2)
                        'Alpha ? unsure what to do.

                        b1 = Convert.ToByte(one_minus_x * c1(3) + fraction_x * c2(3))
                        b2 = Convert.ToByte(one_minus_x * c3(3) + fraction_x * c4(3))
                        alpha = Convert.ToByte(one_minus_y * b1 + fraction_y * b2)

                        position = (y * strideb) + (x * 4)
                        bPixels(position) = blue
                        bPixels(position + 1) = green
                        bPixels(position + 2) = red
                        bPixels(position + 3) = alpha
                    Next
                Next
                bTemp.UnlockBits(bTempData)
                bTemp.Dispose()
                Copy(bPixels, 0, scan0b, bPixels.Length)
                b.UnlockBits(bData)
                Return b
            End If

        End Function

        <Runtime.CompilerServices.Extension()>
        Public Function ResizeSetPixel(ByVal b As Bitmap,
    ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal bBilinear As Boolean) As Bitmap

            ' this is just a straight copy of c.g's code...

            Dim bTemp As Bitmap = b.Clone
            b = New Bitmap(nWidth, nHeight, bTemp.PixelFormat)
            Dim nXFactor As Double = bTemp.Width / nWidth
            Dim nYFactor As Double = bTemp.Height / nHeight

            If Not bBilinear Then
                ' The not very good way:
                ' We are looping through the new image size
                ' and grabbing the pixel color from a real pixel
                ' in the source bitmap
                ' The color comes from the pixel found by scaling again
                '  and rounding the result.
                For x As Integer = 0 To b.Width - 1
                    For y As Integer = 0 To b.Height - 1
                        b.SetPixel(x, y, bTemp.GetPixel(Convert.ToInt32(Math.Floor(x * nXFactor)),
                          Convert.ToInt32(Math.Floor(y * nYFactor))))
                    Next
                Next

                Return b
            Else
                ' The Better Way:
                Dim fraction_x, fraction_y, one_minus_x, one_minus_y As Double
                Dim ceil_x, ceil_y, floor_x, floor_y As Integer
                Dim c1 As Color = New Color
                Dim c2 As Color = New Color
                Dim c3 As Color = New Color
                Dim c4 As Color = New Color
                Dim red, green, blue As Byte
                Dim b1, b2 As Byte
                For x As Integer = 0 To b.Width - 1
                    For y As Integer = 0 To b.Height - 1
                        'Setup
                        floor_x = Convert.ToInt32(Math.Floor(x * nXFactor))
                        floor_y = Convert.ToInt32(Math.Floor(y * nYFactor))
                        ceil_x = floor_x + 1
                        If (ceil_x >= bTemp.Width) Then ceil_x = floor_x
                        ceil_y = floor_y + 1
                        If (ceil_y >= bTemp.Height) Then ceil_y = floor_y
                        fraction_x = x * nXFactor - floor_x
                        fraction_y = y * nYFactor - floor_y
                        one_minus_x = 1.0 - fraction_x
                        one_minus_y = 1.0 - fraction_y
                        c1 = bTemp.GetPixel(floor_x, floor_y)
                        c2 = bTemp.GetPixel(ceil_x, floor_y)
                        c3 = bTemp.GetPixel(floor_x, ceil_y)
                        c4 = bTemp.GetPixel(ceil_x, ceil_y)

                        'Blue
                        b1 = Convert.ToByte(one_minus_x * c1.B + fraction_x * c2.B)
                        b2 = Convert.ToByte(one_minus_x * c3.B + fraction_x * c4.B)
                        blue = Convert.ToByte(one_minus_y * b1 + fraction_y * b2)
                        'Green
                        b1 = Convert.ToByte(one_minus_x * c1.G + fraction_x * c2.G)
                        b2 = Convert.ToByte(one_minus_x * c3.G + fraction_x * c4.G)
                        green = Convert.ToByte(one_minus_y * b1 + fraction_y * b2)
                        'Red
                        b1 = Convert.ToByte(one_minus_x * c1.R + fraction_x * c2.R)
                        b2 = Convert.ToByte(one_minus_x * c3.R + fraction_x * c4.R)
                        red = Convert.ToByte(one_minus_y * b1 + fraction_y * b2)
                        b.SetPixel(x, y, System.Drawing.Color.FromArgb(255, red, green, blue))
                    Next
                Next
                Return b
            End If

        End Function

        Private Class convolutionFilters

            ' the matrix class
            Public Class ConvMatrix

                Public Factor As Integer = 1
                Public Offset As Integer = 0

                'instead of all those integers, we'll use an array:
                Public grid(8) As Integer

                ' then we can get it in a for... next loop

                Sub New()
                    ' fill up with defaults
                    For i As Integer = 0 To 8
                        grid(i) = 0
                        grid(4) = 1
                    Next
                End Sub

                Public Sub SetAll(ByVal value As Integer)
                    'allows us to set all the  items in grid to the same value
                    For i As Integer = 0 To 8
                        grid(i) = value
                    Next
                End Sub

                Default Property item(ByVal index As Integer) As Integer
                    ' default property means we dont have to use the keyword "item"
                    ' lets us set the values at grid(value)
                    Get
                        Return grid(index)
                    End Get
                    Set(ByVal Value As Integer)
                        grid(index) = Value
                    End Set
                End Property

            End Class

            Private _grid As ConvMatrix ' for the property:

            ' Allow us to get a grid
            Public ReadOnly Property GetGrid() As ConvMatrix
                Get
                    Return _grid
                End Get
            End Property

            Sub New()
                _grid = New ConvMatrix
            End Sub

            Public Function conv3x3(ByVal b As Bitmap, ByVal m As ConvMatrix) As Boolean

                ' this will always be fairly slow as for each pixel we are reading 9 other pixels to get
                ' the final color value. The perpixel filters just read from one pixel.

                'avoid / by 0
                If m.Factor = 0 Then Return True

                ' We are moving through the bitmap, and changing pixels based on their surrounding
                '  pixels. This means that we need a copy of the source bitmap, so that we don't
                '  end up using pixels that we have changed (and so filter based on changed pixels)
                ' So here is a copy of the input bitmap:
                Dim bSrc As Bitmap = b.Clone

                ' So we want Two lockbits now. We lock the source bits
                Dim bmSrc As BitmapData =
         bSrc.LockBits(New Rectangle(0, 0, bSrc.Width, bSrc.Height),
         ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)

                ' And we lock the target bits
                Dim bmData As BitmapData =
         b.LockBits(New Rectangle(0, 0, b.Width, b.Height),
         ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)

                ' We need the pointers to the start of both images data:
                Dim Scan0 As IntPtr = bmData.Scan0
                Dim SrcScan0 As IntPtr = bmSrc.Scan0

                ' We are storing all the pixels as int32s in arrays:
                Dim pixels(b.Width * b.Height - 1) As Integer
                Dim pixelsSrc(b.Width * b.Height - 1) As Integer

                ' Marshal copy grabs the pixels
                Marshal.Copy(Scan0, pixels, 0, pixels.Length)
                Marshal.Copy(SrcScan0, pixelsSrc, 0, pixelsSrc.Length)

                ' keep a running total (more later)...
                Dim total(3) As Single ' store sum of the pixels read from the source

                Dim index As Integer

                Dim gridValueDivmFactor As Single
                Dim ninthOfOffset As Single = m.Offset / 9

                ' We are manipulating a pixel based on all its surrounding pixels
                '  the pixels on the edges don't have all the surrounding pixels
                '  so we skip them by staring these loops at 1 and ending at blah -2
                For y As Integer = 1 To b.Height - 2
                    For x As Integer = 1 To b.Width - 2

                        ' We have defined a 3x3 grid and we apply it to the pixels
                        ' around the current one: (E is current pixel)
                        '
                        ' pixels         grid
                        ' A B C          1 2 3
                        ' D E F   with   4 5 6
                        ' G H I          7 8 9
                        '
                        ' (this is not matrix multiplication)
                        '
                        ' We get: (A*1) + (B*2) + (C*3) + (D*4) + (E*5) + (F*6) + (G*7) + (H*8) + (I*9)
                        ' we then divide this by m.factor and add m.offset...
                        '
                        ' e.g. with the starting grid:
                        ' 000
                        ' 010
                        ' 000 we get the result E = the value of the central pixel so no change to the image
                        '
                        ' Our For ... Next loop puts the current pixel at (x,y)
                        ' This means we need to get the pixels in the following positions:
                        ' (x-1,y-1) ( x ,y-1) (x+1,y-1)
                        ' (x-1, y ) ( x , y ) (x+1, y )
                        ' (x-1,y+1) ( x ,y+1) (x+1,y+1)
                        '

                        ' Another loop
                        ' This one loops through a 3x3 grid:
                        For yy As Integer = -1 To +1
                            For xx As Integer = -1 To +1

                                ' the central pixel(x,y) is in the array at this index:
                                ' (y * b.Width) pixels in the rows above + x pixels in the current row
                                ' (y * b.width) + x

                                ' the yyxx for next loop gives us:    (-1,-1)  (0,-1) (1,-1)
                                '                                     (-1,0)   (0,0)  (1,0)
                                '                                     (-1,1)   (0,1)  (1,1)
                                '
                                'so... the locaion of the pixels in the loop is (x+xx,y+yy)
                                'and the position in the array is:
                                '
                                index = ((y + yy) * b.Width) + x + xx

                                'we want to total the argb of the current pixel * the grid value for its position
                                'we'll do the factor here too, and add on 1/9 of offset
                                'trying to keep the number of calculations in the loops to a minimum

                                gridValueDivmFactor = m.grid(((yy + 1) * 3) + (xx + 1)) / m.Factor

                                'ignore alpha, it messes up with some filters. will just set it to 255

                                'total(0) += (((pixelsSrc(index) >> 24) And &HFF) * gridValueDivmFactor) + ninthOfOffset
                                total(1) += (((pixelsSrc(index) >> 16) And &HFF) * gridValueDivmFactor) + ninthOfOffset
                                total(2) += (((pixelsSrc(index) >> 8) And &HFF) * gridValueDivmFactor) + ninthOfOffset
                                total(3) += ((pixelsSrc(index) And &HFF) * gridValueDivmFactor) + ninthOfOffset

                            Next
                        Next

                        For i As Integer = 0 To 3
                            If total(i) > 255 Then total(i) = 255
                            If total(i) < 0 Then total(i) = 0
                        Next

                        'finally we set the pixel in the destination bitmap

                        pixels(y * b.Width + x) = (255 << 24) _
                      Or (Convert.ToInt32(total(1)) << 16) _
                      Or (Convert.ToInt32(total(2)) << 8) _
                      Or Convert.ToInt32(total(3))

                        'reset total for next pixel
                        Array.Clear(total, 0, 4)

                    Next
                Next
                Marshal.Copy(pixels, 0, Scan0, pixels.Length)
                'unlock both bitmaps
                b.UnlockBits(bmData)
                bSrc.UnlockBits(bmSrc)

                Return True

            End Function

        End Class

#End Region

        'Graphic
        ''' <summary>
        ''' Bitmap to Icon
        ''' </summary>
        ''' <param name="Bitmap"></param>
        ''' <returns></returns>
        <Runtime.CompilerServices.Extension()>
        Public Function BitmaptoIcon(ByVal Bitmap As Bitmap) As Icon

            Dim myIcon As Bitmap = Bitmap
            Return Icon.FromHandle(myIcon.GetHicon)

        End Function

#Region "Basic Filters"

        <Runtime.CompilerServices.Extension()>
        Public Function Prewitt(ByRef Source As Bitmap) As Bitmap

            Dim prewittResult As New Bitmap(Source)

            Dim prewittX, prewittY, magnitude As Integer

            Dim neighbourList As ArrayList = New ArrayList

            For y As Integer = 0 To Source.Height - 1
                For x As Integer = 0 To Source.Width - 1
                    neighbourList.Clear()

                    neighbourList = getThreeNeighbourList(Source, x, y)

                    prewittX = getPrewittValue(neighbourList, "X")
                    prewittY = getPrewittValue(neighbourList, "Y")

                    magnitude = Math.Sqrt(Math.Pow(prewittX, 2) + Math.Pow(prewittY, 2))

                    If magnitude > 255 Then
                        magnitude = 255
                    End If

                    prewittResult.SetPixel(x, y, Color.FromArgb(magnitude, magnitude, magnitude))
                Next x
            Next y

            Return prewittResult
        End Function

        <Runtime.CompilerServices.Extension()>
        Public Function Sobel(ByRef source As Bitmap) As Bitmap

            Dim sobelResult As New Bitmap(source)

            Dim sobelX, sobelY, magnitude As Integer

            Dim neighbourList As ArrayList = New ArrayList

            For y As Integer = 0 To source.Height - 1
                For x As Integer = 0 To source.Width - 1
                    neighbourList.Clear()

                    neighbourList = getThreeNeighbourList(source, x, y)

                    sobelX = getSobelValue(neighbourList, "X")
                    sobelY = getSobelValue(neighbourList, "Y")

                    magnitude = Math.Sqrt(Math.Pow(sobelX, 2) + Math.Pow(sobelY, 2))

                    If magnitude > 255 Then
                        magnitude = 255
                    End If

                    sobelResult.SetPixel(x, y, Color.FromArgb(magnitude, magnitude, magnitude))
                Next x
            Next y
            Return sobelResult
        End Function

        <Runtime.CompilerServices.Extension()>
        Private Function getThreeNeighbourList(ByVal source As Bitmap, ByVal xPos As Integer, ByVal yPos As Integer) As ArrayList
            Dim neighbourList As ArrayList = New ArrayList

            Dim xStart, xFinish, yStart, yFinish As Integer

            Dim pixel As Integer

            xStart = xPos - 1
            xFinish = xPos + 1

            yStart = yPos - 1
            yFinish = yPos + 1

            For y As Integer = yStart To yFinish
                For x As Integer = xStart To xFinish
                    If (x < 0) Or (y < 0) Or (x > source.Width - 1) Or (y > source.Height - 1) Then
                        neighbourList.Add(0)
                    Else
                        pixel = source.GetPixel(x, y).R

                        neighbourList.Add(pixel)
                    End If
                Next x
            Next y

            Return neighbourList
        End Function

        <Runtime.CompilerServices.Extension()>
        Private Function getSobelValue(ByVal neighbourList As ArrayList, ByVal maskType As String) As Integer
            Dim result As Integer = 0

            Dim sobelX As Integer(,) = {{-1, 0, 1}, {-2, 0, 2}, {-1, 0, 1}}
            Dim sobelY As Integer(,) = {{1, 2, 1}, {0, 0, 0}, {-1, -2, -1}}

            Dim count As Integer = 0

            If (maskType.Equals("X")) Then
                For y As Integer = 0 To 2
                    For x As Integer = 0 To 2
                        result = result + (sobelX(x, y) * Convert.ToInt16(neighbourList(count)))

                        count = count + 1
                    Next x
                Next y
            ElseIf (maskType.Equals("Y")) Then
                For y As Integer = 0 To 2
                    For x As Integer = 0 To 2
                        result = result + (sobelY(x, y) * Convert.ToInt16(neighbourList(count)))

                        count = count + 1
                    Next x
                Next y
            End If

            Return result
        End Function

        <Runtime.CompilerServices.Extension()>
        Private Function getPrewittValue(ByVal neighbourList As ArrayList, ByVal maskType As String) As Integer
            Dim result As Integer = 0

            Dim prewittX As Integer(,) = {{-1, 0, 1}, {-1, 0, 1}, {-1, 0, 1}}
            Dim prewittY As Integer(,) = {{-1, -1, -1}, {0, 0, 0}, {1, 1, 1}}

            Dim count As Integer = 0

            If (maskType.Equals("X")) Then
                For y As Integer = 0 To 2
                    For x As Integer = 0 To 2
                        result = result + (prewittX(x, y) * Convert.ToInt16(neighbourList(count)))

                        count = count + 1
                    Next x
                Next y
            ElseIf (maskType.Equals("Y")) Then
                For y As Integer = 0 To 2
                    For x As Integer = 0 To 2
                        result = result + (prewittY(x, y) * Convert.ToInt16(neighbourList(count)))

                        count = count + 1
                    Next x
                Next y
            End If

            Return result
        End Function

#End Region

    End Module

    Public Module Pic_SYS
        Public DetectionResults As DResults
        Public DEVLIST As List(Of String) = LoadDeviceList()
        Public FoundImages As New List(Of Bitmap)
        Private Detector As HaarDetector
        Private SelectedBitmap As Bitmap

        'CLOSE VIEW
        ''' <summary>
        ''' CLOSE CAMERA VIEW
        ''' </summary>
        ''' <param name="PB">PICTUREBOX</param>
        ''' <returns></returns>
        Public Function ClosePreviewWindow(ByRef PB As PictureBox) As PictureBox
            On Error Resume Next
            '
            ' Disconnect from device
            '
            SendMessage(hHwnd, WM_CAP_DRIVER_DISCONNECT, iDevice, 0)

            '
            ' close window
            '

            DestroyWindow(hHwnd)

            PB = SetPictureBox(PB)
            Return PB
        End Function

        ''' <summary>
        ''' Converts Format32bppArgb
        ''' </summary>
        ''' <param name="Bmp"></param>
        ''' <returns></returns>
        Public Function ConvertPixelformat(ByRef Bmp As Bitmap) As Bitmap
            ' Create a Bitmap object from a file.
            Dim myBitmap As New Bitmap(Bmp)
            ' Clone a portion of the Bitmap object.
            Dim cloneRect As New Rectangle(0, 0, Bmp.Width, Bmp.Height)
            Dim format As Drawing.Imaging.PixelFormat = Drawing.Imaging.PixelFormat.Format32bppArgb
            Dim cloneBitmap As Bitmap = myBitmap.Clone(cloneRect, format)
            Return cloneBitmap
        End Function

        ''' <summary>
        ''' Using Detector(Smile)
        ''' </summary>
        Public Function DetectEyes(ByRef pbox As PictureBox) As PictureBox
            Dim XMLDoc As New Xml.XmlDocument
            'Load
            XMLDoc.LoadXml(My.Resources.Front_eyes)
            Detector = New HaarDetector(XMLDoc)

            SelectedBitmap = New Bitmap(pbox.Image)
            'Detection Parameters
            Dim MaxDetCount As Integer = Integer.MaxValue
            Dim MinNRectCount As Integer = 0.42
            Dim FirstScale As Single = Detector.Size2Scale(100)
            Dim MaxScale As Single = Detector.Size2Scale(200)
            Dim ScaleMult As Single = 1.4
            Dim SizeMultForNesRectCon As Single = 0.3
            Dim SlidingRatio As Single = 0.1
            Dim Pen As New Pen(Brushes.Brown, 4)
            Dim DetectorParameters As New DetectionParams(MaxDetCount, MinNRectCount, FirstScale, MaxScale, ScaleMult, SizeMultForNesRectCon, SlidingRatio, Pen)
            ' Dim Bmp As Bitmap = ConvertPixelformat(SelectedBitmap.Clone)
            Dim Bmp As Bitmap = SelectedBitmap.Clone
            Dim Start As DateTime = Now
            Dim Results As DResults = Detector.DETECT(Bmp, DetectorParameters)
            Dim Elapsed As TimeSpan = Now - Start
            FoundImages.AddRange(Results.DetectedImages)
            DetectionResults = Results
            pbox.Image = Bmp
            pbox.Refresh()
            Return pbox
        End Function

        ''' <summary>
        ''' Using Detector(FACE)
        ''' </summary>
        Public Function Detectface(ByRef pbox As PictureBox) As PictureBox
            Dim XMLDoc As New Xml.XmlDocument
            'Load
            XMLDoc.LoadXml(My.Resources.FACE_MAIN)
            Detector = New HaarDetector(XMLDoc)
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
            FoundImages.AddRange(Results.DetectedImages)
            DetectionResults = Results
            pbox.Image = Bmp
            pbox.Refresh()
            Return pbox
        End Function

        Public Function DetectGlasses(ByRef pbox As PictureBox) As PictureBox
            Dim XMLDoc As New Xml.XmlDocument
            'Load
            XMLDoc.LoadXml(My.Resources.haarcascade_eye_tree_eyeglasses)
            Detector = New HaarDetector(XMLDoc)
            SelectedBitmap = New Bitmap(pbox.Image)
            'Detection Parameters
            Dim MaxDetCount As Integer = Integer.MaxValue
            Dim MinNRectCount As Integer = 0.6
            Dim FirstScale As Single = Detector.Size2Scale(100)
            Dim MaxScale As Single = Detector.Size2Scale(200)
            Dim ScaleMult As Single = 1.4
            Dim SizeMultForNesRectCon As Single = 0.3
            Dim SlidingRatio As Single = 0.1
            Dim Pen As New Pen(Brushes.OrangeRed, 4)
            Dim DetectorParameters As New DetectionParams(MaxDetCount, MinNRectCount, FirstScale, MaxScale, ScaleMult, SizeMultForNesRectCon, SlidingRatio, Pen)
            ' Dim Bmp As Bitmap = ConvertPixelformat(SelectedBitmap.Clone)
            Dim Bmp As Bitmap = SelectedBitmap.Clone
            Dim Start As DateTime = Now
            Dim Results As DResults = Detector.DETECT(Bmp, DetectorParameters)
            Dim Elapsed As TimeSpan = Now - Start
            FoundImages.AddRange(Results.DetectedImages)
            DetectionResults = Results
            pbox.Image = Bmp
            pbox.Refresh()
            Return pbox
        End Function

        Public Function DetectItemfromVideobox(ByRef PB As PictureBox, Item As String) As PictureBox
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
                PB = ClosePreviewWindow(PB)
                PB.Image = New Bitmap(bmap)
                PB.Refresh()
                Select Case Item
                    Case "Smile"
                        PB = DetectSmile(PB)
                        PB = DetectMouth(PB)
                    Case "Face"
                        PB = Detectface(PB)
                        PB.Refresh()
                    Case "All"
                        PB = Detectface(PB)
                        PB = DetectLeftEyes(PB)
                        PB = DetectRightEyes(PB)
                        PB = DetectSmile(PB)
                        PB = DetectMouth(PB)
                        PB = DetectGlasses(PB)
                        PB = DetectNose(PB)
                        PB = DetectLeftEar(PB)
                        PB = DetectRightEar(PB)
                    Case "Left Eye"
                        PB = DetectLeftEyes(PB)
                    Case "Right Eye"
                        PB = DetectRightEyes(PB)
                    Case "Eyes"
                        PB = DetectLeftEyes(PB)
                        PB = DetectRightEyes(PB)
                        PB = DetectEyes(PB)
                    Case "Mouth"
                        PB = DetectMouth(PB)
                        PB = DetectSmile(PB)'
                    Case "Glasses"
                        PB = DetectGlasses(PB)
                    Case "Nose"
                        PB = DetectNose(PB)
                    Case "Glasses"
                        PB = DetectGlasses(PB)
                    Case "Ears"
                        PB = DetectLeftEar(PB)
                        PB = DetectRightEar(PB)
                End Select
                data = Nothing
            Else
            End If
            Return PB
        End Function

        Public Function DetectLeftEar(ByRef pbox As PictureBox) As PictureBox
            Dim XMLDoc As New Xml.XmlDocument
            'Load
            XMLDoc.LoadXml(My.Resources.left_ear)
            Detector = New HaarDetector(XMLDoc)

            SelectedBitmap = New Bitmap(pbox.Image)
            'Detection Parameters
            Dim MaxDetCount As Integer = Integer.MaxValue
            Dim MinNRectCount As Integer = 0.56
            Dim FirstScale As Single = Detector.Size2Scale(100)
            Dim MaxScale As Single = Detector.Size2Scale(200)
            Dim ScaleMult As Single = 1.14
            Dim SizeMultForNesRectCon As Single = 0.3
            Dim SlidingRatio As Single = 0.1
            Dim Pen As New Pen(Brushes.Pink, 4)
            Dim DetectorParameters As New DetectionParams(MaxDetCount, MinNRectCount, FirstScale, MaxScale, ScaleMult, SizeMultForNesRectCon, SlidingRatio, Pen)
            ' Dim Bmp As Bitmap = ConvertPixelformat(SelectedBitmap.Clone)
            Dim Bmp As Bitmap = SelectedBitmap.Clone
            Dim Start As DateTime = Now
            Dim Results As DResults = Detector.DETECT(Bmp, DetectorParameters)
            Dim Elapsed As TimeSpan = Now - Start
            FoundImages.AddRange(Results.DetectedImages)
            DetectionResults = Results
            pbox.Image = Bmp
            pbox.Refresh()
            Return pbox
        End Function

        ''' <summary>
        ''' Using Detector(Smile)
        ''' </summary>
        Public Function DetectLeftEyes(ByRef pbox As PictureBox) As PictureBox
            Dim XMLDoc As New Xml.XmlDocument
            'Load
            XMLDoc.LoadXml(My.Resources.haarcascade_mcs_lefteye)
            Detector = New HaarDetector(XMLDoc)

            SelectedBitmap = New Bitmap(pbox.Image)
            'Detection Parameters
            Dim MaxDetCount As Integer = Integer.MaxValue
            Dim MinNRectCount As Integer = 0.42
            Dim FirstScale As Single = Detector.Size2Scale(100)
            Dim MaxScale As Single = Detector.Size2Scale(200)
            Dim ScaleMult As Single = 1.4
            Dim SizeMultForNesRectCon As Single = 0.3
            Dim SlidingRatio As Single = 0.1
            Dim Pen As New Pen(Brushes.LightBlue, 4)
            Dim DetectorParameters As New DetectionParams(MaxDetCount, MinNRectCount, FirstScale, MaxScale, ScaleMult, SizeMultForNesRectCon, SlidingRatio, Pen)
            ' Dim Bmp As Bitmap = ConvertPixelformat(SelectedBitmap.Clone)
            Dim Bmp As Bitmap = SelectedBitmap.Clone
            Dim Start As DateTime = Now
            Dim Results As DResults = Detector.DETECT(Bmp, DetectorParameters)
            Dim Elapsed As TimeSpan = Now - Start
            FoundImages.AddRange(Results.DetectedImages)
            DetectionResults = Results
            pbox.Image = Bmp
            pbox.Refresh()
            Return pbox
        End Function

        ''' <summary>
        ''' Using Detector(Smile)
        ''' </summary>
        Public Function DetectMouth(ByRef pbox As PictureBox) As PictureBox
            Dim XMLDoc As New Xml.XmlDocument
            'Load
            XMLDoc.LoadXml(My.Resources.mouth)
            Detector = New HaarDetector(XMLDoc)

            SelectedBitmap = New Bitmap(pbox.Image)
            'Detection Parameters
            Dim MaxDetCount As Integer = Integer.MaxValue
            Dim MinNRectCount As Integer = 0.56
            Dim FirstScale As Single = Detector.Size2Scale(100)
            Dim MaxScale As Single = Detector.Size2Scale(200)
            Dim ScaleMult As Single = 1.14
            Dim SizeMultForNesRectCon As Single = 0.3
            Dim SlidingRatio As Single = 0.1
            Dim Pen As New Pen(Brushes.Blue, 4)
            Dim DetectorParameters As New DetectionParams(MaxDetCount, MinNRectCount, FirstScale, MaxScale, ScaleMult, SizeMultForNesRectCon, SlidingRatio, Pen)
            ' Dim Bmp As Bitmap = ConvertPixelformat(SelectedBitmap.Clone)
            Dim Bmp As Bitmap = SelectedBitmap.Clone
            Dim Start As DateTime = Now
            Dim Results As DResults = Detector.DETECT(Bmp, DetectorParameters)
            Dim Elapsed As TimeSpan = Now - Start
            FoundImages.AddRange(Results.DetectedImages)
            DetectionResults = Results
            pbox.Image = Bmp
            pbox.Refresh()
            Return pbox
        End Function

        Public Function DetectNose(ByRef pbox As PictureBox) As PictureBox
            Dim XMLDoc As New Xml.XmlDocument
            'Load
            XMLDoc.LoadXml(My.Resources.nose)
            Detector = New HaarDetector(XMLDoc)

            SelectedBitmap = New Bitmap(pbox.Image)
            'Detection Parameters
            Dim MaxDetCount As Integer = Integer.MaxValue
            Dim MinNRectCount As Integer = 0.56
            Dim FirstScale As Single = Detector.Size2Scale(100)
            Dim MaxScale As Single = Detector.Size2Scale(200)
            Dim ScaleMult As Single = 1.14
            Dim SizeMultForNesRectCon As Single = 0.3
            Dim SlidingRatio As Single = 0.1
            Dim Pen As New Pen(Brushes.DarkGreen, 4)
            Dim DetectorParameters As New DetectionParams(MaxDetCount, MinNRectCount, FirstScale, MaxScale, ScaleMult, SizeMultForNesRectCon, SlidingRatio, Pen)
            ' Dim Bmp As Bitmap = ConvertPixelformat(SelectedBitmap.Clone)
            Dim Bmp As Bitmap = SelectedBitmap.Clone
            Dim Start As DateTime = Now
            Dim Results As DResults = Detector.DETECT(Bmp, DetectorParameters)
            Dim Elapsed As TimeSpan = Now - Start
            FoundImages.AddRange(Results.DetectedImages)
            DetectionResults = Results
            pbox.Image = Bmp
            pbox.Refresh()
            Return pbox
        End Function

        Public Function DetectRightEar(ByRef pbox As PictureBox) As PictureBox
            Dim XMLDoc As New Xml.XmlDocument
            'Load
            XMLDoc.LoadXml(My.Resources.right_ear)
            Detector = New HaarDetector(XMLDoc)

            SelectedBitmap = New Bitmap(pbox.Image)
            'Detection Parameters
            Dim MaxDetCount As Integer = Integer.MaxValue
            Dim MinNRectCount As Integer = 0.56
            Dim FirstScale As Single = Detector.Size2Scale(100)
            Dim MaxScale As Single = Detector.Size2Scale(200)
            Dim ScaleMult As Single = 1.14
            Dim SizeMultForNesRectCon As Single = 0.3
            Dim SlidingRatio As Single = 0.1
            Dim Pen As New Pen(Brushes.Pink, 4)
            Dim DetectorParameters As New DetectionParams(MaxDetCount, MinNRectCount, FirstScale, MaxScale, ScaleMult, SizeMultForNesRectCon, SlidingRatio, Pen)
            ' Dim Bmp As Bitmap = ConvertPixelformat(SelectedBitmap.Clone)
            Dim Bmp As Bitmap = SelectedBitmap.Clone
            Dim Start As DateTime = Now
            Dim Results As DResults = Detector.DETECT(Bmp, DetectorParameters)
            Dim Elapsed As TimeSpan = Now - Start
            FoundImages.AddRange(Results.DetectedImages)
            DetectionResults = Results
            pbox.Image = Bmp
            pbox.Refresh()
            Return pbox
        End Function

        Public Function DetectRightEyes(ByRef pbox As PictureBox) As PictureBox
            Dim XMLDoc As New Xml.XmlDocument
            'Load
            XMLDoc.LoadXml(My.Resources.haarcascade_mcs_righteye)
            Detector = New HaarDetector(XMLDoc)

            SelectedBitmap = New Bitmap(pbox.Image)
            'Detection Parameters
            Dim MaxDetCount As Integer = Integer.MaxValue
            Dim MinNRectCount As Integer = 0.42
            Dim FirstScale As Single = Detector.Size2Scale(100)
            Dim MaxScale As Single = Detector.Size2Scale(200)
            Dim ScaleMult As Single = 1.4
            Dim SizeMultForNesRectCon As Single = 0.3
            Dim SlidingRatio As Single = 0.1
            Dim Pen As New Pen(Brushes.LightBlue, 4)
            Dim DetectorParameters As New DetectionParams(MaxDetCount, MinNRectCount, FirstScale, MaxScale, ScaleMult, SizeMultForNesRectCon, SlidingRatio, Pen)
            ' Dim Bmp As Bitmap = ConvertPixelformat(SelectedBitmap.Clone)
            Dim Bmp As Bitmap = SelectedBitmap.Clone
            Dim Start As DateTime = Now
            Dim Results As DResults = Detector.DETECT(Bmp, DetectorParameters)
            Dim Elapsed As TimeSpan = Now - Start
            FoundImages.AddRange(Results.DetectedImages)
            DetectionResults = Results
            pbox.Image = Bmp
            pbox.Refresh()
            Return pbox
        End Function

        ''' <summary>
        ''' Using Detector(Smile)
        ''' </summary>
        Public Function DetectSmile(ByRef pbox As PictureBox) As PictureBox
            Dim XMLDoc As New Xml.XmlDocument
            'Load
            XMLDoc.LoadXml(My.Resources.mouth)
            Detector = New HaarDetector(XMLDoc)

            SelectedBitmap = New Bitmap(pbox.Image)
            'Detection Parameters
            Dim MaxDetCount As Integer = Integer.MaxValue
            Dim MinNRectCount As Integer = 0.56
            Dim FirstScale As Single = Detector.Size2Scale(100)
            Dim MaxScale As Single = Detector.Size2Scale(200)
            Dim ScaleMult As Single = 1.14
            Dim SizeMultForNesRectCon As Single = 0.3
            Dim SlidingRatio As Single = 0.1
            Dim Pen As New Pen(Brushes.Blue, 4)
            Dim DetectorParameters As New DetectionParams(MaxDetCount, MinNRectCount, FirstScale, MaxScale, ScaleMult, SizeMultForNesRectCon, SlidingRatio, Pen)
            ' Dim Bmp As Bitmap = ConvertPixelformat(SelectedBitmap.Clone)
            Dim Bmp As Bitmap = SelectedBitmap.Clone
            Dim Start As DateTime = Now
            Dim Results As DResults = Detector.DETECT(Bmp, DetectorParameters)
            Dim Elapsed As TimeSpan = Now - Start
            FoundImages.AddRange(Results.DetectedImages)
            DetectionResults = Results
            pbox.Image = Bmp
            pbox.Refresh()
            Return pbox
        End Function

        ''' <summary>
        ''' DETECT FACE IN BOX
        ''' </summary>
        ''' <param name="pb"></param>
        ''' <returns></returns>
        Public Function DO_DETECT(ByRef pb As PictureBox) As PictureBox
            'Load And Capture Device
            pb = Detectface(pb)
            If FoundImages.Count > 0 Then
                pb.Image = FoundImages(0)
                pb.SizeMode = PictureBoxSizeMode.StretchImage
            Else
                '  DO_DETECT
            End If
            Return pb
        End Function

        'Load Webcam Device List
        ''' <summary>
        ''' LOAD DEVICES
        ''' </summary>
        ''' <returns></returns>
        Public Function LoadDeviceList() As List(Of String)
            On Error Resume Next
            Dim Devlist As New List(Of String)
            Dim strName As String = Space(100)
            Dim strVer As String = Space(100)
            Dim bReturn As Boolean
            Dim x As Integer = 0

            Do
                bReturn = capGetDriverDescriptionA(x, strName, 100, strVer, 100)
                If bReturn Then
                    Devlist.Add(strName.Trim)

                End If

                x += 1
                Application.DoEvents()
            Loop Until bReturn = False
            Return Devlist
        End Function

        ''' <summary>
        ''' lOAD CAMERA INTO BOX
        ''' </summary>
        ''' <param name="PB"></param>
        ''' <returns></returns>
        Public Function LoadPicBox(ByRef PB As PictureBox) As PictureBox
            iDevice = 0
            PB = OpenPreviewWindow(SetPictureBox(PB), iDevice)
            Return PB
        End Function

        ''' <summary>
        ''' OPEN FILE INTO PICTURE BOX
        ''' </summary>
        ''' <param name="PB"></param>
        ''' <returns></returns>
        Public Function OpenFile(ByVal PB As PictureBox) As PictureBox
            Dim ofd As OpenFileDialog = New OpenFileDialog()
            ofd.Title = "Please select a image to open"
            ofd.Filter = ("Image Files | *.png; *.bmp; *.jpg; *.gif")
            ofd.ShowDialog()
            If ofd.FileName IsNot "" Then

                Dim img As Image = New Bitmap(ofd.FileName)
                PB.Image = img
            Else
            End If
            Return PB
        End Function

        'Open View
        ''' <summary>
        ''' OPEN CAMERA PREVIEW
        ''' </summary>
        ''' <param name="PB">PICTUREBOX </param>
        ''' <param name="iCameraDevice">DEVICE ID </param>
        ''' <returns></returns>
        Public Function OpenPreviewWindow(ByRef PB As PictureBox, ByRef iCameraDevice As Integer) As PictureBox
            On Error Resume Next

            Dim iHeight As Integer = PB.Height
            Dim iWidth As Integer = PB.Width

            '
            ' Open Preview window in picturebox
            '
            hHwnd = capCreateCaptureWindowA(iDevice, WS_VISIBLE Or WS_CHILD, 0, 0, 640,
            480, PB.Handle.ToInt32, 0)

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
                SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, PB.Width, PB.Height,
                    SWP_NOMOVE Or SWP_NOZORDER)
            Else
                '
                ' Error connecting to device close window
                '
                DestroyWindow(hHwnd)

                PB = SetPictureBox(PB)

            End If
            Return PB
        End Function

        Public Sub QuickSave(ByRef PB As PictureBox, ByRef Name As String)
            PB.Image.Save(Name, ImageFormat.Png)
        End Sub

        'RESET BOX
        ''' <summary>
        ''' Saves General file
        ''' </summary>
        ''' <param name="PB"></param>
        Public Sub SaveFile(ByRef PB As PictureBox)
            Dim sfd As SaveFileDialog = New SaveFileDialog()
            sfd.Filter = "Image File(*.bmp, *.jpg, *.png)| *.bmp;*.jpg;*.png"
            If sfd.ShowDialog = DialogResult.OK Then
                Select Case sfd.FileName
                    Case sfd.FileName.EndsWith("bmp")
                        PB.Image.Save(sfd.FileName, ImageFormat.Bmp)
                    Case sfd.FileName.EndsWith("png")
                        PB.Image.Save(sfd.FileName, ImageFormat.Png)
                    Case sfd.FileName.EndsWith("jpg")
                        PB.Image.Save(sfd.FileName, ImageFormat.Jpeg)
                End Select
                sfd.Dispose()
            End If
        End Sub

        ''' <summary>
        ''' Saves Higher Quality File
        ''' </summary>
        ''' <param name="PB"></param>
        Public Sub SavePhotoFile(ByRef PB As PictureBox)
            Dim tempFileName As String
            Dim svdlg As New SaveFileDialog()
            svdlg.Filter = "JPEG files (*.jpg)|*.jpg|All files (*.*)|*.*"
            svdlg.FilterIndex = 1
            svdlg.RestoreDirectory = True
            If svdlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
                tempFileName = svdlg.FileName           'check the file exist else save the cropped image
                Try
                    Dim img As Image = PB.Image

                    SavePhoto(img, tempFileName, 225)
                Catch exc As Exception
                    MsgBox("Error on Saving: " & exc.Message)
                End Try
            End If
        End Sub

        Public Function SetPictureBox(ByRef PB As PictureBox) As PictureBox
            PB.BackColor = Color.Black
            PB.BackgroundImageLayout = ImageLayout.Stretch
            PB.Image = Nothing
            PB.SizeMode = PictureBoxSizeMode.StretchImage
            PB.Refresh()
            Return PB
        End Function

        Private Sub SavePhoto(ByVal src As Image, ByVal dest As String, ByVal w As Integer)
            Try
                Dim imgTmp As System.Drawing.Image
                Dim imgFoto As System.Drawing.Bitmap

                imgTmp = src
                imgFoto = New System.Drawing.Bitmap(w, 225)
                Dim recDest As New Rectangle(0, 0, w, imgFoto.Height)
                Dim gphCrop As Graphics = Graphics.FromImage(imgFoto)
                gphCrop.SmoothingMode = SmoothingMode.HighQuality
                gphCrop.CompositingQuality = CompositingQuality.HighQuality
                gphCrop.InterpolationMode = InterpolationMode.High

                gphCrop.DrawImage(imgTmp, recDest, 0, 0, imgTmp.Width, imgTmp.Height, GraphicsUnit.Pixel)

                Dim myEncoder As System.Drawing.Imaging.Encoder
                Dim myEncoderParameter As System.Drawing.Imaging.EncoderParameter
                Dim myEncoderParameters As System.Drawing.Imaging.EncoderParameters

                Dim arrayICI() As System.Drawing.Imaging.ImageCodecInfo = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()
                Dim jpegICI As System.Drawing.Imaging.ImageCodecInfo = Nothing
                Dim x As Integer = 0
                For x = 0 To arrayICI.Length - 1
                    If (arrayICI(x).FormatDescription.Equals("JPEG")) Then
                        jpegICI = arrayICI(x)
                        Exit For
                    End If
                Next
                myEncoder = System.Drawing.Imaging.Encoder.Quality
                myEncoderParameters = New System.Drawing.Imaging.EncoderParameters(1)
                myEncoderParameter = New System.Drawing.Imaging.EncoderParameter(myEncoder, 60L)
                myEncoderParameters.Param(0) = myEncoderParameter
                imgFoto.Save(dest, jpegICI, myEncoderParameters)
                imgFoto.Dispose()
                imgTmp.Dispose()
            Catch ex As Exception

            End Try
        End Sub

    End Module
    Public Module modGraph

        Public Function DetectMovement() As Long
            On Error Resume Next

            Dim detectPicture As Bitmap
            Dim DetectData As IDataObject

            Dim X As Integer
            Dim Y As Integer
            Dim Tolerance As Integer
            Dim inter As Integer
            Dim r1, r2, g1, g2, b1, b2 As Integer
            Dim Color1, Color2 As Color

            SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0)
            DetectData = Clipboard.GetDataObject()
            detectPicture = CType(DetectData.GetData(GetType(System.Drawing.Bitmap)), Image)

            Tolerance = 15
            inter = 10
            X = 0 : Y = 0
            r1 = 0 : r2 = 0 : g1 = 0 : g2 = 0 : b1 = 0 : b2 = 0
            Color1 = Nothing : Color2 = Nothing

            Dim MValue(0 To detectPicture.Width, 0 To detectPicture.Height) As Boolean

            For X = 0 To detectPicture.Width / inter - 1
                For Y = 0 To detectPicture.Height / inter - 1
                    Color1 = detectPicture.GetPixel(X * inter, Y * inter)
                    r1 = Color1.R
                    g1 = Color1.G
                    b1 = Color1.B

                    r2 = Color2.R
                    g2 = Color2.G
                    b2 = Color2.B
                    If System.Math.Abs(r1 - r2) < Tolerance And System.Math.Abs(g1 - g2) < Tolerance And System.Math.Abs(b1 - b2) < Tolerance Then
                        'Remain
                        MValue(X, Y) = True
                    Else
                        'Moved
                        Color2 = detectPicture.GetPixel(X * inter, Y * inter)
                        MValue(X, Y) = False
                    End If
                Next Y
            Next X
            X = 0
            Y = 0

            Dim RealRi As Long = 0
            For X = 1 To detectPicture.Width / inter - 2
                For Y = 1 To detectPicture.Height / inter - 2
                    If MValue(X, Y + 1) = False Then
                        If MValue(X, Y - 1) = False Then
                            If MValue(X + 1, Y) = False Then
                                If MValue(X - 1, Y) = False Then
                                    RealRi = RealRi + 1
                                End If
                            End If
                        End If
                    End If
                Next
            Next

            Return RealRi
            detectPicture.Dispose()
        End Function

        Public Function GrayScalePicture() As Bitmap
            On Error Resume Next
            Dim bmGrayScale As Bitmap
            Dim GrayScaleData As IDataObject

            Dim X As Integer
            Dim Y As Integer
            Dim colorX As Integer

            SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0)
            GrayScaleData = Clipboard.GetDataObject()
            bmGrayScale = CType(GrayScaleData.GetData(GetType(System.Drawing.Bitmap)), Image)

            X = 0
            Y = 0

            For X = 0 To bmGrayScale.Width - 1
                For Y = 0 To bmGrayScale.Height - 1

                    colorX = (CInt(bmGrayScale.GetPixel(X, Y).R) +
                   bmGrayScale.GetPixel(X, Y).G +
                   bmGrayScale.GetPixel(X, Y).B) \ 3

                    bmGrayScale.SetPixel(X, Y, Color.FromArgb(colorX, colorX, colorX))
                Next Y
            Next X

            GrayScaleData = Nothing

            Return bmGrayScale
            bmGrayScale.Dispose()
        End Function

        Public Function InvertPicturesFromCapturedWindow() As Bitmap
            Dim InvertImages As Bitmap
            Dim InvertdataCopy As IDataObject

            Dim X As Integer
            Dim Y As Integer
            Dim r As Integer
            Dim g As Integer
            Dim b As Integer

            SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0)
            InvertdataCopy = Clipboard.GetDataObject()

            InvertImages = CType(InvertdataCopy.GetData(GetType(System.Drawing.Bitmap)), Image)

            X = 0
            Y = 0
            r = 0
            g = 0
            b = 0

            For X = 0 To InvertImages.Width - 1
                For Y = 0 To InvertImages.Height - 1
                    r = 255 - InvertImages.GetPixel(X, Y).R
                    g = 255 - InvertImages.GetPixel(X, Y).G
                    b = 255 - InvertImages.GetPixel(X, Y).B

                    InvertImages.SetPixel(X, Y, Color.FromArgb(r, g, b))
                Next Y
            Next X

            InvertdataCopy = Nothing

            Return InvertImages
            InvertImages.Dispose()
        End Function

        Public Function SephiaRed() As Bitmap
            On Error Resume Next
            Dim SephiaRedBmp As Bitmap
            Dim SephiaRedData As IDataObject

            Dim X As Integer
            Dim Y As Integer
            Dim r As Integer
            Dim g As Integer
            Dim b As Integer

            SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0)
            SephiaRedData = Clipboard.GetDataObject()

            SephiaRedBmp = CType(SephiaRedData.GetData(GetType(System.Drawing.Bitmap)), Image)

            X = 0
            Y = 0
            r = 0
            g = 0
            b = 0

            'Change This Value To Sephia Red
            For X = 0 To SephiaRedBmp.Width - 1
                For Y = 0 To SephiaRedBmp.Height - 1
                    r = 255 - SephiaRedBmp.GetPixel(X, Y).R
                    g = 255 - SephiaRedBmp.GetPixel(X, Y).G / 3
                    b = 255 - SephiaRedBmp.GetPixel(X, Y).B / 3

                    SephiaRedBmp.SetPixel(X, Y, Color.FromArgb(r, g, b))
                Next Y
            Next X

            SephiaRedData = Nothing

            Return SephiaRedBmp
            SephiaRedBmp.Dispose()
        End Function

    End Module

    ''' <summary>
    ''' Picture Matcher - Used to check files in folder match a single image
    ''' </summary>
    Public Class AI_Picture_Matcher

        ''' <summary>
        ''' can Used for holding image list
        ''' </summary>
        Public Images As List(Of Bitmap)

        ''' <summary>
        ''' Match report
        ''' </summary>
        Public Report As String = ""

        Private FoldersLoaded As Boolean = False
        Private iAllowedErrors As Integer = 333
        Private iDetectedErrors As Integer = 0
        Private iFiles As System.Collections.ObjectModel.ReadOnlyCollection(Of String)
        Private iFoundImage As Bitmap
        Private Picmatcher As New FindImageMatch

        Public Sub New()
            Images = New List(Of Bitmap)
        End Sub

        ''' <summary>
        ''' Allowed errors between images Default = 333
        ''' </summary>
        ''' <returns></returns>
        Public Property AllowedErrors As Integer
            Get
                Return iAllowedErrors
            End Get
            Set(value As Integer)
                iAllowedErrors = value
            End Set
        End Property

        ''' <summary>
        ''' Errors Detected between images
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property DetectedErrors As Integer
            Get
                Return iDetectedErrors
            End Get
        End Property

        ''' <summary>
        ''' Image detected by the class
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property FoundImage As Bitmap
            Get
                Return iFoundImage
            End Get

        End Property

        ''' <summary>
        ''' Gets files in folder provided (sets in class ifiles)
        ''' </summary>
        ''' <param name="Folder"></param>
        ''' <returns>number of files</returns>
        Public Function GetFiles(ByRef Folder As String) As Integer
            iFiles = My.Computer.FileSystem.GetFiles(Folder)
            If iFiles IsNot Nothing Then
                Return iFiles.Count
            Else
                Return 0
            End If
        End Function

        ''' <summary>
        ''' loads Path into classes
        ''' </summary>
        ''' <param name="Path"></param>
        ''' <returns></returns>
        Public Function LoadDatabaseFolder(ByRef Path As String) As String
            Dim Count As Integer = Picmatcher.GetFiles(Path)
            iFiles = GeturlsFilesinFolder(Path)
            FoldersLoaded = True

            Return "Files loaded :" & Count

        End Function

        ''' <summary>
        ''' Compares images based on
        ''' </summary>
        ''' <param name="PB_TARGET">Original PictureBox  with image</param>
        ''' <param name="PB_DETECT">Detected Imgae PictureBox</param>
        ''' <param name="Files">File Url list</param>
        ''' <returns>True if match found</returns>
        Public Function Search(ByRef PB_TARGET As PictureBox, ByRef PB_DETECT As PictureBox, ByRef Files As System.Collections.ObjectModel.ReadOnlyCollection(Of String)) As Boolean
            Dim Bmp1 As Bitmap
            Bmp1 = PB_TARGET.Image.Clone()
            Dim foundErrors As Integer = 0
            Dim found As Boolean = False
            Dim FoundImage As New Bitmap(Bmp1)
            found = Picmatcher.CompareImagesFiles(Bmp1, Files, iAllowedErrors, foundErrors, FoundImage)
            If found = True Then
                PB_DETECT.Image = FoundImage
                PB_DETECT.SizeMode = PictureBoxSizeMode.StretchImage
                Report = "Match Found"
            Else
                Report = "Match Not Found"
            End If
            iDetectedErrors = foundErrors
            iFoundImage = FoundImage
            Return found
        End Function

        ''' <summary>
        ''' Compares images based on files in class (FindImageMatcher)
        ''' </summary>
        ''' <param name="PB_TARGET">Original PictureBox  with image</param>
        ''' <param name="PB_DETECT">Detected Imgae PictureBox</param>
        ''' <returns>True if match found</returns>
        Public Function Search(ByRef PB_TARGET As PictureBox, ByRef PB_DETECT As PictureBox) As Boolean
            Dim Bmp1 As Bitmap
            Bmp1 = PB_TARGET.Image.Clone()
            Dim foundErrors As Integer = 0
            Dim found As Boolean = False
            Dim FoundImage As New Bitmap(Bmp1)
            found = Picmatcher.CompareImagesFiles(Bmp1, Picmatcher.Files, iAllowedErrors, foundErrors, FoundImage)
            If found = True Then
                PB_DETECT.Image = FoundImage
                PB_DETECT.SizeMode = PictureBoxSizeMode.StretchImage
                Report = "Match Found"
            Else
                Report = "Match Not Found"
            End If
            iDetectedErrors = foundErrors
            iFoundImage = FoundImage
            Return found
        End Function

        ''' <summary>
        ''' Compares images based on
        ''' </summary>
        ''' <param name="PB_TARGET">Original PictureBox  with image</param>
        ''' <param name="PB_DETECT">Detected Imgae PictureBox</param>
        ''' <param name="mImages">Images to compare</param>
        ''' <returns></returns>
        Public Function Search(ByRef PB_TARGET As PictureBox, ByRef PB_DETECT As PictureBox, mImages As List(Of Bitmap)) As Boolean
            Dim Bmp1 As Bitmap
            Bmp1 = PB_TARGET.Image.Clone()
            Dim foundErrors As Integer = 0
            Dim found As Boolean = False
            Dim FoundImage As New Bitmap(Bmp1)
            found = Picmatcher.CompareImageLst(Bmp1, mImages, iAllowedErrors, foundErrors)
            If found = True Then
                PB_DETECT.Image = FoundImage
                PB_DETECT.SizeMode = PictureBoxSizeMode.StretchImage
                Report = "Match Found"
            Else
                Report = "Match Not Found"
            End If
            iDetectedErrors = foundErrors
            iFoundImage = FoundImage
            Return found
        End Function

        ''' <summary>
        ''' Gets files in folder provided (sets in class ifiles)
        ''' </summary>
        ''' <param name="Folder"></param>
        ''' <returns>number of files</returns>
        Private Function GeturlsFilesinFolder(ByRef Folder As String) As System.Collections.ObjectModel.ReadOnlyCollection(Of String)
            Return My.Computer.FileSystem.GetFiles(Folder)
        End Function

        ''' <summary>
        ''' Image matcher
        ''' </summary>
        Public Class FindImageMatch

            ''' <summary>
            ''' list of fileUrls
            ''' </summary>
            Public Files As System.Collections.ObjectModel.ReadOnlyCollection(Of String)

            ''' <summary>
            ''' Compares Original image; With image collection  with error rate foundBMP is returned with mathced image True is returned is detected
            ''' </summary>
            ''' <param name="Bitmap1">Original image</param>
            ''' <param name="Files">Images</param>
            ''' <param name="AllowedErrors">Error rate</param>
            ''' <param name="FoundErrors">Error detected</param>
            ''' <returns>false if allowed errors are lower than actual errors</returns>
            Public Function CompareImageLst(ByRef Bitmap1 As Bitmap,
                             ByRef Files As List(Of Bitmap),
                            ByRef AllowedErrors As Integer, ByRef FoundErrors As Integer) As Boolean
                Dim Errors As Integer = 0
                Dim MatchFound As Boolean = False
                For Each item In Files
                    Errors = Comparison(Bitmap1, item)
                    If Errors < AllowedErrors Then
                        MatchFound = True
                        Exit For
                    End If
                Next
                FoundErrors = Errors
                Return MatchFound
            End Function

            ''' <summary>
            ''' Compares Original image; With files(urls) in folder with error rate foundBMP is returned with mathced image True is returned is detected
            ''' </summary>
            ''' <param name="Bitmap1">Original image</param>
            ''' <param name="Files">File collection</param>
            ''' <param name="AllowedErrors">Error threshold</param>
            ''' <param name="FoundErrors">detected Error</param>
            ''' <param name="FoundBMP">Detected Picture</param>
            ''' <returns>false if allowed errors are lower than actual errors</returns>
            Public Function CompareImagesFiles(ByRef Bitmap1 As Bitmap,
                             ByRef Files As System.Collections.ObjectModel.ReadOnlyCollection(Of String),
                            ByRef AllowedErrors As Integer, ByRef FoundErrors As Integer, ByRef FoundBMP As Bitmap) As Boolean
                On Error Resume Next
                Dim Errors As Integer = 0
                Dim MatchFound As Boolean = False

                For Each item In Files
                    Errors = Comparison(Bitmap1, System.Drawing.Bitmap.FromFile(item))
                    If Errors < AllowedErrors Then
                        MatchFound = True
                        FoundBMP = System.Drawing.Bitmap.FromFile(item)
                        Exit For
                    Else
                    End If
                Next
                FoundErrors = Errors
                Return MatchFound
            End Function

            ''' <summary>
            ''' Compare Images
            ''' </summary>
            ''' <param name="BITMAP1">Original Image</param>
            ''' <param name="BITMAP2">Comparison Image</param>
            ''' <returns></returns>
            Public Function Comparison(ByRef BITMAP1 As Bitmap, ByRef BITMAP2 As Bitmap) As Integer
                'COMPARACION DE PIXELES ENTRE PICTUREBOX1 Y PICTUREBOX2
                Dim ROJO As Integer = 0
                Dim VERDE As Integer = 0
                Dim AZUL As Integer = 0
                Dim X, Y As Integer
                For Y = 0 To BITMAP1.Height - 1 Step 10
                    For X = 0 To BITMAP1.Width - 1 Step 10
                        Dim MICOLOR1 As Color = BITMAP1.GetPixel(X, Y)
                        Dim MICOLOR2 As Color = BITMAP2.GetPixel(X, Y)

                        If Math.Abs(CInt(MICOLOR1.R) - CInt(MICOLOR2.R)) > 20 Then
                            ROJO = ROJO + 1

                        End If
                        If Math.Abs(CInt(MICOLOR1.G) - CInt(MICOLOR2.G)) > 20 Then
                            VERDE = VERDE + 1

                        End If
                        If Math.Abs(CInt(MICOLOR1.B) - CInt(MICOLOR2.B)) > 20 Then
                            AZUL = AZUL + 1

                        End If
                    Next
                Next
                Dim Differences As Integer = ROJO + VERDE + AZUL
                Return Differences
            End Function

            ''' <summary>
            ''' Get Files in directorys Using open Folder Dialog (sets in class)
            ''' </summary>
            ''' <returns>Number of files</returns>
            Public Function GetFiles() As Integer
                Dim Fdialog As New FolderBrowserDialog
                Fdialog.ShowDialog()
                Dim Folder As String = Fdialog.SelectedPath
                Files = My.Computer.FileSystem.GetFiles(Folder)
                If Files IsNot Nothing Then
                    Return Files.Count
                Else
                    Return 0
                End If
            End Function

            ''' <summary>
            ''' Gets files in folder provided (sets in class files)
            ''' </summary>
            ''' <param name="Folder"></param>
            ''' <returns>true / flase</returns>
            Public Function GetFiles(ByRef Folder As String) As Integer
                Files = My.Computer.FileSystem.GetFiles(Folder)
                If Files IsNot Nothing Then
                    Return Files.Count
                Else
                    Return 0
                End If
            End Function

        End Class

    End Class

    ''' <summary>
    ''' Basic Object detection Based on Haar cascade and Viola jones....
    ''' </summary>
    Public Class AI_Object_Detector

        'Propertys
        ''' <summary>
        ''' Names of devices available;
        ''' When selecting a device the corresponding record id is required 0 based
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property DeviceList As List(Of String) = LoadDeviceList()

        Private mDetectionResults As DResults

        ''' <summary>
        ''' Results from detection process
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property DetectionResults As DResults
            Get
                Return mDetectionResults
            End Get
        End Property

        Private mFoundImages As List(Of Bitmap)

        ''' <summary>
        ''' Accumilated detected images
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property FoundImages As List(Of Bitmap)
            Get
                Return mFoundImages
            End Get

        End Property

        'Reset Box
        ''' <summary>
        ''' Reset the picturebox
        ''' </summary>
        ''' <param name="PB"></param>
        ''' <returns></returns>
        Public Function SetPictureBox(ByRef PB As PictureBox) As PictureBox
            PB.BackColor = Color.Black
            PB.BackgroundImageLayout = ImageLayout.Stretch
            PB.Image = Nothing
            PB.SizeMode = PictureBoxSizeMode.StretchImage
            PB.Refresh()
            Return PB
        End Function

        'New
        ''' <summary>
        ''' Initiates devices
        ''' </summary>
        Public Sub New()
            'Initialize basic list for availability
            mFoundImages = New List(Of Bitmap)
        End Sub

        'Detect Known Items()
        ''' <summary>
        ''' Detects Image in Face video box
        ''' </summary>
        ''' <param name="PB_View">Picturebox With video</param>
        ''' <param name="Item">Part to detect</param>
        ''' <param name="ResultsReport">Report</param>
        ''' <returns></returns>
        Public Function ReportDetectItem(ByRef PB_View As PictureBox, ByRef Item As String, ByRef ResultsReport As String) As PictureBox
            ResultsReport = ""
            Select Case Item
                Case "All"
                    PB_View = DetectItemfromVideobox(PB_View, "Face")
                    ResultsReport = "Face Search =" & DetectionResults.SearchedSubRegionCount & ": subregions were searched and " & DetectionResults.NOfObjects & ": object(s) were detected: "
                    PB_View = DetectItemfromVideobox(PB_View, "Eyes")
                    ResultsReport &= "Eyes Search =" & DetectionResults.SearchedSubRegionCount & ": subregions were searched and " & DetectionResults.NOfObjects & ": object(s) were detected: "
                Case "Face"
                    PB_View = DetectItemfromVideobox(PB_View, "Face")
                    ResultsReport = "Face Search =" & DetectionResults.SearchedSubRegionCount & ": subregions were searched and " & DetectionResults.NOfObjects & ": object(s) were detected: "
                Case "Eyes"
                    PB_View = DetectItemfromVideobox(PB_View, "Eyes")
                    ResultsReport = "Eyes Search =" & DetectionResults.SearchedSubRegionCount & ": subregions were searched and " & DetectionResults.NOfObjects & ": object(s) were detected: "
            End Select

            Return PB_View
        End Function

        'detect
        ''' <summary>
        ''' detects item from video box
        ''' </summary>
        ''' <param name="PB">Picturebox containing video</param>
        ''' <param name="Item">item to be detected</param>
        ''' <returns></returns>
        Public Function DetectItemfromVideobox(ByRef PB As PictureBox, Item As String) As PictureBox
            On Error Resume Next
            Dim captured As Boolean = False

            'GetSnapshotImagefrom video into box
            PB = CapturePictureFromVideoBox(PB, captured)
            'Detect Item
            If captured = True Then
                PB = DetectItemfromPictureBox(PB, Item)
            Else
            End If
            Return PB
        End Function

        ''' <summary>
        ''' detects item from picturebox
        ''' </summary>
        ''' <param name="PB">Contianing Picture to be identified</param>
        ''' <param name="Item">item to be detected</param>
        ''' <returns></returns>
        Public Function DetectItemfromPictureBox(ByRef PB As PictureBox, Item As String) As PictureBox
            On Error Resume Next
            'Select detection item
            Select Case Item
                Case "All"
                    PB = DetectObject(PB, False, My.Resources.FACE_MAIN)
                    PB.Refresh()
                    PB = DetectObject(PB, False, My.Resources.Front_eyes)
                    PB.Refresh()
                    PB = DetectObject(PB, True, My.Resources.haarcascade_mcs_lefteye)
                    PB.Refresh()
                    PB = DetectObject(PB, True, My.Resources.haarcascade_mcs_righteye)
                    PB.Refresh()
                    PB = DetectObject(PB, True, My.Resources.nose)
                    PB.Refresh()
                    PB = DetectObject(PB, True, My.Resources.mouth)
                    PB.Refresh()
                    PB = DetectObject(PB, True, My.Resources.left_ear)
                    PB.Refresh()
                    PB = DetectObject(PB, True, My.Resources.right_ear)
                    PB.Refresh()
                Case "Face"
                    PB = DetectObject(PB, True, My.Resources.FACE_MAIN)
                    PB.Refresh()
                Case "eyes"
                    'Both?
                    PB = DetectObject(PB, True, My.Resources.Front_eyes)
                    'Left
                    PB = DetectObject(PB, True, My.Resources.haarcascade_mcs_lefteye)
                    PB.Refresh()
                    'Right
                    PB = DetectObject(PB, True, My.Resources.haarcascade_mcs_righteye)
                    PB.Refresh()
                    'Both?
                    PB = DetectObject(PB, True, My.Resources.haarcascade_eye_tree_eyeglasses)
                    PB.Refresh()
                Case "Right Eye"
                    PB = DetectObject(PB, True, My.Resources.haarcascade_mcs_righteye)
                    PB.Refresh()
                Case "Left Eye"
                    'Left
                    PB = DetectObject(PB, True, My.Resources.haarcascade_mcs_lefteye)
                    PB.Refresh()
                Case "Glasses"
                    'Both?
                    PB = DetectObject(PB, True, My.Resources.haarcascade_eye_tree_eyeglasses)
                    PB.Refresh()
                Case "Nose"
                    PB = DetectObject(PB, True, My.Resources.nose)
                    PB.Refresh()
                Case "Mouth"
                    PB = DetectObject(PB, True, My.Resources.mouth)
                    PB.Refresh()
                Case "Ears"
                    PB = DetectObject(PB, True, My.Resources.left_ear)
                    PB.Refresh()
                    PB = DetectObject(PB, True, My.Resources.right_ear)
                    PB.Refresh()
                Case "Left Ear"
                    PB = DetectObject(PB, True, My.Resources.left_ear)
                    PB.Refresh()
                Case "Right Ear"
                    PB = DetectObject(PB, True, My.Resources.right_ear)
                    PB.Refresh()
            End Select
            Return PB
        End Function

        'Captures image from Picturebox (When Video is active)
        ''' <summary>
        ''' Given The box is in video preview mode ;  A snapshot is taken
        ''' </summary>
        ''' <param name="PB">Returns image captured to Picture box</param>
        ''' <param name="Captured">returns true if snap taken</param>
        ''' <returns></returns>
        Public Function CapturePictureFromVideoBox(ByRef PB As PictureBox, Optional Captured As Boolean = False) As PictureBox
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
                PB = ClosePreviewWindow(PB)
                PB.Image = New Bitmap(bmap)
                PB.Refresh()
                Captured = True
            Else
                Captured = False
            End If
            Return PB
        End Function

        'Open View
        ''' <summary>
        ''' OPEN CAMERA PREVIEW
        ''' </summary>
        ''' <param name="PB">PICTUREBOX </param>
        ''' <param name="iCameraDevice">DEVICE ID </param>
        ''' <returns></returns>
        Public Function OpenPreviewWindow(ByRef PB As PictureBox, ByRef iCameraDevice As Integer) As PictureBox
            On Error Resume Next

            Dim iHeight As Integer = PB.Height
            Dim iWidth As Integer = PB.Width

            '
            ' Open Preview window in picturebox
            '
            hHwnd = capCreateCaptureWindowA(iDevice, WS_VISIBLE Or WS_CHILD, 0, 0, 640,
            480, PB.Handle.ToInt32, 0)

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
                SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, PB.Width, PB.Height,
                    SWP_NOMOVE Or SWP_NOZORDER)
            Else
                '
                ' Error connecting to device close window
                '
                DestroyWindow(hHwnd)

                PB = SetPictureBox(PB)

            End If
            Return PB
        End Function

        'CLOSE VIEW
        ''' <summary>
        ''' CLOSE CAMERA VIEW
        ''' </summary>
        ''' <param name="PB">PICTUREBOX</param>
        ''' <returns></returns>
        Public Function ClosePreviewWindow(ByRef PB As PictureBox) As PictureBox
            On Error Resume Next
            '
            ' Disconnect from device
            '
            SendMessage(hHwnd, WM_CAP_DRIVER_DISCONNECT, iDevice, 0)

            '
            ' close window
            '

            DestroyWindow(hHwnd)

            PB = SetPictureBox(PB)
            Return PB
        End Function

        'Object Detections
        ''' <summary>
        ''' Detects face in -picture box -
        ''' </summary>
        ''' <param name="pbox">Picturebox with image</param>
        ''' <param name="Mrk">If true Marks a Rectangle at location</param>
        ''' <returns></returns>
        Public Function DetectObject(ByRef pbox As PictureBox, Mrk As Boolean, ByRef CascadeFle As String) As PictureBox
            Dim Detector As HaarDetector
            Dim XMLDoc As New Xml.XmlDocument
            Dim SelectedBitmap As Bitmap
            'Load
            XMLDoc.LoadXml(CascadeFle)
            Detector = New HaarDetector(XMLDoc)
            SelectedBitmap = New Bitmap(pbox.Image)
            'Detection Parameters
            Dim MaxDetCount As Integer = Integer.MaxValue
            Dim MinNRectCount As Integer = 0
            Dim FirstScale As Single = Detector.Size2Scale(100)
            Dim MaxScale As Single = Detector.Size2Scale(200)
            Dim ScaleMult As Single = 1.1
            Dim SizeMultForNesRectCon As Single = 0.3
            Dim SlidingRatio As Single = 0.1
            If Mrk = True Then
                Dim Pen As New Pen(Brushes.Red, 4)
                Dim DetectorParameters As New DetectionParams(MaxDetCount, MinNRectCount, FirstScale, MaxScale, ScaleMult, SizeMultForNesRectCon, SlidingRatio, Pen)
                Dim Bmp As Bitmap = SelectedBitmap.Clone
                Dim Start As DateTime = Now
                Dim Results As DResults = Detector.DETECT(Bmp, DetectorParameters)
                Dim Elapsed As TimeSpan = Now - Start
                mFoundImages.AddRange(Results.DetectedImages)
                mDetectionResults = Results
                pbox.Image = Bmp
            Else
                Dim DetectorParameters As New DetectionParams(MaxDetCount, MinNRectCount, FirstScale, MaxScale, ScaleMult, SizeMultForNesRectCon, SlidingRatio, Nothing)
                Dim Bmp As Bitmap = SelectedBitmap.Clone
                Dim Start As DateTime = Now
                Dim Results As DResults = Detector.DETECT(Bmp, DetectorParameters)
                Dim Elapsed As TimeSpan = Now - Start
                mFoundImages.AddRange(Results.DetectedImages)
                mDetectionResults = Results
                pbox.Image = Bmp
            End If
            pbox.Refresh()
            Return pbox
        End Function

        'haar Cascade
        ''' <summary>
        ''' HAAR CASCADE DECTECTOR
        ''' VB.Net implementation of Viola-Jones Object Detection algorithm
        ''' Huseyin Atasoy
        ''' huseyin@atasoyweb.net
        ''' www.atasoyweb.net
        ''' July 2012
        ''' derived (2015)
        ''' </summary>
        Class ObjectDetector

            Friend Class Parser

                ''' <summary>
                '''--------------------------------------------------------------------------
                ''' HaarCascadeClassifier > Parser.vb
                '''--------------------------------------------------------------------------
                ''' VB.Net implementation of Viola-Jones Object Detection algorithm
                ''' Huseyin Atasoy
                ''' huseyin@atasoyweb.net
                ''' www.atasoyweb.net
                ''' July 2012
                '''--------------------------------------------------------------------------
                ''' Copyright 2012 Huseyin Atasoy
                '''
                ''' Licensed under the Apache License, Version 2.0 (the "License");
                ''' you may not use this file except in compliance with the License.
                ''' You may obtain a copy of the License at
                '''
                '''     http://www.apache.org/licenses/LICENSE-2.0
                '''
                ''' Unless required by applicable law or agreed to in writing, software
                ''' distributed under the License is distributed on an "AS IS" BASIS,
                ''' WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
                ''' See the License for the specific language governing permissions and
                ''' limitations under the License.
                '''--------------------------------------------------------------------------
                ''' </summary>
                ''' <param name="StringVal"> Sample: "20 20"</param>
                ''' <returns></returns>
                Public Shared Function ParseSize(ByVal StringVal As String) As Size
                    Dim Slices() As String = StringVal.Trim.Split(" "c)
                    Return New Size(Convert.ToInt32(Slices(0).Trim), Convert.ToInt32(Slices(1).Trim))
                End Function

                ''' <summary>
                '''  Sample: "0.0337941907346249"
                ''' </summary>
                ''' <param name="StringVal"> Sample: "0.0337941907346249"</param>
                ''' <returns></returns>
                Public Shared Function ParseSingle(ByVal StringVal As String) As Single
                    Return (Single.Parse(ReplaceDecimalSeperator(StringVal.Trim)))
                End Function

                ' Sample: "1"
                Public Shared Function ParseInt(ByVal StringVal As String) As Integer
                    Return Integer.Parse(StringVal.Trim)
                End Function

                ' Sample: "3 7 14 4 -1."
                Public Shared Function ParseFeatureRect(ByVal StringVal As String) As FeatureRect
                    Dim Slices() As String = StringVal.Trim.Split(" "c)
                    Dim FR As New FeatureRect With {
                        .Rectangle = New Rectangle(Convert.ToInt32(Slices(0).Trim), Convert.ToInt32(Slices(1).Trim), Convert.ToInt32(Slices(2).Trim), Convert.ToInt32(Slices(3).Trim))
                    }

                    Dim Weight As String = Slices(4)
                    If Weight.EndsWith(".") Then
                        Weight = Weight.Replace(".", "")
                    Else
                        Weight = ReplaceDecimalSeperator(Weight)
                    End If
                    FR.Weight = Convert.ToInt32(Weight.Trim)
                    Return FR
                End Function

                Public Shared NumberDecimalSeparator As String = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator

                Public Shared Function ReplaceDecimalSeperator(ByVal Val As String) As String
                    Return Val.Replace(".", NumberDecimalSeparator)
                End Function

            End Class

            ''' <summary>
            '''--------------------------------------------------------------------------
            ''' HaarCascadeClassifier > HaarDetector.vb
            '''--------------------------------------------------------------------------
            ''' VB.Net implementation of Viola-Jones Object Detection algorithm
            ''' Huseyin Atasoy
            ''' huseyin@atasoyweb.net
            ''' www.atasoyweb.net
            ''' July 2012
            '''--------------------------------------------------------------------------
            ''' Copyright 2012 Huseyin Atasoy
            '''
            ''' Licensed under the Apache License, Version 2.0 (the "License");
            ''' you may not use this file except in compliance with the License.
            ''' You may obtain a copy of the License at
            '''
            '''     http://www.apache.org/licenses/LICENSE-2.0
            '''
            ''' Unless required by applicable law or agreed to in writing, software
            ''' distributed under the License is distributed on an "AS IS" BASIS,
            ''' WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
            ''' See the License for the specific language governing permissions and
            ''' limitations under the License.
            '''--------------------------------------------------------------------------
            ''' </summary>
            Public Class HaarDetector

                Public Structure DResults

                    Public Sub New(ByVal SearchedSubRegionCount As Integer, ByVal NOfObjects As Integer, ByVal DetectedOLocs() As Rectangle)
                        Me.SearchedSubRegionCount = SearchedSubRegionCount  ' Total number of searched subregions
                        Me.NOfObjects = NOfObjects                          ' Number of objects
                        Me.DetectedOLocs = DetectedOLocs                    ' Detected objects' locations
                        Me.DetectedImages = New List(Of Bitmap) 'Images
                    End Sub

                    Public SearchedSubRegionCount As Integer
                    Public NOfObjects As Integer
                    Public DetectedOLocs() As Rectangle
                    Public DetectedImages As List(Of Bitmap)
                End Structure

                Public Structure DetectionParams

                    ''' <summary>
                    ''' The maximum number of objects to be detected.
                    ''' When the number of detected objects
                    ''' (including detection of the same object more than once in this number) reaches this value,
                    ''' the processes are stopped and the results are returned.
                    ''' This Int32.MaxValue value can be sent if no limit is desired.
                    ''' </summary>
                    Public MaxDetCount As Integer               ' Detector stops searching when number of detected objects reachs this value.

                    ''' <summary>
                    ''' The minimum number of neighboring detections required to accept that the image contains the object.
                    ''' (The same object can be detected more than once by the search window,
                    ''' which is sized with different scales in the same area.)
                    ''' If the value Is large, the objects may Not be detected. 0 Or 1 Is recommended.
                    ''' </summary>
                    Public MinNRectCount As Integer             ' Minimum neighbour areas must be passed the detector to verify existence of searched object.

                    ''' <summary>
                    ''' The first coefficient to scale the search window. T
                    ''' his number is multiplied by the dimensions of the images used in training,
                    ''' and the product determines the initial dimensions of the multiplication search window.
                    ''' A small value should be selected if it is desired to detect very small objects in the image.
                    ''' However, choosing a smaller value decreases the speed in a big way.
                    ''' To assign to this parameter, the library's Size2Scale () function can be used,
                    ''' which allows specifying the minimum object size in pixels.
                    ''' </summary>
                    Public FirstScale As Single                 ' First scaler of searching window.

                    ''' <summary>
                    ''' When the coefficient that scales the search window is enlarged and this value is exceeded,
                    ''' the operations are stopped and the results are returned.
                    ''' Limits the size of objects that can be detected in the image.
                    ''' It is recommended to use the value obtained by sending approximately 2/3 of the image width for Size2Scale () function.
                    ''' </summary>
                    Public MaxScale As Single                   ' Maximum scaler of searching window.

                    ''' <summary>
                    ''' Coefficient that multiplies the scale of the search window by a factor of. With this coefficient, scales between FirstScale and MaxScale are traversed.
                    ''' Selecting the value decreases the speed to increase the number of sub regions to be searched. But at the same time it weakens the likelihood of objects jumping. If the objects to be found are too small, it is suggested to be around 1.1, otherwise a slightly larger value.
                    ''' </summary>
                    Public ScaleMult As Single                  ' ScaleMult (Scale Multiplier) and current scaler are multiplied to make an increment on current scaler.

                    ''' <summary>
                    ''' It is used to determine the rectangles that are nested at the end of detection. The coefficient multiplies the dimensions of one of the rectangles to determine the maximum distance that will allow the vertices to be accepted inside. If the distance between the corners of the rectangles is less than the calculated maximum distance, then the rectangles are considered inside.
                    ''' Minor values ​​cause multiple nested locations to be returned for the same object. It is recommended to give around 0.3.
                    ''' </summary>
                    Public SizeMultForNesRectCon As Single      ' SizeMultForNesRectCon (Size Multiplier For Nested Object Control) and size of every rectangle are multiplied separately to obtain maximum acceptable horizontal and vertical distances between current rectangle and others. Maximum distances are used to check if rectangles are nested or not.

                    ''' <summary>
                    ''' The rate that determines how many times the search window will scroll itself in each step of the image.
                    ''' </summary>
                    Public SlidingRatio As Single               ' The ratio of step size to scaled searching window width. (CurrentStepSize = ScaledWindowWidth * SlidingRatio)

                    Public Pen As Pen                           ' A "Pen" object to draw rectangles on given bitmap. If it is given as null, nothing will be drawn.

                    Public Sub New(ByVal MaxDetCount As Integer, ByVal MinNRectCount As Integer, ByVal FirstScale As Single, ByVal MaxScale As Single, ByVal ScaleMult As Single, ByVal SizeMultForNesRectCon As Single, ByVal SlidingRatio As Single, ByVal Pen As Pen)
                        Me.MaxDetCount = MaxDetCount
                        Me.MinNRectCount = MinNRectCount
                        Me.FirstScale = FirstScale
                        Me.MaxScale = MaxScale
                        Me.ScaleMult = ScaleMult
                        Me.SizeMultForNesRectCon = SizeMultForNesRectCon
                        Me.SlidingRatio = SlidingRatio
                        Me.Pen = Pen
                    End Sub

                End Structure

                Private HCascade As HaarCascade

                ' Creates a HaarDetector object, parsing opencv xml storage file of which full path is given.
                Public Sub New(ByVal OpenCVXmlStorage As String)
                    HCascade = New HaarCascade(OpenCVXmlStorage)
                End Sub

                ' Creates a HaarDetector object, parsing given xml document. This constructor can be used for loading embedded cascades.
                Public Sub New(ByVal XmlDoc As XmlDocument)
                    HCascade = New HaarCascade(XmlDoc)
                End Sub

                Public Sub New(ByVal SHape As ObjectDetector.Shapes)
                    Select Case SHape
                        Case Shapes.FACE_MAIN
                            HCascade = New HaarCascade(My.Resources.FACE_MAIN)
                    End Select
                End Sub

                ' Calculate ratio of given size to unscaled searching window size. It can be used to calculate first and max scales of searching window.
                Public Function Size2Scale(ByVal Size As Integer) As Single
                    Return Convert.ToSingle(Math.Min(Size / HCascade.WindowSize.Width, Size / HCascade.WindowSize.Height))
                End Function

                ' For 8 bits per pixel images
                Private Sub CalculateCumSums8bpp(ByRef CumSum(,) As Integer, ByRef CumSum2(,) As Long, ByRef BitmapData As BitmapData, ByRef Width As Integer, ByRef Height As Integer)
                    Dim AbsOfStride As Integer = FastAbs(BitmapData.Stride)
                    Dim ExtraBPerLine As Integer = AbsOfStride - Width
                    Dim ScanWidthWP As Integer = AbsOfStride - ExtraBPerLine ' Scan width without padding
                    Dim BmpDataPtr As IntPtr = BitmapData.Scan0

                    Dim ByteCount As Integer = AbsOfStride * Height
                    Dim Colors(ByteCount - 1) As Byte
                    Marshal.Copy(BmpDataPtr, Colors, 0, ByteCount)

                    Dim CurRowSum As Integer
                    Dim CurRowSum2 As Long
                    Dim k As Integer = Width  ' image2D(0,1) = image1D(width)   (Skip first row)
                    Dim i As Integer = Width + ExtraBPerLine
                    Dim PosControl As Integer = 0 ' We will start right after first extra bytes
                    While i < ByteCount
                        Dim GrayVal As Integer = Colors(i)
                        i = i + 1

                        PosControl = PosControl + 1
                        If PosControl = ScanWidthWP Then ' If current position is equal to ScanWidthWP now, skip bytes inserted for padding the scan line and zero PosControl for future controls.
                            PosControl = 0
                            i = i + ExtraBPerLine
                        End If

                        Dim CurRow As Integer = Convert.ToInt32(Math.Floor(k / Width))
                        Dim CurCol As Integer = k Mod Width
                        If CurCol = 0 Then
                            CurRowSum = 0
                            CurRowSum2 = 0
                        End If
                        CurRowSum = CurRowSum + GrayVal
                        CurRowSum2 = CurRowSum2 + GrayVal * GrayVal
                        CumSum(CurCol, CurRow) = CumSum(CurCol, CurRow - 1) + CurRowSum
                        CumSum2(CurCol, CurRow) = CumSum2(CurCol, CurRow - 1) + CurRowSum2

                        k = k + 1
                    End While
                End Sub

                ''' <summary>
                '''     For 24 bits per pixel images
                ''' </summary>
                ''' <param name="CumSum"></param>
                ''' <param name="CumSum2"></param>
                ''' <param name="BitmapData"></param>
                ''' <param name="Width"></param>
                ''' <param name="Height"></param>
                Private Sub CalculateCumSums24bpp(ByRef CumSum(,) As Integer, ByRef CumSum2(,) As Long, ByRef BitmapData As BitmapData, ByRef Width As Integer, ByRef Height As Integer)
                    Dim AbsOfStride As Integer = FastAbs(BitmapData.Stride)
                    Dim ExtraBPerLine As Integer = AbsOfStride - Width * 3
                    Dim ScanWidthWP As Integer = AbsOfStride - ExtraBPerLine ' Scan width without padding
                    Dim BmpDataPtr As IntPtr = BitmapData.Scan0

                    Dim ByteCount As Integer = AbsOfStride * Height
                    Dim Colors(ByteCount - 1) As Byte
                    Marshal.Copy(BmpDataPtr, Colors, 0, ByteCount)

                    Dim CurRowSum As Integer
                    Dim CurRowSum2 As Long
                    Dim k As Integer = Width  ' image2D(0,1) = image1D(width)   (Skip first row)
                    Dim i As Integer = 3 * Width + ExtraBPerLine '8bppimage2D(0,1) = 8bppimage1D(3 * Width)
                    Dim PosControl As Integer = 0 ' We will start right after first extra bytes
                    While i < ByteCount
                        ' For conversation from rgb to gray.
                        Dim GrayVal As Single = Colors(i) ' Blue
                        GrayVal = 0.114F * GrayVal
                        i = i + 1

                        GrayVal = GrayVal + 0.587F * Colors(i) ' Green
                        i = i + 1

                        GrayVal = GrayVal + 0.299F * Colors(i) ' Red
                        i = i + 1

                        PosControl = PosControl + 3
                        If PosControl = ScanWidthWP Then ' If current position is equal to ScanWidthWP now, skip bytes inserted for padding the scan line and zero PosControl for future controls.
                            PosControl = 0
                            i = i + ExtraBPerLine
                        End If

                        Dim CurRow As Integer = Convert.ToInt32(Math.Floor(k / Width))
                        Dim CurCol As Integer = k Mod Width
                        If CurCol = 0 Then
                            CurRowSum = 0
                            CurRowSum2 = 0
                        End If
                        CurRowSum = Convert.ToInt32(CurRowSum + GrayVal)
                        CurRowSum2 = Convert.ToInt32(CurRowSum2 + GrayVal * GrayVal)
                        CumSum(CurCol, CurRow) = CumSum(CurCol, CurRow - 1) + CurRowSum
                        CumSum2(CurCol, CurRow) = CumSum2(CurCol, CurRow - 1) + CurRowSum2

                        k = k + 1
                    End While
                End Sub

                ''' <summary>
                '''       For 32 bits per pixel images (for both premultiplied and not premultiplied by alpha values.) Alpha channel is ignored.
                ''' </summary>
                ''' <param name="CumSum"></param>
                ''' <param name="CumSum2"></param>
                ''' <param name="BitmapData"></param>
                ''' <param name="Width"></param>
                ''' <param name="Height"></param>
                Private Sub CalculateCumSums32bpp(ByRef CumSum(,) As Integer, ByRef CumSum2(,) As Long, ByRef BitmapData As BitmapData, ByRef Width As Integer, ByRef Height As Integer)
                    Dim ScanWidthWP As Integer = Width * 4 ' 32bpp formatted bitmaps never contains padding bytes.
                    Dim BmpDataPtr As IntPtr = BitmapData.Scan0

                    Dim ByteCount As Integer = ScanWidthWP * Height
                    Dim Colors(ByteCount - 1) As Byte
                    Marshal.Copy(BmpDataPtr, Colors, 0, ByteCount)

                    Dim CurRowSum As Integer
                    Dim CurRowSum2 As Long
                    Dim k As Integer = Width  ' image2D(0,1) = image1D(width)   (Skip first row)
                    Dim i As Integer = ScanWidthWP '8bppimage2D(0,1) = 8bppimage1D(3 * Width)
                    While i < ByteCount
                        ' For conversation from rgb to gray.
                        Dim GrayVal As Single = Colors(i) ' Blue
                        GrayVal = 0.114F * GrayVal
                        i = i + 1

                        GrayVal = GrayVal + 0.587F * Colors(i) ' Green
                        i = i + 1

                        GrayVal = GrayVal + 0.299F * Colors(i) ' Red
                        i = i + 2 ' Skip alpha channel

                        Dim CurRow As Integer = Convert.ToInt32(Math.Floor(k / Width))
                        Dim CurCol As Integer = k Mod Width
                        If CurCol = 0 Then
                            CurRowSum = 0
                            CurRowSum2 = 0
                        End If
                        CurRowSum = Convert.ToInt32(CurRowSum + GrayVal)
                        CurRowSum2 = Convert.ToInt32(CurRowSum2 + GrayVal * GrayVal)
                        CumSum(CurCol, CurRow) = CumSum(CurCol, CurRow - 1) + CurRowSum
                        CumSum2(CurCol, CurRow) = CumSum2(CurCol, CurRow - 1) + CurRowSum2

                        k = k + 1
                    End While
                End Sub

                Private Function ConvertPixelformat(ByRef Bmp As Bitmap) As Bitmap

                    ' Create a Bitmap object from a file.
                    Dim myBitmap As New Bitmap(Bmp)

                    ' Clone a portion of the Bitmap object.
                    Dim cloneRect As New Rectangle(0, 0, Bmp.Width, Bmp.Height)
                    Dim format As Drawing.Imaging.PixelFormat = Drawing.Imaging.PixelFormat.Format24bppRgb
                    Dim cloneBitmap As Bitmap = myBitmap.Clone(cloneRect, format)

                    Return cloneBitmap
                End Function

                ''' <summary>
                '''         Detects objects on given Bitmap. Only 32bppPArgb, 32bppArgb, 24bppRgb and 8bppIndexed formats are supported for now.
                ''' </summary>
                ''' <param name="Bitmap"></param>
                ''' <param name="Parameters"></param>
                ''' <returns></returns>
                Public Function DETECT(ByRef Bitmap As Bitmap, ByVal Parameters As DetectionParams) As DResults
                    Dim Width As Integer = Bitmap.Width
                    Dim Height As Integer = Bitmap.Height
                    'Test
                    Bitmap = ConvertPixelformat(Bitmap)
                    Dim CumSum(Width - 1, Height - 1) As Integer ' Cumulative sums of every pixel.
                    Dim CumSum2(Width - 1, Height - 1) As Long   ' Squares of sums of every pixel. These will be used for standart deviation calculations.

                    Dim BitmapData As BitmapData = Bitmap.LockBits(New Rectangle(0, 0, Width, Height), ImageLockMode.ReadOnly, Bitmap.PixelFormat)
                    If Bitmap.PixelFormat = PixelFormat.Format24bppRgb Then
                        CalculateCumSums24bpp(CumSum, CumSum2, BitmapData, Width, Height)
                    ElseIf Bitmap.PixelFormat = PixelFormat.Format8bppIndexed Then
                        CalculateCumSums8bpp(CumSum, CumSum2, BitmapData, Width, Height)
                        Parameters.Pen = Nothing ' Can't draw anything on an 8 bit indexed image.
                    ElseIf Bitmap.PixelFormat = PixelFormat.Format32bppPArgb OrElse Bitmap.PixelFormat = PixelFormat.Format32bppArgb Then
                        CalculateCumSums32bpp(CumSum, CumSum2, BitmapData, Width, Height)
                    Else
                        MsgBox(New Exception(Bitmap.PixelFormat.ToString() & " is not supported.").ToString)
                        Bitmap.UnlockBits(BitmapData)
                        Return Nothing
                    End If
                    Bitmap.UnlockBits(BitmapData)

                    Dim DetectedOLocs As New List(Of Rectangle) ' Passed regions will be stored here.
                    Dim NOfObjects As Integer = 0               ' Number of detected objects
                    Dim SearchedSubRegionCount As Integer = 0   ' Searched subregion count

                    Dim Scaler As Single = Parameters.FirstScale
                    While Scaler < Parameters.MaxScale ' For all scales between first scale and max scale.
                        Dim WinWidth As Integer = Convert.ToInt32(HCascade.WindowSize.Width * Scaler) ' Scaled searching window width
                        Dim WinHeight As Integer = Convert.ToInt32(HCascade.WindowSize.Height * Scaler) ' Scaled searching window height
                        Dim InvArea As Single = Convert.ToSingle(1 / (WinWidth * WinHeight)) ' Inverse of the area

                        Dim StepSize As Integer = Convert.ToInt32(WinWidth * Parameters.SlidingRatio) ' Current step size
                        For i = 0 To Width - WinWidth - 1 Step StepSize
                            For j = 0 To Height - WinHeight - 1 Step StepSize
                                SearchedSubRegionCount = SearchedSubRegionCount + 1

                                ' Integral image of current region:
                                Dim IImg As Integer = CumSum(i + WinWidth, j + WinHeight) - CumSum(i, j + WinHeight) - CumSum(i + WinWidth, j) + CumSum(i, j)
                                Dim IImg2 As Long = CumSum2(i + WinWidth, j + WinHeight) - CumSum2(i, j + WinHeight) - CumSum2(i + WinWidth, j) + CumSum2(i, j)
                                Dim Mean As Single = IImg * InvArea
                                Dim Variance As Single = IImg2 * InvArea - Mean * Mean
                                Dim Normalizer As Single ' Will normalize thresholds.
                                If Variance > 1 Then
                                    Normalizer = Convert.ToSingle(Math.Sqrt(Variance)) ' Standart deviation
                                Else
                                    Normalizer = 1
                                End If

                                Dim Passed As Boolean = True
                                For Each Stage As HaarCascade.Stage In HCascade.Stages
                                    Dim StageVal As Single = 0
                                    For Each Tree As HaarCascade.Tree In Stage.Trees
                                        Dim CurNode As HaarCascade.Node = Tree.Nodes(0)
                                        While True
                                            Dim RectSum As Integer = 0
                                            For Each FeatureRect As HaarCascade.FeatureRect In CurNode.FeatureRects
                                                ' Resize current feature rectangle to fit it in scaled searching window:
                                                Dim Rx1 As Integer = Convert.ToInt32(i + Math.Floor(FeatureRect.Rectangle.X * Scaler))
                                                Dim Ry1 As Integer = Convert.ToInt32(j + Math.Floor(FeatureRect.Rectangle.Y * Scaler))
                                                Dim Rx2 As Integer = Convert.ToInt32(Rx1 + Math.Floor(FeatureRect.Rectangle.Width * Scaler))
                                                Dim Ry2 As Integer = Convert.ToInt32(Ry1 + Math.Floor(FeatureRect.Rectangle.Height * Scaler))
                                                ' Integral image of the region bordered by the current feature ractangle (sum of all pixels in it):
                                                RectSum = Convert.ToInt32(RectSum + (CumSum(Rx2, Ry2) - CumSum(Rx1, Ry2) - CumSum(Rx2, Ry1) + CumSum(Rx1, Ry1)) * FeatureRect.Weight)
                                            Next

                                            Dim AvgRectSum As Single = RectSum * InvArea
                                            If AvgRectSum < CurNode.Threshold * Normalizer Then
                                                If CurNode.HasLNode Then
                                                    CurNode = Tree.Nodes(CurNode.LeftNode) ' Go to the left node
                                                    Continue While
                                                Else
                                                    StageVal = StageVal + CurNode.LeftVal
                                                    Exit While ' It is a leaf, exit.
                                                End If
                                            Else
                                                If CurNode.HasRNode Then
                                                    CurNode = Tree.Nodes(CurNode.RightNode) ' Go to the right node
                                                    Continue While
                                                Else
                                                    StageVal = StageVal + CurNode.RightVal
                                                    Exit While ' It is a leaf, exit.
                                                End If
                                            End If
                                        End While
                                    Next
                                    If StageVal < Stage.Threshold Then
                                        Passed = False
                                        Exit For ' Don't waste time with trying to pass it from other stages.
                                    End If
                                Next
                                If Passed Then ' If current region was passed from all stages
                                    DetectedOLocs.Add(New Rectangle(i, j, WinWidth, WinHeight))
                                    NOfObjects += 1
                                    If NOfObjects = Parameters.MaxDetCount Then ' Are they enough? (note that, nested rectangles are not eliminated yet)
                                        Exit While
                                    End If
                                End If
                            Next
                        Next
                        Scaler *= Parameters.ScaleMult
                    End While

                    Dim Results As DResults
                    If DetectedOLocs.Count > 0 Then
                        Results = EliminateNestedRects(DetectedOLocs.ToArray, NOfObjects, Parameters.MinNRectCount + 1, Parameters.SizeMultForNesRectCon)
                        If Parameters.Pen IsNot Nothing Then ' If a pen was given, mark objects using given pen

                            Results = GetImages(Bitmap, Results)

                            Dim G As Graphics = Graphics.FromImage(Bitmap)

                            G.DrawRectangles(Parameters.Pen, Results.DetectedOLocs)
                            G.Dispose()
                        End If
                    Else
                        Results = New DResults(0, 0, Nothing)
                    End If

                    Results.SearchedSubRegionCount = SearchedSubRegionCount
                    Return Results
                End Function

                Private Function GetImages(ByRef bmp As Bitmap, ByRef Results As DResults) As DResults
                    Results.DetectedImages = New List(Of Bitmap)
                    For Each item In Results.DetectedOLocs
                        Dim G As Graphics = Graphics.FromImage(bmp)
                        G.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                        G.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
                        G.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                        G.DrawImage(bmp, 0, 0, item, GraphicsUnit.Pixel)
                        Dim bit As New Bitmap(item.Width, item.Height)
                        Dim GR As Graphics = Graphics.FromImage(bit)
                        GR.DrawImage(bmp, 0, 0, item, GraphicsUnit.Pixel)
                        Results.DetectedImages.Add(bit)
                    Next
                    Return Results
                End Function

                ''' <summary>
                '''  ' Every detected object must be marked only with one rectangle. Others must be eliminated:
                ''' </summary>
                ''' <param name="DetectedOLocs"></param>
                ''' <param name="NOfObjects"></param>
                ''' <param name="MinNRectCount"></param>
                ''' <param name="SizeMultForNesRectCon"></param>
                ''' <returns></returns>
                Private Function EliminateNestedRects(ByVal DetectedOLocs() As Rectangle, ByVal NOfObjects As Integer, ByVal MinNRectCount As Integer, ByRef SizeMultForNesRectCon As Single) As DResults
                    Dim NestedRectsCount(NOfObjects - 1) As Integer
                    Dim AvgRects(NOfObjects - 1) As Rectangle
                    For i As Integer = 0 To NOfObjects - 1
                        Dim Current As Rectangle = DetectedOLocs(i)
                        AvgRects(i) = Current
                        For j As Integer = 0 To NOfObjects - 1
                            ' Check if these 2 rectangles are nested
                            If i <> j AndAlso DetectedOLocs(j).Width > 0 AndAlso AreTheyNested(Current, DetectedOLocs(j), SizeMultForNesRectCon) Then
                                NestedRectsCount(i) += 1
                                AvgRects(i).X += DetectedOLocs(j).X
                                AvgRects(i).Y += DetectedOLocs(j).Y
                                AvgRects(i).Width += DetectedOLocs(j).Width
                                AvgRects(i).Height += DetectedOLocs(j).Height
                                DetectedOLocs(j).Width = 0 ' Zero it to eliminate.
                            End If
                        Next
                    Next

                    Dim k As Integer = 0
                    Dim NewRects(NOfObjects - 1) As Rectangle
                    For i As Integer = 0 To NOfObjects - 1
                        If DetectedOLocs(i).Width > 0 Then ' Rectangles that are not eliminated
                            Dim NOfNRects As Integer = NestedRectsCount(i) + 1 '+1 is itself. It is required, becuse we will calculate average of them.
                            If NOfNRects >= MinNRectCount Then
                                ' Average rectangle:
                                NewRects(k) = New Rectangle(Convert.ToInt32(AvgRects(i).X / NOfNRects), Convert.ToInt32(AvgRects(i).Y / NOfNRects), Convert.ToInt32(AvgRects(i).Width / NOfNRects), Convert.ToInt32(AvgRects(i).Height / NOfNRects))
                            End If
                            k += 1
                        End If
                    Next

                    Dim Results As New DResults
                    ReDim Results.DetectedOLocs(k - 1)
                    Array.Copy(NewRects, Results.DetectedOLocs, k)
                    Results.NOfObjects = k

                    Return Results
                End Function

                Private Function AreTheyNested(ByRef Rectangle1 As Rectangle, ByRef Rectangle2 As Rectangle, ByRef SizeMultForNesRectCon As Single) As Boolean
                    ' Maybe they are not fully nested, we must be tolerant:
                    Dim MaxHorDist As Integer = Convert.ToInt32(SizeMultForNesRectCon * Rectangle1.Width)
                    Dim MaxVertDist As Integer = Convert.ToInt32(SizeMultForNesRectCon * Rectangle1.Height)
                    Return If((FastAbs(Rectangle2.X - Rectangle1.X) < MaxHorDist AndAlso FastAbs(Rectangle2.Right - Rectangle1.Right) < MaxHorDist) AndAlso (FastAbs(Rectangle2.Y - Rectangle1.Y) < MaxVertDist AndAlso FastAbs(Rectangle2.Bottom - Rectangle1.Bottom) < MaxVertDist), True, False)
                End Function

                ' Math.Abs() makes type conversations before and after the operation. It is waste of time...
                Private Function FastAbs(ByVal Int As Integer) As Integer
                    If Int < 0 Then
                        Return -Int
                    Else
                        Return Int
                    End If
                End Function

            End Class

            Friend Class HaarCascade

                '--------------------------------------------------------------------------
                ' HaarCascadeClassifier > HaarCascade.vb
                '--------------------------------------------------------------------------
                ' VB.Net implementation of Viola-Jones Object Detection algorithm
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

                ' Feature rectangle
                Public Structure FeatureRect
                    Public Rectangle As Rectangle
                    Public Weight As Single
                End Structure

                ' Binary tree nodes
                Public Structure Node
                    Public FeatureRects As List(Of FeatureRect) ' Feature rectangles
                    Public Threshold As Single                  ' Threshold for determining what to select (left value/right value) or where to go on binary tree (left or right)
                    Public LeftVal As Single                    ' Left value
                    Public RightVal As Single                   ' Right value
                    Public HasLNode As Boolean                  ' Does this node have a left node? (Checking a boolean takes less time then to control if left node is null or not.)
                    Public LeftNode As Integer                  ' Left node. If current node doesn't have a left node, this will be null.
                    Public HasRNode As Boolean                  ' Does this node have a right node?
                    Public RightNode As Integer                 ' Right node. If current node doesn't have a right node, this will be null.
                End Structure

                ' Will be used as a binary tree
                Public Structure Tree
                    Public Nodes As List(Of Node)               ' Each tree can have max 3 nodes. First one is the current and others are nodes of the current.
                End Structure

                ' Stages
                Public Structure Stage
                    Public Trees As List(Of Tree)               ' Trees in the stage.
                    Public Threshold As Single                  ' Threshold of the stage.
                End Structure

                Public Stages As List(Of Stage)                 ' Stages of the cascade
                Public WindowSize As Size                       ' Original (unscaled) size of searching window

                ' Loads cascade from xml file at given path and creates a HaarCascade object using its content
                Public Sub New(ByVal OpenCVXmlStorageFile As String)
                    Dim XMLDoc As New XmlDocument()
                    XMLDoc.Load(OpenCVXmlStorageFile)
                    Load(XMLDoc)
                End Sub

                ' If you embed the xml file, you can create an XmlDocument using embedded file and then use this constructor to create new HaarCascade.
                Public Sub New(ByVal XmlDoc As XmlDocument)
                    Load(XmlDoc)
                End Sub

                ' Parses given xml document and loads parsed data
                Private Sub Load(ByVal XmlDoc As XmlDocument)
                    For Each RootNode As XmlNode In XmlDoc.ChildNodes
                        If RootNode.NodeType = XmlNodeType.Comment Then Continue For

                        For Each CascadeNode As XmlNode In RootNode
                            ' All haar cascades start with this expression: <haarcascade_frontalface_alt type_id="opencv-haar-classifier">
                            If CascadeNode.NodeType = XmlNodeType.Comment OrElse CascadeNode.Attributes("type_id") Is Nothing OrElse Not CascadeNode.Attributes("type_id").Value.Equals("opencv-haar-classifier") Then Continue For

                            Stages = New List(Of Stage)

                            For Each CascadeChild As XmlNode In CascadeNode
                                If CascadeChild.NodeType = XmlNodeType.Comment Then Continue For

                                If CascadeChild.Name.Equals("size") Then
                                    WindowSize = Parser.ParseSize(CascadeChild.InnerText)
                                ElseIf CascadeChild.Name.Equals("stages") Then
                                    For Each StageNode As XmlNode In CascadeChild
                                        If StageNode.NodeType = XmlNodeType.Comment Then Continue For

                                        Dim NewStage As New Stage
                                        NewStage.Trees = New List(Of Tree)
                                        For Each StageChild As XmlNode In StageNode
                                            If StageChild.NodeType = XmlNodeType.Comment Then Continue For

                                            If StageChild.Name.Equals("stage_threshold") Then
                                                NewStage.Threshold = Parser.ParseSingle(StageChild.InnerText)
                                            ElseIf StageChild.Name.Equals("trees") Then
                                                For Each Tree As XmlNode In StageChild
                                                    If Tree.NodeType = XmlNodeType.Comment Then Continue For

                                                    Dim NewTree As New Tree
                                                    NewTree.Nodes = New List(Of Node)

                                                    For Each TreeNode As XmlNode In Tree
                                                        If TreeNode.NodeType = XmlNodeType.Comment Then Continue For

                                                        Dim NewNode As New Node
                                                        NewNode.FeatureRects = New List(Of FeatureRect)

                                                        For Each TreeNodeChild As XmlNode In TreeNode
                                                            If TreeNodeChild.NodeType = XmlNodeType.Comment Then Continue For

                                                            If TreeNodeChild.Name.Equals("feature") Then
                                                                For Each TNCChild As XmlNode In TreeNodeChild
                                                                    If TNCChild.NodeType = XmlNodeType.Comment Then Continue For

                                                                    If TNCChild.Name.Equals("rects") Then
                                                                        For Each Rect As XmlNode In TNCChild
                                                                            If Rect.NodeType = XmlNodeType.Comment Then Continue For

                                                                            NewNode.FeatureRects.Add(Parser.ParseFeatureRect(Rect.InnerText))
                                                                        Next
                                                                    ElseIf TNCChild.Name.Equals("tilted") Then
                                                                        If Parser.ParseInt(TNCChild.InnerText) = 1 Then
                                                                            ' Not supported for now. Will be implemented in future releases.
                                                                            Throw New Exception("Tilted features are not supported yet!")
                                                                            Return
                                                                        End If
                                                                    End If
                                                                Next
                                                            ElseIf TreeNodeChild.Name.Equals("threshold") Then
                                                                NewNode.Threshold = Parser.ParseSingle(TreeNodeChild.InnerText)
                                                            ElseIf TreeNodeChild.Name.Equals("left_val") Then
                                                                NewNode.LeftVal = Parser.ParseSingle(TreeNodeChild.InnerText)
                                                                NewNode.HasLNode = False
                                                            ElseIf TreeNodeChild.Name.Equals("right_val") Then
                                                                NewNode.RightVal = Parser.ParseSingle(TreeNodeChild.InnerText)
                                                                NewNode.HasRNode = False
                                                            ElseIf TreeNodeChild.Name.Equals("left_node") Then
                                                                NewNode.LeftNode = Parser.ParseInt(TreeNodeChild.InnerText)
                                                                NewNode.HasLNode = True
                                                            ElseIf TreeNodeChild.Name.Equals("right_node") Then
                                                                NewNode.RightNode = Parser.ParseInt(TreeNodeChild.InnerText)
                                                                NewNode.HasRNode = True
                                                            End If
                                                        Next
                                                        NewTree.Nodes.Add(NewNode)
                                                    Next

                                                    NewStage.Trees.Add(NewTree)
                                                Next
                                            End If
                                        Next
                                        Stages.Add(NewStage)
                                    Next
                                End If
                            Next

                            Return
                        Next
                    Next

                    '   Throw New Exception("Given XML document does not contain a haar cascade in supported format.")
                End Sub

            End Class

            ''' <summary>
            ''' CurrentParameters Variable (used to send to Detector)
            ''' </summary>
            Public DetectionParameters As New Parameters

            ''' <summary>
            ''' Detector Parameters
            ''' </summary>
            Public Structure Parameters
                Dim MaxDetCount As Integer

                ''' <summary>
                ''' Mininmun neighbour Rectanglecount
                ''' </summary>
                Dim MinNRectCount As Integer

                ''' <summary>
                ''' Min size of searched object:
                ''' </summary>
                Dim FirstScale As Single

                ''' <summary>
                ''' Max size of searched object:
                ''' </summary>
                Dim MaxScale As Single

                ''' <summary>
                ''' Scale multiplier:
                ''' </summary>
                Dim ScaleMult As Single

                ''' <summary>
                ''' Nested rectangle size multiplier:
                ''' </summary>
                Dim SizeMultForNesRectCon As Single

                ''' <summary>
                ''' Sliding Ratio:
                ''' </summary>
                Dim SlidingRatio As Single

                Dim PenLineWidth As Integer
            End Structure

#Region "Known Objects"

            ''' <summary>
            ''' Currently held Classified objects Trained by OPENCV (internal Objects)
            ''' </summary>
            Public Enum Shapes
                FACE_MAIN
                EYES
                MOUTH
                NOSE
                EARS
                Left_EAR
                Right_EAR
                Left_EYE
                Right_EYE
            End Enum

            ''' <summary>
            ''' attempts to detect object
            ''' </summary>
            ''' <param name="SelectedBitmap">Image</param>
            ''' <param name="mParams">Detection Parameters</param>
            ''' <param name="Shape">object to detect</param>
            ''' <param name="mReport">Report of output findiongs</param>
            ''' <returns></returns>
            Public Function DetectShape(ByRef SelectedBitmap As Bitmap, ByRef mParams As Parameters, ByRef Shape As Shapes, ByRef mReport As String) As Bitmap
                Dim Detector As HaarDetector
                Dim Start As DateTime = Now
                Dim XMLDoc As New Xml.XmlDocument
                Select Case Shape
                    Case Shapes.FACE_MAIN
                        XMLDoc.LoadXml(My.Resources.FACE_MAIN)
                    Case Shapes.EYES
                        XMLDoc.LoadXml(My.Resources.Front_eyes)
                    Case Shapes.MOUTH
                        XMLDoc.LoadXml(My.Resources.mouth)
                    Case Shapes.NOSE
                        XMLDoc.LoadXml(My.Resources.nose)
                    Case Shapes.Left_EAR
                        XMLDoc.LoadXml(My.Resources.left_ear)
                    Case Shapes.Right_EAR
                        XMLDoc.LoadXml(My.Resources.right_ear)
                    Case Shapes.Left_EYE
                        XMLDoc.LoadXml(My.Resources.haarcascade_mcs_lefteye)
                    Case Shapes.Right_EYE
                        XMLDoc.LoadXml(My.Resources.haarcascade_mcs_righteye)
                    Case "Glasses"
                        XMLDoc.LoadXml(My.Resources.haarcascade_eye_tree_eyeglasses)
                End Select

                Detector = New HaarDetector(XMLDoc)
                Dim MaxDetCount As Integer = mParams.MaxDetCount
                Dim MinNRectCount As Integer = mParams.MinNRectCount
                Dim FirstScale As Single = Detector.Size2Scale(mParams.FirstScale)
                Dim MaxScale As Single = Detector.Size2Scale(mParams.FirstScale)
                Dim ScaleMult As Single = mParams.ScaleMult
                Dim SizeMultForNesRectCon As Single = mParams.SizeMultForNesRectCon
                Dim SlidingRatio As Single = mParams.SlidingRatio
                Dim Pen As New Pen(Brushes.Red, mParams.PenLineWidth)

                Dim DetectorParameters As New DetectionParams(MaxDetCount, MinNRectCount, FirstScale, MaxScale, ScaleMult, SizeMultForNesRectCon, SlidingRatio, Pen)

                Dim Bmp As Bitmap = SelectedBitmap.Clone

                Dim Results As DResults = Detector.DETECT(Bmp, DetectorParameters)
                Dim Elapsed As TimeSpan = Now - Start
                mReport = Results.SearchedSubRegionCount & " subregions were searched and " & Results.NOfObjects & " object(s) were detected in " & Math.Round(Elapsed.TotalMilliseconds, 3).ToString & " milliseconds."
                Return Bmp
            End Function

#End Region

            Private Function GetFaceParams(ByRef Detector As HaarDetector) As Parameters
                Dim p As New Parameters With {
                    .MinNRectCount = Integer.MaxValue,
                    .FirstScale = Detector.Size2Scale(100),
                    .MaxScale = Detector.Size2Scale(200),
                    .ScaleMult = 1.1,
                    .SizeMultForNesRectCon = 0.3,
                    .SlidingRatio = 0.2,
                    .PenLineWidth = 4
                }
            End Function

        End Class

        'Load Webcam Device List
        ''' <summary>
        ''' LOAD DEVICES as list of Names
        ''' To use devices when opening a preview window select ID number From 0+
        ''' </summary>
        ''' <returns></returns>
        Public Function LoadDeviceList() As List(Of String)
            On Error Resume Next
            Dim Devlist As New List(Of String)
            Dim strName As String = Space(100)
            Dim strVer As String = Space(100)
            Dim bReturn As Boolean
            Dim x As Integer = 0
            Do
                bReturn = capGetDriverDescriptionA(x, strName, 100, strVer, 100)
                If bReturn Then
                    Devlist.Add(strName.Trim)

                End If
                x += 1
                Application.DoEvents()
            Loop Until bReturn = False
            Return Devlist
        End Function

        Public Function IntializeDefaultDevice(ByRef PB As PictureBox) As PictureBox
            PB = SetPictureBox(PB)

            Dim DeviceNames As List(Of String) = LoadDeviceList()

            Dim Idevice As Integer = 0
            If DeviceNames.Count > 0 Then
                PB = OpenPreviewWindow(PB, Idevice)
            Else

            End If

            Return PB
        End Function

    End Class

End Namespace