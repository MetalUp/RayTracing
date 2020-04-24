namespace RayTracer
{
    public class Plane : Thing
    {
        public Vector3 Norm { get; private set; }
        public double Offset { get; private set; }

        public Plane(Vector3 norm, double offset, SurfaceTexture surface) : base(surface)
        {
            Norm = norm;
            Offset = offset;
        }

        public override Intersection CalculateIntersection(Ray withRay)
        {
            double denom = Norm.DotProduct(withRay.Dir);
            if (denom > 0) return null;
            return new Intersection(this, withRay, (Norm.DotProduct(withRay.Start) + Offset) / (-denom));
        }

        public override Vector3 CalculateNormal(Vector3 surfacePosition)
        {
            return Norm;
        }
    }
}
