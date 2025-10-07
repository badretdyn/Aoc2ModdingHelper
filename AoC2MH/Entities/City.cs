using Aoc2mh.Utils;
using AoC2mh.Exceptions;
using AoC2mh.Serialization.Java;

namespace Aoc2mh.Entities;

public class City : IJavaSerializable
{
    public string FileName { get; set; }
    public int CityLevel { get; set; }
    public int PosX { get; set; }
    public int PosY { get; set; }
    public int Width { get; set; }
    public short NameLength { get; set; }
    public string CityName { get; set; }

    public City(string fileName, int cityLevel, int posX, int posY, int width, short nameLength, string cityName)
    {
        FileName = string.IsNullOrWhiteSpace(fileName) ? throw new ArgumentCityException(
            $"Argument {nameof(fileName)} is null or white space.", nameof(fileName)) : fileName;
        CityLevel = cityLevel;
        PosX = posX;
        PosY = posY;
        Width = width;
        NameLength = nameLength;
        CityName = string.IsNullOrWhiteSpace(cityName) ? throw new ArgumentCityException(
            $"Argument {nameof(cityName)} is null or white space.", nameof(cityName)) : cityName;
    }

    public City(int cityLevel, int posX, int posY, int width, short nameLength, string cityName)
    {
        FileName = string.IsNullOrWhiteSpace(cityName) ? throw new ArgumentCityException(
            $"Argument {nameof(cityName)} is null or white space.",nameof(cityName)) : cityName;
        CityLevel = cityLevel;
        PosX = posX;
        PosY = posY;
        Width = width;
        NameLength = nameLength;
        CityName = cityName;
    }

    public City(string cityName)
    {
        FileName = string.IsNullOrWhiteSpace(cityName) ? throw new ArgumentCityException(
            $"Argument {nameof(cityName)} is null or white space.", nameof(cityName)) : cityName;
        NameLength = (short)cityName.Length;
        CityName = cityName;
    }

    public override string ToString()
    {
        return $"{nameof(City)}:{{{FileName}, {CityLevel}, {PosX}, {PosY}, {Width}, {NameLength}, {CityName}}}";
    }

    public byte[] GetTcString()
    {
        var result = new byte[3 + FileName.Length];

        var lengthBytes = BinaryUtils.ConvertToBytes(FileName.Length);
        var nameBytes = BinaryUtils.ConvertToBytes(FileName ?? throw new ArgumentNullException($"File name is null.", nameof(FileName)));

        result[0] = JavaSerializationConstants.TC_STRING;
        Buffer.BlockCopy(lengthBytes, 0, result, 1, lengthBytes.Length);
        Buffer.BlockCopy(nameBytes, 0, result, 3, nameBytes.Length);

        return result;
    }
}
