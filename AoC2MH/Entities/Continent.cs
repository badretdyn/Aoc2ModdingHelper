using Aoc2mh.Utils;
using AoC2mh.Exceptions;
using AoC2mh.Serialization.Java;

namespace Aoc2mh.Entities;

public class Continent : IJavaSerializable
{
    public string FileName { get; set; }
    public float B { get; set; }
    public float G { get; set; }
    public float R { get; set; }
    public short NameLength { get; set; }
    public string Name { get; set; }

    public Continent(string fileName, float b, float g, float r, short nameLength, string name)
    {
        FileName = string.IsNullOrWhiteSpace(fileName) ? throw new ArgumentContinentException(
            $"Argument {nameof(fileName)} is null or white space.", nameof(fileName)) : fileName;
        B = b;
        G = g;
        R = r;
        NameLength = nameLength;
        Name = string.IsNullOrWhiteSpace(name) ? throw new ArgumentContinentException(
            $"Argument {nameof(name)} is null or white space.", nameof(name)) : name;
    }

    public Continent(float b, float g, float r, short nameLength, string name)
    {
        FileName = string.IsNullOrWhiteSpace(name) ? throw new ArgumentContinentException(
            $"Argument {nameof(name)} is null or white space.", nameof(name)) : name;
        B = b;
        G = g;
        R = r;
        NameLength = nameLength;
        Name = name;
    }

    public Continent(string name)
    {
        FileName = string.IsNullOrWhiteSpace(name) ? throw new ArgumentContinentException(
            $"Argument {nameof(name)} is null or white space.", nameof(name)) : name;
        NameLength = (short)name.Length;
        Name = name;
    }

    public override string ToString()
    {
        return $"{nameof(Continent)}:{{{FileName}, {B}, {G}, {R}, {NameLength}, {Name}}}";
    }

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
