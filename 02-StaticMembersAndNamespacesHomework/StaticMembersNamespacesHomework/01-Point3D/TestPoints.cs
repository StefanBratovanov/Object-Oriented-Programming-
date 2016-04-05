using System;

namespace _01_Point3D
{
    class TestPoints
    {
        static void Main(string[] args)
        {
            Point3D pointOne = new Point3D(5,3,2);
            Console.WriteLine(pointOne);
            Console.WriteLine(Point3D.StartingPoint);
        }
    }
}
