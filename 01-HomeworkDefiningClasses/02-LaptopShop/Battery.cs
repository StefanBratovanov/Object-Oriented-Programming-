
namespace _02_LaptopShop
{
    using System;

    class Battery
    {
        private string type;
        private int cells;
        private int size;

        public Battery(string type, int cells, int size)
        {
            this.Type = type;
            this.Cells = cells;
            this.Size = size;
        }

        public string Type
        {
            get { return this.type; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Inavalid battery type!");
                }
                this.type = value;
            }
        }

        public int Cells
        {
            get { return this.cells; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Inavalid number of battery cells");
                }
                this.cells = value;
            }
        }

        public int Size
        {
            get { return this.size; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Inavalid battery size");
                }
                this.size = value;
            }
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}-cells, {2} mAh", this.Type, this.Cells, this.Size);
        }

    }
}
