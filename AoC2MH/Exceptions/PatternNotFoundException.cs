using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2mh.Exceptions
{
    public class PatternNotFoundException : Exception
    {
        public PatternNotFoundException() : base("Pattern not found in data.") { }
        public PatternNotFoundException(string paramName, string pattern) : base($"Pattern {pattern} not found in {paramName}.") { }
    }
}
