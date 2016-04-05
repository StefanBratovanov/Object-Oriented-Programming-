
namespace Empires.Core.Factories
{
    using System;
    using Empires.Contracts;
    using Empires.Models.Buildings;

    public class BuildingFactory : IBuildingFactory
    {
        public IBuilding CreateBuilding(string buildingType, IUnitFactory unitFactory, IResourceFactory resourceFactory)
        {
            switch (buildingType)
            {
                case "archery":
                    return new Archery(unitFactory, resourceFactory);
                case "barracks":
                    return new Barracks(unitFactory, resourceFactory);
                default:
                    throw new ArgumentException("invalid building type");
            }
        }
    }
}
