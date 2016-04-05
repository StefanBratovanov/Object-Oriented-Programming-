namespace _03_CompanyHierarchy.Interfaces
{
    public interface IEmployee : IPerson
    {
        decimal Salary { get; set; }
        Department Department { get; set; }
    }
}
