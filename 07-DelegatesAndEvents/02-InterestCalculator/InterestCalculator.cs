

namespace _02_InterestCalculator
{
    using System;

    public class InterestCalculator
    {

        public delegate decimal CalculateInterest(decimal sum, double interest, int years);
        private double interest;
        private int years;
        private CalculateInterest calculationType;

        public InterestCalculator(decimal sum, double interest, int years, CalculateInterest calculationType)
        {
            this.Sum = sum;
            this.Interest = interest;
            this.Years = years;
            this.calculationType = calculationType;
        }

        public decimal Sum { get; private set; }

        public double Interest
        {
            get { return this.interest; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Interest", "Interest must be possitive.");
                }
                this.interest = value;
            }
        }

        public int Years
        {
            get { return this.years; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Years", "Years must be possitive.");
                }
                this.years = value;
            }
        }

        public decimal NewSum
        {
            get { return this.calculationType(this.Sum, this.Interest, this.Years); }
        }
    }
}
