Public Interface IThing
    ReadOnly Property Surface As SurfaceTexture
    Function CalculateIntersection(ByVal withRay As Ray) As Intersection
    Function CalculateNormal(ByVal toSurfacePosition As Vector3) As Vector3
End Interface
