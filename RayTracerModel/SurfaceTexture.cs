using System;

namespace RayTracer
{
    public class SurfaceTexture
    {
        public Func<Vector3, Color> Diffuse { get; private set; }
        public Func<Vector3, Color> Specular { get; private set; }
        public Func<Vector3, double> Reflect { get; private set; }
        public double Roughness { get; private set; }

        public SurfaceTexture(Func<Vector3, Color> diffuse, 
            Func<Vector3, Color> specular,
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
