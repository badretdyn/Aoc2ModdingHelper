using Aoc2mh.Serialization.Java;
using Aoc2mh.Utils;

namespace Aoc2mh.Entities;

public class ProvincePoints : IJavaSerializable, IStringifyable
{
    public string FileName { get; set; }

    public List<short> PointsX { get; set; }

    public List<short> PointsY { get; set; }

    public ProvincePoints(string fileName, List<short> pointsX, List<short> pointsY)
    {
        FileName = fileName;
        PointsX = pointsX;
        PointsY = pointsY;
    }

    public ProvincePoints(List<short> pointsX, List<short> pointsY)
    {
        FileName = "";
        PointsX = pointsX;
        PointsY = pointsY;
    }

    public byte[] GetTcString()
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        string result =
            $"{nameof(Province)}:" +
            $"{{" +
            $"FileName: {FileName}, " +
            $"pointsX: {PointsX}, " +
            $"PointsY: {PointsY}, " +
            $"}}";

        return result;
    }

    public string ToStringList(int tabCount = 0)
    {
        string result =
            $"{nameof(Province)}:" + "\n" +
            new string('\t', tabCount) + $"{{" + "\n" +
            new string('\t', tabCount + 1) + $"FileName: {FileName}," + "\n" +
            new string('\t', tabCount + 1) + $"pointsX: {StringUtils.StringifyList(list: PointsX, tabCount: tabCount + 1)}," + "\n" +
            new string('\t', tabCount + 1) + $"PointsY: {StringUtils.StringifyList(list: PointsY, tabCount: 1)}," + "\n" +
            new string('\t', tabCount) + $"}}";

        return result;
    }
}
