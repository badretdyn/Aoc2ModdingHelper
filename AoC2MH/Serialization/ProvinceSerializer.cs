using Aoc2mh.Entities;
using Aoc2mh.Exceptions;
using Aoc2mh.Utils;
using AoC2mh.Entities;
using AoC2mh.Serialization.Java;
using AoC2mh.Utils;
using System.Runtime.ExceptionServices;

namespace AoC2mh.Serialization
{
    public static class ProvinceSerializer
    {
        public static Province FromJava(byte[] data)
        {
            // indexes
            int levelOfPortIndex = 0x14d;
            int portShiftXIndex = 0x151;
            int portShiftYIndex = 0x155;

            int neighboringProvincesSizeIndex = 0x184;
            int neighboringProvincesSize2Index = 0x18a;

            int firstNeighboringProvince = 0x1d5;
            int serializationStart = 0x1d7;

            // values
            int levelOfPort = BinaryUtils.ConvertToInt32(data, levelOfPortIndex);
            int portShiftX = BinaryUtils.ConvertToInt32(data, portShiftXIndex);
            int portShiftY = BinaryUtils.ConvertToInt32(data, portShiftYIndex);

            // neighobring provinces
            int neighboringProvincesSize = BinaryUtils.ConvertToInt32(data, neighboringProvincesSizeIndex);
            int neighboringProvincesSize2 = BinaryUtils.ConvertToInt32(data, neighboringProvincesSize2Index);

            List<short> neighboringProvinces = new List<short>();
            neighboringProvinces.Add(BinaryUtils.ConvertToInt16(data, firstNeighboringProvince));
            int currentIndex = 0; neighboringProvinces.AddRange(FindProvinces(ref currentIndex, data, neighboringProvincesSize - 1, serializationStart));

            // neighboring sea provinces
            currentIndex += 7; int neighboringSeaProvincesSize = BinaryUtils.ConvertToInt32(data, currentIndex);
            currentIndex += 6; int neighboringSeaProvincesSize2 = BinaryUtils.ConvertToInt32(data, currentIndex);

            currentIndex += 4; List<short> neighboringSeaProvinces = FindProvinces(ref currentIndex, data, neighboringSeaProvincesSize, currentIndex);

            // points x
            currentIndex += 7; int pointsXListSize = BinaryUtils.ConvertToInt32(data, currentIndex);
            currentIndex += 10; List<short> pointsX = FindProvinces(ref currentIndex, data, pointsXListSize, currentIndex);

            // points y
            currentIndex += 7; int pointsYListSize = BinaryUtils.ConvertToInt32(data, currentIndex);
            currentIndex += 10; List<short> pointsY = FindProvinces(ref currentIndex, data, pointsYListSize, currentIndex);

            // province borders
            currentIndex += 7; int provinceBorderCount = BinaryUtils.ConvertToInt32(data, currentIndex);
            currentIndex += 138; List<ProvinceBorder> provinceBorders = FindProvinceBorders(ref currentIndex, data, provinceBorderCount, currentIndex);

            // province info
            currentIndex += 169; float growthRate = BinaryUtils.ConvertToFloat32(data, currentIndex);
            currentIndex += 4; int continentID = BinaryUtils.ConvertToInt32(data, currentIndex);
            currentIndex += 4; int regiondID = BinaryUtils.ConvertToInt32(data, currentIndex);
            currentIndex += 4; int shiftX = BinaryUtils.ConvertToInt32(data, currentIndex);
            currentIndex += 4; int shiftY = BinaryUtils.ConvertToInt32(data, currentIndex);
            currentIndex += 4; string terraingTAG = JavaSerialization.TakeTcString(data, currentIndex).str;
            ProvinceInfo provinceInfo = new ProvinceInfo(growthRate, continentID, regiondID, shiftX, shiftY, terraingTAG);

            Province province = new Province("", levelOfPort, portShiftX, portShiftY, neighboringProvincesSize, neighboringProvinces, neighboringSeaProvincesSize, neighboringSeaProvinces, pointsXListSize, pointsX, pointsYListSize, pointsY, provinceBorders, provinceInfo);

            return province;
        }

        /// <summary>
        /// Deserialize list of provinces.
        /// </summary>
        /// <param name="endIndex">Index where cycle stop</param>
        /// <param name="data">File bytes</param>
        /// <param name="listSize">Province count in list</param>
        /// <param name="startIndex">List's first element starting on "sq" (0x73 0x71)</param>
        /// <returns>Provinces's ID list</returns>
        private static List<short> FindProvinces(ref int endIndex, byte[] data, int listSize, int startIndex = 0)
        {
            List<short> result = new List<short>();

            for (int i = 0; i < listSize; i++)
            {
                short neighboringProvince = GetProvince(ref startIndex, data[startIndex..(startIndex+8)]);
                result.Add(neighboringProvince);
            }

            endIndex = startIndex;

            return result;
        }

        private static short GetProvince(ref int endIndex, byte[] data)
        {
            byte[] meta = data[0..6];
            if (meta.SequenceEqual(new byte[] { 0x73, 0x71, 0x00, 0x7E, 0x00, 0x06 }))
            {
                endIndex += data.Length;
                return BinaryUtils.ConvertToInt16(data, 6); // 0 1 2 3 4 5 6 7
            }

            throw new PatternNotFoundException(nameof(data), data.ToString());
        }

        private static List<ProvinceBorder> FindProvinceBorders(ref int endIndex, byte[] data, int borderCount, int startIndex = 0)
        {
            List<ProvinceBorder> result = new List<ProvinceBorder>();

            for (int i = 0; i < borderCount; i++)
            {
                ProvinceBorder provinceBorder = GetProvinceBorder(ref startIndex, data, borderCount, startIndex);
                startIndex += 7;
                result.Add(provinceBorder);
            }

            endIndex = startIndex;

            return result;
        }

        private static ProvinceBorder GetProvinceBorder(ref int currentIndex, byte[] data, int borderCount, int startIndex = 0)
        {
            int withProvinceID = BinaryUtils.ConvertToInt32(data, currentIndex);
            currentIndex += 10; int pointsXSize = BinaryUtils.ConvertToInt32(data, currentIndex);
            currentIndex += 10; List<short> pointsX = FindProvinces(ref currentIndex, data, pointsXSize, currentIndex);
            currentIndex += 17; List<short> pointsY = FindProvinces(ref currentIndex, data, pointsXSize, currentIndex);
            ProvinceBorder provinceBorder = new ProvinceBorder(withProvinceID, pointsX, pointsY);
            return provinceBorder;
        }
    }
}
