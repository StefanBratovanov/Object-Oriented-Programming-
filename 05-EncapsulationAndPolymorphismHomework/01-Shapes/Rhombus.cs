using System;

namespace _01_Shapes
{
    public class Rhombus : BasicShape
    {
        private double angle;

        public Rhombus(double width, double height, double angle) : base(width, height)
        {
            this.Angle = angle;
        }

        public double Angle
        {
            get { return this.angle; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Angle can not be negative!");
                }
                this.angle = value;
            }
        }

        public override double CalculateArea()
        {
            return this.Width * this.Height;
        }

        public override double CalculatePerimeter()
        {
            double side = this.Height / Math.Sin(this.DegreeToRadian(angle));
            return (side + this.Width) * 2;
        }

        private double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }
    }
}
