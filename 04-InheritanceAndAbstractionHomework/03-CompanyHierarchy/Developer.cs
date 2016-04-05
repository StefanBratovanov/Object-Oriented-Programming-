
namespace _03_CompanyHierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;

    public class Developer : RegularEmployee, IDeveloper
    {
        private IList<Project> projects;

        public Developer(int id, string firstName, string lastName, decimal salary, Department department, IList<Project> projects)
            : base(id, firstName, lastName, salary, department)
        {
            this.Projects = projects;
        }

        public IList<Project> Projects
        {
            get
            {
                return new List<Project>(this.projects);
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("List of projects can not be null or empty.");
                }
                this.projects = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Developer Projects: ");
            sb.Append(string.Join("\n", this.Projects));

            return sb.ToString();
        }
    }
}
