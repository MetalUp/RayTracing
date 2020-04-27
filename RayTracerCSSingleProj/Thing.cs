namespace RayTracer
{
    public abstract class Thing
    {
        public SurfaceTexture Surface { get; private set; }
        public abstract Intersection CalculateIntersection(Ray withRay);
        public abstract Vector3 CalculateNormal(Vector3 toSurfacePosition);

        public Thing(SurfaceTexture surface)
        {
            Surface = surface;
        }
    }
}
