
using System.Collections.Generic;
using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        var j = new Journal();
        j.AddEntry("SOlid design pattern");
        j.AddEntry("single responsibility pattern");
        System.Console.WriteLine(j);

        var p = new Persistent();
        var filename = @"C:\Users\vijay\AppData\Local\Temp\journal.txt";
        p.SaveToFile(j, filename, true);
        Process.Start(filename);
    }
}

public class Journal
{
    private readonly List<string> entries = new List<string>();
    private static int count = 0;
    public int AddEntry(string text)
    {
        entries.Add($"{count++}:{text}");
        return count;
    }
    public void RemoveEntry(int index)
    {
        entries.RemoveAt(index);
    }

    public override string ToString()
    {
        return string.Join(Environment.NewLine, entries);
    }
}

//instead of adding the SaveToFile method to Journal class we create a seperate class for  a different set of responsobility
public class Persistent
{
    public void SaveToFile(Journal j, string filename, bool overwrite = false)
    {
        if (overwrite || !File.Exists(filename))
            File.WriteAllText(filename, j.ToString());
    }
}





