

namespace Capitalism.Salaries
{
    using Models;
    using Models.Interfaces;

    public class SalaryManager
    {
        public decimal GetSalary(IEmployee employee, Company company)
        {
            return (decimal)employee.SalaryFactor * GetSalaryPercentage(employee, company) * company.CEO.Salary;
        }

        private decimal GetSalaryPercentage(IEmployee employee, Company company)
        {
            decimal salaryPercantage = 0.15m;

            if (employee.Department == null)
            {
                return salaryPercantage;
            }

            salaryPercantage = GetSalaryPercentage(employee.Department.Manager, company) - 0.01m;

            return salaryPercantage;
        }
    }
}
