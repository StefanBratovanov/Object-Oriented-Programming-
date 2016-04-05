

namespace Empires.Core.Factories
{
    using Empires.Models;
    using Empires.Contracts;
    using Empires.Enums;
    using System.ComponentModel;

    public class ResourceFactory : IResourceFactory
    {
        public IResource CreateResource(ResourceType resourceType, int quantity)
        {
            var resource = new Resource(resourceType, quantity);

            return resource;
        }
    }
}
