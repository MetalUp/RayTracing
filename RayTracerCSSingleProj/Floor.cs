namespace RayTracer
{
    public class Floor : Thing
    {
        private Vector3 Norm = new Vector3(0, 1, 0);

        public Floor(SurfaceTexture surface) : base(surface)
        {
        }

        public override Intersection CalculateIntersection(Ray withRay)
        {
            double denom = Norm.DotProduct(withRay.Dir);
            if (denom > 0) return null;
            return new Intersection(this, withRay, (Norm.DotProduct(withRay.Start)) / (-denom));
        }

        public override Vector3 CalculateNormal(Vector3 surfacePosition)
        {
            return Norm;
        }
    }
}
