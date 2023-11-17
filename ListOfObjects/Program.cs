using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOfObjects
{
    public class Program
    {
        public static void FillArrPoints(Point[] points)
        {
            Random random = new Random();

            for (int i = 0; i < points.Length; i++)
            {
                int randomX = random.Next(0, 11);
                int randomY = random.Next(0, 11);

                points[i] = new Point(randomX, randomY);
            }
        }

        public static void PrintArrPoints(Point[] points)
        {
            for (int i = 0; i < points.Length; i++)
            {
                Console.Write($"value of x {points[i].GetX()} ");
                Console.WriteLine($"value of y {points[i].GetY()} ");
            }
        }


        public static Node<Point>  arrToList(Point[] arrPoint)
        {
            Point point1 = new Point(arrPoint[0].GetX(), arrPoint[0].GetY());
            Node<Point> listToReturn = new Node<Point>(point1);
            Node <Point> current = listToReturn;

            for (int i=1; i<arrPoint.Length;i++)
            {
                Point pointToAdd = new Point(arrPoint[i].GetX(), arrPoint[i].GetY());
                Node<Point> next = new Node<Point>(pointToAdd);
                current.SetNext (next);
                current = current.GetNext();
            }

            return listToReturn;

        }

        //לחץנלחץימ
        public static double DisBetweenPoints(Point point1, Point point2)
        {

            double sumX = Math.Pow((point1.GetX() - point2.GetX()), 2);
            double sumY = Math.Pow((point1.GetY() - point2.GetY()), 2);
            return Math.Sqrt((sumX + sumY));

        }

        public static double sumTrip (Node<Point> tripPoints)
        {
            double sum = 0;

            if (tripPoints == null  || !tripPoints.HasNext())
            { 
            return 0;
            }

            while (tripPoints.HasNext())
            {
                sum += DisBetweenPoints(tripPoints.GetValue(), tripPoints.GetNext().GetValue());
                tripPoints = tripPoints.GetNext();
            }
            return sum;
        }
        public static void Main(string[] args)
        {
            Point[] arrPoints = new Point[5];
            FillArrPoints(arrPoints);
            PrintArrPoints(arrPoints);

            
            Node<Point> listOfPoints = arrToList(arrPoints);
            Console.WriteLine(  " Now printing the list");
            Console.WriteLine(  listOfPoints);

            double sum = sumTrip(listOfPoints);
            Console.WriteLine( sum );







            /*
                        Point p1 = new Point(10, 20);
                        Console.WriteLine(  p1);

                        Node<Point> point1 = new Node<Point> (p1);
                        Console.WriteLine(point1.GetValue().GetX());
                        point1.GetValue().SetX(45454);
                        Console.WriteLine(point1.GetValue().GetX());
            */

        }
    }
}
