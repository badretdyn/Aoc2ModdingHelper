namespace AoC2mh.Entities;

public class ProvinceBorder
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
}
