using _01_Point3D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace _03_Paths3D
{
    public static class Storage
    {
        public static void SavePath(string fileName, params Path3D[] paths)     //params - any number of parameters
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(fileName, FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                using (sw)
                {
                    foreach (Path3D path in paths)
                    {
                        sw.Write(path);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (fs != null)
                {
                    fs.Dispose();
                }
            }
        }

        public static Path3D LoadPath(string fileName)
        {
            List<Point3D> listPoints = new List<Point3D>();
            Path3D path;

            try
            {
                StreamReader sr = new StreamReader(fileName);
                using (sr)
                {
                    string line = sr.ReadLine();
                    while (line !=null)
                    {
                        double[] coordinates = GetCoordinates(line);
                        Point3D point = new Point3D(coordinates[0], coordinates[1], coordinates[2]);
                        listPoints.Add(point);

                        line = sr.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot read the file!");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

            }

            path = new Path3D(listPoints);
            return path;
        }

        private static double[] GetCoordinates(string line)
        {
            double[] coords = new double[3];
            string[] digits = line.Split(',');

            for (int i = 0; i < digits.Length; i++)
            {
                coords[i] = double.Parse(digits[i]);
            }
            return coords;
        }


    }
}
