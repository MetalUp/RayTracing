﻿Public Class Intersection

    Public Property Thing As IThing

    Public Property Ray As Ray

    Public Property Dist As Double

    Public Sub New(ByVal thing As IThing, ByVal ray As Ray, ByVal dist As Double)
        Me.Thing = thing
        Me.Ray = ray
        Me.Dist = dist
    End Sub
End Class
