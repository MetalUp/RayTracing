Public MustInherit Class Thing
    Public ReadOnly Property Surface As SurfaceTexture

    Public Sub New(ByVal surface As SurfaceTexture)
        Me.Surface = surface
    End Sub

    MustOverride Function CalculateIntersection(ByVal withRay As Ray) As Intersection
    MustOverride Function CalculateNormal(ByVal toSurfacePosition As Vector3) As Vector3
End Class
