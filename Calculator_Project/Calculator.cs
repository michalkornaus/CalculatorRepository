using System;

namespace Kalkulator
{
    public delegate double Calc(double a, double b);
    class Calculator
    {
        public static double Add(double a, double b)
        {
            return a + b;
        }
        public static double Substract(double a, double b)
        {
            return a - b;
        }
        public static double Multiply(double a, double b)
        {
            return a * b;
        }
        public static double Divide(double a, double b)
        {
            return a / b;
        }
        public static double Square(double a, double b)
        {
            return Math.Sqrt(a);
        }
        public static double Negation(double a, double b)
        {
            return -a;
        }
        public static double PowerOfTwo(double a, double b)
        {
            return a*a;
        }
    }
}
