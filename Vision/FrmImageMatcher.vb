Imports System.Drawing
Imports System.Windows.Forms

Public Class FrmImageMatcher

#Region "Image Matcher"

    Private FoldersLoaded As Boolean = False
    Private ImageALoaded As Boolean = False
    Private Picmatcher As New Imaging.AI_Picture_Matcher.FindImageMatch

    Private Sub ButtonCompareImage_Click(sender As Object, e As EventArgs) Handles ButtonCompareImage.Click
        Dim Bmp1 As Bitmap
        Bmp1 = InputImageA.Image.Clone()
        Dim foundErrors As Integer = 0
        Dim found As Boolean = False
        Dim FoundImage As New Bitmap(Bmp1)
        found = Picmatcher.CompareImagesFiles(Bmp1, Picmatcher.Files, AllowedErrors.Value, foundErrors, FoundImage)
        If found = True Then
            InputImageB.Image = FoundImage
            InputImageB.SizeMode = PictureBoxSizeMode.StretchImage
            Label1.Text = "Match Found"
        Else
            Label1.Text = "Match Not Found"
        End If
    End Sub

    Private Sub ButtonOpenImageA_Click(sender As Object, e As EventArgs) Handles ButtonOpenImageA.Click
        InputImageA.Image = OpenImageFile()
        InputImageA.SizeMode = PictureBoxSizeMode.StretchImage
        ImageALoaded = True
        If FoldersLoaded = True And ImageALoaded = True Then
            ButtonCompareImage.Enabled = True
        End If

    End Sub

    Private Sub ButtonOpenImageB_Click(sender As Object, e As EventArgs) Handles ButtonOpenImageB.Click
        Dim Count As Integer = Picmatcher.GetFiles()
        FoldersLoaded = True
        If FoldersLoaded = True And ImageALoaded = True Then
            ButtonCompareImage.Enabled = True
            Label3.Text = "Files loaded :" & Count
        End If
    End Sub

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