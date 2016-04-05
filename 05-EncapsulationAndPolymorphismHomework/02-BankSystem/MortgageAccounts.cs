
namespace _02_BankSystem
{
    class MortgageAccounts : Account, IDepositable
    {
        public MortgageAccounts(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {

        }

        public void DepositSum(decimal amount)
        {
            this.Balance += amount;
        }

        public override decimal CalculateInterest(int months)
        {
            if (this.Customer is IndividualCustomer)
            {
                if (months > 6)
                {
                    return this.Balance * (1 + this.InterestRate * (months - 6));
                }

                return 0;
            }

            if (this.Customer is CompanyCustomer)
            {
                if (months > 12)
                {
                    return this.Balance * (1 + this.InterestRate * (months - 12));
                }

            }
            return this.Balance * (0.5m + this.InterestRate * (months));
        }

        public override string ToString()
        {
            return this.Customer + "Account type: Mortgage\n" +
                "Balance: " + this.Balance + "\n" +
                "Interest rate: " + this.InterestRate + "\n";
        }

    }
}
