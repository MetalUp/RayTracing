using System;

namespace RayTracer
{
public class Colour
{
    private double R, G, B; 

    public Colour(double r, double g, double b) {
        R = r;
        G = g;
        B = b;
    }

        public Colour(string str)
        {
            string[] nums = str.Split(',');
            if (nums.Length != 3) throw new ArgumentException();
            R = double.Parse(nums[0]);
            G = double.Parse(nums[1]);
            B = double.Parse(nums[2]);
        }

        public Colour MultiplyBy(double n)
        {
            return new Colour(n * R, n * G, n * B);
        }
        public Colour MultiplyBy(Colour c2)
        {
            return new Colour(R * c2.R, G * c2.G, B * c2.B);
        }
        public Colour Plus(Colour c2)
        {
            return new Colour(R + c2.R, G + c2.G, B + c2.B);
        }
        public Colour Minus(Colour c2)
        {
            return new Colour(R - c2.R, G - c2.G, B - c2.B);
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

        #region Operators
        public static Colour operator *(double n, Colour c1)
        {
            return c1.MultiplyBy(n);
        }
        public static Colour operator *(Colour c1, Colour c2)
        {
            return c1.MultiplyBy(c2);
        }
        public static Colour operator +(Colour c1, Colour c2)
        {
            return c1.Plus(c2);
        }
        public static Colour operator -(Colour c1, Colour c2)
        {
            return c1.Minus(c2);
        }
        #endregion
    }
}
