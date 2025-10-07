using Aoc2mh.Entities;
using Aoc2mh.Utils;

namespace AoC2mh.Serialization;

public static class ContinentSerializer
{
    public static byte[] ToJava(Continent continent)
    {
        throw new NotImplementedException();
    }

    public static Continent FromJava(string filePath)
    {
        string fileName = Path.GetFileName(filePath);
        byte[] fileBytes = File.ReadAllBytes(filePath);
        Continent continent = FromJava(fileBytes);
        continent.FileName = fileName;
        return continent;
    }

    public static Continent FromJava(byte[] data)
    {
        int fBIndex = 0x79;
        int fGIndex = 0x7d;
        int fRIndex = 0x81;
        int nameLengthIndex = 0x86;
        int nameIndex = 0x88;

        float fB = BinaryUtils.ConvertToFloat32(data, fBIndex);
        float fG = BinaryUtils.ConvertToFloat32(data, fGIndex);
        float fR = BinaryUtils.ConvertToFloat32(data, fRIndex);
        short nameLength = BinaryUtils.ConvertToInt16(data, nameLengthIndex);
        string name = BinaryUtils.ConvertToString(data, nameLength, nameIndex);

        //FileName = filePath.Split('\\')[^1];
        //B = fB;
        //G = fG;
        //R = fR;
        //NameLength = nameLength;
        //Name = name;

        return new Continent(fB, fG, fR, nameLength, name);
    }

    [Obsolete("Have to be removed", false)]
    public static Continent[] DeserializeMany(string packgeDataPath)
    {
        string[] filePaths = Directory.GetFiles(packgeDataPath);
        List<Continent> continents = new List<Continent>();
        foreach (string filePath in filePaths)
        {
            if (filePath.Split('\\')[^1] == "Age_of_Civilizations")
                continue;
            try
            {
                Continent continent = new Continent(filePath);
                continents.Add(continent);
            }
            catch (Exception ex)
            {
                //InputOutput.WriteError($"error while processing {filePath}\n{ex.Message}");
            }
        }

        return continents.ToArray();
    }
}
