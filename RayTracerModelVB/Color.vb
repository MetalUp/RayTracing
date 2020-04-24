Public Class Color
    Private R, G, B As Double

    'Constructors
    Public Sub New(ByVal r As Double, ByVal g As Double, ByVal b As Double)
        Me.R = r
        Me.G = g
        Me.B = b
    End Sub

    Public Sub New(ByVal str As String)
        Dim nums As String() = str.Split(","c)
        If nums.Length <> 3 Then Throw New ArgumentException()
        R = Double.Parse(nums(0))
        G = Double.Parse(nums(1))
        B = Double.Parse(nums(2))
    End Sub

    Public Shared ReadOnly Background As Color = New Color(0, 0, 0)
    Public Shared ReadOnly DefaultColor As Color = New Color(0, 0, 0)


    ' 'operators' allow use of  +,-,*, instead of conventional method signatures
    ' like 'add(...), subtract(...)'. They are static and hence must take two parameters
    Public Shared Operator *(ByVal n As Double, ByVal v As Color) As Color
        Return New Color(n * v.R, n * v.G, n * v.B)
    End Operator

    Public Shared Operator *(ByVal v1 As Color, ByVal v2 As Color) As Color
        Return New Color(v1.R * v2.R, v1.G * v2.G, v1.B * v2.B)
    End Operator

    Public Shared Operator +(ByVal v1 As Color, ByVal v2 As Color) As Color
        Return New Color(v1.R + v2.R, v1.G + v2.G, v1.B + v2.B)
    End Operator

    Public Shared Operator -(ByVal v1 As Color, ByVal v2 As Color) As Color
        Return New Color(v1.R - v2.R, v1.G - v2.G, v1.B - v2.B)
    End Operator

    Private Function ToByte(ByVal d As Double) As Byte
        Return Convert.ToByte(Math.Min(1, d) * 255)
    End Function

    Public Function RedByte() As Byte
        Return ToByte(R)
    End Function

    Public Function GreenByte() As Byte
        Return ToByte(G)
    End Function

    Public Function BlueByte() As Byte
        Return ToByte(B)
    End Function
End Class


