using Aoc2mh.Entities;
using AoC2mh.Exceptions;

namespace AoC2mh.Entities
{
    public class CityPackage
    {
        public string FileName { get; set; }

        public List<City> Cities { get; set; }

        public CityPackage(string fileName, List<City> cities)
        {
            FileName = string.IsNullOrWhiteSpace(fileName) ? throw new ArgumentCitiesException($"{nameof(fileName)} is null or whitespace.", nameof(fileName)) : fileName;
            Cities = cities ?? throw new ArgumentCitiesException($"{nameof(cities)} is null.", nameof(cities));
        }
    }
}
