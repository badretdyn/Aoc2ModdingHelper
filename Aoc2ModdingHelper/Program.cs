using AoC2mh.Serialization;

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

            #region test
            //byte[] provBytes = File.ReadAllBytes(@"D:\game\AoC2 CR BE\map\Earth_AoC1\data\provinces\0");
            //var prov = ProvinceSerializer.FromJava(provBytes);
            //Console.WriteLine(prov.ToStringList());

            //provBytes = File.ReadAllBytes(@"D:\game\AoC2 CR BE\map\Earth_AoC1\data\provinces\10");
            //prov = ProvinceSerializer.FromJava(provBytes);
            //Console.WriteLine(prov.ToStringList());
            #endregion

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
