Public Class Ray

    Public Property Start As Vector3

    Public Property Dir As Vector3

    Public Sub New(ByVal start As Vector3, ByVal dir As Vector3)
        Me.Start = start
        Me.Dir = dir
    End Sub
End Class
