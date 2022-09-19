//Faceted builder we create several builder to build one object, the base builder act as a facade
using System;

public class Person
{
    //address
    public string StreetAddress, PostCode, City;

    //employment
    public string CompanyName, Position;
    public int AnnualIncome;

    public override string ToString()
    {
        return $"{nameof(StreetAddress)}:{StreetAddress}, {nameof(PostCode)}:{PostCode}, {nameof(City)}:{City}, {nameof(CompanyName)}:{CompanyName}, {nameof(Position)}:{Position}, {nameof(AnnualIncome)}:{AnnualIncome},";
    }

}

public class PersonBuilder //facade
{
    //refrence
    protected Person person = new Person();
    public PersonJobBuilder Works => new PersonJobBuilder(person);
    public PersonAddressBuilder Lives => new PersonAddressBuilder(person);

    public static implicit operator Person(PersonBuilder pb)
    {
        return pb.person;
    }
}

public class PersonJobBuilder : PersonBuilder
{
    public PersonJobBuilder(Person person)
    {
        this.person = person;
    }

    public PersonJobBuilder At(string companyName)
    {
        person.CompanyName = companyName;
        return this;
    }
    public PersonJobBuilder AsA(string position)
    {
        person.Position = position;
        return this;
    }
    public PersonJobBuilder Earning(int income)
    {
        person.AnnualIncome = income;
        return this;
    }
}
public class PersonAddressBuilder : PersonBuilder
{
    public PersonAddressBuilder(Person person)
    {
        this.person = person;
    }

    public PersonAddressBuilder At(string streetAddress)
    {
        person.StreetAddress = streetAddress;
        return this;
    }
    public PersonAddressBuilder WithPostCode(string postCode)
    {
        person.PostCode = postCode;
        return this;
    }
    public PersonAddressBuilder In(string city)
    {
        person.City = city;
        return this;
    }
}
public class Demo
{
    static void Main(string[] args)
    {
        var pb = new PersonBuilder();
        Person person = pb
                        .Works
                            .At("Hexaware")
                            .AsA("Engineer")
                            .Earning(1200)
                        .Lives
                            .At("Vill-Katabaga")
                            .WithPostCode("768027")
                            .In("Bargarh");

        Console.WriteLine(person);
    }
}