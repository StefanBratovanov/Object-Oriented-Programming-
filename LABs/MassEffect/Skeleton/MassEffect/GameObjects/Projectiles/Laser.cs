

namespace MassEffect.GameObjects.Projectiles
{
    using Interfaces;

    public class Laser : Projectile
    {
        public Laser(int damage)
            : base(damage)
        {
        }

        public override void Hit(IStarship targetShip)
        {
            targetShip.Shields -= this.Damage;
            if (this.Damage > targetShip.Shields)
            {
                targetShip.Health -= this.Damage - targetShip.Shields;
            }
        }
    }
}
