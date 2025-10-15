using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2mh.Exceptions
{
    public class ArgumentCityException : ArgumentException
    {
        public ArgumentCityException() { }

        public ArgumentCityException(string paramName) : base($"Ivalid argument {paramName}.", paramName) { }

        public ArgumentCityException(string message, string paramName) : base(message, paramName) { }
    }
}
