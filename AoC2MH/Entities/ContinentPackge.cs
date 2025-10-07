using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2mh.Entities;

public class ContinentPackge
{
    public ContinentPackge(int continentCount, int arrayListCapacity, List<Continent> continents, string packageName)
    {
        ContinentCount = continentCount;
        ArrayListCapacity = arrayListCapacity;
        Continents = continents;
        PackageName = packageName;
    }

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

        for (int i = 0; i < ContinentCount; i++)
        {
            continents += "\t" + Continents[i] + (i == ContinentCount - 1 ? "" : listElementSeparator);
        }

        return $"{nameof(ContinentPackge)}:{{{ContinentCount}, {ArrayListCapacity},\n{Continents}:\n[\n{continents}\n],\n{PackageName}}}";
    }
}