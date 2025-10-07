namespace ConsoleApp;

public static class InputOutput
{
    public static string ReadLine()
    {
        Console.ForegroundColor = ConsoleColor.White;
        string result = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        return result;
    }

    public static ConsoleKeyInfo ReadKey()
    {
        Console.ForegroundColor = ConsoleColor.White;
        ConsoleKeyInfo result = Console.ReadKey();
        Console.ForegroundColor = ConsoleColor.Yellow;
        return result;
    }

    public static void WriteError(string error)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(error);
        Console.ForegroundColor = ConsoleColor.Yellow;
    }
}
