namespace RayTracer
{
    public class LightSource
    {
        public Vector3 Pos { get; private set; }
        public Colour Color { get; private set; }

        public LightSource(Vector3 pos, Colour color)
        {
            Pos = pos;
            Color = color;
        }
    }
}
