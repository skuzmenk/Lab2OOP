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
            Console.WriteLine("Plus: " + frac1.Plus(frac2));
            Console.WriteLine("Minus: " + frac1.Minus(frac2));
            Console.WriteLine("Multiply: " + frac1.Multiply(frac2));
            Console.WriteLine("Divide: " + frac1.Divide(frac2));
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
    }
}
