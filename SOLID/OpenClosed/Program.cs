//open closed principle -- classes are open for extension but closed foe modification
//instead of keep on adding method for diffret fileter criteria , create generic function which can be extend upon

using System;


public class Demo
{
    static void Main(string[] args)
    {
        var apple = new Product("Apple", Color.Green, Size.Small);
        var tree = new Product("Tree", Color.Green, Size.Large);
        var house = new Product("House", Color.Blue, Size.Large);

        Product[] products = { apple, tree, house };

        var bf = new BetterFilter();
        Console.WriteLine("Green products:");
        foreach (var product in bf.Filter(products, new ColorSpecification(Color.Green)))
        {
            Console.WriteLine($" - {product.Name} is green");
        }

        Console.WriteLine("Large blue items");
        foreach (var product in bf.Filter(products, new AndSpecification<Product>(new SizeSpecification(Size.Large), new ColorSpecification(Color.Blue))))
        {
            Console.WriteLine($" - {product.Name} is Large and blue");
        }

    }
}

public enum Color
{
    Red, Green, Blue
}

public enum Size
{
    Small, Medium, Large
}

public class Product
{
    public string Name { get; set; }
    public Color Color { get; set; }
    public Size Size { get; set; }

    public Product(string name, Color color, Size size)
    {
        if (name == null)
        {
            throw new ArgumentNullException(paramName: nameof(name));
        }
        Name = name;
        Color = color;
        Size = size;
    }
}

public interface Ispecification<T>
{
    bool IsSatisfied(T t);
}

public interface IFilter<T>
{
    IEnumerable<T> Filter(IEnumerable<T> items, Ispecification<T> spec);
}

public class ColorSpecification : Ispecification<Product>
{
    public Color color;

    public ColorSpecification(Color color)
    {
        this.color = color;
    }

    public bool IsSatisfied(Product t)
    {
        return t.Color == color;
    }
}

public class SizeSpecification : Ispecification<Product>
{
    public Size size;

    public SizeSpecification(Size size)
    {
        this.size = size;
    }

    public bool IsSatisfied(Product t)
    {
        return t.Size == size;
    }
}

public class AndSpecification<T> : Ispecification<T>
{
    private Ispecification<T> first, second;

    public AndSpecification(Ispecification<T> first, Ispecification<T> second)
    {
        this.first = first;
        this.second = second;
    }

    public bool IsSatisfied(T t)
    {
        return first.IsSatisfied(t) && second.IsSatisfied(t);
    }

}

public class BetterFilter : IFilter<Product>
{
    public IEnumerable<Product> Filter(IEnumerable<Product> items, Ispecification<Product> spec)
    {
        foreach (var item in items)
        {
            if (spec.IsSatisfied(item))
                yield return item;
        }
    }

}