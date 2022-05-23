using System;

namespace InKeyword__Parameters
{
    struct Point
    {
        public double X, Y;
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public void Reset()
        {
            X = Y = 0;
        }
        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }
    public class Program
    {
        void changeMe(ref Point p)
        {
            p.X++;
        }
        double MeasureDistance(in Point p1, in Point p2)
        {
            //   p1 = changeMe(p1);
            // changeMe(ref p2); 
            p1.Reset();

            var dx = p1.X - p2.Y;
            var dy = p1.Y - p2.X;
            return Math.Sqrt(dx * dy + dy * dy);
        }
        double MeauserDistance(Point p1, Point p2)
        {
            return 0.0;
        }
        public Program()
        {
            var p1 = new Point(1, 1);
            var p2 = new Point(4, 5);

            var distance = MeasureDistance(p1, p2);

            Console.WriteLine($"Distance between {p1} and {p2} is {distance}");

            var distFromOrigin = MeasureDistance(p1, new Point());
        }
        static void Main(string[] args)
        {
            new Program();
        }
    }
}
