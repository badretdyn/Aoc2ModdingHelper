using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aoc2ModdingHelper.Entities;
using Aoc2ModdingHelper.Utils;

namespace Aoc2ModdingHelper.Serializers;

public static class ContinentPackgeSerializer
{
    private static byte[] ConvertContinentsToBytes(ContinentPackge continentPackge)
    {
        List<byte> bytes = new List<byte>();

        foreach (Continent cont in continentPackge.Continents)
        {
            // TC_STRING
            bytes.Add(0x74);
            // name length
            bytes.AddRange(BinaryUtils.ConvertToBytes(cont.NameLength));
            // name
            bytes.AddRange(BinaryUtils.ConvertToBytes(cont.Name));
        }
        bytes.Add(0x78);

        return bytes.ToArray();
    }

    public static byte[] Serialize(ContinentPackge continentPackge)
    {
        List<byte> bytes = new List<byte>();

        // odd file content in the start
        byte[] fileStart = File.ReadAllBytes(@"Files\ContinentPackgeStart");
        bytes.AddRange(fileStart);

        // array length, 4 bytes
        bytes.AddRange(BinaryUtils.ConvertToBytes(continentPackge.ContinentCount));
        // TC_BLOCKDATA
        bytes.AddRange([0x77, 0x04]);
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

    private static List<Continent> FindContinents(ref int endIndex, byte[] data, int startIndex = 0)
    {
        List<Continent> continents = new List<Continent>();

        for (int i = startIndex; i < data.Length;)
        {
            endIndex = i;

            byte current = data[i];
            short nameLength = -1;
            string name = "";

            if (current == 0x74)
            {
                var tcString = JavaUtils.TakeTcString(data, i);
                nameLength = tcString.length;
                name = tcString.str;

                Continent continent = new Continent(nameLength, name);
                continents.Add(continent);

                i += nameLength + 3;
                continue;
            }
            else if (current == 0x78)
            {
                break;
            }
            i++;
        }

        return continents;
    }

    public static ContinentPackge DeserializePackge(string packgePath)
    {
        byte[] fileContent = File.ReadAllBytes(packgePath);

        int continentCountIndex = 0xc5;
        int arrayListCapacityIndex = 0xcb;
        int arrayListStartIndex = 0xcf;

        int continentCount = BinaryUtils.ConvertToInt32(fileContent, continentCountIndex);
        int arrayListCapacity = BinaryUtils.ConvertToInt32(fileContent, arrayListCapacityIndex);
        string name = "";
        int endIndex = 0; List<Continent> continents = FindContinents(ref endIndex, fileContent, arrayListStartIndex);

        for (int i = endIndex; i < fileContent.Length; i++)
        {
            byte current = fileContent[i];
            if (current == 0x74)
            {
                var tcString = JavaUtils.TakeTcString(fileContent, i);

                short nameLength = tcString.length;
                name = tcString.str;

                break;
            }
        }

        ContinentPackge continentPackge = new ContinentPackge(continentCount, arrayListCapacity, continents, name);

        return continentPackge;
    }
}
