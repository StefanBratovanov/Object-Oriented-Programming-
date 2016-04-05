namespace FootballLeague.Models
{
    using System;

    public class Player
    {
        private const int MinimunAllowedPlayerYearBorn = 1980;

        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private decimal salary;
        private Team team;

        public Player(string firstName, string lastName, DateTime dateOfBirth, decimal salary, Team team)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Salary = salary;
            this.Team = team;
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentException("First name should be at least 3 characters long");
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentException("Last name should be at least 3 characters long");
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
                    throw new ArgumentException("Salary can not be negative");
                }
                this.salary = value;
            }
        }

        public DateTime DateOfBirth
        {
            get { return this.dateOfBirth; }
            set
            {
                if (value.Year < MinimunAllowedPlayerYearBorn)
                {
                    throw new ArgumentException("Date of birth can not be earlier than " + MinimunAllowedPlayerYearBorn);
                }
                this.dateOfBirth = value;
            }
        }

        public Team Team { get; set; }

    }
}
