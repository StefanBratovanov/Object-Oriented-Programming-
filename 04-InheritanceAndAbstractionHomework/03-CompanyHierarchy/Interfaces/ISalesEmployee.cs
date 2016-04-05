
namespace _03_CompanyHierarchy.Interfaces
{
    using System.Collections.Generic;

    public interface ISalesEmployee : IEmployee
    {
        IList<Sale> Sales { get; set; }
    }
}
