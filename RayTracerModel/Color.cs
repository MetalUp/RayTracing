using System;

namespace RayTracer
{
    public class Color
    {
        private double R, G, B; 
        //Constructors
        public Color(double r, double g, double b) { R = r; G = g; B = b; }
        public Color(string str)
        {
            string[] nums = str.Split(',');
            if (nums.Length != 3) throw new ArgumentException();
            R = double.Parse(nums[0]);
            G = double.Parse(nums[1]);
            B = double.Parse(nums[2]);
        }

        public static readonly Color Background = new Color(0, 0, 0);
        public static readonly Color DefaultColor = new Color(0, 0, 0);

        // 'operators' allow use of  +,-,*, instead of conventional method signatures
        // like 'add(...), subtract(...)'. They are static and hence must take two parameters
        public static Color operator *(double n, Color v)
        {
            return new Color(n * v.R, n * v.G, n * v.B);
        }
        public static Color operator *(Color v1, Color v2)
        {
            return new Color(v1.R * v2.R, v1.G * v2.G, v1.B * v2.B);
        }
        public static Color operator +(Color v1, Color v2)
        {
            return new Color(v1.R + v2.R, v1.G + v2.G, v1.B + v2.B);
        }
        public static Color operator -(Color v1, Color v2)
        {
            return new Color(v1.R - v2.R, v1.G - v2.G, v1.B - v2.B);
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
