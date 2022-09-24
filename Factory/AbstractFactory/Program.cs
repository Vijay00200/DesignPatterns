//Abstract factory is used to give out abstract objectas oppose to concreate object in case of normal factory
using System;
using System.Collections.Generic;
using static System.Console;

namespace DesignPattern
{


    public interface IHotDrink
    {
        void Consume();
    }

    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            WriteLine($"This Tea is nice I'd prefer it with milk");
        }
    }

    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
            WriteLine($"This coffee is sensational!");
        }
    }

    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }

    internal class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            WriteLine($"Put in a tea bag, boil wate, pour {amount} ml, add lemon, enjoy!!");
            return new Tea();
        }
    }

    internal class CoffeeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            WriteLine($"Grind some beans, boil water, pour {amount} ml, add cream and sugar, enjoy!!");
            return new Coffee();
        }
    }

    public class HotDrinkMachine
    {
        // public enum AvailableDrink
        // {
        //     Coffee, Tea
        // }
        // private Dictionary<AvailableDrink, IHotDrinkFactory> factories = new Dictionary<AvailableDrink, IHotDrinkFactory>();
        // public HotDrinkMachine()
        // {
        //     foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
        //     {
        //         var factory = (IHotDrinkFactory)Activator.CreateInstance(
        //             Type.GetType("DesignPattern." + Enum.GetName(typeof(AvailableDrink), drink) + "Factory")
        //             );
        //         factories.Add(drink, factory);
        //     }
        // }

        // public IHotDrink MakeDrink(AvailableDrink drink, int amount)
        // {
        //     return factories[drink].Prepare(amount);
        // }

        //New impleentation by reflection / you can use DI for creating the factories list
        private List<Tuple<string, IHotDrinkFactory>> factories = new List<Tuple<string, IHotDrinkFactory>>();

        public HotDrinkMachine()
        {
            foreach (var t in typeof(HotDrinkMachine).Assembly.GetTypes())
            {
                if (typeof(IHotDrinkFactory).IsAssignableFrom(t) && !t.IsInterface)
                {
                    factories.Add(Tuple.Create(t.Name.Replace("Factory", string.Empty), (IHotDrinkFactory)Activator.CreateInstance(t)));
                }
            }
        }

        public IHotDrink MakeDrink()
        {
            WriteLine("Available Drinks");
            for (int index = 0; index < factories.Count; index++)
            {
                Tuple<string, IHotDrinkFactory> tuple = factories[index];
                WriteLine($"{index}: {tuple.Item1}");
            }

            while (true)
            {
                string s;
                if ((s = Console.ReadLine()) != null
                    && int.TryParse(s, out int i)
                    && i >= 0
                    && i < factories.Count
                )
                {
                    Write("Specify amount: ");
                    s = ReadLine();
                    if (s != null
                        && int.TryParse(s, out int amount)
                        && amount > 0
                    )
                    {
                        return factories[i].Item2.Prepare(amount);
                    }
                }


            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // var machine = new HotDrinkMachine();
            // var drink = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Tea, 100);
            // drink.Consume();

            var machine = new HotDrinkMachine();
            var drink = machine.MakeDrink();
            drink.Consume();

        }
    }
}