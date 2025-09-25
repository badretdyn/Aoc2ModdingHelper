using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2ModdingHelper
{
    public static class Tools
    {
        public static string ReadLine()
        {
            Console.ForegroundColor = ConsoleColor.White;
            string result = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            return result;
        }

        public static ConsoleKeyInfo ReadKey()
        {
            Console.ForegroundColor = ConsoleColor.White;
            ConsoleKeyInfo result = Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Yellow;
            return result;
        }

        public static void WriteError(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        public static byte[] HexStringToByteArray(string hex)
        {
            if (hex.Length % 2 != 0)
                throw new ArgumentException("hex string length error");

            byte[] data = new byte[hex.Length / 2];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return data;
        }

        public static int[] FindPattern(byte[] source, byte[] pattern)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (pattern == null)
                throw new ArgumentNullException(nameof(pattern));
            if (pattern.Length == 0)
                throw new ArgumentException("pattern cannot be empty", nameof(pattern));
            if (pattern.Length > source.Length)
                return new int[0];

            var indices = new List<int>();

            for (int i = 0; i <= source.Length - pattern.Length; i++)
            {
                bool found = true;

                for (int j = 0; j < pattern.Length; j++)
                {
                    if (source[i + j] != pattern[j])
                    {
                        found = false;
                        break;
                    }
                }

                if (found)
                {
                    indices.Add(i);
                }
            }

            return indices.ToArray();
        }

        public class PatternNotFoundException : Exception
        {
            public PatternNotFoundException() : base("pattern not found in data") { }
            public PatternNotFoundException(string message) : base(message) { }
        }
    }
}
