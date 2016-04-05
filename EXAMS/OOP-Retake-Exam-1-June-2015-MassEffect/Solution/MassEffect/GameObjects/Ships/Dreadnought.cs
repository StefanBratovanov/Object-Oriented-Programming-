namespace MassEffect.GameObjects.Ships
{
    using MassEffect.Interfaces;
    using MassEffect.GameObjects.Locations;
    using MassEffect.GameObjects.Projectiles;

    public class Dreadnought : Starship
    {
        public Dreadnought(string name, StarSystem location)
            : base(name, 200, 300, 150, 700, location)
        {
        }

        public override IProjectile ProduceAttack()
        {
            int damageCoefficient = (this.Shields / 2) + this.Damage;
            
            return new Laser(damageCoefficient);
        }

        public override void RespondToAttack(IProjectile attack)
        {
            this.Shields += 50;

            base.RespondToAttack(attack);

            this.Shields -= 50;
        }
    }
}
