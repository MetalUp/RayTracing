Public Class Camera
    Public ReadOnly Pos As Vector3
    Public ReadOnly Forward As Vector3
    Public ReadOnly Up As Vector3
    Public ReadOnly Right As Vector3

    Public Sub New(ByVal pos As Vector3, ByVal lookAt As Vector3)
        Forward = (lookAt - pos).Normalized()
        Dim down = New Vector3(0, -1, 0)
        Right = Forward.CrossProduct(down).Normalized() * 1.5
        Up = Forward.CrossProduct(Right).Normalized() * 1.5
        Me.Pos = pos
    End Sub

    Private Function RecenterX(ByVal x As Double, ByVal screenWidth As Integer) As Double
        Return (x - (screenWidth / 2.0)) / (2.0 * screenWidth)
    End Function

    Private Function RecenterY(ByVal y As Double, ByVal screenHeight As Integer) As Double
        Return -(y - (screenHeight / 2.0)) / (2.0 * screenHeight)
    End Function

    Public Function GetPoint(ByVal x As Double, ByVal y As Double, ByVal screenWidth As Integer, ByVal screenHeight As Integer) As Vector3
        Return (Forward + RecenterX(x, screenWidth) * Right + RecenterY(y, screenHeight) * Up).Normalized()
    End Function
End Class

