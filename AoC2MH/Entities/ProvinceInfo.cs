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
}
