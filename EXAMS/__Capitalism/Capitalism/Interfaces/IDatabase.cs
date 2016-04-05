

namespace Capitalism.Interfaces
{
    using Models.Interfaces;
    using System.Collections.Generic;
    using Models;

    public interface IDatabase
    {
        ICollection<Company> Companies { get; }

        IDictionary<IPaidPerson, decimal> TotalSalaries { get; }

    }
}
