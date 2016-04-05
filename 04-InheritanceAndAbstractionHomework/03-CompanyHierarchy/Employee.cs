
namespace _03_CompanyHierarchy
{
    using System;
    using Interfaces;

    public abstract class Employee : Person, IEmployee
    {
        private decimal salary;
        private Department department;

        protected Employee(int id, string firstName, string lastName, decimal salary, Department department)
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
            this.Department = department;
        }

        public decimal Salary
        {
            get { return this.salary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Salary can not be negative.");
                }

                this.salary = value;
            }
        }

        public Department Department { get; set; }

        public override string ToString()
        {
            return base.ToString() + string.Format(", department: {0}, salary: {1}", this.Department.ToString(), this.Salary);
        }
    }
}
