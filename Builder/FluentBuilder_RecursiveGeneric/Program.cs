// recursive generics - help to inherit the fluent builder classes and provide the functionality of most derived class
using System;

public class Person
{
    public string Name;
    public string Position;

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
    }

    public class Builder : PersonJobBuilder<Builder>
    { }

    public static Builder New => new Builder();
}

public abstract class PersonBuilder
{
    protected Person person = new Person();

    public Person Build()
    {
        return person;
    }

}

public class PersonInfoBuilder<SELF> : PersonBuilder where SELF : PersonInfoBuilder<SELF>
{
    public SELF Called(string Name)
    {
        person.Name = Name;
        return (SELF)this;
    }
}


public class PersonJobBuilder<SELF> : PersonInfoBuilder<PersonJobBuilder<SELF>> where SELF : PersonJobBuilder<SELF>
{
    public SELF WorkAsA(string Position)
    {
        person.Position = Position;
        return (SELF)this;
    }
}


public class Demo
{
    static void Main(string[] args)
    {
        var me = Person.New
              .Called("Vijay")
              .WorkAsA("Software Dev")
              .Build();
        Console.WriteLine(me.ToString());
    }
}