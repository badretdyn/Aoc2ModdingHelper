using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2ModdingHelper.Entities
{
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

        private static List<Continent> FindContinents(ref int endIndex, byte[] data, int startIndex = 0)
        {
            List<Continent> continents = new List<Continent>();

            for (int i = startIndex; i < data.Length;)
            {
                endIndex = i;

                byte current = data[i];
                short nameLength = -1;
                string name = "";

                if (current == 0x74)
                {
                    var tcString = JavaHelper.TakeTcString(data, i);
                    nameLength = tcString.length;
                    name = tcString.str;

                    Continent continent = new Continent(nameLength, name);
                    continents.Add(continent);

                    i += nameLength + 3;
                    continue;
                }
                else if (current == 0x78)
                {
                    break;
                }
                i++;
            }

            return continents;
        }

        public static ContinentPackge DeserializePackge(string packgePath)
        {
            byte[] fileContent = File.ReadAllBytes(packgePath);

            int continentCountIndex = 0xc5;
            int arrayListCapacityIndex = 0xcb;
            int arrayListStartIndex = 0xcf;

            int continentCount = ByteHelper.ConvertToInt32(fileContent, continentCountIndex);
            int arrayListCapacity = ByteHelper.ConvertToInt32(fileContent, arrayListCapacityIndex);
            string name = "";
            int endIndex = 0; List<Continent> continents = FindContinents(ref endIndex, fileContent, arrayListStartIndex);

            for (int i = endIndex; i < fileContent.Length; i++)
            {
                byte current = fileContent[i];
                if (current == 0x74)
                {
                    var tcString = JavaHelper.TakeTcString(fileContent, i);

                    short nameLength = tcString.length;
                    name = tcString.str;

                    break;
                }
            }

            ContinentPackge continentPackge = new ContinentPackge(continentCount, arrayListCapacity, continents, name);

            return continentPackge;
        }
    }
}
