

namespace MassEffect.Engine.Commands
{
    using System;
    using Interfaces;
    using System.Linq;
    using GameObjects.Locations;
    using Exceptions;

    public class PlotJumpCommand : Command
    {
        public PlotJumpCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string shipName = commandArgs[1];
            string destinationName = commandArgs[2];

            IStarship ship = null;
            ship = this.GameEngine.Starships.FirstOrDefault(s => s.Name == shipName);

            this.ValidateAlive(ship);

            var previousLocation = ship.Location;
            StarSystem destionation = null;
            destionation = this.GameEngine.Galaxy.StarSystems.FirstOrDefault(ss => ss.Name == destinationName);

            if (previousLocation == destionation)
            {
                throw new ShipException(string.Format(Messages.ShipAlreadyInStarSystem, destinationName));
            }

            this.GameEngine.Galaxy.TravelTo(ship, destionation);
            Console.WriteLine(Messages.ShipTraveled, shipName, previousLocation.Name, destinationName);
        }
    }
}
