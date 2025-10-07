using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2mh.Entities
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
    }
}
