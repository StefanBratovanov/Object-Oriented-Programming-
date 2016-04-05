
namespace Empires.Core.Factories
{

    using System;
    using Empires.Models.Units;
    using Empires.Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit ProduceUnit(string unitType)
        {
            switch (unitType)
            {
                case "Archer":
                    return new Archer();
                case "Swordsman":
                    return new Swordsman();
                default:
                    throw new ArgumentException("invalid unit type");
            }

        }
    }
}
