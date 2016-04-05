using _01_Point3D;
using _02_DistanceCalculator;
using System;
using System.Collections.Generic;
using System.Linq;


namespace _03_Paths3D
{
    public class Path3D
    {
        private List<Point3D> listOfPoints;
        private double distance;

        public Path3D(List<Point3D> listOfPoints)
        {
            this.listOfPoints = listOfPoints;
            this.distance = CalculateDistance(listOfPoints);
        }

        public double Distance
        {
            get { return this.distance; }  //get;
        }

        public double CalculateDistance(List<Point3D> listOfPoints)
        {
            double result = 0;
            for (int i = 0; i < listOfPoints.Count - 1; i++)
            {
                result += DistanceCalculator.CalculateDistance(listOfPoints[i], listOfPoints[i + 1]);
            }
            return result;
        }

        public override string ToString()
        {
            string path = "";
            for (int i = 0; i < listOfPoints.Count; i++)
            {
                path += "Point " + (i + 1) + ", coordinates: (" + listOfPoints[i].X + ", " + listOfPoints[i].Y + ", " + listOfPoints[i].Z + ")" + "\r\n";
            }
            path += "Distanse between points: " + this.distance + "\r\n" + "\r\n";


            return path;
        }

    }
}
