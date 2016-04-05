
namespace _03_CompanyHierarchy
{
    using System;
    using Interfaces;

    public abstract class Person : IPerson
    {
        private int id;
        private string firstName;
        private string lastName;

        protected Person(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public int Id
        {
            get { return this.id; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The id must be a positive integer.");
                }
                this.id = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("firstName", "First name can not be null or empty.");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("lastName", "Last name can not be null or empty.");
                }

                this.lastName = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Id: {0}, {1} {2}", this.Id, this.FirstName, this.LastName);
        }
    }
}
