namespace AoC2mh.Utils;

public static class StringUtils
{
    public static string StringifyList<T>(List<T> list, string listElementSeparator = ",\n")
    {
        if (list == null)
        {
            return "[]";
        }

        string result = "[\n";
        for (int i = 0; i < list.Count; i++)
        {
            result += "\t" + list[i] + (i == list.Count - 1 ? "" : listElementSeparator);
        }
        return result + "\n]";
    }
}
