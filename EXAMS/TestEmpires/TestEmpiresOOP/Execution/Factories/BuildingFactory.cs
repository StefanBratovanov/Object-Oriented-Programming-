
using System;
using TestEmpiresOOP.Interfaces;
using TestEmpiresOOP.Models.Buildings;
using TestEmpiresOOP.Models.Interfaces;

namespace TestEmpiresOOP.Execution.Factories
{
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
