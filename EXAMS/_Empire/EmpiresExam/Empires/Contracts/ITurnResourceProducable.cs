
namespace Empires.Contracts
{
    public interface ITurnResourceProducable : IResourceProducable
    {
        bool CanProduceResource { get; }
    }
}
