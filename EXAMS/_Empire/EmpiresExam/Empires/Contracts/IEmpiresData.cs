

namespace Empires.Contracts
{
    using System.Collections.Generic;
    using Enums;

    public interface IEmpiresData
    {
        IEnumerable<IBuilding> Buildings { get; }

        IDictionary<string, int> Units { get; }

        IDictionary<ResourceType, int> Resources { get; }


        void AddBuilding(IBuilding building);

        void AddUnit(IUnit unit);
    }
}
