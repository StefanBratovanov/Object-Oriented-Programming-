
using System;
using TestEmpiresOOP.Interfaces;
using TestEmpiresOOP.Models.Interfaces;
using TestEmpiresOOP.Models.Units;

namespace TestEmpiresOOP.Execution.Factories
{
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
