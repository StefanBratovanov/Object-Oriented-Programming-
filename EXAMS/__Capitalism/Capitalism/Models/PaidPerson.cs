

namespace Capitalism.Models
{
    using System;
    using Interfaces;

    public abstract class PaidPerson : IPaidPerson, IPerson
    {
        private string firstName;
        private string lastName;
        private decimal salary;

        protected PaidPerson(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
        }

        public string FirstName
        {
            get { return this.firstName; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 2)
                {
                    throw new ArgumentException("Name", "First name should be valid.");
                }
                this.firstName = value;
            }

        }

        public string LastName
        {
            get { return this.lastName; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 2)
                {
                    throw new ArgumentException("Name", "Last name should be valid.");
                }
                this.lastName = value;
            }

        }

        public decimal Salary
        {
            get { return this.salary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("salary", "Salary must be possitive");
                }
                this.salary = value;
            }
        }


    }
}
