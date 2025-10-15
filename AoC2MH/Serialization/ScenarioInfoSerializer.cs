using Aoc2mh.Entities;
using System.Text.Json;

namespace Aoc2mh.Serialization;

public static class ScenarioInfoSerializer
{
    public static string Serialize(ScenarioInfo scenarioInfo)
    {
        string json = JsonSerializer.Serialize(scenarioInfo, new JsonSerializerOptions() { WriteIndented = true });

        return json;
    }

    public static ScenarioInfo DeserializePath(string filePath)
    {
        string fileName = Path.GetFileName(filePath);
        string fileContent = File.ReadAllText(filePath);
        ScenarioInfo scenarioInfo = Deserialize(fileContent);
        scenarioInfo.FileName = fileName;
        return scenarioInfo;
    }

    public static ScenarioInfo Deserialize(string json)
    {
        ScenarioInfo? scenarioInfo = JsonSerializer.Deserialize<ScenarioInfo>(json);

        if (scenarioInfo == null)
        {
            throw new JsonException($"Error while deserializing ScenarioInfo JSON.");
        }

        return scenarioInfo;
    }
}
