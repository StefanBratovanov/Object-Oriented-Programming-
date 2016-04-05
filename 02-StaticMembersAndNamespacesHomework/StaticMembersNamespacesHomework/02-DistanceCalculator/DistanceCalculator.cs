using _01_Point3D;
using System;

namespace _02_DistanceCalculator
{
    public static class DistanceCalculator
    {
        public static double CalculateDistance(Point3D p1, Point3D p2)
        {
            double distance = 0;

            distance = Math.Sqrt(Math.Pow((p1.X - p2.X), 2) +
                                 Math.Pow((p1.Y - p2.Y), 2) +
                                 Math.Pow((p1.Z - p2.Z), 2));
            return distance;
        }
    }
}
