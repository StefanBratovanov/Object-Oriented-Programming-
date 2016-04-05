using _01_Point3D;
using _02_DistanceCalculator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Paths3D
{
    class TestPaths
    {
        static void Main()
        {
            Point3D pointOne = new Point3D(10, 20, 30.5);
            Point3D pointTwo = new Point3D(-5.2, 10, 80);
            Point3D pointThree = new Point3D(100, 200, 300);

            List<Point3D> ListOne = new List<Point3D> { pointOne, pointTwo, pointThree };
            List<Point3D> ListTwo = new List<Point3D> { pointOne, pointTwo};
            List<Point3D> ListThree = new List<Point3D> { pointOne, pointThree };

            Path3D pathOne = new Path3D(ListOne);
            Path3D pathTwo = new Path3D(ListTwo);
            Path3D pathThree = new Path3D(ListThree);

           // Console.WriteLine(pathOne);
           // Console.WriteLine(pathThree);

           // Storage.SavePath("..\\..\\testShit.txt", pathOne, pathTwo);

            Path3D newLoadedPath = Storage.LoadPath("..\\..\\LoadShit.txt");
            Storage.SavePath("..\\..\\newShit.txt", newLoadedPath);

        }
    }
}
