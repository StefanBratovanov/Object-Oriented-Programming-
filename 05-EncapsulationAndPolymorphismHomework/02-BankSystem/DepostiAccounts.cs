
namespace _02_BankSystem
{
    public class DepostiAccounts : Account, IDepositable, IWhithdrawable
    {
        public DepostiAccounts(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {

        }

        public void DepositSum(decimal amount)
        {
            this.Balance += amount;
        }

        public void WithdrawSum(decimal amount)
        {
            this.Balance -= amount;
        }

        public override decimal CalculateInterest(int months)
        {
            if (this.Balance >= 1000)
            {
                return this.Balance * (1 + this.InterestRate * months);
            }
            return 0;
        }

        public override string ToString()
        {
            return this.Customer + "Account type: Deposit\n" +
                "Balance: " + this.Balance + "\n" +
                "Interest rate: " + this.InterestRate + "\n";
        }
    }
}
