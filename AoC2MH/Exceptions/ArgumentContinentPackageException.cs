using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2mh.Exceptions
{
    public class ArgumentContinentPackageException : ArgumentException
    {
        public ArgumentContinentPackageException() { }

        public ArgumentContinentPackageException(string paramName) : base($"Ivalid argument {paramName}.", paramName) { }

        public ArgumentContinentPackageException(string message, string paramName) : base(message, paramName) { }
    }
}
