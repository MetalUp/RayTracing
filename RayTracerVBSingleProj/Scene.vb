Imports System.Linq

Public Class Scene

    Public Property Things As Thing()

    Public Property Lights As LightSource()

    Public Property Camera As Camera

    Public Sub New(ByVal things As Thing(), ByVal lights As LightSource(), ByVal camera As Camera)
        Me.Things = things
        Me.Lights = lights
        Me.Camera = camera
    End Sub

    Public Function Intersect(ByVal r As Ray) As IEnumerable(Of Intersection)
        Return Things.Select(Function(t) t.CalculateIntersection(r))
    End Function
End Class
