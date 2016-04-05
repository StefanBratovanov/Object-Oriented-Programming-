
namespace _02_FractionCalculator
{
    using System;

    class CalculatorTest
    {
        static void Main(string[] args)
        {
            Fraction fraction1 = new Fraction(22, 7);
            Fraction fraction2 = new Fraction(40, 4);
            Fraction result = fraction1 + fraction2;
            Console.WriteLine(result.Numerator);
            Console.WriteLine(result.Denominator);
            Console.WriteLine(result);

            Console.WriteLine();

            Fraction result1 = fraction1 - fraction2;
            Console.WriteLine(result1.Numerator);
            Console.WriteLine(result1.Denominator);
            Console.WriteLine(result1);

        }
    }
}
