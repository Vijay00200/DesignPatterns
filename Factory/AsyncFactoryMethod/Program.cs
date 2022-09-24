//constructor does not provides async intialization, we have to rely on method

using static System.Console;
using System.Threading;

public class Foo
{
    private Foo()
    {

    }

    private async Task<Foo> InitAsync()
    {
        await Task.Delay(1000);
        return this;
    }

    public static Task<Foo> CreateAsync()
    {
        var result = new Foo();
        return result.InitAsync();
    }
}
public class Demo
{
    static async void Main(string[] args)
    {
        Foo x = await Foo.CreateAsync();
    }
}