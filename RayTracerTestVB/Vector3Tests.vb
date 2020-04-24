Imports RayTracerModelVB

<TestClass>
Public Class Vector3Tests
    <TestMethod>
    Public Sub Constructor()
        Dim v1 = New Vector3(1.1, 2.2, 3.3)
        Assert.AreEqual(1.1, v1.X)
        Assert.AreEqual(2.2, v1.Y)
        Assert.AreEqual(3.3, v1.Z)
    End Sub

    <TestMethod>
    Public Sub Equality()
        Dim v1 = New Vector3(1.1, 2.2, 3.3)
        Dim v2 = New Vector3(1.1, 2.2, 3.3)
        Dim v3 = New Vector3(3.3, 2.2, 1.1)
        Assert.AreEqual(v1, v2)
        Assert.AreNotEqual(v1, v3)
    End Sub

    <TestMethod>
    Public Sub Length()
        Dim v1 = New Vector3(1, 2, 3)
        Assert.AreEqual(3.74, Math.Round(v1.Length(), 2))
    End Sub

    <TestMethod>
    Public Sub Normalised()
        Dim v1 = New Vector3(1, 2, 3)
        Dim vr = v1.Normalized()
        Assert.AreEqual(1.0, vr.Length())
        Assert.AreEqual(0.27, Math.Round(vr.X, 2))
        Assert.AreEqual(0.53, Math.Round(vr.Y, 2))
        Assert.AreEqual(0.8, Math.Round(vr.Z, 2))
    End Sub

    <TestMethod>
    Public Sub ScalarMultiply()
        Dim v1 = New Vector3(1, 2, 3)
        Dim vr = v1.ScalarMultiply(4)
        Assert.AreEqual(4.0, vr.X)
        Assert.AreEqual(8.0, vr.Y)
        Assert.AreEqual(12.0, vr.Z)
    End Sub

    <TestMethod>
    Public Sub Plus1()
        Dim v1 = New Vector3(1, 2, 3)
        Dim v2 = New Vector3(7, 0, 6)
        Dim vr = v1.Plus(v2)
        Assert.AreEqual(8.0, vr.X)
        Assert.AreEqual(2.0, vr.Y)
        Assert.AreEqual(9.0, vr.Z)
    End Sub

    <TestMethod>
    Public Sub Plus2()
        Dim v1 = New Vector3(1, 2, 3)
        Dim v2 = New Vector3(7, 0, 6)
        Dim vr = v2.Plus(v1)
        Assert.AreEqual(8.0, vr.X)
        Assert.AreEqual(2.0, vr.Y)
        Assert.AreEqual(9.0, vr.Z)
    End Sub

    <TestMethod>
    Public Sub Minus1()
        Dim v1 = New Vector3(1, 2, 3)
        Dim v2 = New Vector3(7, 0, 6)
        Dim vr = v2.Minus(v1)
        Assert.AreEqual(6.0, vr.X)
        Assert.AreEqual(-2.0, vr.Y)
        Assert.AreEqual(3.0, vr.Z)
    End Sub

    <TestMethod>
    Public Sub Minus2()
        Dim v1 = New Vector3(1, 2, 3)
        Dim v2 = New Vector3(7, 0, 6)
        Dim vr = v1.Minus(v2)
        Assert.AreEqual(-6.0, vr.X)
        Assert.AreEqual(2.0, vr.Y)
        Assert.AreEqual(-3.0, vr.Z)
    End Sub

    <TestMethod>
    Public Sub DotProduct()
        Dim v1 = New Vector3(1, 2, 3)
        Dim v2 = New Vector3(7, 0, 6)
        Dim dp As Double = v2.DotProduct(v1)
        Assert.AreEqual(25.0, dp)
    End Sub

    <TestMethod>
    Public Sub CrossProduct1()
        Dim v1 = New Vector3(2, 3, 4)
        Dim v2 = New Vector3(5, 6, 7)
        Dim vr = v1.CrossProduct(v2)
        Assert.AreEqual(-3.0, vr.X)
        Assert.AreEqual(6.0, vr.Y)
        Assert.AreEqual(-3.0, vr.Z)
    End Sub

    <TestMethod>
    Public Sub CrossProduct2()
        Dim v1 = New Vector3(2, 3, 4)
        Dim v2 = New Vector3(5, 6, 7)
        Dim vr = v2.CrossProduct(v1)
        Assert.AreEqual(3.0, vr.X)
        Assert.AreEqual(-6.0, vr.Y)
        Assert.AreEqual(3.0, vr.Z)
    End Sub

    <TestMethod>
    Public Sub MultiplyOperatorScalar1()
        Dim v1 = New Vector3(1, 2, 3)
        Dim vr = v1 * 4
        Assert.AreEqual(4.0, vr.X)
        Assert.AreEqual(8.0, vr.Y)
        Assert.AreEqual(12.0, vr.Z)
    End Sub

    <TestMethod>
    Public Sub MultiplyOperatorScalar2()
        Dim v1 = New Vector3(1, 2, 3)
        Dim vr = 4 * v1
        Assert.AreEqual(4.0, vr.X)
        Assert.AreEqual(8.0, vr.Y)
        Assert.AreEqual(12.0, vr.Z)
    End Sub

    <TestMethod>
    Public Sub PlusOperator1()
        Dim v1 = New Vector3(1, 2, 3)
        Dim v2 = New Vector3(7, 0, 6)
        Dim vr = v1 + v2
        Assert.AreEqual(8.0, vr.X)
        Assert.AreEqual(2.0, vr.Y)
        Assert.AreEqual(9.0, vr.Z)
    End Sub

    <TestMethod>
    Public Sub PlusOperator2()
        Dim v1 = New Vector3(1, 2, 3)
        Dim v2 = New Vector3(7, 0, 6)
        Dim vr = v2 + v1
        Assert.AreEqual(8.0, vr.X)
        Assert.AreEqual(2.0, vr.Y)
        Assert.AreEqual(9.0, vr.Z)
    End Sub

    <TestMethod>
    Public Sub MinusOperator1()
        Dim v1 = New Vector3(1, 2, 3)
        Dim v2 = New Vector3(7, 0, 6)
        Dim vr = v2 - v1
        Assert.AreEqual(6.0, vr.X)
        Assert.AreEqual(-2.0, vr.Y)
        Assert.AreEqual(3.0, vr.Z)
    End Sub

    <TestMethod>
    Public Sub MinusOperator2()
        Dim v1 = New Vector3(1, 2, 3)
        Dim v2 = New Vector3(7, 0, 6)
        Dim vr = v1 - v2
        Assert.AreEqual(-6.0, vr.X)
        Assert.AreEqual(2.0, vr.Y)
        Assert.AreEqual(-3.0, vr.Z)
    End Sub
End Class
