Imports System.Drawing
Imports System.Windows.Forms
Imports Basic_AI_VisualReco2023.Imaging
Public Class FrmCompare

#Region "Compare image"

    Private Sub ButtonCompareImage_Click(sender As Object, e As EventArgs) Handles ButtonCompareImage.Click
        Dim bmp1 As New Bitmap(InputCompareImageA.Image)
        If ComparePicture(InputCompareImageA.Image.Clone, InputCompareImageB.Image.Clone, 1000, bmp1, AllowedErrors.Value) = True Then
            LabelDisplayMatch.Text = "The Images are a Match"
        Else
            LabelDisplayMatch.Text = "The Images are a Not Match"
            OutputImage.Image = bmp1
            OutputImage.SizeMode = PictureBoxSizeMode.StretchImage
        End If
    End Sub

    Private Sub ButtonEdgeEnhance_Click(sender As Object, e As EventArgs) Handles ButtonEdgeEnhance.Click
        If CheckApplyBothFilter() = True Then
            InputCompareImageA.Image = EdgeEnhance(InputCompareImageA.Image.Clone, 100)
            InputCompareImageB.Image = EdgeEnhance(InputCompareImageB.Image.Clone, 100)
        Else
            If FilterA.Checked = True Then
                InputCompareImageA.Image = EdgeEnhance(InputCompareImageA.Image.Clone, 100)
            End If
            If FilterB.Checked = True Then
                InputCompareImageB.Image = EdgeEnhance(InputCompareImageB.Image.Clone, 100)
            End If
        End If
    End Sub

    Private Sub ButtonGreyScale_Click(sender As Object, e As EventArgs) Handles ButtonGreyScale.Click
        If CheckApplyBothFilter() = True Then
            InputCompareImageA.Image = GreyScale(InputCompareImageA.Image.Clone)
            InputCompareImageB.Image = GreyScale(InputCompareImageB.Image.Clone)
        Else
            If FilterA.Checked = True Then
                InputCompareImageA.Image = GreyScale(InputCompareImageA.Image.Clone)
            End If
            If FilterB.Checked = True Then
                InputCompareImageB.Image = GreyScale(InputCompareImageB.Image.Clone)
            End If
        End If
    End Sub

    Private Sub ButtonHorizontalEdges_Click(sender As Object, e As EventArgs) Handles ButtonHorizontalEdges.Click
        If CheckApplyBothFilter() = True Then
            InputCompareImageA.Image = EdgeDetectionHorizontal(InputCompareImageA.Image.Clone)
            InputCompareImageB.Image = EdgeDetectionHorizontal(InputCompareImageB.Image.Clone)
        Else
            If FilterA.Checked = True Then
                InputCompareImageA.Image = EdgeDetectionHorizontal(InputCompareImageA.Image.Clone)
            End If
            If FilterB.Checked = True Then
                InputCompareImageB.Image = EdgeDetectionHorizontal(InputCompareImageB.Image.Clone)
            End If
        End If
    End Sub

    Private Sub ButtonKirsh_Click(sender As Object, e As EventArgs) Handles ButtonKirsh.Click
        If CheckApplyBothFilter() = True Then
            InputCompareImageA.Image = EdgeDetectConvolution(InputCompareImageA.Image.Clone, EDGE_DETECT_KIRSH, 100)
            InputCompareImageB.Image = EdgeDetectConvolution(InputCompareImageB.Image.Clone, EDGE_DETECT_KIRSH, 100)
        Else
            If FilterA.Checked = True Then
                InputCompareImageA.Image = EdgeDetectConvolution(InputCompareImageA.Image.Clone, EDGE_DETECT_KIRSH, 100)
            End If
            If FilterB.Checked = True Then
                InputCompareImageB.Image = EdgeDetectConvolution(InputCompareImageB.Image.Clone, EDGE_DETECT_KIRSH, 100)
            End If
        End If
    End Sub

    Private Sub ButtonOpenImageA_Click(sender As Object, e As EventArgs) Handles ButtonOpenCompareImageA.Click
        InputCompareImageA.Image = OpenImageFile()
        InputCompareImageA.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    Private Sub ButtonOpenImageB_Click(sender As Object, e As EventArgs) Handles ButtonOpenCompareImageB.Click
        InputCompareImageB.Image = OpenImageFile()
        InputCompareImageB.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    Private Sub ButtonPrewitt_Click(sender As Object, e As EventArgs) Handles ButtonPrewitt.Click
        If CheckApplyBothFilter() = True Then
            InputCompareImageA.Image = EdgeDetectConvolution(InputCompareImageA.Image.Clone, EDGE_DETECT_PREWITT, 100)
            InputCompareImageB.Image = EdgeDetectConvolution(InputCompareImageB.Image.Clone, EDGE_DETECT_PREWITT, 100)
        Else
            If FilterA.Checked = True Then
                InputCompareImageA.Image = EdgeDetectConvolution(InputCompareImageA.Image.Clone, EDGE_DETECT_PREWITT, 100)
            End If
            If FilterB.Checked = True Then
                InputCompareImageB.Image = EdgeDetectConvolution(InputCompareImageB.Image.Clone, EDGE_DETECT_PREWITT, 100)
            End If
        End If
    End Sub

    Private Sub ButtonSobel_Click(sender As Object, e As EventArgs) Handles ButtonSobel.Click
        If CheckApplyBothFilter() = True Then
            InputCompareImageA.Image = EdgeDetectConvolution(InputCompareImageA.Image.Clone, EDGE_DETECT_SOBEL, 100)
            InputCompareImageB.Image = EdgeDetectConvolution(InputCompareImageB.Image.Clone, EDGE_DETECT_SOBEL, 100)
        Else
            If FilterA.Checked = True Then
                InputCompareImageA.Image = EdgeDetectConvolution(InputCompareImageA.Image.Clone, EDGE_DETECT_SOBEL, 100)
            End If
            If FilterB.Checked = True Then
                InputCompareImageB.Image = EdgeDetectConvolution(InputCompareImageB.Image.Clone, EDGE_DETECT_SOBEL, 100)
            End If
        End If
    End Sub

    Private Sub ButtonVerticalEdges_Click(sender As Object, e As EventArgs) Handles ButtonVerticalEdges.Click
        If CheckApplyBothFilter() = True Then
            InputCompareImageA.Image = EdgeDetectionVertical(InputCompareImageA.Image.Clone)
            InputCompareImageB.Image = EdgeDetectionVertical(InputCompareImageB.Image.Clone)
        Else
            If FilterA.Checked = True Then
                InputCompareImageA.Image = EdgeDetectionVertical(InputCompareImageA.Image.Clone)
            End If
            If FilterB.Checked = True Then
                InputCompareImageB.Image = EdgeDetectionVertical(InputCompareImageB.Image.Clone)
            End If
        End If
    End Sub

    Private Function CheckApplyBothFilter() As Boolean

        Dim Both As Boolean = False
        If FilterA.Checked = True And FilterB.Checked = True Then Both = True

        If Both = True Then
            If FilterA.Checked = True Then

            End If
            If FilterB.Checked = True Then

            End If
        End If

        Return Both
    End Function

    Private Function OpenImageFile() As Bitmap
        Dim ofd As New OpenFileDialog

        ofd.Title = "Browse Image Files"

        ofd.DefaultExt = "bmp"

        ofd.Filter = "Image Files|*.bmp;*.jpg;*.png"

        If ofd.ShowDialog = DialogResult.OK Then
            Dim NewImage = New Bitmap(ofd.FileName)
            Return NewImage
        Else
            Return Nothing
        End If

    End Function

#End Region

End Class