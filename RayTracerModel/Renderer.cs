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

        private IEnumerable<Intersection> Intersections(Ray ray, Scene scene)
        {
            return scene.Things
                        .Select(obj => obj.CalculateIntersection(ray))
                        .Where(inter => inter != null)
                        .OrderBy(inter => inter.Dist);
        }

        private double TestRay(Ray ray, Scene scene) {
            var isects = Intersections(ray, scene);
            Intersection isect = isects.FirstOrDefault();
            if (isect == null)
                return 0;
            return isect.Dist;
        }

        private Color TraceRay(Ray ray, Scene scene, int depth) {
            var isects = Intersections(ray, scene);
            Intersection isect = isects.FirstOrDefault();
            if (isect == null)
                return Color.Background;
            return Shade(isect, scene, depth);
        }

        private Color GetNaturalColor(IThing thing, Vector3 pos, Vector3 norm, Vector3 rd, Scene scene) {
            Color ret = new Color(0, 0, 0);
            foreach (LightSource light in scene.Lights) {
                Vector3 ldis = light.Pos- pos;
                Vector3 livec = ldis.Normalized();
                double neatIsect = TestRay(new Ray(pos, livec), scene);
                bool isInShadow = !((neatIsect > ldis.Length()) || (neatIsect == 0));
                if (!isInShadow) {
                    double illum = livec.DotProduct(norm);
                    Color lcolor = illum > 0 ? illum * light.Color : new Color(0, 0, 0);
                    double specular = livec.DotProduct(rd.Normalized());
                    Color scolor = specular > 0 ? Math.Pow(specular, thing.Surface.Roughness) * light.Color : new Color(0, 0, 0);
                    ret = ret +  (thing.Surface.Diffuse(pos) * lcolor) + (thing.Surface.Specular(pos) * scolor);
                }
            }
            return ret;
        }

        private Color GetReflectionColor(IThing thing, Vector3 pos, Vector3 norm, Vector3 rd, Scene scene, int depth) {
            return thing.Surface.Reflect(pos) * TraceRay(new Ray( pos,  rd ), scene, depth + 1);
        }

        private Color Shade(Intersection isect, Scene scene, int depth) {
            var d = isect.Ray.Dir;
            var pos = isect.Dist * isect.Ray.Dir +  isect.Ray.Start;
            var normal = isect.Thing.CalculateNormal(pos);
            var reflectDir = d - 2 * normal.DotProduct(d) * normal;
            Color ret = Color.DefaultColor;
            ret = ret + GetNaturalColor(isect.Thing, pos, normal, reflectDir, scene);
            if (depth >= MaxDepth) {
                return ret + new Color(.5, .5, .5);
            }
            return ret + GetReflectionColor(isect.Thing, pos + (.001 * reflectDir), normal, reflectDir, scene, depth);
        }

        private double RecenterX(double x) {
            return (x - (screenWidth / 2.0)) / (2.0 * screenWidth);
        }
        private double RecenterY(double y) {
            return -(y - (screenHeight / 2.0)) / (2.0 * screenHeight);
        }

        private Vector3 GetPoint(double x, double y, Camera camera) {
            return (camera.Forward + RecenterX(x)*camera.Right + RecenterY(y)* camera.Up).Normalized();
        }

        public Color[] Render(Scene scene) {
            Color[] image = new Color[screenWidth * screenHeight];
            for (int y = 0; y < screenHeight; y++)
            {
                for (int x = 0; x < screenWidth; x++)
                {
                    int index = y * screenWidth + x;
                    image[index] = TraceRay(new Ray(scene.Camera.Pos, GetPoint(x, y, scene.Camera)), scene, 0);
                }
            }
            return image;
        }
    }

}
