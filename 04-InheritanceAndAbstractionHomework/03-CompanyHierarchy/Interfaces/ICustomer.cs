
namespace _03_CompanyHierarchy.Interfaces
{
    public interface ICustomer : IPerson
    {
        decimal NetPurchaseAmount { get; set; }
    }
}
