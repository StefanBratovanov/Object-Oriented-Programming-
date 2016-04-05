
namespace _03_CompanyHierarchy
{
    using System;
    using System.Collections.Generic;

    class TestCompanyHierarchy
    {
        static void Main()
        {
            List<Sale> sales1 = new List<Sale>
            {
                new Sale("Coffee", new DateTime(2015, 11, 26), 5.34m),
                new Sale("Tea", new DateTime(2015, 10, 13), 2.34m),
                new Sale("Beer", new DateTime(2015, 11, 25), 3.79m)
            };
            List<Sale> sales2 = new List<Sale>
            {
                new Sale("Tomatoes", new DateTime(2015, 2, 28), 9.20m),
                new Sale("Meat", new DateTime(2015, 3, 13), 4.00m),
                new Sale("Onions", new DateTime(2015, 10, 5), 7.66m)
            };

            List<Project> projects1 = new List<Project>
            {
                new Project("ASP MVC", null, "SoftUni", State.Closed),
                new Project("PHP MVC", new DateTime(2015, 10, 30), "SoftUni shit", State.Open),
                new Project("Databases", new DateTime(2015, 07, 20), "Exam", State.Closed),
            };
            List<Project> projects2 = new List<Project>
            {
                new Project("HouseOne", new DateTime(2015, 10, 13), "Polu", State.Open),
                new Project("Hotel", new DateTime(2014, 11, 11), "Drqn", State.Open),
                new Project("Vacation Village", new DateTime(2014, 10, 25), "Expencive project", State.Open),
            };

            SalesEmployee qze = new SalesEmployee(01, "Stef", "Petrov", 780.50m, Department.Sales, sales1);
            SalesEmployee tize = new SalesEmployee(02, "Dan", "Florev", 1100.90m, Department.Sales, sales2);

            Developer minka = new Developer(03, "Mariq", "Dimitrova", 1500m, Department.Production, projects1);
            Developer chichi = new Developer(04, "Sisa", "Zarkova", 1499.99m, Department.Production, projects2);

            Manager mitko = new Manager(05, "Dimitar", "Peshev", 2345.67m, Department.Sales, new List<Employee> { qze, tize });
            Manager gencho = new Manager(06, "Gencho", "Yankov", 3456.78m, Department.Production, new List<Employee> { minka, chichi });

            List<Employee> empoyees = new List<Employee> { qze, tize, minka, gencho, mitko, gencho };
            foreach (var e in empoyees)
            {
                Console.WriteLine(e);
                Console.WriteLine();
            }

            var customer = new Customer(2, "Mitko", "Mitkov", 500);
            Console.WriteLine(customer);
        }
    }
}
