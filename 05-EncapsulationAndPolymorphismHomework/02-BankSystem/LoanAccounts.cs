
namespace _02_BankSystem
{
    public class LoanAccounts : Account, IDepositable
    {
        public LoanAccounts(Customer customer, decimal balance, decimal interestRate)
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
                if (months > 3 && this.Balance >= 1000)
                {
                    return this.Balance * (1 + this.InterestRate * (months - 3));
                }
            }

            if (this.Customer is CompanyCustomer)
            {
                if (months > 2 && this.Balance >= 1000)
                {
                    return this.Balance * (1 + this.InterestRate * (months - 2));
                }
            }

            return 0;
        }

        public override string ToString()
        {
            return this.Customer + "Account type: Loan\n" +
                "Balance: " + this.Balance + "\n" +
                "Interest rate: " + this.InterestRate + "\n";
        }
    }
}
