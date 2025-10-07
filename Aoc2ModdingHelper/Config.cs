using System.Text.Json;

namespace ConsoleApp;

public class Config
{
    public static string ConfigPath { get; } = GlobalData.CurDir + @"\config.txt";

    public Config(string aocDir)
    {
        AocDir = aocDir;
    }

    public string AocDir { get; set; }

    public static void Save()
    {
        var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(GlobalData.Config, jsonOptions);
        File.WriteAllText(ConfigPath, json);
    }

    public static void Load()
    {
        string json = "";

        if (File.Exists(ConfigPath))
        {
            json = File.ReadAllText(GlobalData.CurDir + @"\config.txt");
            try
            {
                Config config = JsonSerializer.Deserialize<Config>(json);
                if (config != null)
                {
                    GlobalData.Config = config;
                    return;
                }
            }
            catch (Exception ex) { InputOutput.WriteError($"{ex.Message}"); }
        }
        InputOutput.WriteError($"no configuration");
    }
}