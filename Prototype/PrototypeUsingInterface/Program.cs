using System;

namespace Coding.Exercise
{
    interface IPrototype<T>
    {
        T DeepCopy();
    }
    public class Point : IPrototype<Point>
    {
        public int X, Y;

        public Point DeepCopy()
        {
            return new Point { X = this.X, Y = this.Y };
        }
    }

    public class Line : IPrototype<Line>
    {
        public Point Start, End;

        public Line DeepCopy()
        {
            return new Line { Start = this.Start.DeepCopy(), End = this.End.DeepCopy() };
        }
    }

    class program
    {
        static void Main(string[] args)
        {
            var p1 = new Line { Start = new Point { X = 0, Y = 1 }, End = new Point { X = 0, Y = 2 } };
            var p2 = p1.DeepCopy();


        }
    }
}
