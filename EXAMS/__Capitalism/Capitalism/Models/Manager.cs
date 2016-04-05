

namespace Capitalism.Models
{
    using Interfaces;
    using System.Collections.Generic;

    public class Manager : Employee, IBoss
    {
        public Manager(string firstName, string lastName)
           : this(firstName, lastName, null)
        {
        }

        public Manager(string firstName, string lastName, Department department)
            : base(firstName, lastName, department)
        {
            this.SubordinateEmployees = new List<Employee>();
        }

        public ICollection<Employee> SubordinateEmployees { get; }
    }
}