namespace RayTracer
{
    public static class StandardScenes
    {
        public static readonly Scene DefaultScene = new Scene(DefaultThings(), DefaultLightSources(), DefaultCamera());

        private static IThing[] DefaultThings()
        {
            return new IThing[] {
                                new Plane(new Vector3(0,1,0),0, StandardSurfaces.CheckerBoard),
                                new Sphere(new Vector3(0,0.5,0),0.5,StandardSurfaces.Shiny),
                                new Sphere(new Vector3(1,1,1),0.2,StandardSurfaces.Matt),
                                new Sphere(new Vector3(-2,1,-1),1,StandardSurfaces.Shiny)
                                };
        }

        private static LightSource[] DefaultLightSources()
        {
            return new LightSource[] {
                                new LightSource(new Vector3(-2,2.5,0), new Color(.49,.07,.07)),
                                new LightSource(new Vector3(1.5,2.5,1.5),new Color(.07,.07,.49)),
                                new LightSource(new Vector3(1.5,2.5,-1.5),new Color(.07,.49,.071)),
                                new LightSource(new Vector3(0,3.5,0),new Color(.21,.21,.35))
                    };
        }

        private static Camera DefaultCamera()
        {
            return new Camera(new Vector3(6, 1, 1), new Vector3(0, 0, 0));
        }
    }
}
