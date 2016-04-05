

namespace Capitalism.Execution
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using Models;
    using Salaries;
    using Interfaces;

    public class CapitalismCommandExecutor : ICommandExecutor
    {
        private IDatabase database;
        private SalaryManager salaryManager;
        private IUserInterface userInterface;

        public CapitalismCommandExecutor()
        {
            this.database = new CapitalismDatabase();
            this.salaryManager = new SalaryManager();
        }

        public string ExecuteCommand(ICommand command)
        {
            string commandResult = null;
            switch (command.Name)
            {
                case "create-company":
                    commandResult = ExecuteCreateCompanyCommand(command);
                    break;
                case "create-department":
                    commandResult = ExecuteCreateDepartmentCommand(command);
                    break;
                case "create-employee":
                    commandResult = ExecuteCreateEmployeeCommand(command);
                    break;
                case "pay-salaries":
                    commandResult = ExecutePaySalariesCommand(command);
                    break;
                case "show-employees":
                    commandResult = ExecuteShowEmpoyeeCommand(command);
                    break;
                case "end":
                    break;

                default:
                    throw new InvalidOperationException("The command name is invalid");
            }
            return commandResult;
        }

        private string ExecuteCreateCompanyCommand(ICommand command)
        {
            var ceo = new CEO(command.Parameters[1], command.Parameters[2], decimal.Parse(command.Parameters[3]));
            this.database.TotalSalaries[ceo] = 0m;
            string companyName = command.Parameters[0];
            var company = new Company(companyName, ceo);

            if (this.database.Companies.Any(c => c.Name == company.Name))
            {
                return string.Format($"Company {company.Name} already exists");
            }

            this.database.Companies.Add(company);
            return null;
        }

        private string ExecuteCreateDepartmentCommand(ICommand command)
        {
            string companyName = command.Parameters[0];
            var company = this.database.Companies.FirstOrDefault(c => c.Name == companyName);

            if (company == null)
            {
                return string.Format($"Company {companyName} does not exists");
            }

            if (command.Parameters.Count == 4)
            {
                string managerFirstName = command.Parameters[2];
                string managerLasttName = command.Parameters[3];
                var manager = company.Employees.FirstOrDefault(e => e.FirstName == managerFirstName && e.LastName == managerLasttName);

                if (manager == null)
                {
                    return string.Format($"There is no employee called {managerFirstName} {managerLasttName} in company {companyName}");
                }

                if (!(manager is Manager))
                {
                    //string postition = string.Empty;
                    //switch (manager.GetType().Name)
                    //{
                    //    case "ChiefTelephoneOfficer":
                    //        postition = "chief telephone officer";
                    //        break;
                    //    case "CleaningLady":
                    //        postition = "cleaning lady";
                    //        break;
                    //    case "RegularEmployee":
                    //        postition = "regular";
                    //        break;
                    //    default:
                    //        postition = manager.GetType().Name;
                    //        break;
                    //}

                    string postition = manager.GetType().Name;
                    string realPosition = postition[0].ToString();

                    for (int i = 1; i < postition.Length; i++)
                    {
                        if (realPosition[i].ToString().ToUpper() == realPosition[i].ToString())
                        {
                            realPosition += " " + postition[i];
                        }
                        else
                        {
                            realPosition += postition[i];
                        }
                    }
                    return string.Format($"{managerFirstName} {managerLasttName} is not a manager (real position: {realPosition})");
                }

                var departmentName = command.Parameters[1];
                if (company.Departments.Any(d => d.Name == departmentName))
                {
                    return string.Format($"Department{departmentName} already exists in {companyName}” ");
                }

                var department = new Department(departmentName, manager as Manager);
                company.Departments.Add(department);
            }
            else
            {
                var mainDepartmentName = command.Parameters[4];
                var mainDepartment = company.Departments.FirstOrDefault(d => d.Name == mainDepartmentName);

                if (mainDepartment == null)
                {
                    return string.Format($"There is no department {mainDepartmentName} in {company.Name}");
                }

                string managerFirstName = command.Parameters[2];
                string managerLasttName = command.Parameters[3];
                var manager = mainDepartment.Employees.FirstOrDefault(e => e.FirstName == managerFirstName && e.LastName == managerLasttName);

                if (manager == null)
                {
                    return string.Format($"There is no employee called {managerFirstName} {managerLasttName} in department {mainDepartmentName}");
                }

                if (!(manager is Manager))
                {

                    string postition = manager.GetType().Name;
                    string realPosition = postition[0].ToString();

                    for (int i = 1; i < postition.Length; i++)
                    {
                        if (realPosition[i].ToString().ToUpper() == realPosition[i].ToString())
                        {
                            realPosition += " " + postition[i];
                        }
                        else
                        {
                            realPosition += postition[i];
                        }
                    }

                    return string.Format($"{managerFirstName} {managerLasttName} is not a manager (real position: {realPosition})");
                }

                var departmentName = command.Parameters[1];

                if (mainDepartment.SubDepartments.Any(sb => sb.Name == departmentName))
                {
                    return string.Format($"Department{departmentName} already exists in {mainDepartment.Name}");
                }

                if (company.Departments.Any(d => d.Name == departmentName))
                {
                    return string.Format($"Department{departmentName} already exists in {companyName}");
                }

                var department = new Department(departmentName, manager as Manager);
                mainDepartment.SubDepartments.Add(department);
                company.Departments.Add(department);

            }
            return null;
        }

        private string ExecuteCreateEmployeeCommand(ICommand command)
        {
            string firstName = command.Parameters[0];
            string lastName = command.Parameters[1];
            string companyName = command.Parameters[3];
            var company = this.database.Companies.FirstOrDefault(c => c.Name == companyName);

            if (company == null)
            {
                return string.Format($"Company {companyName} does not exist");
            }

            if (company.Employees.Any(e => e.FirstName == firstName && e.LastName == lastName))
            {
                return string.Format($"Employee {firstName} {lastName} already exists in {company.Name} (no department)");
            }


            var firstConflictingEmployee = company
                .Departments
                .SelectMany(d => d.Employees)
                .FirstOrDefault(e => e.FirstName == firstName && e.LastName == lastName);

            if (firstConflictingEmployee != null)
            {
                return string.Format($"Employee {firstName} {lastName} already exists in {company.Name} (in department {firstConflictingEmployee.Department.Name})");
            }
            //IPaidPerson person;

            //switch (command.Parameters[2])
            //{
            //    case "Regular":
            //        person = new Regular(firstName, lastName, 0m);
            //        break;
            //}

            var employeeTypeName = command.Parameters[2];
            var employeeType = Assembly.GetExecutingAssembly().GetType("Capitalism.Models." + employeeTypeName);
            var employee = Activator.CreateInstance(employeeType,
                args: new object[] { command.Parameters[0], command.Parameters[1], null }) as Employee;

            decimal salary = salaryManager.GetSalary(employee, company);
            employee.Salary = salary;
            this.database.TotalSalaries[employee] = 0;

            if (command.Parameters.Count == 4)
            {
                company.Employees.Add(employee);
                company.CEO.SubordinateEmployees.Add(employee);

            }
            else //command.Parameters.Count == 5
            {
                var departmentName = command.Parameters[4];
                var department = company.Departments.FirstOrDefault(d => d.Name == departmentName);
                if (department == null)
                {
                    department = company.Departments.SelectMany(d => d.SubDepartments).FirstOrDefault(sd => sd.Name == departmentName);
                }

                if (department == null)
                {
                    return string.Format($"Department {departmentName} does not exist in {company.Name}");
                }

                department.Employees.Add(employee);
                department.Manager.SubordinateEmployees.Add(employee);
                employee.Department = department;

            }
            return null;
        }

        private string ExecutePaySalariesCommand(ICommand command)
        {
            string companyName = command.Parameters[0];
            var company = this.database.Companies.FirstOrDefault(c => c.Name == companyName);

            if (company == null)
            {
                return string.Format($"Company {companyName} does not exist");
            }

            var output = new StringBuilder();

            this.database.TotalSalaries[company.CEO] = +company.CEO.Salary;
            decimal totalMoneyPaid = company.CEO.Salary;

            foreach (var employee in company.Employees)
            {
                this.database.TotalSalaries[employee] += employee.Salary;
                totalMoneyPaid += employee.Salary;
            }

            foreach (var department in company.Departments)
            {
                totalMoneyPaid += PaySalaryToDepartment(department, output, 1);
            }
            output.AppendFormat($"{company.Name} {totalMoneyPaid:F2}").AppendLine();

            return string.Join(Environment.NewLine,
                output.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Reverse());
        }

        private decimal PaySalaryToDepartment(Department department, StringBuilder output, int departmentLevel)
        {
            var totalMoneyPerDepartment = 0m;
            foreach (var employee in department.Employees)
            {
                this.database.TotalSalaries[employee] += employee.Salary;
                totalMoneyPerDepartment += employee.Salary;
            }

            foreach (var subDepartment in department.SubDepartments)
            {
                totalMoneyPerDepartment += PaySalaryToDepartment(subDepartment, output, departmentLevel + 1);
            }
            output.AppendFormat("{0}{1} ({2:F2})", new string(' ', 4 * departmentLevel), department.Name, totalMoneyPerDepartment).AppendLine();

            return totalMoneyPerDepartment;
        }

        private string ExecuteShowEmpoyeeCommand(ICommand command)
        {
            string companyName = command.Parameters[0];
            var company = this.database.Companies.FirstOrDefault(c => c.Name == companyName);

            if (company == null)
            {
                return string.Format($"Company {companyName} does not exist");
            }

            var output = new StringBuilder();
            output.AppendLine(company.Name);
            output.AppendFormat("{0} {1} ({2:F2})", company.CEO.FirstName, company.CEO.LastName, this.database.TotalSalaries[company.CEO]).AppendLine();

            foreach (var employee in company.Employees)
            {
                output.AppendFormat("{0} {1} ({2:F2})", employee.FirstName, employee.LastName, this.database.TotalSalaries[employee]).AppendLine();

            }

            foreach (var department in company.Departments)
            {
                DisplayDepartment(department, output, 1);
            }

            return output.ToString();
        }

        private void DisplayDepartment(Department department, StringBuilder output, int departmentLevel)
        {
            foreach (var employee in department.Employees)
            {
                output.AppendFormat("{0} {1} {2} ({3:F2})", new string(' ', 4 * departmentLevel), employee.FirstName, employee.LastName, this.database.TotalSalaries[employee]).AppendLine();
            }

            foreach (var subDept in department.SubDepartments)
            {
                DisplayDepartment(subDept, output, departmentLevel + 1);
            }
        }
    }
}