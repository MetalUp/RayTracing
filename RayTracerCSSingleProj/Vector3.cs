using System;

namespace RayTracer
{
    public class Vector3
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }

        public Vector3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double Length()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public Vector3 Normalized()
        {
            return new Vector3(X / Length(), Y / Length(), Z / Length());
        }

        public Vector3 Plus(Vector3 other)
        {
            return new Vector3(X + other.X, Y + other.Y, Z + other.Z);
        }
        public Vector3 Minus(Vector3 other)
        {
            return new Vector3(X - other.X, Y - other.Y, Z - other.Z);
        }

        public Vector3 ScalarMultiply(double scalar)
        {
            return new Vector3(X * scalar, Y * scalar, Z * scalar);
        }

        public double DotProduct(Vector3 other)
        {
            return X * other.X + Y * other.Y + Z * other.Z;
        }

        public Vector3 CrossProduct(Vector3 other)
        {
            return new Vector3(
                Y * other.Z - Z * other.Y,
                Z * other.X - X * other.Z,
                X * other.Y - Y * other.X);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Vector3)) return false;
            var v = obj as Vector3;
            return (v.X == X) && (v.Y == Y) && (v.Z == Z);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode() + Z.GetHashCode();
        }

        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return a.Plus(b);
        }

        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return a.Minus(b);
        }

        public static Vector3 operator *(Vector3 a, Vector3 b)
        {
            return a.CrossProduct(b);
        }

        public static Vector3 operator *(Vector3 a, double b)
        {
            return a.ScalarMultiply(b);
        }
        public static Vector3 operator *(double a, Vector3 b)
        {
            return b.ScalarMultiply(a);
        }
    }
}
