using System;

namespace RayTracer
{
    public class Colour
    {
        private double R, G, B; 

        public Colour(double r, double g, double b) { R = r; G = g; B = b; }

        public Colour(string str)
        {
            string[] nums = str.Split(',');
            if (nums.Length != 3) throw new ArgumentException();
            R = double.Parse(nums[0]);
            G = double.Parse(nums[1]);
            B = double.Parse(nums[2]);
        }

        public static Colour operator *(double n, Colour v)
        {
            return new Colour(n * v.R, n * v.G, n * v.B);
        }
        public static Colour operator *(Colour v1, Colour v2)
        {
            return new Colour(v1.R * v2.R, v1.G * v2.G, v1.B * v2.B);
        }
        public static Colour operator +(Colour v1, Colour v2)
        {
            return new Colour(v1.R + v2.R, v1.G + v2.G, v1.B + v2.B);
        }
        public static Colour operator -(Colour v1, Colour v2)
        {
            return new Colour(v1.R - v2.R, v1.G - v2.G, v1.B - v2.B);
        }

        private byte ToByte(double d)
        {
            return Convert.ToByte(Math.Min(1,d)*255);
        }

        public byte RedByte()
        {
            return ToByte(R);
        }

        public byte GreenByte()
        {
            return ToByte(G);
        }

        public byte BlueByte()
        {
            return ToByte(B);
        }

        public static readonly Colour Red = new Colour(1, 0, 0);
        public static readonly Colour Green = new Colour(0, 1, 0);
        public static readonly Colour Blue = new Colour(0, 0, 1);
        public static readonly Colour Yellow = new Colour(1, 1, 0);
        public static readonly Colour White = new Colour(1, 1, 1);
        public static readonly Colour Black = new Colour(0, 0, 0);
    }
}
