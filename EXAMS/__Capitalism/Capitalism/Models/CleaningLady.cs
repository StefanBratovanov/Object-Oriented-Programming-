

namespace Capitalism.Models
{

    public class CleaningLady : Employee
    {
        public CleaningLady(string firstName, string lastName,Department department)
            : base(firstName, lastName, department)
        {
        }

        public override double SalaryFactor
        {
            get { return 0.98; }
        }

    }
}
