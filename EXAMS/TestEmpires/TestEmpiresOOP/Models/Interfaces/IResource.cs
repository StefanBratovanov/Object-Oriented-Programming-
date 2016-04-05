
using System.Security.AccessControl;

namespace TestEmpiresOOP.Models.Interfaces
{
    public interface IResource
    {
        ResourceType ResourceType { get; }

        int Quantity { get; }
    }
}
