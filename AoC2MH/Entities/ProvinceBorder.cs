using AoC2mh.Utils;

namespace AoC2mh.Entities;

public class ProvinceBorder : IStringifyable
{
    public int WithProvinceID { get; set; }

    public List<short> PointsX { get; set; }

    public List<short> PointsY { get; set; }

    public ProvinceBorder(int withProvinceID, List<short> pointsX, List<short> pointsY)
    {
        WithProvinceID = withProvinceID;
        PointsX = pointsX;
        PointsY = pointsY;
    }

    public override string ToString()
    {
        string result =
                $"{nameof(Province)}:{{WithProvinceID: {WithProvinceID}, PointsX: {PointsX}, PointsY: {PointsY}}}";

        return result;
    }

    public string ToStringList(int tabCount = 0)
    {
        string result =
            $"{nameof(ProvinceBorder)}:" + "\n" +
            new string('\t', tabCount) + $"{{" + "\n" +
            new string('\t', tabCount + 1) + $"WithProvinceID: {WithProvinceID}," + "\n" +
            new string('\t', tabCount + 1) + $"PointsX: {StringUtils.StringifyList(list: PointsX, tabCount: tabCount + 1)}," + "\n" +
            new string('\t', tabCount + 1) + $"PointsY: {StringUtils.StringifyList(list: PointsY, tabCount: tabCount + 1)}," + "\n" +
            new string('\t', tabCount) + $"}}";

        return result;
    }
}
