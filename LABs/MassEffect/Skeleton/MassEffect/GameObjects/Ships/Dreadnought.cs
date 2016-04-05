
namespace MassEffect.GameObjects.Ships
{
    using Locations;
    using Projectiles;
    using Interfaces;

    public class Dreadnought : Starship
    {
        public Dreadnought(string name, StarSystem location)
            : base(name, 200, 300, 150, 700, location)
        {

        }

        public override IProjectile ProduceAttack()
        {
            return new Laser(this.Damage + this.Shields / 2);
        }

        public override void RespondToAttack(IProjectile attack)
        {
            this.Shields += 50;

            base.RespondToAttack(attack);

            this.Shields -= 50;

        }
    }
}
