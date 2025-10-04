using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2ModdingHelper
{
    public class JavaHelper
    {
        public static (short length, string str) TakeTcString(byte[] data, int startIndex)
        {
            short length = ByteHelper.ConvertToInt16([data[startIndex + 1], data[startIndex + 2]]);
            string str = ByteHelper.ConvertToString(data, length, startIndex + 3);
            return (length, str);
        }
    }
}
