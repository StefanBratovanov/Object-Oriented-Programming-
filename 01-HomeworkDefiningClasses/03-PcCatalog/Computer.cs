
namespace _03_PcCatalog
{
    using System;
    using System.Collections.Generic;

    class Computer
    {
        private string name;
        private List<Component> components;
        private decimal price;

        public Computer(string name, List<Component> components)
        {
            this.Name = name;
            this.components = components;
            this.Price = CalculatePrice(this.components);
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Invalid name!");
                }
                this.name = value;
            }
        }

        public decimal Price { get; set; }

        private decimal CalculatePrice(List<Component> componentos)
        {
            decimal totalPrice = 0m;

            foreach (Component componento in componentos)
            {
                totalPrice += componento.Price;
            }
            return totalPrice;
        }

        public void PrintConfiguration()
        {
            string configuration = "PC : " + this.Name + "\n";
            foreach (Component component in this.components)
            {
                configuration += component + "\n";
            }
            configuration += "Total price: " + this.Price;
            Console.WriteLine(configuration);
        }
    }
}
