
namespace _02_FractionCalculator
{
    using System;
    using System.Numerics;

    public struct Fraction
    {
        private long denominator;

        public Fraction(long numerator, long denominator)
            : this()
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public long Numerator { get; set; }

        public long Denominator
        {
            get { return this.denominator; }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Denomerator cannot be 0");
                }

                this.denominator = value;
            }
        }


        public static Fraction operator +(Fraction a, Fraction b)
        {
            var commonNumerator = ((BigInteger)a.Numerator * b.Denominator) + ((BigInteger)a.Denominator * b.Numerator);
            var commonDenominator = (BigInteger)a.Denominator * b.Denominator;

            var gcd = GreatestCommonDivisor(commonNumerator, commonDenominator);

            if (gcd > 1)
            {
                commonNumerator /= gcd;
                commonDenominator /= gcd;
            }

            if (commonNumerator < long.MinValue || long.MaxValue < commonNumerator)
            {
                throw new ArithmeticException("Numerator of resulting fraction is either too large or too small.");
            }

            if (commonDenominator > long.MaxValue)
            {
                throw new ArithmeticException("Denominator of resulting fraction is too large.");
            }

            return new Fraction((long)commonNumerator, (long)commonDenominator);
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            var result = a + new Fraction(b.Numerator * -1, b.Denominator);
            return result;
        }


        public override string ToString()
        {
            return (double)this.Numerator / this.Denominator + "";
        }

        private static long GreatestCommonDivisor(BigInteger numerator, BigInteger denominator)
        {
            if (numerator < 0)
            {
                numerator *= -1;
            }

            if (denominator < 0)
            {
                denominator *= -1;
            }

            while (denominator != 0)
            {
                var tempDenominator = denominator;
                denominator = numerator % denominator;
                numerator = tempDenominator;
            }

            return (long)numerator;
        }
    }
}
