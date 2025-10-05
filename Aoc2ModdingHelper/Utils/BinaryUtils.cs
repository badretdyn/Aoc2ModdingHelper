using System.Text;

namespace Aoc2ModdingHelper.Utils
{
    public static class BinaryUtils
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
                if (useLineBreak && i % 16 == 0 && i != 0)
                    stringBytes += "\n";
            }

            return stringBytes;
        }

        public static string BytesToCsharp(string filePath, bool useLineBreak = false)
        {
            byte[] fileContent = File.ReadAllBytes(filePath);
            return BytesToCsharp(filePath, useLineBreak);
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
    }
}
