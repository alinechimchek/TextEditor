using System;
using System.IO;

internal class Program
{
    private static void Main(string[] args)
    {
        Menu();

    }

    static void Menu()
    {
        Console.Clear();
        Console.WriteLine("Please, choose an option:");
        Console.WriteLine("1 - Open file");
        Console.WriteLine("2 - Create a new file");
        Console.WriteLine("0 - Exit");
        Console.WriteLine("");

        short option = short.Parse(Console.ReadLine());

        switch (option)
        {
            case 0: Environment.Exit(0); break;
            case 1: OpenFile(); break;
            case 2: CreateFile(); break;
            default: Menu(); break;
        }
    }

    static void OpenFile()
    {
        Console.Clear();
        Console.WriteLine(" What is the file path?");
        string path = Console.ReadLine();

        using (var file = new StreamReader(path))
        {
            string text = file.ReadToEnd();
            Console.WriteLine(text);
        }

        Console.WriteLine("");
        Console.ReadLine();
        Menu();
    }

    static void CreateFile()
    {
        Console.Clear();
        Console.WriteLine("Enter your text below");
        Console.WriteLine("Note: Use ESC to exit");
        Console.WriteLine("---------------------");

        string text = "";

        do
        {
            text += Console.ReadLine();
            text += Environment.NewLine;
        }
        while (Console.ReadKey().Key != ConsoleKey.Escape);

        SaveFile(text);
    }

    static void SaveFile(string text)
    {
        Console.Clear();
        Console.WriteLine("Which path to save the file?");
        var path = Console.ReadLine();

        using (var file = new StreamWriter(path))
        {
            file.Write(text);
        }

        Console.WriteLine($"File {path} saved successfully");
        Console.ReadLine();
        Menu();
    }
}