﻿Public Class Colour
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

    Public Shared Operator *(ByVal n As Double, ByVal v As Colour) As Colour
        Return New Colour(n * v.R, n * v.G, n * v.B)
    End Operator

    Public Shared Operator *(ByVal v1 As Colour, ByVal v2 As Colour) As Colour
        Return New Colour(v1.R * v2.R, v1.G * v2.G, v1.B * v2.B)
    End Operator

    Public Shared Operator +(ByVal v1 As Colour, ByVal v2 As Colour) As Colour
        Return New Colour(v1.R + v2.R, v1.G + v2.G, v1.B + v2.B)
    End Operator

    Public Shared Operator -(ByVal v1 As Colour, ByVal v2 As Colour) As Colour
        Return New Colour(v1.R - v2.R, v1.G - v2.G, v1.B - v2.B)
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

#Region "Standard Colours"
    Public Shared Red As Colour = New Colour(1, 0, 0)
    Public Shared Green As Colour = New Colour(0, 1, 0)
    Public Shared Blue As Colour = New Colour(0, 0, 1)
    Public Shared Yellow As Colour = New Colour(1, 1, 0)
    Public Shared White As Colour = New Colour(1, 1, 1)
    Public Shared Black As Colour = New Colour(0, 0, 0)
#End Region

End Class


