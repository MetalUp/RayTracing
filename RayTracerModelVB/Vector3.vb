Public Class Vector3
    Public Property X As Double
    Public Property Y As Double
    Public Property Z As Double

    Public Sub New(ByVal x As Double, ByVal y As Double, ByVal z As Double)
        Me.X = x
        Me.Y = y
        Me.Z = z
    End Sub

    Public Function Length() As Double
        Return Math.Sqrt(X * X + Y * Y + Z * Z)
    End Function

    Public Function Normalized() As Vector3
        Return New Vector3(X / Length(), Y / Length(), Z / Length())
    End Function

    Public Function Plus(ByVal other As Vector3) As Vector3
        Return New Vector3(X + other.X, Y + other.Y, Z + other.Z)
    End Function

    Public Function Minus(ByVal other As Vector3) As Vector3
        Return New Vector3(X - other.X, Y - other.Y, Z - other.Z)
    End Function

    Public Function ScalarMultiply(ByVal scalar As Double) As Vector3
        Return New Vector3(X * scalar, Y * scalar, Z * scalar)
    End Function

    Public Function DotProduct(ByVal other As Vector3) As Double
        Return X * other.X + Y * other.Y + Z * other.Z
    End Function

    Public Function CrossProduct(ByVal other As Vector3) As Vector3
        Return New Vector3(Y * other.Z - Z * other.Y, Z * other.X - X * other.Z, X * other.Y - Y * other.X)
    End Function

    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        If obj.GetType() <> GetType(Vector3) Then Return False
        Dim v = TryCast(obj, Vector3)
        Return (v.X = X) AndAlso (v.Y = Y) AndAlso (v.Z = Z)
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return X.GetHashCode() + Y.GetHashCode() + Z.GetHashCode()
    End Function

    Public Shared Operator +(a As Vector3, b As Vector3) As Vector3
        Return a.Plus(b)
    End Operator

    Public Shared Operator -(a As Vector3, b As Vector3) As Vector3
        Return a.Minus(b)
    End Operator
    Public Shared Operator *(a As Vector3, b As Vector3) As Vector3
        Return a.CrossProduct(b)
    End Operator
    Public Shared Operator *(a As Vector3, b As Double) As Vector3
        Return a.ScalarMultiply(b)
    End Operator
    Public Shared Operator *(a As Double, b As Vector3) As Vector3
        Return b.ScalarMultiply(a)
    End Operator
End Class
