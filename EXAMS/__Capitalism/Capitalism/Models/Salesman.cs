

namespace Capitalism.Models
{

    public class Salesman : Employee
    {
        public Salesman(string firstName, string lastName)
            : base(firstName, lastName)
        {
        }

        public Salesman(string firstName, string lastName, Department department)
           : base(firstName, lastName, department)
        {
        }

        public override double SalaryFactor
        {
            get { return 1.015; }
        }
    }
}
