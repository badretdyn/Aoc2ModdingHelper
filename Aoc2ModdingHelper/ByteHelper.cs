using Aoc2ModdingHelper.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Aoc2ModdingHelper
{
    public static class ByteHelper
    {
        public static float ConvertToFloat32(byte[] data, int index = 0)
        {
            byte[] bytes = new byte[4];
            Array.Copy(data, index, bytes, 0, 4);
            Array.Reverse(bytes);
            float result = BitConverter.ToSingle(bytes, 0);
            return result;
        }

        public static short ConvertToInt16(byte[] data, int index = 0)
        {
            byte[] bytes = new byte[2];
            Array.Copy(data, index, bytes, 0, 2);
            Array.Reverse(bytes);
            short result = BitConverter.ToInt16(bytes, 0);
            return result;
        }

        public static int ConvertToInt32(byte[] data, int index = 0)
        {
            byte[] bytes = new byte[4];
            Array.Copy(data, index, bytes, 0, 4);
            Array.Reverse(bytes);
            int result = BitConverter.ToInt32(bytes, 0);
            return result;
        }

        public static string ConvertToString(byte[] data, int length, int index = 0)
        {
            byte[] bytes = new byte[length];
            Array.Copy(data, index, bytes, 0, length);
            string result = Encoding.UTF8.GetString(bytes);
            return result;
        }
    }
}
