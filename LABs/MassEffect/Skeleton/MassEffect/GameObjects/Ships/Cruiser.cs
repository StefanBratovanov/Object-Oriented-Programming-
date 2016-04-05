﻿

namespace MassEffect.GameObjects.Ships
{
    using Locations;
    using Interfaces;
    using Projectiles;

    public class Cruiser : Starship
    {
        public Cruiser(string name, StarSystem location)
            : base(name, 100, 100, 50, 300, location)
        {

        }

        public override IProjectile ProduceAttack()
        {
            return new PenetrationShell(this.Damage);
        }
    }
}
