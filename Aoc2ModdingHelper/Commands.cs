using Aoc2ModdingHelper.Entities;
using System.IO;

namespace Aoc2ModdingHelper;

public static class Commands
{
    public static void HandleCommand(string[] inputArray)
    {
        var command = inputArray[0].ToLower();
        string path = string.Join(" ", inputArray[1..inputArray.Length]);

        if (command == "getcitiesinfo" || command == "gci")
        {
            if (inputArray.Length > 1)
            {
                if (inputArray[1] == "-help" || inputArray[1] == "--?")
                {
                    Console.WriteLine("command: getcitiesinfo/gci %modifier% %path%\n" +
                        "gets custom cities data and converts them to json file.\n" +
                        "input path for custom cities directory, you can write spaces in path.\n" +
                        "command without arguments uses parent directory of current.\n" +
                        "creates json file in custom cities directory when accepted pressing [Y] key.\n" +
                        "modifier -askpath asks path where create json file.\n" +
                        @"example: gci AoC2\map\%your_map%\data\cities");
                    Console.WriteLine();
                    return;
                }
                else if (inputArray[1] == "-askpath" || inputArray[1] == "--a")
                {
                    path = string.Join(" ", inputArray[2..inputArray.Length]);
                    try
                    {
                        Commands.GetCitiesInfo(path, true);
                    }
                    catch (Exception ex)
                    {
                        Tools.WriteError($"{ex.Message}");
                    }
                }
                else
                {
                    try
                    {
                        Commands.GetCitiesInfo(path);
                    }
                    catch (Exception ex)
                    {
                        Tools.WriteError($"{ex.Message}");
                    }
                }
            }
            else
                GetCitiesInfo(Directory.GetParent(GlobalData.CurDir).ToString());

            Console.WriteLine();
        }
        else if (command == "clear" || command == "cl")
        {
            if (inputArray.Length > 1 && (inputArray[1] == "-help" || inputArray[1] == "--?"))
            {
                Console.WriteLine("command: clear/cl %modifier%\nclears screen");
                Console.WriteLine();
                return;
            }

            Console.Clear();
        }
        else if (command == "help")
        {
            if (inputArray.Length > 1 && (inputArray[1] == "-help" || inputArray[1] == "--?"))
            {
                Console.WriteLine("command: help %modifier%\nprints commands");
                Console.WriteLine();
                return;
            }

            Console.WriteLine(GlobalData.help);
            Console.WriteLine();
        }
        else if (command == "exit" || command == "close" || command == "quit" || command == "q")
        {
            if (inputArray.Length > 1 && (inputArray[1] == "-help" || inputArray[1] == "--?"))
            {
                Console.WriteLine("command: exit/close/quit/q/[Ctrl]+[C] %modifier%\ncloses console");
                Console.WriteLine();
                return;
            }

            GlobalData.CommandCycle = false;
            return;
        }
        else if (command == "convertcities" || command == "cc")
        {
            if (inputArray.Length > 1)
            {
                if (inputArray[1] == "-help" || inputArray[1] == "--?")
                {
                    Console.WriteLine("command: convertcities/cc %modifier% %path%\n" +
                        "convets custom cities to json cities.\n" +
                        "input path for map directory, you can write spaces in path.\n" +
                        "command without arguments uses parent directory of current.\n" +
                        "appends custom cities to json file.\n" +
                        "removes custom cities when accepted pressing [Y] key.\n" +
                        "modifier -del deletes custom cities without ask.\n" +
                        @"example: cc AoC2\map\%your_map%");
                    Console.WriteLine();
                    return;
                }
                else if (inputArray[1] == "-del" || inputArray[1] == "--d")
                {
                    path = string.Join(" ", inputArray[2..inputArray.Length]);
                    try
                    {
                        //Commands.ConvertCities(path, true);
                    }
                    catch (Exception ex)
                    {
                        Tools.WriteError($"{ex.Message}");
                    }
                }
                else
                {
                    try
                    {
                        //Commands.ConvertCities(path);
                    }
                    catch (Exception ex)
                    {
                        Tools.WriteError($"{ex.Message}");
                    }
                }
            }

            Console.WriteLine();
        }
        else if (command == "saveconfig" || command == "sc")
        {
            Config.Save();

            Console.WriteLine();
        }
        else if (command == "createaoc2file" || command == "caf")
        {
            if (inputArray.Length > 1)
            {
                if (inputArray[1] == "-help" || inputArray[1] == "--?")
                {
                    Console.WriteLine("command: createaoc2file/caf %modifier% %path%\n" +
                        "creates Age_of_Civilization file for directory.\n" +
                        "the file has list of all file names in directory (including extensions)\n" +
                        "separated by ; char.\n" +
                        "if the file is exists, ask user for overwriting.\n" +
                        @"example: caf ...AoC2\game\civilizations");
                    Console.WriteLine();
                    return;
                }
                else
                {
                    try
                    {
                        CreateAoc2File(path);
                    }
                    catch (Exception ex)
                    {
                        Tools.WriteError($"{ex.Message}");
                    }
                }
            }
            else
                CreateAoc2File(Directory.GetParent(GlobalData.CurDir).ToString());

            Console.WriteLine();
        }
        else if (command == "getcontinentsinfo" || command == "gcni")
        {
            if (inputArray.Length > 1)
            {
                if (inputArray[1] == "-help" || inputArray[1] == "--?")
                {
                    Console.WriteLine("command: getcontinentsinfo/gcni %modifier% %aoc2_path%\n" +
                        "deserializes continent files and prints information about continents.\n" +
                        "continents located in %aoc2_path%\\map\\data\\continents\n" +
                        @"example: gcni D:\game\Age of Civilizations 2");
                    Console.WriteLine();
                    return;
                }
                else
                {
                    try
                    {
                        GetContinentsInfo(path);
                    }
                    catch (Exception ex)
                    {
                        Tools.WriteError($"{ex.Message}");
                    }
                }
            }
            else
                GetCitiesInfo(Directory.GetParent(GlobalData.CurDir).ToString());

            Console.WriteLine();
        }
        else if (command == "getcontinentpackgeinfo" || command == "gcpi")
        {
            if (inputArray.Length > 1)
            {
                if (inputArray[1] == "-help" || inputArray[1] == "--?")
                {
                    Console.WriteLine("command: getcontinentpackgeinfo/gcpi %modifier% %continent_packge_path%\n" +
                        "deserializes continent packge file and prints information about it.\n" +
                        "continent packges located in %aoc2_path%\\map\\data\\continents\\packges\n" +
                        @"example: gcpi D:\game\Age of Civilizations 2\map\data\continents\packges\Earth6");
                    Console.WriteLine();
                    return;
                }
                else
                {
                    try
                    {
                        GetContinentPackgeInfo(path);
                    }
                    catch (Exception ex)
                    {
                        Tools.WriteError($"{ex.Message}");
                    }
                }
            }
        }
        else if (command == "managepackge" || command == "mp")
        {
            if (inputArray.Length > 1)
            {
                if (inputArray[1] == "-help" || inputArray[1] == "--?")
                {
                    Console.WriteLine("command: menagepackge/mp %modifier% %continent_packge_path%\n" +
                        "manage continent packge changing order of continents and renaming\n" +
                        "continent packges located in %aoc2_path%\\map\\data\\continents\\packges\n" +
                        @"example: mp D:\game\Age of Civilizations 2\map\data\continents\packges\Earth6");
                    Console.WriteLine();
                    return;
                }
                else
                {
                    try
                    {
                        ManagePackge(path);
                    }
                    catch (Exception ex)
                    {
                        Tools.WriteError($"{ex.Message}");
                    }
                }
            }
        }
    }

    public static void GetCitiesInfo(string citiesPath, bool askPath = false)
    {
        if (citiesPath == null || citiesPath == "")
        {
            citiesPath = Directory.GetParent(GlobalData.CurDir).ToString();

            if (citiesPath == null || citiesPath == "")
            {
                if (GlobalData.CurDir == null || GlobalData.CurDir == "")
                    throw new ArgumentException($"{GlobalData.CurDir} must be a directory");
                citiesPath = GlobalData.CurDir;
            }
        }

        Console.WriteLine($"directory path: {citiesPath}");

        if (!Directory.Exists(citiesPath))
            throw new DirectoryNotFoundException($"{citiesPath} is not a directory");

        List<CityHelper.City> cityList = new List<CityHelper.City>();
        try
        {
            cityList = CityHelper.GetCities(citiesPath);
        }
        catch (Exception ex)
        {
            Tools.WriteError($"{ex.Message}");
        }
        Console.WriteLine();

        Console.Write("write json? [Y] to accept: ");

        var key = Tools.ReadKey();
        Console.WriteLine();

        if (key.Key == ConsoleKey.Y)
        {
            string fileContent = "{\r\n\tcities:\r\n\t[\r\n";
            foreach (var city in cityList)
            {
                fileContent += $"\t\t{{\r\n\t\t\tName: \"{city.CityName}\",\r\n\t\t\tx: \"{city.PosX}\",\r\n\t\t\ty: \"{city.PosY}\",\r\n\t\t}},\r\n";
            }
            fileContent += "\t],\r\n\tname: Earth\r\n}";

        askpath:

            string jsonPath = "";
            if (askPath)
            {
                Console.Write("input path where create json < ");
                jsonPath = Tools.ReadLine();
            }

            if (askPath && (jsonPath == null || jsonPath == "" || !Directory.Exists(jsonPath)))
            {
                Tools.WriteError($"incorect json path {jsonPath}");
                goto askpath;
            }
            Repos.WriteFile((askPath ? jsonPath : citiesPath) + @"\cities.json", fileContent);
        }
    }

    public static void ConvertCities(string citiesPath)
    {

    }

    public static void CreateAoc2File(string path)
    {
        if (path == null || path == "")
        {
            path = Directory.GetParent(GlobalData.CurDir).ToString();

            if (path == null || path == "")
            {
                if (GlobalData.CurDir == null || GlobalData.CurDir == "")
                    throw new ArgumentException($"{GlobalData.CurDir} must be a directory");
                path = GlobalData.CurDir;
            }
        }

        Console.WriteLine($"directory path: {path}");

        if (!Directory.Exists(path))
            throw new DirectoryNotFoundException($"{path} is not a directory");

        string[] filePaths = Directory.GetFiles(path);
        
        string GetFileName(string path)
        {
            string[] array = path.Split('\\');

            return array[^1];
        }

        List<string> files = new List<string>();
        foreach (string filePath in filePaths)
        {
            string file = GetFileName(filePath);
            if (file == "Age_of_Civilizations")
                continue;
            Console.WriteLine(file);
            files.Add(file);
        }

        string aoc2FileContent = string.Join(';', files);
        aoc2FileContent += ";";

        if (File.Exists(path + @"\Age_of_Civilizations"))
        {
            Console.WriteLine("aoc2 file is exists. overwrite? [Y] to accept");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Y)
            {
                File.WriteAllText(path + @"\Age_of_Civilizations", aoc2FileContent);
                return;
            }
        }

        File.WriteAllText(path + @"\Age_of_Civilizations_Created", aoc2FileContent);
    }

    public static void GetContinentsInfo(string aoc2Path)
    {
        string packgesDataPath = aoc2Path + @"\map\data\continents\packges_data";
        var continents = Continent.DeserializeContinents(packgesDataPath);

        Console.WriteLine("files:");
        foreach (var i in continents)
        {
            Console.WriteLine(
                $"\tfile {i.FileName}:\n" +
                $"\t\tB: {i.B}\n" +
                $"\t\tG: {i.G}\n" +
                $"\t\tR: {i.R}\n" +
                $"\t\tNameLength: {i.NameLength}\n" +
                $"\t\tName: {i.Name}");
        }
        Console.WriteLine($"successfully processed file count: {continents.Length}");
    }

    public static void GetContinentPackgeInfo(string packgePath)
    {
        ContinentPackge contPackge = ContinentPackge.DeserializePackge(packgePath);

        Console.WriteLine(
            $"processing file {packgePath}\n" +
            contPackge.ToStringList());
    }

    public static void ManagePackge(string packgePath)
    {
        ContinentPackge continentPackge = ContinentPackge.DeserializePackge(packgePath);

        byte[] fileStart = 
            [
                0xAC, 0xED, 0x0, 0x5, 0x73, 0x72, 0x0, 0x3C, 0x61, 0x67, 0x65, 0x2E, 0x6F, 0x66, 0x2E, 0x63, 0x69,
                0x76, 0x69, 0x6C, 0x69, 0x7A, 0x61, 0x74, 0x69, 0x6F, 0x6E, 0x73, 0x32, 0x2E, 0x6A, 0x61, 0x6B,
                0x6F, 0x77, 0x73, 0x6B, 0x69, 0x2E, 0x6C, 0x75, 0x6B, 0x61, 0x73, 0x7A, 0x2E, 0x50, 0x61, 0x63,
                0x6B, 0x61, 0x67, 0x65, 0x5F, 0x43, 0x6F, 0x6E, 0x74, 0x69, 0x6E, 0x65, 0x6E, 0x74, 0x73, 0x44,
                0x61, 0x74, 0x61, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x2, 0x0, 0x2, 0x4C, 0x0,
                0xF, 0x6C, 0x43, 0x6F, 0x6E, 0x74, 0x69, 0x6E, 0x65, 0x6E, 0x74, 0x73, 0x54, 0x61, 0x67, 0x73,
                0x74, 0x0, 0x10, 0x4C, 0x6A, 0x61, 0x76, 0x61, 0x2F, 0x75, 0x74, 0x69, 0x6C, 0x2F, 0x4C, 0x69,
                0x73, 0x74, 0x3B, 0x4C, 0x0, 0xC, 0x73, 0x50, 0x61, 0x63, 0x6B, 0x61, 0x67, 0x65, 0x4E, 0x61,
                0x6D, 0x65, 0x74, 0x0, 0x12, 0x4C, 0x6A, 0x61, 0x76, 0x61, 0x2F, 0x6C, 0x61, 0x6E, 0x67, 0x2F,
                0x53, 0x74, 0x72, 0x69, 0x6E, 0x67, 0x3B, 0x78, 0x70, 0x73, 0x72, 0x0, 0x13, 0x6A, 0x61, 0x76,
                0x61, 0x2E, 0x75, 0x74, 0x69, 0x6C, 0x2E, 0x41, 0x72, 0x72, 0x61, 0x79, 0x4C, 0x69, 0x73, 0x74,
                0x78, 0x81, 0xD2, 0x1D, 0x99, 0xC7, 0x61, 0x9D, 0x3, 0x0, 0x1, 0x49, 0x0, 0x4, 0x73, 0x69,
                0x7A, 0x65, 0x78, 0x70
            ];
            //File.ReadAllBytes(packgePath)[0..197];

        Console.WriteLine(ByteHelper.BytesToCsharp(fileStart, true));

        for (int i = 0; i < continentPackge.Continents.Count; i++)
        {
            Console.WriteLine($"{i}\t{continentPackge.Continents[i].Name}");
        }

        ContinentPackgeSerializer packgeBuilder =
            new ContinentPackgeSerializer(Directory.GetParent(packgePath).ToString() + @"\new_package", continentPackge);
        packgeBuilder.Build();

        Console.WriteLine("type command");
        string command = Tools.ReadLine();
    }
}
