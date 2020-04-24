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
        ClientSize = New Drawing.Size(imageWidth, imageHeight + 24)
        Controls.Add(pictureBox)
        Text = "Ray Tracer"
        'Load += AddressOf RayTracerForm_Load
        Show()
    End Sub

    Private Sub RayTracerForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Me.Show()
        Dim rayTracer As Renderer = New Renderer(imageWidth, imageHeight, Sub(ByVal x As Integer, ByVal y As Integer, ByVal color As Drawing.Color)
                                                                              bitmap.SetPixel(x, y, color)
                                                                              If x = 0 Then pictureBox.Refresh()
                                                                          End Sub)
        rayTracer.Render(StandardScenes.DefaultScene)
        pictureBox.Invalidate()
    End Sub

    <STAThread>
    Private Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New RayTracerForm())
    End Sub
End Class


