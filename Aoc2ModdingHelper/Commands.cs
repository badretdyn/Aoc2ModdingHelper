using Aoc2mh.Entities;
using Aoc2mh.Exceptions;
using AoC2mh.Entities;
using AoC2mh.Serialization;

namespace ConsoleApp;

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
                        InputOutput.WriteError($"{ex.Message}");
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
                        InputOutput.WriteError($"{ex.Message}");
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

            Console.WriteLine(GlobalData.Help);
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
                        InputOutput.WriteError($"{ex.Message}");
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
                        InputOutput.WriteError($"{ex.Message}");
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
                        InputOutput.WriteError($"{ex.Message}");
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
                        InputOutput.WriteError($"{ex.Message}");
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
                        InputOutput.WriteError($"{ex.Message}");
                    }
                }
            }
        }
        else if (command == "managepackge" || command == "mp")
        {
            if (inputArray.Length == 1)
            {
                ManagePackge("");
            }
            else if (inputArray.Length > 1)
            {
                if (inputArray[1] == " - help" || inputArray[1] == "--?")
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
                        InputOutput.WriteError($"{ex.Message}");
                    }
                }
            }

            Console.WriteLine();
        }
        else if (command == "getprovinceinfo" || command == "gpi")
        {
            if (inputArray.Length > 1)
            {
                if (inputArray[1] == "-help" || inputArray[1] == "--?")
                {
                    Console.WriteLine("command: getprovinceinfo/gpi %modifier% %prov_path%\n" +
                        "deserialize province information" +
                        @"example: gpi AoC2\map\%your_map%\data\provinces\0");
                    Console.WriteLine();
                    return;
                }
                else
                {
                    try
                    {
                        GetProvinceInfo(path);
                    }
                    catch (Exception ex)
                    {
                        InputOutput.WriteError($"{ex.Message}");
                    }
                }
            }
            else
                Console.WriteLine("input path to the province you want to deserialize");

            Console.WriteLine();
        }
        else if (command == "tomapeditor" || command == "tme")
        {
            if (inputArray.Length > 1)
            {
                if (inputArray[1] == "-help" || inputArray[1] == "--?")
                {
                    Console.WriteLine("command: tomapeditor/tme %modifier% %provs_path%\n" +
                        "converts provinces to map editor file.\n" +
                        $"creates file in {GlobalData.GeneratedDir}\\mapAoC2_v2.txt\n" +
                        $"warining: it does not deserialize all provinces (on borders of the map)\n" +
                        @"example: gpi AoC2\map\%your_map%\data\provinces");
                    Console.WriteLine();
                    return;
                }
                else
                {
                    try
                    {
                        ToMapEditor2(path);
                    }
                    catch (Exception ex)
                    {
                        InputOutput.WriteError($"{ex.Message}");
                    }
                }
            }
            else
                Console.WriteLine("input path to the provinces you want to convert");

            Console.WriteLine();
        }
        else if (command == "test")
        {
            if (inputArray.Length > 1)
            {
                if (inputArray[1] == "-help" || inputArray[1] == "--?")
                {
                    Console.WriteLine("command: test\n" +
                        "testing..." +
                        @"example: test");
                    Console.WriteLine();
                    return;
                }
                else
                {
                    try
                    {
                        TestCommand();
                    }
                    catch (Exception ex)
                    {
                        InputOutput.WriteError($"{ex.Message}");
                    }
                }
            }
            else
                TestCommand();

            Console.WriteLine();
        }
    }

    private static void GetCitiesInfo(string citiesPath, bool askPath = false)
    {
        City[] getCities(string dirPath)
        {
            List<City> cityList = new List<City>();

            string[] filePaths = Directory.GetFiles(dirPath);
            Console.WriteLine("files:");
            foreach (string path in filePaths)
            {
                Console.WriteLine($"* {path}");
            }

            if (filePaths.Length == 0)
                throw new ArgumentException($"no files in directory: {dirPath}");
            Console.WriteLine();

            foreach (string filePath in filePaths)
            {
                Console.WriteLine($"file: {filePath}");

                string[] pathSplited = filePath.Split('\\');
                if (pathSplited[^1] == "Age_of_Civilizations")
                    continue;

                byte[] fileContent = File.ReadAllBytes(filePath);
                City city = CitySerializer.FromJava(fileContent);

                Console.WriteLine(
                    "data:\n" +
                    $"* CityLevel: {city.CityLevel}" + "\n" +
                    $"* PosX: {city.PosX}" + "\n" +
                    $"* PosY: {city.PosY}" + "\n" +
                    $"* Width: {city.Width}" + "\n" +
                    $"* NameLength: {city.NameLength}" + "\n" +
                    $"* CityName: {city.CityName}" + "\n"
                    );

                cityList.Add(city);
            }

            return cityList.ToArray();
        }

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

        List<City> cityList = new List<City>();
        try
        {
            cityList = getCities(citiesPath).ToList();
        }
        catch (Exception ex)
        {
            InputOutput.WriteError($"{ex.Message}");
        }
        Console.WriteLine();

        Console.Write("write json? [Y] to accept: ");

        var key = InputOutput.ReadKey();
        Console.WriteLine();

        if (key.Key == ConsoleKey.Y)
        {
            string fileContent = "";
            try
            {
                CityPackage cityPackage = new CityPackage("cities.json", cityList);
                fileContent = CityPackageSerializer.ToJson(cityPackage);
            }
            catch (Exception ex) { }

            fileContent = "{\r\n\tcities:\r\n\t[\r\n";
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
                jsonPath = InputOutput.ReadLine();
            }

            if (askPath && (jsonPath == null || jsonPath == "" || !Directory.Exists(jsonPath)))
            {
                InputOutput.WriteError($"incorect json path {jsonPath}");
                goto askpath;
            }
            File.WriteAllText((askPath ? jsonPath : citiesPath) + @"\cities.json", fileContent);
        }
    }

    private static void ConvertCities(string citiesPath)
    {

    }

    private static void CreateAoc2File(string path)
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

    private static void GetContinentsInfo(string aoc2Path)
    {
        string packgesDataPath = aoc2Path + @"\map\data\continents\packges_data";
        var continents = ContinentSerializer.DeserializeMany(packgesDataPath);

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

    private static void GetContinentPackgeInfo(string packgePath)
    {
        ContinentPackage contPackge = ContinentPackgeSerializer.FromJava(packgePath);

        Console.WriteLine(
            $"processing file {packgePath}\n" +
            contPackge.ToStringList());
    }

    #region ManagePackage
    private static void ManagePackge(string packgePath)
    {
        string help =
            "commands:\n" +
            "* renamethis/rt %new_packge_name%\n" +
            "* rename/ren %index% %new_name%\n" +
            "* !delete/del %index%\n" +
            "* !add %name%\n" +
            "* !move %index% %new_index%\n" +
            "* save/sv\n" +
            "* exit/close/quit/q";

        bool isAbsolutePath = false;
        if (packgePath.Contains(":\\"))
            isAbsolutePath = true;

        packgePath = isAbsolutePath? packgePath : GlobalData.GeneratedDir + @$"\{packgePath}";

        ContinentPackage continentPackge;
        if (File.Exists(packgePath))
        {
            continentPackge = ContinentPackgeSerializer.FromJava(packgePath);
            Console.WriteLine($"opened {packgePath}\n");
        }
        else
        {
            continentPackge = new ContinentPackage(0, 0, new List<Continent>(), "NewContinentPackge");
            Console.WriteLine("creating new packge\n");
        }

        bool commandCycle = true;
        while (commandCycle)
        {
            Console.WriteLine($"PackgeName: {continentPackge.PackageName}\n" +
                $"Continents:\n[\n");
            for (int i = 0; i < continentPackge.Continents.Count; i++)
            {
                Console.WriteLine($"\t{i}\t{continentPackge.Continents[i].Name}");
            }
            Console.WriteLine("]\n");

            //byte[] packge = ContinentPackgeSerializer.Serialize(continentPackge);
            //File.WriteAllBytes((Directory.GetParent(packgePath).ToString()) + @"\new_packge", packge);

            Console.WriteLine(help + "\n");
            Console.Write("< ");
            string[] inputArray = InputOutput.ReadLine().Split();
            HandleManagePackgeCommand(ref commandCycle, inputArray, continentPackge);
        }

        Console.WriteLine("exited from managing packge");
    }

    private static void HandleManagePackgeCommand(ref bool commandCycle, string[] inputArray, ContinentPackage continentPackge)
    {
        Console.WriteLine();

        string command = inputArray[0];
        if (command == "rename" || command == "ren")
        {
            if (inputArray.Length > 1)
            {
                string second = inputArray[1];
                if (second == "-help" || second == "--?")
                {
                    Console.WriteLine(
                        "command: rename/ren %index% %new_name%\n" +
                        "renames object to %new_name% without spaces" +
                        "example: ren 0 MyObj123");
                }
                else if ("0123456789".Contains(second[0]))
                {
                    try
                    {
                        int index = Convert.ToInt32(second);
                        string newName = inputArray[2];
                        continentPackge.Continents[index].Name = newName;
                        continentPackge.Continents[index].NameLength = (short)newName.Length;
                    }
                    catch (Exception ex) { InputOutput.WriteError(ex.Message); }
                }
            }
        }
        else if (command == "exit" || command == "close" || command == "quit" || command == "q")
        {
            if (inputArray.Length > 1)
            {
                string second = inputArray[1];
                if (second == "-help" || second == "--?")
                {
                    Console.WriteLine(
                        "command: exit/close/quit/q\n" +
                        "exits managing packge");
                }

                return;
            }

            commandCycle = false;
        }
        else if (command == "save" || command == "sv")
        {
            byte[] packgeBytes = ContinentPackgeSerializer.ToJava(continentPackge);

            if (inputArray.Length > 1)
            {
                string second = inputArray[1];
                if (second == "-help" || second == "--?")
                {
                    Console.WriteLine(
                        "command: save/sv %save_path%\n" +
                        "saves continent package file.\n" +
                        $"command with empty save_path saves in {GlobalData.GeneratedDir}\\%PackageName%\n" +
                        $"command with non-absolute path saves in {GlobalData.GeneratedDir}\\%save_path%, you give file name to save." +
                        @"example sv D:\game\AoC2 CR BE\map\data\continents\packges\MyContinentPackge");

                    return;
                }
                else
                {
                    string path = GlobalData.GeneratedDir + $"\\{second}";
                    if (second.Contains(":\\"))
                        path = string.Join(' ', inputArray[1..^1]);
                    File.WriteAllBytes(path, packgeBytes);
                }
            }

            File.WriteAllBytes(GlobalData.GeneratedDir + @$"\{continentPackge.PackageName}", packgeBytes);
        }
        else if (command == "renamethis" || command == "rt")
        {
            if (inputArray.Length > 1)
            {
                string second = inputArray[1];
                if (second == "-help" || second == "--?")
                {
                    Console.WriteLine(
                        "command: renamthis/rt %new_packge_name%\n" +
                        "renames current continent packge (not file name).\n" +
                        @"example rt NewPackgeName");

                    return;
                }
                else
                {
                    continentPackge.PackageName = second;
                }
            }
        }
    }
    #endregion ManagePackge

    private static void GetProvinceInfo(string provPath)
    {
        byte[] provBytes = File.ReadAllBytes(provPath);
        Province province = ProvinceSerializer.FromJava(provBytes);
        Console.WriteLine(province.ToStringList());
    }

    [Obsolete("Does not deserialize all provinces (on borders of the map).", false)]
    private static void ToMapEditor(string provsPath)
    {
        string[] filePaths = Directory.GetFiles(provsPath);

        string mapEditorFile = GlobalData.GeneratedDir + @"\mapAoC2_v2.txt";
        File.WriteAllText(mapEditorFile, "");

        foreach (var filePath in filePaths)
        {
            Province province = new Province();
            try
            {
                province = ProvinceSerializer.FromJava(filePath);
            }
            catch (Exception ex)
            {
                InputOutput.WriteError($"file: {filePath}\n{ex.Message}");
            }
            List<short> list;
            string toFile = "";

            list = province.PointsX;
            if (list == null)
            {
                Console.WriteLine(filePath);
                continue;
            }
            for (int i = 0; i < list.Count; i++)
            {
                toFile += list[i] + (i < list.Count - 1 ? "," : "\n");
            }
            list = province.PointsY;
            for (int i = 0; i < list.Count; i++)
            {
                toFile += list[i] + (i < list.Count - 1 ? "," : "\n");
            }

            File.AppendAllText(mapEditorFile, toFile);
        }
        Console.WriteLine($"file generated in {mapEditorFile}");
    }

    private static void ToMapEditor2(string provsPath)
    {
        string[] filePaths = Directory.GetFiles(provsPath);

        string mapEditorFile = GlobalData.GeneratedDir + @"\mapAoC2_v2.txt";
        File.WriteAllText(mapEditorFile, "");

        foreach (var filePath in filePaths)
        {
            ProvincePoints provincePoints = new ProvincePoints(null, null);
            try
            {
                provincePoints = ProvinceSerializer.PointsFromJava(filePath);
            }
            catch (Exception ex)
            {
                InputOutput.WriteError($"file: {filePath}\n{ex.Message}");
            }
            List<short> list;
            string toFile = "";

            list = provincePoints.PointsX;
            if (list == null)
            {
                Console.WriteLine(filePath);
                continue;
            }
            for (int i = 0; i < list.Count; i++)
            {
                toFile += list[i] + (i < list.Count - 1 ? "," : "\n");
            }
            list = provincePoints.PointsY;
            for (int i = 0; i < list.Count; i++)
            {
                toFile += list[i] + (i < list.Count - 1 ? "," : "\n");
            }

            File.AppendAllText(mapEditorFile, toFile);
        }
        Console.WriteLine($"file generated in {mapEditorFile}");
    }

    private static void TestCommand()
    {
        Console.WriteLine("there is no testing but this WriteLine!");

        byte[] fileBytes = File.ReadAllBytes(@"D:\game\AoC2 CR BE\map\Earth_AoC1\data\provinces\174");
        ProvincePoints provincePoints = ProvinceSerializer.PointsFromJava(fileBytes);
        Console.WriteLine(provincePoints.ToStringList());
    }
}
