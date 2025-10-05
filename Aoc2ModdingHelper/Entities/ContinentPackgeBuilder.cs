using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2ModdingHelper.Entities;

public class ContinentPackageBuilder
{
    public ContinentPackageBuilder(string buildPath, int continentCount, int arrayListCapacity, List<Continent> continents, string packageName)
    {
        BuildPath = buildPath;
        ContinentCount = continentCount;
        ArrayListCapacity = arrayListCapacity;
        Continents = continents;
        PackageName = packageName;
    }

    private byte[] _fileStart =
        [
            0xAC, 0xED, 0x0, 0x5, 0x73, 0x72, 0x0, 0x3C, 0x61, 0x67, 0x65, 0x2E, 0x6F, 0x66, 0x2E, 0x63, 0x69,
            0x76, 0x69, 0x6C, 0x69, 0x7A, 0x61, 0x74, 0x69, 0x6F, 0x6E, 0x73, 0x32, 0x2E, 0x6A, 0x61, 0x6B,
            0x6F, 0x77, 0x73, 0x6B, 0x69, 0x2E, 0x6C, 0x75, 0x6B, 0x61, 0x73, 0x7A, 0x2E, 0x50, 0x61, 0x63,
            0x6B, 0x61, 0x67, 0x65, 0x5F, 0x43, 0x6F, 0x6E, 0x74, 0x69, 0x6E, 0x65, 0x6E, 0x74, 0x73, 0x44,
            0x61, 0x74, 0x61, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x2, 0x0, 0x2, 0x4C, 0x0,
            0xF, 0x6C, 0x43, 0x6F, 0x6E, 0x74, 0x69, 0x6E, 0x65, 0x6E, 0x74, 0x73, 0x54, 0x61, 0x67, 0x73,
            0x74, 0x0, 0x10, 0x4C, 0x6A, 0x61, 0x76, 0x61, 0x2F, 0x75, 0x74, 0x69, 0x6C, 0x2F, 0x4C, 0x69,
            0x73, 0x74, 0x3B, 0x4C, 0x0, 0xC, 0x73, 0x50, 0x61, 0x63, 0x6B, 0x61, 0x67, 0x65, 0x4E, 0x61,
            0x6D, 0x65, 0x74, 0x0, 0x12, 0x4C, 0x6A, 0x61, 0x76, 0x61, 0x2F, 0x6C, 0x61, 0x6E, 0x67, 0x2F,
            0x53, 0x74, 0x72, 0x69, 0x6E, 0x67, 0x3B, 0x78, 0x70, 0x73, 0x72, 0x0, 0x13, 0x6A, 0x61, 0x76,
            0x61, 0x2E, 0x75, 0x74, 0x69, 0x6C, 0x2E, 0x41, 0x72, 0x72, 0x61, 0x79, 0x4C, 0x69, 0x73, 0x74,
            0x78, 0x81, 0xD2, 0x1D, 0x99, 0xC7, 0x61, 0x9D, 0x3, 0x0, 0x1, 0x49, 0x0, 0x4, 0x73, 0x69,
            0x7A, 0x65, 0x78, 0x70
        ];

    public string BuildPath { get; set; }

    public int ContinentCount { get; set; }

    public int ArrayListCapacity { get; set; }

    public List<Continent> Continents { get; set; }

    public string PackageName { get; set; }

    public override string ToString()
    {
        return $"{nameof(ContinentPackge)}:{{{ContinentCount}, {ArrayListCapacity}, {Continents}, {PackageName}}}";
    }

    public string ToStringList(string listElementSeparator = ",\n")
    {
        string continents = "";
        string fileStart = "";

        for (int i = 0; i < ContinentCount; i++)
        {
            continents += "\t" + Continents[i] + (i == ContinentCount - 1 ? "" : listElementSeparator);
        }

        return $"{nameof(ContinentPackge)}:{{{ContinentCount}, {ArrayListCapacity},\n{Continents}:\n[\n{continents}\n],\n{PackageName}}}";
    }

    private byte[] ConvertContinentsToBytes()
    {
        List<byte> bytes = new List<byte>();

        foreach (Continent cont in Continents)
        {
            // TC_STRING
            bytes.Add(0x74);
            // name length
            bytes.AddRange(ByteHelper.ConvertToBytes(cont.NameLength));
            // name
            bytes.AddRange(ByteHelper.ConvertToBytes(cont.Name));
        }
        bytes.Add(0x78);

        return bytes.ToArray();
    }

    public void Build()
    {
        List<Byte> fileContent = new List<Byte>();

        // odd file content in the start
        fileContent.AddRange(_fileStart);

        // array length, 4 bytes
        fileContent.AddRange(ByteHelper.ConvertToBytes(ContinentCount));
        // TC_BLOCKDATA
        fileContent.AddRange([0x77, 0x04]);
        // array capacity, 4 bytes
        fileContent.AddRange(ByteHelper.ConvertToBytes(ArrayListCapacity));

        // continents
        fileContent.AddRange(ConvertContinentsToBytes());

        // PackageName TC_STRING, 1 byte
        fileContent.Add(0x74);
        // PackageName Length, 2 bytes
        fileContent.AddRange(ByteHelper.ConvertToBytes((short)PackageName.Length));
        // PackageName, string in bytes
        fileContent.AddRange(ByteHelper.ConvertToBytes(PackageName));

        File.WriteAllBytes(BuildPath, fileContent.ToArray());
    }
}
