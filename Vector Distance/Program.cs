using System;
using System.Collections.Generic;

namespace Vector_Distance
{
    class Program
    {
        static void Main(string[] args)
        {
            RunCalulations();


        }
        public static void RunCalulations()
        {
            Console.WriteLine("\n\tVector Distance Calulations");
            RandomNum2D();
            RandomNum3D();

            Compare2DPoints();
            Compare3DPoints();


            Console.WriteLine("\n\tPress enter to reset");
            Console.ReadKey();
            Console.Clear();
            RunCalulations();
        }
        //Two lists that stores 2D and 3D points. To save memory, this may be better places in the main method.
        public static List<Points3D> points3Ds = new List<Points3D>();
        public static List<Points2D> points2Ds = new List<Points2D>();
        //structs that add the points to the list
        public struct Points3D
        {
            public int x3;
            public int y3;
            public int z3;
            public Points3D(int x, int y, int z)
            {
                this.x3 = x;
                this.y3 = y;
                this.z3 = z;
            }
        }
        public struct Points2D
        {
            public int x2;
            public int y2;
            public Points2D(int x, int y)
            {
                this.x2 = x;
                this.y2 = y;
            }
        }
        //Methods that randomly generate points to pass to the struct
        public static void RandomNum2D()
        {
            points2Ds.Clear();
            for (int i = 0; i < 100; i++)
            {
                Random xR = new Random();
                int x2 = xR.Next(1, 101);
                Random yR = new Random();
                int y2 = yR.Next(1, 101);

                points2Ds.Add(new Points2D(x2, y2));
            }
        }
        public static void RandomNum3D()
        {
            points3Ds.Clear();
            for (int i = 0; i < 1000; i++)
            {
                Random xR = new Random();
                int x3 = xR.Next(1, 1001);
                Random yR = new Random();
                int y3 = yR.Next(1, 1001);
                Random zR = new Random();
                int z3 = zR.Next(1, 1001);
                points3Ds.Add(new Points3D(x3, y3, z3));
            }
        }
        //Methods calculates the distance between the two points
        public static double Distance2D(Points2D firstPoint, Points2D secondPoint)
        {
            double distance = Math.Sqrt(
                Math.Pow(firstPoint.x2 - secondPoint.x2, 2) +
                Math.Pow(firstPoint.y2 - secondPoint.y2, 2)
                );

            return distance;
        }
        public static double Distance3D(Points3D firstPoint, Points3D secondPoint)
        {
            double distance = Math.Sqrt(
                Math.Pow(firstPoint.x3 - secondPoint.x3, 2) +
                Math.Pow(firstPoint.y3 - secondPoint.y3, 2) +
                Math.Pow(firstPoint.z3 - secondPoint.z3, 2)
                );

            return distance;
        }
        //Methods take loop through the lists to compare points and prints results
        public static void Compare2DPoints()
        {
            //shortestDistance is 2000 to set a number that will be changes in the loop
            //first and second index are used to reference the element of the points
            double shortestDistance = 2000;
            int firstElement = 0;
            int secondElement = 0;

            //bool is count - 1 because the last element in the last has already been compared with the rest of the list.
            for (int i = 0; i < points2Ds.Count - 1; i++)
            {
                for (int k = i + 1; k < points2Ds.Count; k++)
                {
                    double tempDistance = Distance2D(points2Ds[i], points2Ds[k]);
                    if (tempDistance < shortestDistance)
                    {
                        shortestDistance = tempDistance;
                        firstElement = i;
                        secondElement = k;
                    }
                }
            }
            Console.WriteLine($"\n\tThe closest two 2D points are ({points2Ds[firstElement].x2}, {points2Ds[firstElement].y2}) and ({points2Ds[secondElement].x2}, {points2Ds[secondElement].y2}) with the distance of {shortestDistance}");
            Console.WriteLine($"\tThe first element is {firstElement} and the second element is {secondElement}");

        }
        public static void Compare3DPoints()
        {
            double shortestDistance = 9999999;
            int firstElement = 0;
            int secondElement = 0;

            for (int i = 0; i < points3Ds.Count - 1; i++)
            {
                for (int k = i +1; k < points3Ds.Count; k++)
                {
                    double tempDistance = Distance3D(points3Ds[i],points3Ds[k]);
                    if (tempDistance < shortestDistance)
                    {
                        shortestDistance = tempDistance;
                        firstElement = i;
                        secondElement = k;
                    }
                }
            }
            Console.WriteLine($"\n\tThe closest two 3D points are ({points3Ds[firstElement].x3}, {points3Ds[firstElement].y3}, {points3Ds[firstElement].z3}) and ({points3Ds[secondElement].x3}, {points3Ds[secondElement].y3}, {points3Ds[secondElement].z3}) with the distance of {shortestDistance}");
            Console.WriteLine($"\tThe first element is {firstElement} and the second element is {secondElement}");
        }

    }

}
