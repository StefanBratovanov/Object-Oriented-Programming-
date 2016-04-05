using System;
using System.Collections.Generic;

using TestEmpiresOOP.Interfaces;
using TestEmpiresOOP.Models;
using TestEmpiresOOP.Models.Interfaces;

namespace TestEmpiresOOP.Execution
{
    public class TestDatabase : IDatabase
    {
        private readonly ICollection<IBuilding> buildings = new List<IBuilding>();

        public TestDatabase()
        {
            this.Resources = new Dictionary<ResourceType, int>();
            this.Units = new Dictionary<string, int>();

            this.InitResorces();
        }

        private void InitResorces()
        {
            var resTypes = Enum.GetValues(typeof(ResourceType));

            foreach (ResourceType resourceType in resTypes)
            {
                this.Resources.Add(resourceType, 0);
            }
        }

        public IEnumerable<IBuilding> Buildings
        {
            get { return this.buildings; }
        }

        public IDictionary<ResourceType, int> Resources { get; }

        public IDictionary<string, int> Units { get; }


        public void AddBuilding(IBuilding building)
        {
            if (building == null)
            {
                throw new ArgumentNullException(nameof(building));
            }

            this.buildings.Add(building);
        }

        public void AddUnit(IUnit unit)
        {
            if (unit == null)
            {
                throw new ArgumentNullException(nameof(unit));
            }

            var unitType = unit.GetType().Name;

            if (!this.Units.ContainsKey(unitType))
            {
                this.Units.Add(unitType, 0);
            }

            this.Units[unitType]++;
        }
    }
}
