

namespace Capitalism.Models
{
    using System;
    using Interfaces;
    using System.Collections.Generic;

    public class Company : ICompanyStructure
    {

        private string name;
        private CEO ceo;


        public Company(string name, CEO ceo)
        {
            this.Name = name;
            this.CEO = ceo;
            this.Employees = new List<Employee>();
            this.Departments = new List<Department>();
        }

        public string Name
        {
            get { return this.name; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name", "Name cannot be empty.");
                }
                this.name = value;
            }
        }

        public CEO CEO
        {
            get { return this.ceo; }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("CEO", "Company must have CEO.");
                }
                this.ceo = value;
            }
        }

        public ICollection<Department> Departments { get; set; }

        public ICollection<Employee> Employees { get; set; }

    }
}