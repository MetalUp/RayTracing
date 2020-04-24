namespace RayTracer
{
    public interface IThing
    {
          SurfaceTexture Surface { get; }
          Intersection CalculateIntersection(Ray withRay);
          Vector3 CalculateNormal(Vector3 toSurfacePosition);
    }
}
