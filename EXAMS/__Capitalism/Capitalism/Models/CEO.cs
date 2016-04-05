

namespace Capitalism.Models
{
    using Interfaces;
    using System.Collections.Generic;

    public class CEO : PaidPerson, IBoss
    {
        public CEO(string firstName, string lastName, decimal salary)
            : base(firstName, lastName)
        {
            this.Salary = salary;
            this.SubordinateEmployees = new List<Employee>();
        }

        public ICollection<Employee> SubordinateEmployees { get; }
    }
}