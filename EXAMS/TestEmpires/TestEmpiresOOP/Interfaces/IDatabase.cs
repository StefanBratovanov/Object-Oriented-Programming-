
using System.Collections.Generic;
using TestEmpiresOOP.Models;
using TestEmpiresOOP.Models.Interfaces;

namespace TestEmpiresOOP.Interfaces
{
    public interface IDatabase
    {
        IEnumerable<IBuilding> Buildings { get; }

        IDictionary<string, int> Units { get; }

        IDictionary<ResourceType, int> Resources { get; }


        void AddBuilding(IBuilding building);

        void AddUnit(IUnit unit);
    }
}
