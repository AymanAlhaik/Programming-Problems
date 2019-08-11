using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;
namespace Exercise1
{
    class Program
    {
        static int[] allXIndecies;
        static int[] allYIdecies;

        private static List<Point> points;
        private static void FillSetWithPoints(int from, int to)
        {
            for (int i = from; i <=to ; i++)
            {
                for (int j = from; j < to; j++)
                {
                    points.Add(new Point { X = i, Y = j });
                }
            }
        }
        public static void AddPoint(int x, int y)
        {
            points.Add(new Point { X = x, Y = y });
        }
        private static List<int> GetHorizantalLines()
        {
            int minX = allXIndecies.Min();
            int maxX = allXIndecies.Max();
            List<int> allHorizantalLines = new List<int>();
            for (int i = minX; i <= maxX; i++)
            {
                int allPointsAfter = GetCountAfter(i,allXIndecies);
                int allPointsBefor = GetCountBefor(i,allXIndecies);

                if (allPointsBefor==allPointsAfter)
                {
                    if (allPointsAfter > 0 && allPointsBefor > 0)
                    {
                        allHorizantalLines.Add(i);
                    }
                }
            }
            return allHorizantalLines;
        }
        private static List<int> GetHVerticalLines()
        {
            int minY = allYIdecies.Min();
            int maxY = allYIdecies.Max();
            List<int> allHorizantalLines = new List<int>();
            for (int i = minY; i <= maxY; i++)
            {
                int allPointsAbove = GetCountAfter(i, allYIdecies);
                int allPointsBelow = GetCountBefor(i, allYIdecies);

                if (allPointsAbove == allPointsBelow)
                {
                    if (allPointsAbove > 0 && allPointsBelow > 0)
                    {
                        allHorizantalLines.Add(i);
                    }
                }
            }
            return allHorizantalLines;
        }
        public static void AllHorizantalLines()
        {
            List<int> horizantals = GetHorizantalLines();
            if(horizantals.Count > 0)
            {
                Console.WriteLine("Horizantal lines: ");
                foreach (int line in horizantals)
                {
                    Console.Write($"X= {line}, ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("there are no Horizantal Lines split the plan");
            }
        }
        public static void AllVerticalLines()
        {
            List<int> vertical = GetHVerticalLines();
            if (vertical.Count > 0)
            {
                Console.WriteLine("Vertical lines: ");
                foreach (int line in vertical)
                {
                    Console.Write($"Y= {line}, ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("there are no Vertical Lines split the plan");
            }
        }
        private static void InitilizeXArray()
        {

            allXIndecies = new int[points.Count];
            allYIdecies = new int[points.Count];
            for (int i = 0; i < allXIndecies.Length; i++)
            {
                allXIndecies[i] = points[i].X;
                allYIdecies[i] = points[i].Y;
            }
            Array.Sort(allXIndecies);
            Array.Sort(allYIdecies);
        }
        static void Main(string[] args)
        {
            points = new List<Point>();
            //here we create 317*317 points, which are more than 100 000
             FillSetWithPoints(0, 316);
            // points.Add(new Point { X = -6, Y = 1 });
            //points.Add(new Point { X = -5, Y = 3 });
            // points.Add(new Point { X = -2, Y = 7 });
            //points.Add(new Point { X = -1, Y = 1 });
            //points.Add(new Point { X = 1, Y = 1 });
            //points.Add(new Point { X = 2, Y = 1 });
            //points.Add(new Point { X = 3, Y = 2 });
            //points.Add(new Point { X = 4, Y = 5});
            //points.Add(new Point { X = 6, Y = 2 });
            //points.Add(new Point { X = 3, Y = 3 });
            //points.Add(new Point { X = 2, Y = 2 });
            //points.Add(new Point { X = 5, Y = 6 });
            if (points.Count == 0)
            {
                Console.WriteLine("the Points Container must contains at least one Point (x, y)");
                return;
            }

             InitilizeXArray();

             DateTime start = DateTime.Now;
             AllHorizantalLines();
             AllVerticalLines();

             Console.WriteLine(DateTime.Now-start);
        } 

        private static int GetCountAfter(int x,int[] arr)
        {
            int index = -1;
            int arrLength = arr.Length;
            for (int i = 0; i < arrLength; i++)
            {
                if(arr[i]>x)
                {
                    index = i;
                    break;
                }
            }
            if(index>-1)
            {
                return arrLength - index;
            }
            return 0;
        }
        private static int GetCountBefor(int x,int[] arr)
        {
            int index = -1;
            int i = 0;
            int arrLength = arr.Length;
            while(i< arrLength)
            {
                
                if(arr[i]>=x)
                {
                    index = i;
                    break;
                }
                i++;
            }
            if (index > -1)
            {
                return index;
            }
            return 0;
        }

    }
}
