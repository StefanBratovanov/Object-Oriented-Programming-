
namespace _01_HumanStudentWorker
{
    using System;

    public class Worker : Human
    {
        private decimal weekSalary;
        private int workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, int workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary
        {
            get { return this.weekSalary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Week Salary can not be negative!");
                }
                this.weekSalary = value;
            }
        }

        public int WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            set
            {
                if (value < 0 || value > 24)
                {
                    throw new ArgumentOutOfRangeException("Error! Working hours per day must be in [0..24] range.");
                }
                this.workHoursPerDay = value;
            }
        }

        public decimal MoneyPerHour()
        {
            if (this.weekSalary == 0)
            {
                return 0;
            }
            return this.weekSalary / 5 / this.workHoursPerDay;
        }

        public override string ToString()
        {
            return base.ToString() + ", week salary: " + this.WeekSalary + "лв, money per hour: " + String.Format("{0:f2}лв.", this.MoneyPerHour());
        }
    }
}
