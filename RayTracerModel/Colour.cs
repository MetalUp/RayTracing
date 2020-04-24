using System;

namespace RayTracer
{
    public class Colour
    {
        private double R, G, B; 
        //Constructors
        public Colour(double r, double g, double b) { R = r; G = g; B = b; }
        public Colour(string str)
        {
            string[] nums = str.Split(',');
            if (nums.Length != 3) throw new ArgumentException();
            R = double.Parse(nums[0]);
            G = double.Parse(nums[1]);
            B = double.Parse(nums[2]);
        }

        public static readonly Colour Background = new Colour(0, 0, 0);
        public static readonly Colour DefaultColor = new Colour(0, 0, 0);

        // 'operators' allow use of  +,-,*, instead of conventional method signatures
        // like 'add(...), subtract(...)'. They are static and hence must take two parameters
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
    }
}
