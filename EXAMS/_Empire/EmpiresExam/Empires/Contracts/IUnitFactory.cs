

namespace Empires.Contracts
{
    public interface IUnitFactory
    {
        IUnit ProduceUnit(string unitType);
    }
}
