namespace RayTracer
{
    public class Ray
    {
        public Vector3 Start { get; private set; }
        public Vector3 Dir { get; private set; }
        public Ray(Vector3 start, Vector3 dir)
        {
            Start = start;
            Dir = dir;
        }
    }
}
