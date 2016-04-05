

namespace MassEffect.GameObjects.Ships
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Locations;
    using Enhancements;
    using System.Linq;
    using System.Text;

    public abstract class Starship : IStarship
    {
        private List<Enhancement> enhancements;

        protected Starship(string name, int health, int shields, int damage, double fuel, StarSystem location)
        {
            this.enhancements = new List<Enhancement>();
            this.Name = name;
            this.Health = health;
            this.Shields = shields;
            this.Damage = damage;
            this.Fuel = fuel;
            this.Location = location;

        }

        public string Name { get; set; }
        public int Health { get; set; }
        public int Shields { get; set; }
        public int Damage { get; set; }
        public double Fuel { get; set; }
        public StarSystem Location { get; set; }


        public IEnumerable<Enhancement> Enhancements
        {
            get { return this.enhancements; }
        }

        public virtual IProjectile ProduceAttack()
        {
            return null;
        }
        public virtual void RespondToAttack(IProjectile projectile)
        {
            projectile.Hit(this);
        }

        public void AddEnhancement(Enhancement enhancement)
        {
            if (enhancement == null)
            {
                throw new ArgumentNullException("Enhancement can not be null!");
            }
            this.enhancements.Add(enhancement);
            this.ApplyEnhancementEffects(enhancement);
        }

        private void ApplyEnhancementEffects(Enhancement enhancement)
        {
            this.Shields += enhancement.ShieldBonus;
            this.Fuel += enhancement.FuelBonus;
            this.Damage += enhancement.DamageBonus;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine(string.Format("--{0} - {1}", this.Name, this.GetType().Name));

            if (this.Health <= 0)
            {
                output.Append("(Destroyed)");
            }
            else
            {
                output.AppendLine(string.Format("-Location: {0}", this.Location.Name));
                output.AppendLine(string.Format("-Health: {0}", this.Health));
                output.AppendLine(string.Format("-Shields: {0}", this.Shields));
                output.AppendLine(string.Format("-Damage: {0}", this.Damage));
                output.AppendLine(string.Format("-Fuel: {0:F1}", this.Fuel));
                output.Append(string.Format("-Enhancements: "));
                output.Append(!this.Enhancements.Any() ? "N/A" : string.Join(", ", this.Enhancements.Select(e => e.Name)));
            }
            return output.ToString();
        }
    }
}






