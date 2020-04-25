Public Class Plane
    Inherits Thing

    Public Property Norm As Vector3

    Public Property Offset As Double

    Public Sub New(ByVal norm As Vector3, ByVal offset As Double, ByVal surface As SurfaceTexture)
        MyBase.New(surface)
        Me.Norm = norm
        Me.Offset = offset
    End Sub

    Public Overrides Function CalculateIntersection(ByVal withRay As Ray) As Intersection
        Dim denom As Double = Norm.DotProduct(withRay.Dir)
        If denom > 0 Then Return Nothing
        Return New Intersection(Me, withRay, (Norm.DotProduct(withRay.Start) + Offset) / -denom)
    End Function

    Public Overrides Function CalculateNormal(ByVal surfacePosition As Vector3) As Vector3
        Return Norm
    End Function
End Class
