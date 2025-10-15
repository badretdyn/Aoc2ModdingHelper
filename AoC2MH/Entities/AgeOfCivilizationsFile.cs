using Aoc2mh.Serialization.Java;
using Aoc2mh.Utils;
using System.IO;

namespace Aoc2mh.Entities;

public class AgeOfCivilizationsFile : IJavaSerializable, IStringifyable
{
    public string FileName { get; set; }

    public string[] Dirs { get; set; }

    public string[] Files { get; set; }


    public AgeOfCivilizationsFile(string fileName, string[] dirs, string[] files)
    {
        FileName = fileName;
        Dirs = dirs;
        Files = files;
    }

    public AgeOfCivilizationsFile(string[] dirs, string[] files)
    {
        FileName = "Age_of_Civilizations";
        Dirs = dirs;
        Files = files;
    }

    public override string ToString()
    {
        string result =
            $"{nameof(AgeOfCivilizationsFile)}:" +
            $"{{" +
            $"FileName: {FileName}, " +
            $"Dirs: {Dirs}, " +
            $"Files: {Files}, " +
            $"}}";

        return result;
    }

    public string ToStringList(int tabCount = 0)
    {
        string result =
            $"{nameof(Province)}:" + "\n" +
            new string('\t', tabCount) + $"{{" + "\n" +
            new string('\t', tabCount + 1) + $"FileName: {FileName}," + "\n" +
            new string('\t', tabCount + 1) + $"Dirs: {StringUtils.StringifyList(list: Dirs.ToList(), tabCount: tabCount + 1)}," + "\n" +
            new string('\t', tabCount + 1) + $"Files: {StringUtils.StringifyList(list: Files.ToList(), tabCount: tabCount + 1)}," + "\n" +
            new string('\t', tabCount) + $"}}";

        return result;
    }

    public byte[] GetTcString()
    {
        throw new NotImplementedException();
    }
}
