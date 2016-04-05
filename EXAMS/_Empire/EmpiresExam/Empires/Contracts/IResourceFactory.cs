

namespace Empires.Contracts
{
    using Empires.Enums;

    public interface IResourceFactory
    {
        IResource CreateResource(ResourceType resourceType, int quantity);
    }
}
