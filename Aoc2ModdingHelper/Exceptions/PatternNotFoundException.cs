using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2ModdingHelper.Exceptions
{
    public class PatternNotFoundException : Exception
    {
        public PatternNotFoundException() : base("pattern not found in data") { }
        public PatternNotFoundException(string message) : base(message) { }
    }
}
