using System;
using System.Text;
using System.Collections.Generic;
//Builder are creatonal pattern which solve the problems where we have to pass multiple parameter to the contuctor, it allows creating the object piece by piece

public class HTMLElement
{
    public string Name, Text;
    public List<HTMLElement> Elements = new List<HTMLElement>();
    private const int indentsize = 2;

    public HTMLElement()
    {

    }

    public HTMLElement(string name, string text)
    {
        Name = name;
        Text = text;
    }

    private string ToStringImpl(int indent)
    {
        var sb = new StringBuilder();
        var i = new string(' ', indentsize * indent);
        sb.AppendLine($"{i}<{Name}>");
        if (!string.IsNullOrWhiteSpace(Text))
        {
            sb.Append(new string(' ', indentsize * (indent + 1)));
            sb.AppendLine(Text);
        }

        foreach (var e in Elements)
        {
            sb.Append(e.ToStringImpl(indent + 1));
        }
        sb.AppendLine($"{i}</{Name}>");
        return sb.ToString();
    }

    public override string ToString()
    {
        return ToStringImpl(0);
    }
}

public class HTMLBuilder
{
    private readonly string rootName;
    HTMLElement root = new HTMLElement();

    public HTMLBuilder(string rootName)
    {
        this.root.Name = rootName;
        this.rootName = rootName;
    }

    public HTMLBuilder AddChild(string childName, string childText)
    {
        var e = new HTMLElement(childName, childText);
        root.Elements.Add(e);
        return this;
    }

    public override string ToString()
    {
        return root.ToString();
    }

    public void clear()
    {
        root = new HTMLElement { Name = rootName };
    }
}

public class Demo
{
    static void Main(string[] args)
    {
        var builder = new HTMLBuilder("ul");
        builder.AddChild("li", "hello")
               .AddChild("li", "world");
        Console.WriteLine(builder.ToString());
    }
}