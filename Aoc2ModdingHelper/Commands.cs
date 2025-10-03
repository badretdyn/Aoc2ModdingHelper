using Aoc2ModdingHelper.Entities;

namespace Aoc2ModdingHelper;

public static class Commands
{
    public static void HandleCommand(string[] inputArray)
    {
        if (inputArray[0] == "getcitiesinfo" || inputArray[0] == "gci")
        {
            string path = string.Join(" ", inputArray[1..inputArray.Length]);

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
        else if (inputArray[0] == "clear" || inputArray[0] == "cl")
        {
            if (inputArray.Length > 1 && (inputArray[1] == "-help" || inputArray[1] == "--?"))
            {
                Console.WriteLine("command: clear/cl %modifier%\nclears screen");
                Console.WriteLine();
                return;
            }

            Console.Clear();
        }
        else if (inputArray[0] == "help")
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
        else if (inputArray[0] == "exit" || inputArray[0] == "close" || inputArray[0] == "quit" || inputArray[0] == "q")
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
        else if (inputArray[0] == "convertcities" || inputArray[0] == "cc")
        {
            string path = string.Join(" ", inputArray[1..inputArray.Length]);

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
        else if (inputArray[0] == "saveconfig" || inputArray[0] == "sc")
        {
            Config.Save();

            Console.WriteLine();
        }
        else if (inputArray[0] == "createaoc2file" || inputArray[0] == "caf")
        {
            string path = string.Join(" ", inputArray[1..inputArray.Length]);

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
        else if (inputArray[0] == "getcontinentsinfo" || inputArray[0] == "gcni")
        {
            string path = string.Join(" ", inputArray[1..inputArray.Length]);

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
        var continents = Continent.GetContinents(packgesDataPath);

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
}
