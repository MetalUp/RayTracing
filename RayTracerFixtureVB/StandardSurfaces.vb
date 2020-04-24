Imports RayTracerModelVB

Friend Module StandardSurfaces
    ' Only works with X-Z plane.
    Public ReadOnly CheckerBoard As SurfaceTexture =
        New SurfaceTexture(Function(pos) If((Math.Floor(pos.Z) + Math.Floor(pos.X)) Mod 2 <> 0, New Color(1, 1, 1), New Color(0, 0, 0)),
                           Function(pos) New Color(1, 1, 1),
                           Function(pos) If((Math.Floor(pos.Z) + Math.Floor(pos.X)) Mod 2 <> 0, 0.1, 0.7), 150)

    Public ReadOnly Shiny As SurfaceTexture =
        New SurfaceTexture(Function(pos) New Color(1, 1, 1),
                           Function(pos) New Color(0.5, 0.5, 0.5),
                           Function(pos) 0.6, 50)
    Public ReadOnly Matt As SurfaceTexture =
        New SurfaceTexture(Function(pos) New Color(1, 1, 1),
                           Function(pos) New Color(0, 0, 0),
                           Function(pos) 0, 50)
End Module
