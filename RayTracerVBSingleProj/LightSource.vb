Public Class LightSource

    Public ReadOnly Property Pos As Vector3

    Public ReadOnly Property Color As Colour

    Public Sub New(ByVal pos As Vector3, ByVal color As Colour)
        Me.Pos = pos
        Me.Color = color
    End Sub
End Class
