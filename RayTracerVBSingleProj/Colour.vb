Public Class Colour
    Private R, G, B As Double

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

    Public Function MultiplyBy(ByVal n As Double) As Colour
        Return New Colour(n * R, n * G, n * B)
    End Function

    Public Function MultiplyBy(ByVal c2 As Colour) As Colour
        Return New Colour(R * c2.R, G * c2.G, B * c2.B)
    End Function

    Public Function Plus(ByVal c2 As Colour) As Colour
        Return New Colour(R + c2.R, G + c2.G, B + c2.B)
    End Function

    Public Function Minus(ByVal c2 As Colour) As Colour
        Return New Colour(R - c2.R, G - c2.G, B - c2.B)
    End Function

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

    Public Shared Red As Colour = New Colour(1, 0, 0)
    Public Shared Green As Colour = New Colour(0, 1, 0)
    Public Shared Blue As Colour = New Colour(0, 0, 1)
    Public Shared Yellow As Colour = New Colour(1, 1, 0)
    Public Shared White As Colour = New Colour(1, 1, 1)
    Public Shared Black As Colour = New Colour(0, 0, 0)

#Region "Operators"

    Public Shared Operator *(ByVal n As Double, ByVal c1 As Colour) As Colour
        Return c1.MultiplyBy(n)
    End Operator

    Public Shared Operator *(ByVal c1 As Colour, ByVal c2 As Colour) As Colour
        Return c1.MultiplyBy(c2)
    End Operator

    Public Shared Operator +(ByVal c1 As Colour, ByVal c2 As Colour) As Colour
        Return c1.Plus(c2)
    End Operator

    Public Shared Operator -(ByVal c1 As Colour, ByVal c2 As Colour) As Colour
        Return c1.Minus(c2)
    End Operator
#End Region
End Class


