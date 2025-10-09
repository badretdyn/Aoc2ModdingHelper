using AoC2mh.Utils;

namespace AoC2mh.Entities;

public class ProvinceInfo
{
    public float GrowthRate { get; set; }

    public int ContinentID { get; set; }

    public int RegionID { get; set; }

    public int ShiftX { get; set; }

    public int ShiftY { get; set; }

    public string TerrainTAG { get; set; }

    public ProvinceInfo(float growthRate, int continentID, int regionID, int shiftX, int shiftY, string terrainTAG)
    {
        GrowthRate = growthRate;
        ContinentID = continentID;
        RegionID = regionID;
        ShiftX = shiftX;
        ShiftY = shiftY;
        TerrainTAG = terrainTAG;
    }

    public override string ToString()
    {
        string result =
                $"{nameof(Province)}:{{GrowthRate: {GrowthRate}, ContinentID: {ContinentID}, RegionID: {RegionID}, ShiftX: {ShiftX}, ShiftY: {ShiftY}, TerrainTAG: {TerrainTAG}}}";

        return result;
    }

    public string ToString(int tabCount = 0)
    {
        string result =
                $"{nameof(ProvinceInfo)}:" + "\n" +
                new string('\t', tabCount) + $"{{" + "\n" +
                new string('\t', tabCount + 1) + $"GrowthRate: {GrowthRate}," + "\n" +
                new string('\t', tabCount + 1) + $"ContinentID: {ContinentID}," + "\n" +
                new string('\t', tabCount + 1) + $"RegionID: {RegionID}," + "\n" +
                new string('\t', tabCount + 1) + $"ShiftX: {ShiftX}," + "\n" +
                new string('\t', tabCount + 1) + $"ShiftY: {ShiftY}," + "\n" +
                new string('\t', tabCount + 1) + $"TerrainTAG: {TerrainTAG}," + "\n" +
                new string('\t', tabCount) + $"}}";

        return result;
    }
}
