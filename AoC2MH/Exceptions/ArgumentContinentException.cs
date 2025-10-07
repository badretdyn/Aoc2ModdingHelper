using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2mh.Exceptions
{
    public class ArgumentContinentException : ArgumentException
    {
        public ArgumentContinentException() { }

        public ArgumentContinentException(string paramName) : base($"Ivalid argument {paramName}.", paramName) { }

        public ArgumentContinentException(string message, string paramName) : base(message, paramName) { }
    }
}
