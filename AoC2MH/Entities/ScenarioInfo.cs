using Aoc2mh.Serialization.Java;
using Aoc2mh.Utils;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using static Aoc2mh.Entities.ScenarioInfo;

namespace Aoc2mh.Entities;

public class ScenarioInfo : IJavaSerializable, IStringifyable
{
    public string FileName { get; set; }

    public string Age_of_Civilizations { get; set; } = "Data";

    public DataScenarioInfo[] Data_Scenario_Info { get; set; }

    [JsonConstructor]
    public ScenarioInfo(string age_of_Civilizations, DataScenarioInfo[] data_Scenario_Info)
    {
        FileName = "";
        Age_of_Civilizations = age_of_Civilizations;
        Data_Scenario_Info = data_Scenario_Info;
    }

    public ScenarioInfo(string fileName, string age_of_Civilizations, DataScenarioInfo data_Scenario_Info)
    {
        FileName = fileName;
        Age_of_Civilizations = age_of_Civilizations;
        Data_Scenario_Info = new[] { data_Scenario_Info };
    }

    public ScenarioInfo(DataScenarioInfo data_Scenario_Info)
    {
        FileName = "";
        Data_Scenario_Info = new[] { data_Scenario_Info };
    }

    public ScenarioInfo(string name, string author, string wiki, int civs, int age, int year, int month, int day)
    {
        FileName = "";

        DataScenarioInfo dataScenarioInfo = new DataScenarioInfo(name, author, wiki, civs, age, year, month, day);

        Data_Scenario_Info = new[] { dataScenarioInfo };
    }

    public override string ToString()
    {
        string result =
            $"{nameof(ScenarioInfo)}:" +
            $"{{" +
            $"FileName: {FileName}, " +
            $"Age_of_Civilizations: {Age_of_Civilizations}, " +
            $"Data_Scenario_Info:  {Data_Scenario_Info}, " +
            $"}}";

        return result;
    }

    public string ToStringList(int tabCount = 0)
    {

        string result =
            $"{nameof(ScenarioInfo)}:" + "\n" +
            new string('\t', tabCount) + $"{{" + "\n" +
            new string('\t', tabCount + 1) + $"FileName: {FileName}," + "\n" +
            new string('\t', tabCount + 1) + $"Age_of_Civilizations: {Age_of_Civilizations}," + "\n" +
            new string('\t', tabCount + 1) + $"Data_Scenario_Info: {StringUtils.StringifyList(list: Data_Scenario_Info.ToList(), tabCount: tabCount + 1)}," + "\n" +
            new string('\t', tabCount) + $"}}";

        return result;
    }

    public byte[] GetTcString()
    {
        throw new NotImplementedException();
    }

    public class DataScenarioInfo : IStringifyable
    {
        public string Name { get; set; }

        public string Author { get; set; }

        public string Wiki { get; set; }

        public int Civs { get; set; }

        public int Age { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public int Day { get; set; }

        public DataScenarioInfo(string name, string author, string wiki, int civs, int age, int year, int month, int day)
        {
            Name = name;
            Author = author;
            Wiki = wiki;
            Civs = civs;
            Age = age;
            Year = year;
            Month = month;
            Day = day;
        }

        public override string ToString()
        {
            string result =
                $"{nameof(DataScenarioInfo)}:" +
                $"{{" +
                $"Name: {Name}, " +
                $"Author: {Author}, " +
                $"Wiki: {Wiki}, " +
                $"Civs: {Civs}, " +
                $"Age: {Age}, " +
                $"Year: {Year}, " +
                $"Month: {Month}, " +
                $"Day:  {Day}, " +
                $"}}";

            return result;
        }

        public string ToStringList(int tabCount = 0)
        {

            string result =
                $"{nameof(DataScenarioInfo)}:" + "\n" +
                new string('\t', tabCount) + $"{{" + "\n" +
                new string('\t', tabCount + 1) + $"Name: {Name}," + "\n" +
                new string('\t', tabCount + 1) + $"Author: {Author}," + "\n" +
                new string('\t', tabCount + 1) + $"Wiki: {Wiki}," + "\n" +
                new string('\t', tabCount + 1) + $"Civs: {Civs}," + "\n" +
                new string('\t', tabCount + 1) + $"Age: {Age}," + "\n" +
                new string('\t', tabCount + 1) + $"Year: {Year}," + "\n" +
                new string('\t', tabCount + 1) + $"Month: {Month}," + "\n" +
                new string('\t', tabCount + 1) + $"Day: {Day}," + "\n" +
                new string('\t', tabCount) + $"}}";

            return result;
        }
    }
}
