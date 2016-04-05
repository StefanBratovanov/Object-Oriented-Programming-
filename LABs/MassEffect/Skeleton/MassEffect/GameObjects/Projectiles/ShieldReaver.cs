
namespace MassEffect.GameObjects.Projectiles
{
    using Interfaces;

    public class ShieldReaver : Projectile
    {
        public ShieldReaver(int damage)
            : base(damage)
        {
        }

        public override void Hit(IStarship targetShip)
        {
            targetShip.Shields -= 2 * this.Damage;
            targetShip.Health -= this.Damage;
        }
    }
}
