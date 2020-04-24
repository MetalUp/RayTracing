Public Class Renderer
    Private screenWidth As Integer
    Private screenHeight As Integer
    Private Const MaxDepth As Integer = 5
    Public setPixel As Action(Of Integer, Integer, Drawing.Color)

    Public Sub New(ByVal screenWidth As Integer, ByVal screenHeight As Integer, ByVal setPixel As Action(Of Integer, Integer, Drawing.Color))
        Me.screenWidth = screenWidth
        Me.screenHeight = screenHeight
        Me.setPixel = setPixel
    End Sub

    Private Function Intersections(ByVal ray As Ray, ByVal scene As Scene) As IEnumerable(Of Intersection)
        Return scene.Things.Select(Function(obj) obj.CalculateIntersection(ray)).Where(Function(inter) inter IsNot Nothing).OrderBy(Function(inter) inter.Dist)
    End Function

    Private Function TestRay(ByVal ray As Ray, ByVal scene As Scene) As Double
        Dim isects = Me.Intersections(ray, scene)
        Dim isect As Intersection = isects.FirstOrDefault()
        If isect Is Nothing Then Return 0
        Return isect.Dist
    End Function

    Private Function TraceRay(ByVal ray As Ray, ByVal scene As Scene, ByVal depth As Integer) As Color
        Dim isects = Me.Intersections(ray, scene)
        Dim isect As Intersection = isects.FirstOrDefault()
        If isect Is Nothing Then Return Color.Background
        Return Me.Shade(isect, scene, depth)
    End Function

    Private Function GetNaturalColor(ByVal thing As IThing, ByVal pos As Vector3, ByVal norm As Vector3, ByVal rd As Vector3, ByVal scene As Scene) As Color
        Dim ret As Color = New Color(0, 0, 0)

        For Each light As LightSource In scene.Lights
            Dim ldis As Vector3 = light.Pos - pos
            Dim livec As Vector3 = ldis.Normalized()
            Dim neatIsect As Double = Me.TestRay(New Ray(pos, livec), scene)
            Dim isInShadow As Boolean = Not ((neatIsect > ldis.Length()) OrElse neatIsect = 0)

            If Not isInShadow Then
                Dim illum As Double = livec.DotProduct(norm)
                Dim lcolor As Color = If(illum > 0, illum * light.Color, New Color(0, 0, 0))
                Dim specular As Double = livec.DotProduct(rd.Normalized())
                Dim scolor As Color = If(specular > 0, Math.Pow(specular, thing.Surface.Roughness) * light.Color, New Color(0, 0, 0))
                ret = ret + thing.Surface.Diffuse(pos) * lcolor + thing.Surface.Specular(pos) * scolor
            End If
        Next

        Return ret
    End Function

    Private Function GetReflectionColor(ByVal thing As IThing, ByVal pos As Vector3, ByVal norm As Vector3, ByVal rd As Vector3, ByVal scene As Scene, ByVal depth As Integer) As Color
        Return thing.Surface.Reflect(pos) * Me.TraceRay(New Ray(pos, rd), scene, depth + 1)
    End Function

    Private Function Shade(ByVal isect As Intersection, ByVal scene As Scene, ByVal depth As Integer) As Color
        Dim d = isect.Ray.Dir
        Dim pos = isect.Dist * isect.Ray.Dir + isect.Ray.Start
        Dim normal = isect.Thing.CalculateNormal(pos)
        Dim reflectDir = d - 2 * normal.DotProduct(d) * normal
        Dim ret As Color = Color.DefaultColor
        ret = ret + GetNaturalColor(isect.Thing, pos, normal, reflectDir, scene)

        If depth >= MaxDepth Then
            Return ret + New Color(0.5, 0.5, 0.5)
        End If

        Return ret + GetReflectionColor(isect.Thing, pos + 0.001 * reflectDir, normal, reflectDir, scene, depth)
    End Function

    Private Function RecenterX(ByVal x As Double) As Double
        Return (x - screenWidth / 2.0) / (2.0 * screenWidth)
    End Function

    Private Function RecenterY(ByVal y As Double) As Double
        Return -(y - screenHeight / 2.0) / (2.0 * screenHeight)
    End Function

    Private Function GetPoint(ByVal x As Double, ByVal y As Double, ByVal camera As Camera) As Vector3
        Return (camera.Forward + RecenterX(x) * camera.Right + RecenterY(y) * camera.Up).Normalized()
    End Function

    Public Sub Render(ByVal scene As Scene)
        For y As Integer = 0 To screenHeight - 1

            For x As Integer = 0 To screenWidth - 1
                'if (x == 300 && y == 300) Debugger.Break();
                Dim color As Color = Me.TraceRay(New Ray(scene.Camera.Pos, GetPoint(x, y, scene.Camera)), scene, 0)
                setPixel(x, y, color.ToDrawingColor())
            Next
        Next
    End Sub
End Class

Public Delegate Sub Action(Of T, U, V)(ByVal t As T, ByVal u As U, ByVal v As V)
