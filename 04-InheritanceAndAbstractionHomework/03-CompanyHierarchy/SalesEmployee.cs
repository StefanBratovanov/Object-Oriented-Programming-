
namespace _03_CompanyHierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;

    public class SalesEmployee : RegularEmployee, ISalesEmployee
    {
        private IList<Sale> sales;

        public SalesEmployee(int id, string firstName, string lastName, decimal salary, Department department, IList<Sale> sales)
            : base(id, firstName, lastName, salary, department)
        {
            this.Sales = sales;
        }

        public IList<Sale> Sales
        {
            get
            {
                return new List<Sale>(this.sales);
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("List of sales can not be null ");
                }
                this.sales = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Sales made: ");
            sb.Append(string.Join("\n", this.Sales));

            return sb.ToString();
        }
    }
}
