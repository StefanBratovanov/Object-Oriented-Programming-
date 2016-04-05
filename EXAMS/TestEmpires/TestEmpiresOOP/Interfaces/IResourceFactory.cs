


using TestEmpiresOOP.Models;
using TestEmpiresOOP.Models.Interfaces;

namespace TestEmpiresOOP.Interfaces
{
    public interface IResourceFactory
    {
        IResource CreateResource(ResourceType resourceType, int quantity);
    }
}
