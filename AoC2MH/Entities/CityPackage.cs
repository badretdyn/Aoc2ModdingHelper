using Aoc2mh.Entities;
using AoC2mh.Exceptions;
using AoC2mh.Utils;

namespace AoC2mh.Entities
{
    public class CityPackage : IStringifyable
    {
        public string FileName { get; set; }

        public List<City> Cities { get; set; }

        public CityPackage(string fileName, List<City> cities)
        {
            FileName = string.IsNullOrWhiteSpace(fileName) ? throw new ArgumentCitiesException($"{nameof(fileName)} is null or whitespace.", nameof(fileName)) : fileName;
            Cities = cities ?? throw new ArgumentCitiesException($"{nameof(cities)} is null.", nameof(cities));
        }

        public string ToStringList(int tabCount = 0)
        {
            string result =
                $"{nameof(CityPackage)}:" + "\n" +
                new string('\t', tabCount) + $"{{" + "\n" +
                new string('\t', tabCount + 1) + $"FileName: {FileName}," + "\n" +
                new string('\t', tabCount + 1) + $"ProvinceInfo: {StringUtils.StringifyList(list: Cities, tabCount: tabCount)}," + "\n" +
                new string('\t', tabCount) + $"}}";

            return result;
        }
    }
}
