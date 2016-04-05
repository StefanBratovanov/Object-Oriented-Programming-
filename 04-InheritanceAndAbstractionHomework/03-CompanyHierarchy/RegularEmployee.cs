namespace _03_CompanyHierarchy
{
    public abstract class RegularEmployee : Employee
    {
        public RegularEmployee(int id, string firstName, string lastName, decimal salary, Department department)
            : base(id, firstName, lastName, salary, department)
        {

        }
    }
}
