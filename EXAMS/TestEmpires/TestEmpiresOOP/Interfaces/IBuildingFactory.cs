
using TestEmpiresOOP.Models.Interfaces;

namespace TestEmpiresOOP.Interfaces
{
    public interface IBuildingFactory
    {
        IBuilding CreateBuilding(string buildingType, IUnitFactory unitFactory, IResourceFactory resourceFactory);
    }
}
