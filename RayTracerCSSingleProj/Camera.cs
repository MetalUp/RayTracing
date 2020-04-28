namespace RayTracer
{
    public class Camera
    {
        public Vector3 Pos;
        private Vector3 Forward;
        private Vector3 Up;
        private Vector3 Right;

        public Camera(Vector3 pos, Vector3 lookAt)
        {
            Forward = (lookAt - pos).Normalized();
            var down = new Vector3(0, -1, 0);
            Right = Forward.CrossProduct(down).Normalized() * 1.5;
            Up = Forward.CrossProduct(Right).Normalized() * 1.5;
            Pos = pos;
        }

        private double RecenterX(double x, int screenWidth)
        {
            return (x - (screenWidth / 2.0)) / (2.0 * screenWidth);
        }
        private double RecenterY(double y, int screenHeight)
        {
            return -(y - (screenHeight / 2.0)) / (2.0 * screenHeight);
        }

        public Vector3 GetPoint(double x, double y, int screenWidth, int screenHeight)
        {
            return (Forward + RecenterX(x, screenWidth) * Right + RecenterY(y, screenHeight) * Up).Normalized();
        }
    }
}
