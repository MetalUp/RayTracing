using System.Linq;
using System;
using System.Collections.Generic;

namespace RayTracer {
    public class Renderer {

        private int screenWidth;
        private int screenHeight;
        private const int MaxDepth = 5;

        public Renderer(int screenWidth, int screenHeight) {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
        }

        private List<Intersection> Intersections(Ray ray, Scene scene)
        {
            return scene.Things
                        .Select(obj => obj.CalculateIntersection(ray))
                        .Where(inter => inter != null)
                        .OrderBy(inter => inter.Dist).ToList();
        }

        private double TestRay(Ray ray, Scene scene) {
            Intersection isect = Intersections(ray, scene).FirstOrDefault();
            if (isect == null)
                return 0;
            return isect.Dist;
        }

        private Colour TraceRay(Ray ray, Scene scene, int depth) {
            Intersection isect = Intersections(ray, scene).FirstOrDefault();
            if (isect == null)
                return Colour.Black;
            return Shade(isect, scene, depth);
        }

        private Colour GetNaturalColor(Thing thing, Vector3 pos, Vector3 norm, Vector3 rd, Scene scene) {
            Colour ret = new Colour(0, 0, 0);
            foreach (LightSource light in scene.Lights) {
                Vector3 ldis = light.Pos- pos;
                Vector3 livec = ldis.Normalized();
                double neatIsect = TestRay(new Ray(pos, livec), scene);
                bool isInShadow = !((neatIsect > ldis.Length()) || (neatIsect == 0));
                if (!isInShadow) {
                    double illum = livec.DotProduct(norm);
                    Colour lcolor = illum > 0 ? illum * light.Color : new Colour(0, 0, 0);
                    double specular = livec.DotProduct(rd.Normalized());
                    Colour scolor = specular > 0 ? Math.Pow(specular, thing.Surface.Roughness) * light.Color : new Colour(0, 0, 0);
                    ret = ret +  (thing.Surface.Diffuse(pos) * lcolor) + (thing.Surface.Specular(pos) * scolor);
                }
            }
            return ret;
        }

        private Colour GetReflectionColor(Thing thing, Vector3 pos, Vector3 norm, Vector3 rd, Scene scene, int depth) {
            return thing.Surface.Reflect(pos) * TraceRay(new Ray( pos,  rd ), scene, depth + 1);
        }

        private Colour Shade(Intersection isect, Scene scene, int depth) {
            var d = isect.Ray.Dir;
            var pos = isect.Dist * isect.Ray.Dir +  isect.Ray.Start;
            var normal = isect.Thing.CalculateNormal(pos);
            var reflectDir = d - 2 * normal.DotProduct(d) * normal;
            Colour ret = Colour.Black + GetNaturalColor(isect.Thing, pos, normal, reflectDir, scene);
            if (depth >= MaxDepth) {
                return ret + new Colour(.5, .5, .5);
            }
            return ret + GetReflectionColor(isect.Thing, pos + (.001 * reflectDir), normal, reflectDir, scene, depth);
        }

        public Colour[] Render(Scene scene) {
            Colour[] image = new Colour[screenWidth * screenHeight];
            for (int y = 0; y < screenHeight; y++)
            {
                for (int x = 0; x < screenWidth; x++)
                {
                    int index = y * screenWidth + x;
                    image[index] = TraceRay(new Ray(scene.Camera.Pos, scene.Camera.GetPoint(x, y, screenWidth, screenHeight)), scene, 0);
                }
            }
            return image;
        }
    }

}
