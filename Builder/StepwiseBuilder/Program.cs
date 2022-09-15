// stepwise builder enforce a chain of methods (interface returning other interface) for the object creation
// example - you would like to enforce WheelSize based on the cartype

using System;

public enum Cartype
{
    Sedan,
    Crossover
}


public class Car
{
    public Cartype Type;
    public int WheelSize;
    public override string ToString()
    {
        return $"{nameof(Type)}: {Type}, {nameof(WheelSize)}:{WheelSize}";
    }
}

public interface ISpecifyCarType
{
    ISpecifyWheelSize OfType(Cartype type);
}

public interface ISpecifyWheelSize
{
    IBuildCar WithWheels(int size);
}

public interface IBuildCar
{
    public Car Build();
}

public class CarBuilder
{
    private class Impl : ISpecifyCarType, ISpecifyWheelSize, IBuildCar
    {
        private Car car = new Car();
        public ISpecifyWheelSize OfType(Cartype type)
        {
            car.Type = type;
            return this;
        }
        public IBuildCar WithWheels(int size)
        {
            switch (car.Type)
            {
                case Cartype.Crossover when size < 17 || size > 20:
                case Cartype.Sedan when size < 15 || size > 17:
                    throw new ArgumentException($"Wrong size of wheel for {car.Type}");
            }
            car.WheelSize = size;
            return this;
        }
        public Car Build()
        {
            return car;
        }

    }
    public static ISpecifyCarType Create()
    {
        return new Impl();
    }
}


public class Demo
{
    static void Main(string[] args)
    {
        var car = CarBuilder.Create() //enforcing the order by using the interface which returns the next interface
                            .OfType(Cartype.Crossover)
                            .WithWheels(18)
                            .Build();

        Console.WriteLine(car.ToString());
    }
}