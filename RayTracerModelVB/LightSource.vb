Public Class LightSource

    Public Property Pos As Vector3

    Public Property Color As Color

    Public Sub New(ByVal pos As Vector3, ByVal color As Color)
        Me.Pos = pos
        Me.Color = color
    End Sub
End Class
