using System;
using System.Linq;
using System.Text;
using TestEmpiresOOP.Execution.Factories;
using TestEmpiresOOP.Interfaces;
using TestEmpiresOOP.Models.Interfaces;

namespace TestEmpiresOOP.Execution
{
    public class TestCommandExecutor : ICommandExecutor
    {
        private IDatabase database;
        private IUserInterface userInterface;
        private IBuildingFactory buildingFactory;
        private IResourceFactory resourceFactory;
        private IUnitFactory unitFactory;

        public TestCommandExecutor()
        {
            this.database = new TestDatabase();
            this.buildingFactory = new BuildingFactory();
            this.unitFactory = new UnitFactory();
            this.resourceFactory = new ResourceFactory();
        }

        public string ExecuteCommand(ICommand command)
        {
            string commandResult = null;
            switch (command.Name)
            {
                case "empire-status":
                    commandResult = ExecuteStatusCommand();
                    this.UpdateBuildings();
                    break;
                case "skip":
                    this.UpdateBuildings();
                    break;
                case "build":
                    commandResult = ExecuteBuildCommand(command);
                    this.UpdateBuildings();
                    break;

                default:
                    throw new InvalidOperationException("The command name is invalid");
            }

            return commandResult;
        }

        private string ExecuteBuildCommand(ICommand command)
        {
            string buildingType = command.Parameters[0];

            IBuilding building = this.buildingFactory.CreateBuilding(buildingType, this.unitFactory, this.resourceFactory);
            this.database.AddBuilding(building);

            return null;
        }

        private string ExecuteStatusCommand()
        {
            StringBuilder output = new StringBuilder();

            AppendTreasuryInfo(output);
            AppendBuildingsInfo(output);
            AppendUnitsInfo(output);

            return output.ToString().Trim();
        }

        private void AppendUnitsInfo(StringBuilder output)
        {
            output.AppendLine("Units:");

            if (this.database.Units.Any())
            {
                foreach (var unit in this.database.Units)
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
            if (this.database.Buildings.Any())
            {
                foreach (IBuilding building in this.database.Buildings)
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
            foreach (var resource in this.database.Resources)
            {
                output.Append($"--{resource.Key}: {resource.Value}{Environment.NewLine}");
            }
        }

        private void UpdateBuildings()
        {
            foreach (IBuilding building in this.database.Buildings)
            {
                building.Upadte();
                if (building.CanProduceResource)
                {
                    var resource = building.ProdiceResource();
                    this.database.Resources[resource.ResourceType] += resource.Quantity;
                }

                if (building.CanProduceUnit)
                {
                    var unit = building.ProdiceUnit();
                    this.database.AddUnit(unit);
                }
            }
        }
    }
}
