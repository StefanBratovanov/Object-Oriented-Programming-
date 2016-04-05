
namespace _02_LaptopShop
{
    using System;

    class Laptop
    {
        private string model;
        private string manufacturer;
        private string processor;
        private int ram;
        private string graphicsCard;
        private string hdd;
        private string screen;
        private Battery battery;
        private double batteryLife;
        private decimal price;

        public Laptop(string model, decimal price)
        {
            this.Model = model;
            this.Price = price;
        }

        public Laptop(string model, decimal price, string manufacturer, string processor)
            : this(model, price)
        {
            this.Manufacturer = manufacturer;
            this.Processor = processor;
        }

        public Laptop(string model, decimal price, string manufacturer, string processor, int ram, string graphicsCard,
            string hdd, string screen, Battery battery, double batteryLife)
            : this(model, price, manufacturer, processor)
        {
            this.Ram = ram;
            this.GraphicsCard = graphicsCard;
            this.Hdd = hdd;
            this.Screen = screen;
            this.Battery = battery;
            this.BatteryLife = batteryLife;
        }

        public string Model
        {
            get { return this.model; }
            set
            {
                if (!IsValidString(value))
                {
                    throw new ArgumentException("Invalid model!");
                }
                this.model = value;
            }
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }
            set
            {
                if (!IsValidString(value))
                {
                    throw new ArgumentException("Inavalid manufacturer!");
                }
                this.manufacturer = value;
            }
        }

        public string Processor
        {
            get { return this.processor; }
            set
            {
                if (!IsValidString(value))
                {
                    throw new ArgumentException("Inavalid processor!");
                }
                this.processor = value;
            }
        }

        public int Ram
        {
            get { return this.ram; }
            set
            {
                if (!IsValidNumber((decimal)value))
                {
                    throw new ArgumentException("Inavalid RAM size!");
                }
                this.ram = value;
            }
        }

        public string GraphicsCard
        {
            get { return this.graphicsCard; }
            set
            {
                if (!IsValidString(value))
                {
                    throw new ArgumentException("Inavalid graphics card!");
                }
                this.graphicsCard = value;
            }
        }

        public string Hdd
        {
            get { return this.hdd; }
            set
            {
                if (!IsValidString(value))
                {
                    throw new ArgumentException("Inavalid HDD!");
                }
                this.hdd = value;
            }
        }

        public string Screen
        {
            get { return this.screen; }
            set
            {
                if (!IsValidString(value))
                {
                    throw new ArgumentException("Inavalid screen!");
                }
                this.screen = value;
            }
        }

        public Battery Battery               //public Battery Battery { get; set; }
        {
            get { return this.battery; }
            set { this.battery = value; }
        }

        public double BatteryLife
        {
            get { return this.batteryLife; }
            set
            {
                if (!IsValidNumber((decimal)value))
                {
                    throw new ArgumentException("Inavalid battey life!");
                }
                this.batteryLife = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (!IsValidNumber(value))
                {
                    throw new ArgumentException("Inavalid price!");
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            string displayInfo = "Model: " + this.Model;
            displayInfo = this.Manufacturer != null ? displayInfo += "\n" + "Manufacturer: " + this.Manufacturer : displayInfo += "";
            displayInfo = this.Processor != null ? displayInfo += "\n" + "Processor: " + this.Processor : displayInfo += "";
            displayInfo = this.Ram != 0 ? displayInfo += "\n" + "RAM: " + this.Ram + " GB" : displayInfo += "";
            displayInfo = this.GraphicsCard != null ? displayInfo += "\n" + "Graphics Card: " + this.GraphicsCard : displayInfo += "";
            displayInfo = this.Hdd != null ? displayInfo += "\n" + "HDD: " + this.Hdd : displayInfo += "";
            displayInfo = this.Screen != null ? displayInfo += "\n" + "Screen: " + this.Screen : displayInfo += "";
            displayInfo = this.Battery != null ? displayInfo += "\n" + "Battery: " + this.Battery : displayInfo += "";
            displayInfo = this.BatteryLife != 0 ? displayInfo += "\n" + "Battery life: " + this.BatteryLife + " hours" : displayInfo += "";
            displayInfo = this.Price != 0 ? displayInfo += "\n" + "Price: " + this.Price + " lv." : displayInfo += "";

            return displayInfo;
        }

        public bool IsValidString(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return false;
            }
            return true;
        }

        public bool IsValidNumber(decimal input)
        {
            if (input < 0)
            {
                return false;
            }
            return true;
        }
    }
}