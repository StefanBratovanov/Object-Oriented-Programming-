

namespace Empires.Models.Units
{
    using System;
    using Contracts;

    public abstract class Unit : IUnit
    {
        private int attackDamage;
        private int health;

        protected Unit(int attackDamage, int health)
        {
            this.AttackDamage = attackDamage;
            this.Health = health;
        }

        public int AttackDamage
        {
            get { return this.attackDamage; }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.attackDamage), "Attack damage cannot be negative.");
                }

                this.attackDamage = value;
            }
        }

        public int Health
        {
            get { return this.health; }

            set
            {
                this.health = value < 0 ? 0 : value;
            }
        }
    }
}
