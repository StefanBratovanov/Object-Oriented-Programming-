
namespace _03_CompanyHierarchy
{
    using System;
    using Interfaces;

    public class Sale : ISale
    {
        private string productName;
        private decimal price;

        public Sale(string productName, DateTime date, decimal price)
        {
            this.ProductName = productName;
            this.Date = date;
            this.Price = price;
        }

        public string ProductName
        {
            get { return this.productName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("productName", "Product name can not be null or empty.");
                }
                this.productName = value;
            }
        }

        public DateTime Date { get; set; }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price can not be negative.");
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Product: {0}, date: {1}, price: {2}", this.ProductName, this.Date, this.Price);
        }
    }
}
