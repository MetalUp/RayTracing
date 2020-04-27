using System.Collections.Generic;
using System.Linq;

namespace RayTracer
{
    public class Scene
    {
        public Thing[] Things { get; private set; }
        public LightSource[] Lights { get; private set; }
        public Camera Camera { get; private set; }

        public Scene(Thing[] things, LightSource[] lights, Camera camera)
        {
            Things = things;
            Lights = lights;
            Camera = camera;
        }

        public List<Intersection> Intersect(Ray r)
        {
            return Things.Select(t => t.CalculateIntersection(r)).ToList();
        }
    }
}