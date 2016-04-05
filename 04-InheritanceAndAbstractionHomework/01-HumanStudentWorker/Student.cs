
namespace _01_HumanStudentWorker
{
    using System;
    using System.Text.RegularExpressions;

    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get { return this.facultyNumber; }
            set
            {
                if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentOutOfRangeException("Faculty number length must be in range [5..10]!");
                }
                Regex regex = new Regex("[\\dA-Za-z]");
                var matches = regex.Matches(value);
                if (value.Length > matches.Count)
                {
                    throw new ArithmeticException("Invalid argument. Use only digits or letters!");
                }
                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + " - " + this.FacultyNumber;
        }

    }
}
