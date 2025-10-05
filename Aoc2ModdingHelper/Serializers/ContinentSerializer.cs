using Aoc2ModdingHelper.Entities;
using Aoc2ModdingHelper.Utils;

namespace Aoc2ModdingHelper.Serializers;

public class ContinentSerializer
{
    public static Continent Deserialize(string filePath)
    {
        string fileName = filePath.Split('\\')[^1];

        byte[] fileContent = File.ReadAllBytes(filePath);

        int fBIndex = 0x79;
        int fGIndex = 0x7d;
        int fRIndex = 0x81;
        int nameLengthIndex = 0x86;
        int nameIndex = 0x88;

        float fB = BinaryUtils.ConvertToFloat32(fileContent, fBIndex);
        float fG = BinaryUtils.ConvertToFloat32(fileContent, fGIndex);
        float fR = BinaryUtils.ConvertToFloat32(fileContent, fRIndex);
        short nameLength = BinaryUtils.ConvertToInt16(fileContent, nameLengthIndex);
        string name = BinaryUtils.ConvertToString(fileContent, nameLength, nameIndex);

        //FileName = filePath.Split('\\')[^1];
        //B = fB;
        //G = fG;
        //R = fR;
        //NameLength = nameLength;
        //Name = name;

        return new Continent(fileName, fB, fG, fR, nameLength, name);
    }

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
                InputOutput.WriteError($"error while processing {filePath}\n{ex.Message}");
            }
        }

        return continents.ToArray();
    }
}
