
namespace TestEmpiresOOP.Models.Interfaces
{
    public interface ITurnResourceProducable : IResourceProducable
    {
        bool CanProduceResource { get; }
    }
}
