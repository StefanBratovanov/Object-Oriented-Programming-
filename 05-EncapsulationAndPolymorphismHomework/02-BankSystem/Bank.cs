
namespace _02_BankSystem
{
    using System.Collections.Generic;

    public class Bank
    {
        public Bank(IList<Account> accounts)
        {
            this.Accounts = accounts;
        }

        public IList<Account> Accounts { get; set; }

        public override string ToString()
        {
            string result = "";
            foreach (var account in this.Accounts)
            {
                result += account + "\n";
            }

            return result;
        }
    }
}
