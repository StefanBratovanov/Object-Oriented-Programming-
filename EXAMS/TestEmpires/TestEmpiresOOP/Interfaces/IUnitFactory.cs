

using TestEmpiresOOP.Models.Interfaces;

namespace TestEmpiresOOP.Interfaces
{
    public interface IUnitFactory
    {
        IUnit ProduceUnit(string unitType);
    }
}
