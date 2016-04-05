

using Capitalism.Models.Interfaces;

namespace Capitalism.Execution
{

    using System.Collections.Generic;
    using Models;
    using Interfaces;

    public class CapitalismDatabase : IDatabase
    {
        public CapitalismDatabase()
        {
            this.Companies = new List<Company>();
            this.TotalSalaries = new Dictionary<IPaidPerson, decimal>();
        }

        public ICollection<Company> Companies { get; private set; }

        public IDictionary<IPaidPerson, decimal> TotalSalaries { get; private set; }

    }
}
