Imports RayTracerModelVB

Public Module StandardScenes

    Public ReadOnly DefaultScene As Scene = New Scene(DefaultThings(), DefaultLightSources(), DefaultCamera())

    Private Function DefaultThings() As Thing()
        Return New Thing() {
                    New Plane(New Vector3(0, 1, 0), 0, StandardSurfaces.CheckerBoard),
                    New Sphere(New Vector3(0, 0.5, 0), 0.5, StandardSurfaces.Shiny),
                    New Sphere(New Vector3(1, 1, 1), 0.2, StandardSurfaces.Matt),
                    New Sphere(New Vector3(-2, 1, -1), 1, StandardSurfaces.Shiny)}
    End Function

    Private Function DefaultLightSources() As LightSource()
        Return New LightSource() {
                    New LightSource(New Vector3(-2, 2.5, 0), New Colour(0.49, 0.07, 0.07)),
                    New LightSource(New Vector3(1.5, 2.5, 1.5), New Colour(0.07, 0.07, 0.49)),
                    New LightSource(New Vector3(1.5, 2.5, -1.5), New Colour(0.07, 0.49, 0.071)),
                    New LightSource(New Vector3(0, 3.5, 0), New Colour(0.21, 0.21, 0.35))}
    End Function

    Private Function DefaultCamera() As Camera
        'In this view:
        'X axis Is left-right (zero Is centre-picture, +ve to the Right)
        'Y axis Is up-down (zero Is the plane of the floor, positive upwards)
        'Z axis Is in/out of screen (zero Is a few squares in from front, positive Is further into screen)
        Return New Camera(New Vector3(0, 1, -6), New Vector3(0, 0, 0))
    End Function
End Module
