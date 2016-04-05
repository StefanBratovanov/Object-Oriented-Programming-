using TestEmpiresOOP.Interfaces;
using TestEmpiresOOP.Models;
using TestEmpiresOOP.Models.Interfaces;

namespace TestEmpiresOOP.Execution.Factories
{
    public class ResourceFactory : IResourceFactory
    {
        public IResource CreateResource(ResourceType resourceType, int quantity)
        {
            var resource = new Resource(resourceType, quantity);

            return resource;
        }
    }
}
