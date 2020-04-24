using System.Windows.Media.Media3D;
namespace RayTracer
{
    public class Camera
    {
        public Vector3 Pos;
        public Vector3 Forward;
        public Vector3 Up;
        public Vector3 Right;

        public Camera(Vector3 pos, Vector3 lookAt)
        {
            Forward = (lookAt - pos).Normalized();
            var down = new Vector3(0, -1, 0);
            Right = Forward.CrossProduct(down).Normalized() * 1.5;
            Up = Forward.CrossProduct(Right).Normalized() * 1.5;
            Pos = pos;
        }
    }
}
