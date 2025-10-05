using Aoc2ModdingHelper.Utils;

namespace Aoc2ModdingHelper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (!Directory.Exists(GlobalData.GeneratedDir))
                Directory.CreateDirectory(GlobalData.GeneratedDir);

            Config.Load();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(GlobalData.help);
            Console.WriteLine();

            while (GlobalData.CommandCycle)
            {
                Console.Write("< ");

                string input = InputOutput.ReadLine();

                if (input == "" || input == null)
                    continue;

                Console.WriteLine();

                string[] inputArray = input.Split(' ');

                //for (int i = 0; i < inputArray.Length; i++)
                //{
                //    inputArray[i] = inputArray[i].ToLower();
                //}

                Commands.HandleCommand(inputArray);
            }
        }
    }
}
