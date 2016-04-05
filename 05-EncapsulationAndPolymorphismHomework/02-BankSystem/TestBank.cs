
namespace _02_BankSystem
{
    using System;
    using System.Collections.Generic;

    public class TestBank
    {
        static void Main()
        {
            IndividualCustomer gogo = new IndividualCustomer("Goran", "Goranож", 2003147893,
               "Sofia", "55555");
            IndividualCustomer ceco = new IndividualCustomer("Cecko", "Ceckoov", 2003147894,
                "Sofia", "1121222");
            CompanyCustomer mTel = new CompanyCustomer("Mtel", 121212121,
                "Sofia, 1000", "0888 888 888");
            CompanyCustomer vivacom = new CompanyCustomer("Vivacom", 111111111,
                "Sofia, 1111", "0878 878787");

            DepostiAccounts d1 = new DepostiAccounts(gogo, 1000, 0.1m);
            DepostiAccounts d2 = new DepostiAccounts(mTel, 50000, 0.15m);

            LoanAccounts l1 = new LoanAccounts(ceco, 5500, 0.2m);
            LoanAccounts l2 = new LoanAccounts(vivacom, 90000, 0.18m);

            MortgageAccounts m1 = new MortgageAccounts(gogo, 60000, 0.12m);
            MortgageAccounts m2 = new MortgageAccounts(vivacom, 160000, 0.1m);

            Console.Write("Old balance deposit account 1: " + d1.Balance + "; ");
            d1.DepositSum(500);
            Console.WriteLine("Balance after deposit: " + d1.Balance);

            Console.Write("Old balance deposit account 2" + d2.Balance + "; ");
            d2.WithdrawSum(12500.50m);
            Console.WriteLine("Balance after withdraw: " + d2.Balance);

            Console.Write("Old balance loan account 1" + l1.Balance + "; ");
            l1.DepositSum(500);
            Console.WriteLine("Balance after deposit: " + l1.Balance);

            Console.Write("Old balance mortgage account 1" + m1.Balance + "; ");
            m1.DepositSum(10000.90m);
            Console.WriteLine("Balance after deposit: " + m1.Balance);

            Console.WriteLine();

            IList<Account> accounts = new List<Account>
            {
                d1, d2, l1, l2, m1, m2
            };

            var bank = new Bank(accounts);

            Console.WriteLine("Bank:");
            Console.WriteLine(bank);

            Console.WriteLine("Interest = {0:F2} лв", d1.CalculateInterest(6));
            Console.WriteLine("Interest = {0:F2} лв", d2.CalculateInterest(6));
            Console.WriteLine("Interest = {0:F2} лв", l1.CalculateInterest(3));
            Console.WriteLine("Interest = {0:F2} лв", l2.CalculateInterest(6));
            Console.WriteLine("Interest = {0:F2} лв", m1.CalculateInterest(6));
            Console.WriteLine("Interest = {0:F2} лв", m1.CalculateInterest(13));
            Console.WriteLine("Interest = {0:F2} лв", m2.CalculateInterest(6));
        }
    }
}
