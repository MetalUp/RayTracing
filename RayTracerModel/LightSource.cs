namespace RayTracer
{
    public class LightSource
    {
        public Vector3 Pos { get; private set; }
        public Color Color { get; private set; }

        public LightSource(Vector3 pos, Color color)
        {
            Pos = pos;
            Color = color;
        }
    }
}
