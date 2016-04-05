
namespace Capitalism.Models
{

    public class Regular : Employee
    {
        public Regular(string firstName, string lastName)
            : base(firstName, lastName)
        {
        }

        public Regular(string firstName, string lastName, Department department)
            : base(firstName, lastName, department)
        {
        }
    }
}
