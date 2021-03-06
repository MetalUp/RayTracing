﻿namespace RayTracer
{
    public static class StandardScenes
    {
        public static readonly Scene DefaultScene = new Scene(DefaultThings(), DefaultLightSources(), DefaultCamera());

        private static Thing[] DefaultThings()
        {
            return new Thing[] {
                                new Floor(StandardSurfaces.CheckerBoard),
                                new Sphere(new Vector3(0,0.5,0),0.5,StandardSurfaces.Shiny),
                                new Sphere(new Vector3(1,1,1),0.2,StandardSurfaces.Matt),
                                new Sphere(new Vector3(-2,1,-1),1,StandardSurfaces.Shiny)
                                };
        }

        private static LightSource[] DefaultLightSources()
        {
            return new LightSource[] {
                                new LightSource(new Vector3(-2,2.5,0), new Colour(.49,.07,.07)),
                                new LightSource(new Vector3(1.5,2.5,1.5),new Colour(.07,.07,.49)),
                                new LightSource(new Vector3(1.5,2.5,-1.5),new Colour(.07,.49,.071)),
                                new LightSource(new Vector3(0,3.5,0),new Colour(.21,.21,.35))
                    };
        }

        private static Camera DefaultCamera()
        {
            return new Camera(new Vector3(0, 1, -6), new Vector3(0, 0, 0));
        }
    }
}
