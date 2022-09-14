
// The Dependency Inversion Principle (DIP) states that a high-level class must not depend upon a lower level class. They must both depend upon abstractions. And, secondly, an abstraction must not depend upon details, but the details must depend upon abstractions. This will ensure the class and ultimately the whole application is very robust and easy to maintain and expand, if required. Let us look at this with an example.


using System;
using System.Linq;
using System.Collections.Generic;
// using System.ValueTuple;
public enum Relationship
{
    Parent,
    Child,
    Sibling
}

public class Person
{
    public Person(string Name)
    {
        this.Name = Name;
    }

    public string Name { get; set; }
}

public interface IRelationshipBrowser
{
    IEnumerable<Person> FindAllChildrenOf(string name);
}

//low-level 
public class Relationships : IRelationshipBrowser
{
    private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();

    public void AddParentAndChild(Person parent, Person child)
    {
        relations.Add((parent, Relationship.Parent, child));
        relations.Add((child, Relationship.Child, parent));
    }

    //Instead of creating hard dependency we created seperate method to expose data
    public IEnumerable<Person> FindAllChildrenOf(string name)
    {
        foreach (var r in relations.Where(
            x => x.Item1.Name == name && x.Item2 == Relationship.Parent
        ))
        {
            yield return r.Item3;
        }
    }

}

public class Research
{
    public Research(IRelationshipBrowser browser)
    {
        foreach (var p in browser.FindAllChildrenOf("John"))
        {
            Console.WriteLine($"John has a child called {p.Name}");
        }
    }

    static void Main(string[] args)
    {
        var parent = new Person("John");
        var child1 = new Person("Chris");
        var child2 = new Person("Mary");

        var relationships = new Relationships();
        relationships.AddParentAndChild(parent, child1);
        relationships.AddParentAndChild(parent, child2);

        new Research(relationships);

    }

}

