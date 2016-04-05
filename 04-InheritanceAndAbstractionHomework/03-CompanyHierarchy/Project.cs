
namespace _03_CompanyHierarchy
{
    using System;
    using Interfaces;

    public class Project : IProject
    {
        private string name;
        private string details;

        public Project(string name, DateTime? startDate, string details, State state)
        {
            this.Name = name;
            this.StartDate = startDate;
            this.Details = details;
            this.State = state;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("name", "Project name can not be null or empty.");
                }
                this.name = value;
            }
        }

        public DateTime? StartDate { get; set; }

        public string Details
        {
            get { return this.details; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("details", "Project details can not be null or empty.");
                }

                this.details = value;
            }
        }

        public State State { get; set; }

        public void CloseProject()
        {
            if (this.State == State.Open)
            {
                this.State = State.Closed;
            }
        }

        public override string ToString()
        {
            return string.Format("Project: {0}, start date: {1}, details: {2}, state: {3}",
                this.Name, this.StartDate?.ToString("dd/mm/yyyy"), this.Details, this.State);
        }
    }
}
