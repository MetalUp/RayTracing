Imports System.Linq

Public Class Renderer
    Private screenWidth As Integer
    Private screenHeight As Integer
    Private Const MaxDepth As Integer = 5

    Public Sub New(ByVal screenWidth As Integer, ByVal screenHeight As Integer)
        Me.screenWidth = screenWidth
        Me.screenHeight = screenHeight
    End Sub

    Private Function Intersections(ByVal ray As Ray, ByVal scene As Scene) As List(Of Intersection)
        Return scene.Things.Select(Function(obj) obj.CalculateIntersection(ray)).
                            Where(Function(inter) inter IsNot Nothing).
                            OrderBy(Function(inter) inter.Dist).ToList()
    End Function

    Private Function TestRay(ByVal ray As Ray, ByVal scene As Scene) As Double
        Dim isect As Intersection = Intersections(ray, scene).FirstOrDefault()
        If isect Is Nothing Then Return 0
        Return isect.Dist
    End Function

    Private Function TraceRay(ByVal ray As Ray, ByVal scene As Scene, ByVal depth As Integer) As Colour
        Dim isect As Intersection = Intersections(ray, scene).FirstOrDefault()
        If isect Is Nothing Then Return Colour.Black
        Return Me.Shade(isect, scene, depth)
    End Function

    Private Function GetNaturalColor(ByVal thing As Thing, ByVal pos As Vector3, ByVal norm As Vector3, ByVal rd As Vector3, ByVal scene As Scene) As Colour
        Dim ret As Colour = New Colour(0, 0, 0)

        For Each light As LightSource In scene.Lights
            Dim ldis As Vector3 = light.Pos - pos
            Dim livec As Vector3 = ldis.Normalized()
            Dim neatIsect As Double = Me.TestRay(New Ray(pos, livec), scene)
            Dim isInShadow As Boolean = Not ((neatIsect > ldis.Length()) OrElse neatIsect = 0)

            If Not isInShadow Then
                Dim illum As Double = livec.DotProduct(norm)
                Dim lcolor As Colour = If(illum > 0, illum * light.Color, New Colour(0, 0, 0))
                Dim specular As Double = livec.DotProduct(rd.Normalized())
                Dim scolor As Colour = If(specular > 0, Math.Pow(specular, thing.Surface.Roughness) * light.Color, New Colour(0, 0, 0))
                ret = ret + thing.Surface.Diffuse(pos) * lcolor + thing.Surface.Specular(pos) * scolor
            End If
        Next

        Return ret
    End Function

    Private Function GetReflectionColor(ByVal thing As Thing, ByVal pos As Vector3, ByVal norm As Vector3, ByVal rd As Vector3, ByVal scene As Scene, ByVal depth As Integer) As Colour
        Return thing.Surface.Reflect(pos) * TraceRay(New Ray(pos, rd), scene, depth + 1)
    End Function

    Private Function Shade(ByVal isect As Intersection, ByVal scene As Scene, ByVal depth As Integer) As Colour
        Dim d = isect.Ray.Dir
        Dim pos = isect.Dist * isect.Ray.Dir + isect.Ray.Start
        Dim normal = isect.Thing.CalculateNormal(pos)
        Dim reflectDir = d - 2 * normal.DotProduct(d) * normal
        Dim ret As Colour = Colour.Black + GetNaturalColor(isect.Thing, pos, normal, reflectDir, scene)
        If depth >= MaxDepth Then
            Return ret + New Colour(0.5, 0.5, 0.5)
        End If

        Return ret + GetReflectionColor(isect.Thing, pos + 0.001 * reflectDir, normal, reflectDir, scene, depth)
    End Function

    Public Function Render(ByVal scene As Scene) As Colour()
        Dim image As Colour() = New Colour(screenWidth * screenHeight - 1) {}

        For y As Integer = 0 To screenHeight - 1

            For x As Integer = 0 To screenWidth - 1
                Dim index As Integer = y * screenWidth + x
                image(index) = TraceRay(New Ray(scene.Camera.Pos, scene.Camera.GetPoint(x, y, screenWidth, screenHeight)), scene, 0)
            Next
        Next
        Return image
    End Function
End Class

