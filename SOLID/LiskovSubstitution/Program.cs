// The Liskov Substitution Principle in C# states that even the child object is replaced with the parent, the behavior should not be changed
public class Rectangle
{
    public virtual int Width { get; set; }
    public virtual int Height { get; set; }

    public Rectangle()
    {

    }

    public Rectangle(int Height, int Width)
    {
        this.Height = Height;
        this.Width = Width;
    }

    public override string ToString()
    {
        return $"{nameof(Width)}:{Width}, {nameof(Height)}:{Height}";
    }
}

public class Square : Rectangle
{
    public override int Height { set => base.Height = base.Width = value; }
    public override int Width { set => base.Height = base.Width = value; }
}

public class Demo
{
    public static int Area(Rectangle r) => r.Width * r.Height;


    static void Main(string[] args)
    {
        Rectangle rc = new Rectangle(2, 3);
        Console.WriteLine($"{rc} has Area {Area(rc)}");

        // Square sq = new Square();
        Rectangle sq = new Square(); // we were able to replace child class square with parent class ref rectangle
        sq.Width = 2;
        Console.WriteLine($"{sq} has Area {Area(sq)}");
    }
}
