using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2b2
{
    internal class Program
    {
        public class MyFrac
        {
            public int Numerator { get; private set; }
            public int Denominator { get; private set; }
            public MyFrac(int numerator, int denominator)
            {
                if (denominator == 0)
                {
                    throw new ArgumentException("Denominator cannot be zero.");
                }

                if (denominator < 0)
                {
                    numerator = -numerator;
                    denominator = -denominator;
                }

                int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
                Numerator = numerator / gcd;
                Denominator = denominator / gcd;
            }
            private int GCD(int a, int b)
            {
                while (b != 0)
                {
                    int t = b;
                    b = a % b;
                    a = t;
                }
                return a;
            }
        }
        static void Main(string[] args)
        {
        }
    }
}
