using Aoc2mh.Serialization;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (GlobalData.GeneratedDir == null)
            {
                throw new NullReferenceException($"{nameof(GlobalData.GeneratedDir)} is null.");
            }

            if (!Directory.Exists(GlobalData.GeneratedDir))
                Directory.CreateDirectory(GlobalData.GeneratedDir);

            Config.Load();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(GlobalData.Help);
            Console.WriteLine();

            while (GlobalData.CommandCycle)
            {
                Console.Write("< ");

                string input = InputOutput.ReadLine();

                if (input == "" || input == null)
                    continue;

                Console.WriteLine();

                string[] inputArray = input.Split(' ');

                Commands.HandleCommand(inputArray);
            }
        }
    }
}
