using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2ModdingHelper;

public static class CityHelper
{
    public class City
    {
        public City(int cityLevel, int posX, int posY, int width, int nameLength, string cityName)
        {
            CityLevel = cityLevel;
            PosX = posX;
            PosY = posY;
            Width = width;
            NameLength = nameLength;
            CityName = cityName;
        }

        public int CityLevel { get; set; }
        public int PosX { get;set; }
        public int PosY { get; set; }
        public int Width { get; set; }
        public int NameLength { get; set; }
        public string CityName { get; set; }
    }

    public static Dictionary<string, string> GetCity(byte[] data)
    {
        Dictionary<string, string> result = new Dictionary<string, string>()
        {
            { "iCityLevel", "0" },
            { "iPosX", "0" },
            { "iPosY", "0" },
            { "iWidth", "0" },
            { "nameLength", "0" },
            { "sCityName", "" },
        };

        int[] indexes = Tools.FindPattern(data, new byte[] { 0x78, 0x70 });
        if (indexes.Length == 0) throw new Tools.PatternNotFoundException();

        int index = indexes[0];

        int iCityLevelIndex = index + 2;
        int iPosXIndex = index + 6;
        int iPosYIndex = index + 10;
        int iWidthIndex = index + 14;
        int nameLengthIndex = index + 19;
        int sCityNameIndex = index + 21;

        int getValue(byte[] data, int index, int size = 1)
        {
            if (size < 1) throw new ArgumentOutOfRangeException("int size must be > 0");
            byte[] bytes = new byte[size];
            Array.Copy(data, index, bytes, 0, size);
            Array.Reverse(bytes);
            int result = 0;
            if (bytes.Length == 4)
                result = BitConverter.ToInt32(bytes);
            else if (bytes.Length == 2)
                result = BitConverter.ToInt16(bytes);
            else throw new Exception("not 4 or 2 bytes to convert to integer");
            return result;
        }

        int iCityLevel = getValue(data, iCityLevelIndex, 4);
        int iPosX = getValue(data, iPosXIndex, 4);
        int iPosY = getValue(data, iPosYIndex, 4);
        int iWidth = getValue(data, iWidthIndex, 4);
        int nameLength = getValue(data, nameLengthIndex, 2);
        string sCityName = Encoding.UTF8.GetString(data[sCityNameIndex..data.Length]);

        result["iCityLevel"] = iCityLevel.ToString();
        result["iPosX"] = iPosX.ToString();
        result["iPosY"] = iPosY.ToString();
        result["iWidth"] = iWidth.ToString();
        result["sCityName"] = sCityName;

        return result;
    }

    public static List<Dictionary<string, string>> GetCities(string dirPath)
    {
        List<Dictionary<string, string>> cityDict = new List<Dictionary<string, string>>();

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

            byte[] fileContent = Repos.GetFileBytes(filePath);
            var cityInfo = GetCity(fileContent);

            Console.WriteLine(
                "data:\n" +
                $"* iCityLevel: {cityInfo["iCityLevel"]}" + "\n" +
                $"* iPosX: {cityInfo["iPosX"]}" + "\n" +
                $"* iPosY: {cityInfo["iPosY"]}" + "\n" +
                $"* iWidth: {cityInfo["iWidth"]}" + "\n" +
                $"* nameLength: {cityInfo["nameLength"]}" + "\n" +
                $"* sCityName: {cityInfo["sCityName"]}" + "\n"
                );

            cityInfo.Add("filePath", filePath);
            cityDict.Add(cityInfo);
        }

        return cityDict;
    }
}