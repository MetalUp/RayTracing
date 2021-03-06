﻿Public Class Camera
    Public Pos As Vector3
    Public Forward As Vector3
    Public Up As Vector3
    Public Right As Vector3

    Public Sub New(ByVal pos As Vector3, ByVal lookAt As Vector3)
        Forward = (lookAt - pos).Normalized()
        Dim down = New Vector3(0, -1, 0)
        Right = Forward.CrossProduct(down).Normalized() * 1.5
        Up = Forward.CrossProduct(Right).Normalized() * 1.5
        Me.Pos = pos
    End Sub
End Class

