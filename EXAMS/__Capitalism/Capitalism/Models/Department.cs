
using System;

namespace Capitalism.Models
{
    using System.Collections.Generic;
    using Interfaces;

    public class Department : ICompanyStructure
    {
        private string name;
        private Manager manager;


        public Department(string name, Manager manager)
        {
            this.Name = name;
            this.Manager = manager;
            this.Employees = new List<IEmployee>();
            this.SubDepartments = new List<Department>();
        }


        public string Name
        {
            get { return this.name; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException("Name", "Name cannot be empty.");
                }
                this.name = value;
            }
        }

        public Manager Manager
        {
            get { return this.manager; }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Manager", "Department must have manager.");
                }
                this.manager = value;
            }
        }

        public ICollection<IEmployee> Employees { get; set; }

        public ICollection<Department> SubDepartments { get; set; }
    }
}