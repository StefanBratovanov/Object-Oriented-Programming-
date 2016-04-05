
namespace _03_CompanyHierarchy.Interfaces
{
    using System.Collections.Generic;

    public interface IManager : IEmployee
    {
        IList<Employee> EmployeesUnderComand { get; set; }
    }
}
