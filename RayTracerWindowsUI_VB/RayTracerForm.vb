Imports RayTracerFixtureVB
Imports RayTracerModelVB

Partial Public Class RayTracerForm
    Inherits Form

    Private bitmap As Bitmap
    Private pictureBox As PictureBox
    Const imageWidth As Integer = 600
    Const imageHeight As Integer = 600

    Public Sub New()
        bitmap = New Bitmap(imageWidth, imageHeight)
        pictureBox = New PictureBox()
        pictureBox.Dock = DockStyle.Fill
        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage
        pictureBox.Image = bitmap
        ClientSize = New Size(imageWidth, imageHeight + 24)
        Controls.Add(pictureBox)
        Text = "Ray Tracer"
        Show()
    End Sub

    Private Sub RayTracerForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Show()
        Dim rayTracer As Renderer = New Renderer(imageWidth, imageHeight)
        Dim pixels As Color() = rayTracer.Render(StandardScenes.DefaultScene)
        Dim image As Bitmap = New Bitmap(imageWidth, imageHeight)

        For x As Integer = 0 To imageWidth - 1

            For y As Integer = 0 To imageHeight - 1
                Dim c As Color = pixels(y * imageWidth + x)
                image.SetPixel(x, y, ToDrawingColor(c))
            Next
        Next

        pictureBox.Image = image
        pictureBox.Invalidate()
    End Sub

    Private Function ToDrawingColor(ByVal c As Color) As Drawing.Color
        Return Drawing.Color.FromArgb(c.RedByte(), c.GreenByte(), c.BlueByte())
    End Function

    <STAThread>
    Private Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New RayTracerForm())
    End Sub
End Class


