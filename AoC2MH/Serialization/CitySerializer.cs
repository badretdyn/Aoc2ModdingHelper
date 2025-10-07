using System.Text;
using Aoc2mh.Entities;
using Aoc2mh.Utils;
using Aoc2mh.Exceptions;

namespace AoC2mh.Serialization
{
    public static class CitySerializer
    {
        public static byte[] ToJava(City city)
        {
            throw new NotImplementedException();
        }

        public static City FromJava(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            byte[] fileBytes = File.ReadAllBytes(filePath);
            City city = FromJava(fileBytes);
            city.FileName = fileName;
            return city;
        }

        [Obsolete("Have to be changed", false)]
        public static City FromJava(byte[] data)
        {
            int[] indexes = BinaryUtils.FindPattern(data, new byte[] { 0x78, 0x70 });
            if (indexes.Length == 0) throw new PatternNotFoundException();

            int index = indexes[0];

            int iCityLevelIndex = index + 2;
            int iPosXIndex = index + 6;
            int iPosYIndex = index + 10;
            int iWidthIndex = index + 14;
            int nameLengthIndex = index + 19;
            int sCityNameIndex = index + 21;

            int getValue(byte[] data, int index, int size = 1)
            {
                if (size < 1) throw new ArgumentOutOfRangeException("int size must be > 0");
                byte[] bytes = new byte[size];
                Array.Copy(data, index, bytes, 0, size);
                Array.Reverse(bytes);
                int result = 0;
                if (bytes.Length == 4)
                    result = BitConverter.ToInt32(bytes);
                else if (bytes.Length == 2)
                    result = BitConverter.ToInt16(bytes);
                else throw new Exception("not 4 or 2 bytes to convert to integer");
                return result;
            }

            int iCityLevel = getValue(data, iCityLevelIndex, 4);
            int iPosX = getValue(data, iPosXIndex, 4);
            int iPosY = getValue(data, iPosYIndex, 4);
            int iWidth = getValue(data, iWidthIndex, 4);
            int nameLength = getValue(data, nameLengthIndex, 2);
            string sCityName = Encoding.UTF8.GetString(data[sCityNameIndex..data.Length]);

            City result = new City(
                iCityLevel,
                iPosX,
                iPosY,
                iWidth,
                (short)nameLength,
                sCityName);

            return result;
        }
    }
}
