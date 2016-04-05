
namespace _01_Shapes
{
    using System;

    class TestShapes
    {
        static void Main()
        {
            IShape[] shapes = new IShape[]
            {
                new Rectangle(20.6,30),
                new Rectangle(50,30.99),
                new Rhombus(800,300,28),
                new Rhombus(800,300,15),
                new Rhombus(150.5,300.65,15.88),
                new Circle(200.0),
            };

            foreach (var item in shapes)
            {
                Console.WriteLine("Shape: {0}, Area: {1:f2}, Perimeter: {2:f2}",
                    item.GetType().Name, item.CalculateArea(), item.CalculatePerimeter());
            }
        }
    }
}
