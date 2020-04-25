Public Class SurfaceTexture

    Public Property Diffuse As Func(Of Vector3, Colour)

    Public Property Specular As Func(Of Vector3, Colour)

    Public Property Reflect As Func(Of Vector3, Double)

    Public Property Roughness As Double

    Public Sub New(ByVal diffuse As Func(Of Vector3, Colour), ByVal specular As Func(Of Vector3, Colour), ByVal reflect As Func(Of Vector3, Double), ByVal roughness As Double)
        Me.Diffuse = diffuse
        Me.Specular = specular
        Me.Reflect = reflect
        Me.Roughness = roughness
    End Sub
End Class
