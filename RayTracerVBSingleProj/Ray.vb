Public Class Ray

    Public ReadOnly Property Start As Vector3

    Public ReadOnly Property Dir As Vector3

    Public Sub New(ByVal start As Vector3, ByVal dir As Vector3)
        Me.Start = start
        Me.Dir = dir.Normalized()
    End Sub
End Class
