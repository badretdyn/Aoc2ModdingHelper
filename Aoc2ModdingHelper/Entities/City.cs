using System.Xml.Linq;

namespace Aoc2ModdingHelper.Entities;

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
    public int PosX { get; set; }
    public int PosY { get; set; }
    public int Width { get; set; }
    public int NameLength { get; set; }
    public string CityName { get; set; }

    public override string ToString()
    {
        return $"{nameof(City)}:{{{CityLevel}, {PosX}, {PosY}, {Width}, {NameLength}, {CityName}}}";
    }
}
