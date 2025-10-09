using Aoc2mh.Utils;
using AoC2mh.Entities;
using AoC2mh.Exceptions;
using AoC2mh.Serialization.Java;
using AoC2mh.Utils;

namespace Aoc2mh.Entities;

public class ContinentPackage : IJavaSerializable, IStringifyable
{
    public string FileName { get; set; }
    public int ContinentCount { get; set; }
    public int ArrayListCapacity { get; set; }
    public List<Continent> Continents { get; set; }
    public string PackageName { get; set; }

    public ContinentPackage(string fileName, int continentCount, int arrayListCapacity, List<Continent> continents, string packageName)
    {
        FileName = string.IsNullOrWhiteSpace(fileName) ? throw new ArgumentContinentPackageException(
            $"Argument {nameof(fileName)} is null or white space.", nameof(fileName)) : fileName;
        ContinentCount = continentCount;
        ArrayListCapacity = arrayListCapacity;
        Continents = continents ?? throw new ArgumentContinentPackageException($"List {nameof(continents)} is null.", nameof(continents));
        PackageName = string.IsNullOrWhiteSpace(packageName) ? throw new ArgumentContinentPackageException(
            $"Argument {nameof(packageName)} is null or white space.", nameof(packageName)) : packageName;
    }

    public ContinentPackage(int continentCount, int arrayListCapacity, List<Continent> continents, string packageName)
    {
        FileName = string.IsNullOrWhiteSpace(packageName) ? throw new ArgumentContinentPackageException(
            $"Argument {nameof(packageName)} is null or white space.", nameof(packageName)) : packageName;
        ContinentCount = continentCount;
        ArrayListCapacity = arrayListCapacity;
        Continents = continents ?? throw new ArgumentContinentPackageException($"List {nameof(continents)} is null.", nameof(continents));
        PackageName = packageName;
    }

    public ContinentPackage(string packageName)
    {
        FileName = string.IsNullOrWhiteSpace(packageName) ? throw new ArgumentContinentPackageException(
            $"Argument {nameof(packageName)} is null or white space.", nameof(packageName)) : packageName;
        Continents = new List<Continent>();
        PackageName = packageName;
    }

    public override string ToString()
    {
        return $"{nameof(ContinentPackage)}:{{{ContinentCount}, {ArrayListCapacity}, {Continents}, {PackageName}}}";
    }

    public string ToStringList(int tabCount = 0)
    {
        string result =
            $"{nameof(ContinentPackage)}:" + "\n" +
            new string('\t', tabCount) + $"{{" + "\n" +
            new string('\t', tabCount + 1) + $"FileName: {FileName}," + "\n" +
            new string('\t', tabCount + 1) + $"ContinentCount: {ContinentCount}," + "\n" +
            new string('\t', tabCount + 1) + $"ArrayListCapacity: {ArrayListCapacity}," + "\n" +
            new string('\t', tabCount + 1) + $"Continents: {StringUtils.StringifyList(list: Continents, tabCount: tabCount)}," + "\n" +
            new string('\t', tabCount + 1) + $"PackageName: {PackageName}," + "\n" +
            new string('\t', tabCount) + $"}}";

        return result;
    }

    //public string ToStringList(string listElementSeparator = ",\n")
    //{
    //    string continents = "";

    //    for (int i = 0; i < ContinentCount; i++)
    //    {
    //        continents += "\t" + Continents[i] + (i == ContinentCount - 1 ? "" : listElementSeparator);
    //    }

    //    return $"{nameof(ContinentPackage)}:{{{ContinentCount}, {ArrayListCapacity},\n{Continents}:\n[\n{continents}\n],\n{PackageName}}}";
    //}

    public byte[] GetTcString()
    {
        var result = new byte[3 + FileName.Length];

        var lengthBytes = BinaryUtils.ConvertToBytes(FileName.Length);
        var nameBytes = BinaryUtils.ConvertToBytes(FileName ?? throw new ArgumentNullException($"File name is null.", nameof(FileName)));

        result[0] = JavaSerializationConstants.TC_STRING;
        Buffer.BlockCopy(lengthBytes, 0, result, 1, lengthBytes.Length);
        Buffer.BlockCopy(nameBytes, 0, result, 3, nameBytes.Length);

        return result;
    }
}