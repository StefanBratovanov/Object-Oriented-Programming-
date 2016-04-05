
namespace _03_CompanyHierarchy.Interfaces
{
    using System.Collections.Generic;

    public interface IDeveloper : IEmployee
    {
        IList<Project> Projects { get; set; }
    }
}
