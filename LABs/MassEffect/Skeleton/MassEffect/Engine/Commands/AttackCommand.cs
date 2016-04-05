

using System;
using MassEffect.Exceptions;

namespace MassEffect.Engine.Commands
{
    using Interfaces;
    using System.Linq;

    public class AttackCommand : Command
    {
        public AttackCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string attackerName = commandArgs[1];
            string targetName = commandArgs[2];

            IStarship attackerShip = null;
            IStarship targetShip = null;
            attackerShip = this.GameEngine.Starships.FirstOrDefault(s => s.Name == attackerName);
            targetShip = this.GameEngine.Starships.FirstOrDefault(s => s.Name == targetName);

            this.ProcessStarshipBattle(attackerShip, targetShip);

        }

        private void ProcessStarshipBattle(IStarship attackerShip, IStarship targetShip)
        {
            base.ValidateAlive(attackerShip);
            base.ValidateAlive(targetShip);

            if (attackerShip.Location != targetShip.Location)
            {
                throw new ShipException(Messages.NoSuchShipInStarSystem);
            }

            IProjectile attack = attackerShip.ProduceAttack();
            targetShip.RespondToAttack(attack);

            Console.WriteLine(Messages.ShipAttacked, attackerShip.Name, targetShip.Name);

            if (targetShip.Shields < 0)
            {
                targetShip.Shields = 0;
            }

            if (targetShip.Health <= 0)
            {
                targetShip.Health = 0;
                Console.WriteLine(Messages.ShipDestroyed, targetShip.Name);
            }
        }


    }
}
