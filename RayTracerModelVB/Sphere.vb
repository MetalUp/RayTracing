Public Class Sphere
    Inherits Thing

    Public Property Centre As Vector3

    Public Property Radius As Double

    Public Sub New(ByVal centre As Vector3, ByVal radius As Double, ByVal surface As SurfaceTexture)
        MyBase.New(surface)
        Me.Centre = centre
        Me.Radius = radius
    End Sub

    Public Overrides Function CalculateIntersection(ByVal withRay As Ray) As Intersection
        Dim eo As Vector3 = Centre - withRay.Start
        Dim v As Double = eo.DotProduct(withRay.Dir)
        Dim dist As Double

        If v < 0 Then
            dist = 0
        Else
            Dim disc As Double = Math.Pow(Radius, 2) - (eo.DotProduct(eo) - Math.Pow(v, 2))
            dist = If(disc < 0, 0, v - Math.Sqrt(disc))
        End If

        If dist = 0 Then Return Nothing
        Return New Intersection(Me, withRay, dist)
    End Function

    Public Overrides Function CalculateNormal(ByVal surfacePosition As Vector3) As Vector3
        Return (surfacePosition - Centre).Normalized()
    End Function
End Class
