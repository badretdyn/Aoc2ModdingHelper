namespace Aoc2mh.Serialization.Java;

public interface IJavaSerializable
{
    string FileName { get; set; }

    byte[] GetTcString();
}
