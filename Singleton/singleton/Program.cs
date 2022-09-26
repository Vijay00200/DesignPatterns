using System;
using System.Collections.Generic;
using System.IO;
interface IDatabase
{
    int GetPopulation(string name);
}

class SingletonDatabase : IDatabase
{
    private Dictionary<string, int> capitals;
    private SingletonDatabase()
    {
        System.Console.WriteLine("Intializing database");

        capitals = File.ReadAllLines("capital.txt").ToDictionary(x => x.Split(':')[0], x => int.Parse(x.Split(':')[1]));
    }

    public int GetPopulation(string name)
    {
        return capitals[name];
    }

    private static Lazy<SingletonDatabase> instance = new Lazy<SingletonDatabase>(() => new SingletonDatabase());

    public static SingletonDatabase Instance => instance.Value;
}

class Program
{
    static void Main(string[] args)
    {
        var db = SingletonDatabase.Instance;
        var city = "bbsr";
        System.Console.WriteLine($"city {city} has a population of {db.GetPopulation(city)}");

    }
}
