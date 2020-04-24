using System;

namespace RayTracer
{
    public class SurfaceTexture
    {
        public Func<Vector3, Colour> Diffuse { get; private set; }
        public Func<Vector3, Colour> Specular { get; private set; }
        public Func<Vector3, double> Reflect { get; private set; }
        public double Roughness { get; private set; }

        public SurfaceTexture(Func<Vector3, Colour> diffuse, 
            Func<Vector3, Colour> specular,
            Func<Vector3, double> reflect,
            double roughness)
        {
            Diffuse = diffuse;
            Specular = specular;
            Reflect = reflect;
            Roughness = roughness;
        }
    }
}
