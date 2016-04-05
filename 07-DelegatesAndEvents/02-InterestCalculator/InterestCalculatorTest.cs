

namespace _02_InterestCalculator
{
    using System;

    public class InterestCalculatorTest
    {
        static void Main()
        {
            InterestCalculator simpleInterest = new InterestCalculator(2500m, 7.2, 15, GetSimpleInterest);
            Console.WriteLine(simpleInterest.NewSum);

            InterestCalculator compoundInterest = new InterestCalculator(500m, 5.6, 10, GetCompoundInterest);
            Console.WriteLine(compoundInterest.NewSum);

        }

        public static decimal GetSimpleInterest(decimal sum, double interest, int years)
        {
            decimal balance = sum * (decimal)(1 + interest / 100 * years);
            return decimal.Round(balance, 4);
        }

        public static decimal GetCompoundInterest(decimal sum, double interest, int years)
        {
            decimal balance = sum * (decimal)Math.Pow(1 + (interest / 100 / 12), years * 12);
            return decimal.Round(balance, 4);
        }
    }
}
