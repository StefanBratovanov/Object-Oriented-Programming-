
namespace _03_CompanyHierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;

    public class Manager : Employee, IManager
    {
        private IList<Employee> employeesUnderComand;

        public Manager(int id, string firstName, string lastName, decimal salary, Department department, IList<Employee> employeesUnderComand)
            : base(id, firstName, lastName, salary, department)
        {
            this.EmployeesUnderComand = employeesUnderComand;
        }

        public IList<Employee> EmployeesUnderComand
        {
            get { return new List<Employee>(this.employeesUnderComand); }
            set
            {
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentException("List of emplyees can not be null or empty.");
                }
                this.employeesUnderComand = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Employees under command: ");
            foreach (var e in this.EmployeesUnderComand)
            {
                sb.AppendLine(e.FirstName + " " + e.LastName);
            }
            return sb.ToString();
        }
    }
}
