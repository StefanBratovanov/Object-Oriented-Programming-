﻿
using Empires.Contracts;
using Empires.Enums;

namespace Empires.Models.Buildings
{
    public class Barracks : Building
    {
        private const string BarracksUnitType = "Swordsman";
        private const int BarracksUnitCycleLength = 4;
        private const ResourceType BarracksResourceType = ResourceType.Steel;
        private const int BarracksResourceCycleLength = 3;
        private const int BarracksResourceQuantity = 10;


        public Barracks(IUnitFactory unitFactory, IResourceFactory resourceFactory)
            : base(BarracksUnitType,
                  BarracksUnitCycleLength,
                  BarracksResourceType,
                  BarracksResourceCycleLength,
                  BarracksResourceQuantity,
                  unitFactory,
                  resourceFactory)
        {
        }

    }
}
