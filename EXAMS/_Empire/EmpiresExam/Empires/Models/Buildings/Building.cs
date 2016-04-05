

namespace Empires.Models.Buildings
{
    using System;
    using Empires.Contracts;
    using Empires.Enums;

    public abstract class Building : IBuilding
    {
        private const int ProductionDelay = 1;
        private int cyclesCount = 0;

        private string unitType;
        private int unitCycleLength;
        private ResourceType resourceType;
        private int resourceCycleLength;
        private int resourceQuantity;
        private IUnitFactory unitFactory;
        private IResourceFactory resourceFactory;

        protected Building(string unitType, int unitCycleLength, ResourceType resourceType, int resourceCycleLength,
                           int resourceQuantity, IUnitFactory unitFactory, IResourceFactory resourceFactory)
        {
            this.unitType = unitType;
            this.UnitCycleLength = unitCycleLength;
            this.resourceType = resourceType;
            this.ResourceCycleLength = resourceCycleLength;
            this.ResourceQuantity = resourceQuantity;
            this.unitFactory = unitFactory;
            this.resourceFactory = resourceFactory;
        }

        public bool CanProduceUnit
        {
            get
            {
                bool canProduceUnit = this.cyclesCount > ProductionDelay && (this.cyclesCount - ProductionDelay) % this.unitCycleLength == 0;
                return canProduceUnit;
            }
        }

        public bool CanProduceResource
        {
            get
            {
                bool CanProduceResource = this.cyclesCount > ProductionDelay && (this.cyclesCount - ProductionDelay) % this.resourceCycleLength == 0;
                return CanProduceResource;
            }
        }

        private int UnitCycleLength
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.unitCycleLength),
                        "The length of the production cycle for units should be positive.");
                }

                this.unitCycleLength = value;
            }
        }

        private int ResourceCycleLength
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.resourceCycleLength),
                        "The length of the production cycle for units should be positive.");
                }

                this.resourceCycleLength = value;
            }
        }

        private int ResourceQuantity
        {
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.resourceQuantity),
                        "The resource quantity produced by the building cannot be negative.");
                }

                this.resourceQuantity = value;
            }
        }


        public IUnit ProdiceUnit()
        {
            var unit = this.unitFactory.ProduceUnit(this.unitType);
            return unit;
        }

        public IResource ProdiceResource()
        {
            var resource = this.resourceFactory.CreateResource(this.resourceType, this.resourceQuantity);
            return resource;
        }

        public void Upadte()
        {
            this.cyclesCount++;
        }

        public override string ToString()
        {
            int turnsUntilUnit = this.unitCycleLength - (this.cyclesCount - ProductionDelay) % this.unitCycleLength;
            int turnsUntilResource = this.resourceCycleLength - (this.cyclesCount - ProductionDelay) % this.resourceCycleLength;



            var result = string.Format("--{0}: {1} turns ({2} turns until {3}, {4} turns until {5})",
                this.GetType().Name,
                this.cyclesCount - ProductionDelay,
                turnsUntilUnit,
                this.unitType,
                turnsUntilResource,
                this.resourceType);

            return result;
        }
    }
}
