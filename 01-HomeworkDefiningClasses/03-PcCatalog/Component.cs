
namespace _03_PcCatalog
{
    using System;

    class Component
    {
        private string name;
        private decimal price;
        private string details;

        public Component(string name, decimal price, string details = null)
        {
            this.Name = name;
            this.Price = price;
            this.Details = details;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                this.name = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Inavlid price!");
                }
                this.price = value;
            }
        }

        public string Details { get; set; }

        public override string ToString()
        {
            return String.Format("{0}, {1} - {2} BGN", this.Name, this.Details != null ? this.Details : "", this.Price);
        }
    }
}
