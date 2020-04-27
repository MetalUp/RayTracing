using System;

namespace RayTracer
{
    public class Sphere : Thing
    {
        public Vector3 Centre { get; private set; }
        public double Radius { get; private set; }

        public Sphere(Vector3 centre, double radius, SurfaceTexture surface) : base(surface)
        {
            Centre = centre;
            Radius = radius;
        }

        public override Intersection CalculateIntersection(Ray withRay)
        {
            Vector3 eo = Centre - withRay.Start;
            double v = eo.DotProduct(withRay.Dir);
            double dist;
            if (v < 0)
            {
                dist = 0;
            }
            else
            {
                double disc = Math.Pow(Radius, 2) - (eo.DotProduct(eo) - Math.Pow(v, 2));
                dist = disc < 0 ? 0 : v - Math.Sqrt(disc);
            }
            if (dist == 0) return null;
            return new Intersection(this, withRay, dist);
        }

        public override Vector3 CalculateNormal(Vector3 surfacePosition)
        {
            return (surfacePosition - Centre).Normalized();
        }
    }
}
