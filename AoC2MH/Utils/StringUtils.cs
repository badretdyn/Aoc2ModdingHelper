using System.Text;

namespace AoC2mh.Utils;

public static class StringUtils
{
    /// <summary>
    /// Get string out of list.
    /// </summary>
    /// <typeparam name="T">List's element type.</typeparam>
    /// <param name="list">List of T elements.</param>
    /// <param name="listElementSeparator">Character between elements in list.</param>
    /// <param name="tabCount">Count of \t characters. Elements always have (<paramref name="tabCount"/> + 1).</param>
    /// <returns>[\n%list elements, separated <paramref name="listElementSeparator"/>%\n]</returns>
    /// <exception cref="ArgumentException">If <paramref name="tabCount"/> < 0</exception>
    public static string StringifyList<T>(List<T> list, string listElementSeparator = ",\n", int tabCount = 0)
    {
        if (list == null)
        {
            return "[](0)";
        }

        if (tabCount < 0)
            throw new ArgumentException($"{nameof(tabCount)} must be >= 0.", nameof(tabCount));

        string result = "\n" + new string('\t', tabCount) + "[\n";
        for (int i = 0; i < list.Count; i++)
        {
            result += new string('\t', tabCount + 1) + $"[{i}]:" + (list[i] is IStringifyable stringifyable ? stringifyable.ToStringList(tabCount + 1) : list[i]) + (i == list.Count - 1 ? "" : listElementSeparator);
        }
        result = result + "\n" + new string('\t', tabCount) + $"]({list.Count})";
        return result;
    }
}
