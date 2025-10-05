using Aoc2ModdingHelper.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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

            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);

            float result = BitConverter.ToSingle(bytes, 0);
            return result;
        }

        public static short ConvertToInt16(byte[] data, int index = 0)
        {
            byte[] bytes = new byte[2];
            Array.Copy(data, index, bytes, 0, 2);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);

            short result = BitConverter.ToInt16(bytes, 0);
            return result;
        }

        public static int ConvertToInt32(byte[] data, int index = 0)
        {
            byte[] bytes = new byte[4];
            Array.Copy(data, index, bytes, 0, 4);

            if (BitConverter.IsLittleEndian)
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

        public static byte[] ConvertToBytes(short number)
        {
            byte[] bytes = BitConverter.GetBytes(number);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);

            return bytes;
        }

        public static byte[] ConvertToBytes(int number)
        {
            byte[] bytes = BitConverter.GetBytes(number);
            
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);
            
            return bytes;
        }

        public static byte[] ConvertToBytes(string str)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(str);

            //if (BitConverter.IsLittleEndian)
            //    Array.Reverse(bytes);

            return bytes;
        }

        public static string BytesToCsharp(byte[] bytes, bool useLineBreak = false)
        {
            string stringBytes = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                stringBytes += $"0x{bytes[i]:X}, ";
                if (useLineBreak && (i % 16 == 0) && i != 0)
                    stringBytes += "\n";
            }

            return stringBytes;
        }

        public static string BytesToCsharp(string filePath, bool useLineBreak = false)
        {
            byte[] fileContent = File.ReadAllBytes(filePath);
            return BytesToCsharp(filePath, useLineBreak);
        }
    }
}
