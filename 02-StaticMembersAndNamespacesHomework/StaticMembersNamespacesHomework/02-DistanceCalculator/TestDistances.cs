using _01_Point3D;
using System;


namespace _02_DistanceCalculator
{
    class TestDistances
    {
        static void Main()
        {
            Point3D pointOne = new Point3D(7.2, 8.6, 5.5);
            Point3D pointTwo = new Point3D(1, 2, 100);
            
            double distance = DistanceCalculator.CalculateDistance(pointOne, pointTwo);

            Console.WriteLine("distance = {0:f3}",distance);
        }
    }
}
