namespace RayTracer
{
    public class Intersection
    {
        public Thing Thing { get; private set; }
        public Ray Ray { get; private set; }
        public double Dist { get; private set; }

        public Intersection(Thing thing, Ray ray, double dist)
        {
            Thing = thing;
            Ray = ray;
            Dist = dist;
        }
    }
}
