


using MassEffect.GameObjects.Projectiles;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Ships
{
    using Locations;
    using System.Text;

    public class Frigate : Starship
    {
        private int projectilesFired;

        public Frigate(string name, StarSystem location)
            : base(name, 60, 50, 30, 220, location)
        {
        }

        public override IProjectile ProduceAttack()
        {
            this.projectilesFired++;
            return new ShieldReaver(this.Damage);
        }


        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(base.ToString());

            if (this.Health > 0)
            {
                output.Append(string.Format("-Projectiles fired: {0}", this.projectilesFired));
            }

            return output.ToString();
        }
    }
}
