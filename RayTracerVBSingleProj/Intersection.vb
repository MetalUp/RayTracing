Public Class Intersection

    Public ReadOnly Property Thing As Thing
    Public ReadOnly Property Ray As Ray
    Public ReadOnly Property Dist As Double

    Public Sub New(ByVal thing As Thing, ByVal ray As Ray, ByVal dist As Double)
        Me.Thing = thing
        Me.Ray = ray
        Me.Dist = dist
    End Sub
End Class
