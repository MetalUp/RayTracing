Public Class Plane
    Implements IThing

    Public ReadOnly Property Surface As SurfaceTexture Implements IThing.Surface

    Public Property Norm As Vector3

    Public Property Offset As Double

    Public Sub New(ByVal norm As Vector3, ByVal offset As Double, ByVal surface As SurfaceTexture)
        Me.Norm = norm
        Me.Offset = offset
        Me.Surface = surface
    End Sub

    Public Function CalculateIntersection(ByVal withRay As Ray) As Intersection Implements IThing.CalculateIntersection
        Dim denom As Double = Norm.DotProduct(withRay.Dir)
        If denom > 0 Then Return Nothing
        Return New Intersection(Me, withRay, (Norm.DotProduct(withRay.Start) + Offset) / -denom)
    End Function

    Public Function CalculateNormal(ByVal surfacePosition As Vector3) As Vector3 Implements IThing.CalculateNormal
        Return Norm
    End Function
End Class
