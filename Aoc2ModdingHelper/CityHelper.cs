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

    public static City GetCity(byte[] data)
    {
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

        City result = new City(
            iCityLevel,
            iPosX,
            iPosY,
            iWidth,
            nameLength,
            sCityName);

        return result;
    }

    public static List<City> GetCities(string dirPath)
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

            byte[] fileContent = Repos.GetFileBytes(filePath);
            City city = GetCity(fileContent);

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

        return cityList;
    }
}