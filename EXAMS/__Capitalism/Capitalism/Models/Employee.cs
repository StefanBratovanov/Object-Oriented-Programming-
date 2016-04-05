
namespace Capitalism.Models
{
    using Interfaces;

    public class Employee : PaidPerson, IEmployee
    {
        public Employee(string firstName, string lastName,  Department department)
            : base(firstName, lastName)
        {
            this.Department = department;
        }

        //employee with no department(directly in the company)
        public Employee(string firstName, string lastName)
            : this(firstName, lastName, null)
        {
        }

        public virtual double SalaryFactor
        {
            get { return 1; }
        }

        public Department Department { get; set; }

    }
}
