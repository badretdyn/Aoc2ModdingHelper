namespace Aoc2ModdingHelper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Config.Load();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(GlobalData.help);
            Console.WriteLine();

            while (GlobalData.CommandCycle)
            {
                Console.Write("< ");

                string input = Tools.ReadLine();

                if (input == "" || input == null)
                    continue;

                Console.WriteLine();

                string[] inputArray = input.Split(' ');

                for (int i = 0; i < inputArray.Length; i++)
                {
                    inputArray[i] = inputArray[i].ToLower();
                }

                Commands.HandleCommand(inputArray);
            }
        }
    }
}
