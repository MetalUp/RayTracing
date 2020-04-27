Public Class Scene

    Public ReadOnly Property Things As Thing()
    Public ReadOnly Property Lights As LightSource()
    Public ReadOnly Property Camera As Camera

    Public Sub New(ByVal things As Thing(), ByVal lights As LightSource(), ByVal camera As Camera)
        Me.Things = things
        Me.Lights = lights
        Me.Camera = camera
    End Sub

    Public Function Intersect(ByVal r As Ray) As List(Of Intersection)
        Return Things.Select(Function(t) t.CalculateIntersection(r)).ToList()
    End Function
End Class
