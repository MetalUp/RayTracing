Public Class Floor
    Inherits Thing

    Private Norm As Vector3 = New Vector3(0, 1, 0)

    Public Sub New(ByVal surface As SurfaceTexture)
        MyBase.New(surface)
    End Sub

    Public Overrides Function CalculateIntersection(ByVal withRay As Ray) As Intersection
        Dim denom As Double = Norm.DotProduct(withRay.Dir)
        If denom > 0 Then Return Nothing
        Return New Intersection(Me, withRay, (Norm.DotProduct(withRay.Start)) / -denom)
    End Function

    Public Overrides Function CalculateNormal(ByVal surfacePosition As Vector3) As Vector3
        Return Norm
    End Function
End Class
