namespace Aoc2ModdingHelper.Utils;

public class JavaUtils
{
    public static (short length, string str) TakeTcString(byte[] data, int startIndex)
    {
        short length = BinaryUtils.ConvertToInt16([data[startIndex + 1], data[startIndex + 2]]);
        string str = BinaryUtils.ConvertToString(data, length, startIndex + 3);
        return (length, str);
    }
}
