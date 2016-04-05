

namespace Empires.Contracts
{
    public interface ITurnUnitProducable : IUnitProducable
    {
        bool CanProduceUnit { get; }
    }
}
