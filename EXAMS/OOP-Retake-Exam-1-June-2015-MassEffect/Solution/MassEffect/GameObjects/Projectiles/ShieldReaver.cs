namespace MassEffect.GameObjects.Projectiles
{
    using MassEffect.Interfaces;

    public class ShieldReaver : Projectile
    {
        public ShieldReaver(int damage)
            : base(damage)
        {
        }

        public override void Hit(IStarship targetShip)
        {
            targetShip.Shields -= this.Damage * 2;
            targetShip.Health -= this.Damage;
        }
    }
}
