﻿

namespace MassEffect.Engine.Commands
{
    using System;
    using System.Linq;
    using Interfaces;
    using GameObjects.Ships;
    using GameObjects.Enhancements;
    using Exceptions;

    public class CreateCommand : Command
    {
        public CreateCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string type = commandArgs[1];
            string shipName = commandArgs[2];
            string locationName = commandArgs[3];

            bool shipAlreadyExists = this.GameEngine.Starships.Any(s => s.Name == shipName);
            if (shipAlreadyExists)
            {
                throw new ShipException(Messages.DuplicateShipName);
            }

            var location = this.GameEngine.Galaxy.GetStarSystemByName(locationName);
            StarshipType shipType = (StarshipType)Enum.Parse(typeof(StarshipType), type);

            var ship = this.GameEngine.ShipFactory.CreateShip(shipType, shipName, location);
            this.GameEngine.Starships.Add(ship);

            for (var i = 4; i < commandArgs.Length; i++)
            {
                var enchantmentType = (EnhancementType)Enum.Parse(typeof(EnhancementType), commandArgs[i]);
                Enhancement enhancement = null;
                enhancement = this.GameEngine.EnhancementFactory.Create(enchantmentType);
                ship.AddEnhancement(enhancement);
            }

            Console.WriteLine(Messages.CreatedShip, shipType, shipName);
        }
    }
}
