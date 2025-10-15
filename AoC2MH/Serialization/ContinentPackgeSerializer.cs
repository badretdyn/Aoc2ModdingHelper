using Aoc2mh.Entities;
using Aoc2mh.Utils;
using Aoc2mh.Serialization.Java;

namespace Aoc2mh.Serialization;

public static class ContinentPackgeSerializer
{
    public static byte[] ToJava(ContinentPackage continentPackge)
    {
        List<byte> bytes = new List<byte>();

        // odd file content in the start
        byte[] fileStart = File.ReadAllBytes(@"Files\ContinentPackgeStart");
        bytes.AddRange(fileStart);

        // array length, 4 bytes
        bytes.AddRange(BinaryUtils.ConvertToBytes(continentPackge.ContinentCount));
        // TC_BLOCKDATA
        bytes.AddRange([JavaSerializationConstants.TC_BLOCKDATA, sizeof(int)]);
        // array capacity, 4 bytes
        bytes.AddRange(BinaryUtils.ConvertToBytes(continentPackge.ArrayListCapacity));

        // continents
        bytes.AddRange(ConvertContinentsToBytes(continentPackge));

        // PackageName TC_STRING, 1 byte
        bytes.Add(0x74);
        // PackageName Length, 2 bytes
        bytes.AddRange(BinaryUtils.ConvertToBytes((short)continentPackge.PackageName.Length));
        // PackageName, string in bytes
        bytes.AddRange(BinaryUtils.ConvertToBytes(continentPackge.PackageName));

        //File.WriteAllBytes(SerializePath, fileContent.ToArray());
        return bytes.ToArray();
    }

    public static ContinentPackage FromJava(string filePath)
    {
        string fileName = Path.GetFileName(filePath);
        byte[] fileBytes = File.ReadAllBytes(filePath);
        ContinentPackage continentPackage = FromJava(fileBytes);
        continentPackage.FileName = fileName;
        return continentPackage;
    }


    public static ContinentPackage FromJava(byte[] data)
    {
        int continentCountIndex = 0xc5;
        int arrayListCapacityIndex = 0xcb;
        int arrayListStartIndex = 0xcf;

        int continentCount = BinaryUtils.ConvertToInt32(data, continentCountIndex);
        int arrayListCapacity = BinaryUtils.ConvertToInt32(data, arrayListCapacityIndex);
        string name = "";
        int endIndex = 0; List<Continent> continents = FindContinents(ref endIndex, data, arrayListStartIndex);

        for (int i = endIndex; i < data.Length; i++)
        {
            byte current = data[i];
            if (current == JavaSerializationConstants.TC_STRING)
            {
                var tcString = JavaSerialization.TakeTcString(data, i);

                short nameLength = tcString.length;
                name = tcString.str;

                break;
            }
        }

        ContinentPackage continentPackge = new ContinentPackage(name, continentCount, arrayListCapacity, continents, name);

        return continentPackge;
    }

    private static byte[] ConvertContinentsToBytes(ContinentPackage continentPackge)
    {
        List<byte> bytes = new List<byte>();

        foreach (Continent cont in continentPackge.Continents)
        {
            bytes.AddRange(cont.GetTcString());
        }
        bytes.Add(JavaSerializationConstants.TC_ENDBLOCKDATA);

        return bytes.ToArray();
    }

    private static List<Continent> FindContinents(ref int endIndex, byte[] data, int startIndex = 0)
    {
        List<Continent> continents = new List<Continent>();

        for (int i = startIndex; i < data.Length;)
        {
            endIndex = i;

            byte current = data[i];
            short nameLength = -1;
            string name = "";

            if (current == JavaSerializationConstants.TC_STRING)
            {
                var tcString = JavaSerialization.TakeTcString(data, i);
                nameLength = tcString.length;
                name = tcString.str;

                Continent continent = new Continent(name);
                continents.Add(continent);

                i += nameLength + 3;
                continue;
            }
            else if (current == JavaSerializationConstants.TC_ENDBLOCKDATA)
            {
                break;
            }
            i++;
        }

        return continents;
    }
}