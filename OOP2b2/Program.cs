using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2b2
{
    internal class Program
    {
        private static MyFrac Input()
        {
            Console.WriteLine("Enter the numerator:");
            int numerator = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the denominator:");
            int denominator = Convert.ToInt32(Console.ReadLine());
            return new MyFrac(numerator, denominator);
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter first fraction");
            MyFrac frac1 = Input();
            Console.WriteLine("Enter second fraction");
            MyFrac frac2 = Input();

            Console.WriteLine("Fraction 1: " + frac1);
            Console.WriteLine("Fraction 2: " + frac2);

            Console.WriteLine("Fraction 1 with integer part: " + frac1.ToStringWithIntegerPart());
            Console.WriteLine("Fraction 2 with integer part: " + frac2.ToStringWithIntegerPart());

            Console.WriteLine("Fraction 1 as double: " + frac1.DoubleValue());
            Console.WriteLine("Fraction 2 as double: " + frac2.DoubleValue());
           
            Console.WriteLine("Plus: " + frac1.Plus(frac2));
            Console.WriteLine("Minus: " + frac1.Minus(frac2));
           
            Console.WriteLine("Multiply: " + frac1.Multiply(frac2));
            Console.WriteLine("Divide: " + frac1.Divide(frac2));

            Console.WriteLine("Series 1 result up to numerator of fraction 1: " + MyFrac.CalculateSeries1(frac1.Numerator));
            Console.WriteLine("Series 2 result up to numerator of fraction 2: " + MyFrac.CalculateSeries2(frac2.Numerator));

            Console.ReadLine();
        }
    }

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

        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int t = b;
                b = a % b;
                a = t;
            }
            return a;
        }
        
        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }
        public string ToStringWithIntegerPart()
        {
            int intPart = Numerator / Denominator;
            MyFrac remainingFrac = new MyFrac(Numerator % Denominator, Denominator);
            if (intPart >= 0)
            {
                return $"{intPart}+{remainingFrac}";
            }
            return $"{intPart}{remainingFrac}";
        }

        public double DoubleValue()
        {
            return (double)Numerator / Denominator;
        }
        public MyFrac Plus(MyFrac other)
        {
            int newNumerator = Numerator * other.Denominator + Denominator * other.Numerator;
            int newDenominator = Denominator * other.Denominator;
            return new MyFrac(newNumerator, newDenominator);
        }

        public MyFrac Minus(MyFrac other)
        {
            int newNumerator = Numerator * other.Denominator - Denominator * other.Numerator;
            int newDenominator = Denominator * other.Denominator;
            return new MyFrac(newNumerator, newDenominator);
        }
        public MyFrac Multiply(MyFrac other)
        {
            int newNumerator = Numerator * other.Numerator;
            int newDenominator = Denominator * other.Denominator;
            return new MyFrac(newNumerator, newDenominator);
        }

        public MyFrac Divide(MyFrac other)
        {
            if (other.Numerator == 0)
            {
                throw new DivideByZeroException("Cannot divide by a fraction with zero numerator.");
            }
            int newNumerator = Numerator * other.Denominator;
            int newDenominator = Denominator * other.Numerator;
            return new MyFrac(newNumerator, newDenominator);
        }
        public static MyFrac CalculateSeries1(int n)
        {
            MyFrac result = new MyFrac(0, 1);
            for (int i = 1; i <= n; i++)
            {
                MyFrac plus = new MyFrac(1, i * (i + 1));
                result = result.Plus(plus);
            }
            return result;
        }

        public static MyFrac CalculateSeries2(int n)
        {
            MyFrac result = new MyFrac(1, 1);
            for (int i = 2; i <= n; i++)
            {
                MyFrac minus = new MyFrac(1, i * i);
                result = result.Multiply(new MyFrac(1, 1).Minus(minus));
            }
            return result;
        }
    }
}
