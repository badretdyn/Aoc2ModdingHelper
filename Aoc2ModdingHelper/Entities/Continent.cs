using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2ModdingHelper.Entities
{
    public class Continent
    {
        public Continent(string fileName, float b, float g, float r, short nameLength, string name)
        {
            FileName = fileName;
            B = b;
            G = g;
            R = r;
            NameLength = nameLength;
            Name = name;
        }

        public Continent(string fileName, float b, float g, float r, string name)
        {
            FileName = fileName;
            B = b;
            G = g;
            R = r;
            NameLength = (short)name.Length;
            Name = name;
        }

        public Continent(short nameLength, string name)
        {
            FileName = null;
            B = null;
            G = null;
            R = null;
            NameLength = nameLength;
            Name = name;
        }

        public Continent(string name)
        {
            FileName = null;
            B = null;
            G = null;
            R = null;
            NameLength = (short)name.Length;
            Name = name;
        }

        public string? FileName { get; set; }

        public float? B { get; set; }

        public float? G { get; set; }

        public float? R { get; set; }

        public short NameLength { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"{nameof(Continent)}:{{{FileName}, {B}, {G}, {R}, {NameLength}, {Name}}}";
        }

        public static Continent DeserializeContinent(string filePath)
        {
            string fileName = filePath.Split('\\')[^1];

            byte[] fileContent = File.ReadAllBytes(filePath);

            int fBIndex = 0x79;
            int fGIndex = 0x7d;
            int fRIndex = 0x81;
            int nameLengthIndex = 0x86;
            int nameIndex = 0x88;

            float fB = ByteHelper.ConvertToFloat32(fileContent, fBIndex);
            float fG = ByteHelper.ConvertToFloat32(fileContent, fGIndex);
            float fR = ByteHelper.ConvertToFloat32(fileContent, fRIndex);
            short nameLength = ByteHelper.ConvertToInt16(fileContent, nameLengthIndex);
            string name = ByteHelper.ConvertToString(fileContent, nameLength, nameIndex);

            //FileName = filePath.Split('\\')[^1];
            //B = fB;
            //G = fG;
            //R = fR;
            //NameLength = nameLength;
            //Name = name;

            return new Continent(fileName, fB, fG, fR, nameLength, name);
        }

        public static Continent[] DeserializeContinents(string packgeDataPath)
        {
            string[] filePaths = Directory.GetFiles(packgeDataPath);
            List<Continent> continents = new List<Continent>();
            foreach (string filePath in filePaths)
            {
                if (filePath.Split('\\')[^1] == "Age_of_Civilizations")
                    continue;
                try
                {
                    Continent continent = new Continent(filePath);
                    continents.Add(continent);
                }
                catch (Exception ex)
                {
                    Tools.WriteError($"error while processing {filePath}\n{ex.Message}");
                }
            }

            return continents.ToArray();
        }
    }
}
