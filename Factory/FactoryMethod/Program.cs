//factory is a creational pattern where you create the object in one go

using System;

public static class PointFactory
{
    //factory method
    public static Point NewCartesianPoint(double x, double y)
    {
        return new Point(x, y);
    }

    public static Point NewPolarPoint(double rho, double theta)
    {
        return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
    }
}

public class Point
{
    private double x, y;

    public Point(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public override string ToString()
    {
        return $"{nameof(x)}: {x}, {nameof(y)}:{y}";
    }
}

public class Demo
{
    static void Main(string[] args)
    {
        var point = PointFactory.NewPolarPoint(1.0, Math.PI / 2);
        Console.WriteLine(point);
    }
}