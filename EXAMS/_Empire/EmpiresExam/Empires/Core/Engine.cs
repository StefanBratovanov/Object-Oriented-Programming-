

using System;
using System.Linq;
using System.Text;

namespace Empires.Core
{
    using Empires.Contracts;

    public class Engine : IRunnable
    {
        private IBuildingFactory buildingFactory;
        private IResourceFactory resourceFactory;
        private IUnitFactory unitFactory;
        private IEmpiresData data;
        private IInputReader reader;
        private IOutputWriter writer;

        public Engine(IBuildingFactory buildingFactory,
                    IResourceFactory resourceFactory,
                    IUnitFactory unitFactory,
                    IEmpiresData data,
                    IInputReader reader,
                    IOutputWriter writer)
        {
            this.buildingFactory = buildingFactory;
            this.resourceFactory = resourceFactory;
            this.unitFactory = unitFactory;
            this.data = data;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            while (true)
            {
                string[] input = this.reader.ReadLine().Split();

                this.ExacuteCommand(input);
                this.UpdateBuildings();

            }
        }

        private void UpdateBuildings()
        {
            foreach (IBuilding building in this.data.Buildings)
            {
                building.Upadte();
                if (building.CanProduceResource)
                {
                    var resource = building.ProdiceResource();
                    this.data.Resources[resource.ResourceType] += resource.Quantity;
                }

                if (building.CanProduceUnit)
                {
                    var unit = building.ProdiceUnit();
                    this.data.AddUnit(unit);
                }
            }
        }

        private void ExacuteCommand(string[] inputParams)
        {
            switch (inputParams[0])
            {
                case "empire-status":
                    this.ExecuteStatusCommand();
                    break;
                case "armistice":
                    Environment.Exit(0);
                    break;
                case "skip":
                    break;
                case "build":
                    this.ExecuteBuildCommand(inputParams[1]);
                    break;
                default:
                    throw new ArgumentException("Unknown command");
            }
        }

        private void ExecuteBuildCommand(string buildingType)
        {
            IBuilding building = this.buildingFactory.CreateBuilding(buildingType, this.unitFactory, this.resourceFactory);
            this.data.AddBuilding(building);
        }

        private void ExecuteStatusCommand()
        {
            StringBuilder output = new StringBuilder();

            AppendTreasuryInfo(output);
            AppendBuildingsInfo(output);
            AppendUnitsInfo(output);

            this.writer.Print(output.ToString().Trim());
        }

        private void AppendUnitsInfo(StringBuilder output)
        {
            output.AppendLine("Units:");

            if (this.data.Units.Any())
            {
                foreach (var unit in this.data.Units)
                {
                    output.Append($"--{unit.Key}: {unit.Value}{Environment.NewLine}");
                }
            }
            else
            {
                output.AppendLine("N/A");
            }
        }

        private void AppendBuildingsInfo(StringBuilder output)
        {
            output.AppendLine("Buildings:");
            if (this.data.Buildings.Any())
            {
                foreach (IBuilding building in this.data.Buildings)
                {
                    //TODO : override
                    output.AppendLine(building.ToString());
                }
            }
            else
            {
                output.AppendLine("N/A");
            }
        }

        private void AppendTreasuryInfo(StringBuilder output)
        {
            output.AppendLine("Treasury: ");
            foreach (var resource in this.data.Resources)
            {
                output.Append($"--{resource.Key}: {resource.Value}{Environment.NewLine}");
            }
        }
    }
}
