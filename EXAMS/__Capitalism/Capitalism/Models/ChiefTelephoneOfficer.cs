

namespace Capitalism.Models
{

    public class ChiefTelephoneOfficer : Employee
    {
        public ChiefTelephoneOfficer(string firstName, string lastName, Department department)
            : base(firstName, lastName, department)
        {
        }

        public ChiefTelephoneOfficer(string firstName, string lastName)
            : base(firstName, lastName)
        {
        }


        public override double SalaryFactor
        {
            get { return 0.98; }
        }


    }
}
