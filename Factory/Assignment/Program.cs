// You are given a class called Person . The person has two fields: Id , and Name .

// Please implement a non-static PersonFactory  that has a CreatePerson()  method that takes a person's name.

// The Id of the person should be set as a 0-based index of the object created. So, the first person the factory makes should have Id=0, second Id=1 and so on.


using System;

namespace Coding.Exercise
{
    public class Person
    {
        public int Id;
        public string Name;

        public override string ToString()
        {
            return $"Name: {Name}, Id: {Id}";
        }
    }

    public class PersonFactory
    {
        public static int Id = 0;

        public Person CreatePerson(string Name)
        {
            Person p = new Person() { Id = Id, Name = Name };
            Id += 1;
            return p;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PersonFactory pf = new PersonFactory();
            var p1 = pf.CreatePerson("Vijay");
            var p2 = pf.CreatePerson("Ajay");

            Console.WriteLine(p1);
            Console.WriteLine(p2);
        }
    }

}