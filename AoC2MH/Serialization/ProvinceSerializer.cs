using Aoc2mh.Exceptions;
using Aoc2mh.Utils;
using AoC2mh.Entities;
using AoC2mh.Serialization.Java;

namespace AoC2mh.Serialization
{
    public static class ProvinceSerializer
    {
        public static Province FromJava(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            byte[] fileBytes = File.ReadAllBytes(filePath);
            Province province = FromJava(fileBytes);
            province.FileName = fileName;
            return province;
        }

        public static ProvincePoints PointsFromJava(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            byte[] fileBytes = File.ReadAllBytes(filePath);
            ProvincePoints provincePoints = PointsFromJava(fileBytes);
            provincePoints.FileName = fileName;
            return provincePoints;
        }

        public static ProvincePoints PointsFromJava(byte[] data)
        {
            int[] listIndexes = BinaryUtils.FindPattern(data, [0x73, 0x71, 0x00, 0x7E, 0x00, 0x04]);
            int pointsXIndex = listIndexes[1];
            int current = pointsXIndex + 6; int pointsXSize = BinaryUtils.ConvertToInt32(data, current);
            current += 10; List<short> pointsX = DeserializeListShorts(ref current, data, pointsXSize);

            int pointsYIndex = listIndexes[2];
            current = pointsYIndex + 6; int pointsYSize = BinaryUtils.ConvertToInt32(data, current);
            current += 10; List<short> pointsY = DeserializeListShorts(ref current, data, pointsXSize);

            ProvincePoints provincePoints = new ProvincePoints(pointsX, pointsY);
            return provincePoints;
        }

        [Obsolete("It does not deserialize all provinces (on borders of the map).", false)]
        public static Province FromJava(byte[] data)
        {
            // indexes
            int levelOfPortIndex = 0x14d;
            int portShiftXIndex = 0x151;
            int portShiftYIndex = 0x155;

            int neighboringProvincesSizeIndex = 0x184;
            //int neighboringProvincesSize2Index = 0x18a;

            // values
            int levelOfPort = BinaryUtils.ConvertToInt32(data, levelOfPortIndex);
            int portShiftX = BinaryUtils.ConvertToInt32(data, portShiftXIndex);
            int portShiftY = BinaryUtils.ConvertToInt32(data, portShiftYIndex);

            // neighobring provinces
            int neighboringProvincesSize = BinaryUtils.ConvertToInt32(data, neighboringProvincesSizeIndex);

            int firstNeighboringProvince = 0x1d5;
            int serializationStart = 0x1d7;

            List<short> neighboringProvinces = new List<short>();
            neighboringProvinces.Add(BinaryUtils.ConvertToInt16(data, firstNeighboringProvince));
            int currentIndex = serializationStart; neighboringProvinces.AddRange(DeserializeListShorts(ref currentIndex, data, neighboringProvincesSize - 1));

            // neighboring sea provinces
            currentIndex += 7; int neighboringSeaProvincesSize = BinaryUtils.ConvertToInt32(data, currentIndex);
            currentIndex += 6; //int neighboringSeaProvincesSize2 = BinaryUtils.ConvertToInt32(data, currentIndex);

            currentIndex += 4; List<short> neighboringSeaProvinces = DeserializeListShorts(ref currentIndex, data, neighboringSeaProvincesSize);

            // points x
            currentIndex += 7; int pointsXListSize = BinaryUtils.ConvertToInt32(data, currentIndex);
            currentIndex += 10; List<short> pointsX = DeserializeListShorts(ref currentIndex, data, pointsXListSize);

            // points y
            currentIndex += 7; int pointsYListSize = BinaryUtils.ConvertToInt32(data, currentIndex);
            currentIndex += 10; List<short> pointsY = DeserializeListShorts(ref currentIndex, data, pointsYListSize);

            // province borders
            currentIndex += 7; int provinceBorderCount = BinaryUtils.ConvertToInt32(data, currentIndex);
            currentIndex += 138; List<ProvinceBorder> provinceBorders = GetProvinceBorders(ref currentIndex, data, provinceBorderCount);

            // province info
            currentIndex += 169; float growthRate = BinaryUtils.ConvertToFloat32(data, currentIndex);
            currentIndex += 4; int continentID = BinaryUtils.ConvertToInt32(data, currentIndex);
            currentIndex += 4; int regiondID = BinaryUtils.ConvertToInt32(data, currentIndex);
            currentIndex += 4; int shiftX = BinaryUtils.ConvertToInt32(data, currentIndex);
            currentIndex += 4; int shiftY = BinaryUtils.ConvertToInt32(data, currentIndex);
            currentIndex += 4; string terraingTAG = JavaSerialization.TakeTcString(data, currentIndex).str;
            ProvinceInfo provinceInfo = new ProvinceInfo(growthRate, continentID, regiondID, shiftX, shiftY, terraingTAG);

            Province province = new Province("", levelOfPort, portShiftX, portShiftY, neighboringProvinces, neighboringSeaProvinces, pointsX, pointsY, provinceBorders, provinceInfo);

            return province;
        }

        /// <summary>
        /// Deserialize list of shorts (Int16).
        /// </summary>
        /// <param name="currentIndex">List's first element starting on "sq" (0x73 0x71)</param>
        /// <param name="data">File bytes</param>
        /// <param name="listSize">List length</param>
        /// <returns>Provinces's ID list</returns>
        private static List<short> DeserializeListShorts(ref int currentIndex, byte[] data, int listSize)
        {
            List<short> result = new List<short>();

            short lastNormal = 0;
            for (int i = 0; i < listSize; i++)
            {
                if (data[currentIndex] == 0x71)
                {
                    currentIndex += 5; result.Add(lastNormal); continue;
                }

                short sh = DeserializeShort(ref currentIndex, data[currentIndex..(currentIndex+8)]);
                lastNormal = sh;
                result.Add(sh);
            }

            return result;
        }

        private static short DeserializeShort(ref int endIndex, byte[] data)
        {
            byte[] meta = data[0..2];

            if (meta.SequenceEqual(new byte[] { 0x73, 0x71, }))
            {
                endIndex += data.Length ;
                return BinaryUtils.ConvertToInt16(data, 6); // 0 1 2 3 4 5 6 7
            }

            throw new PatternNotFoundException(nameof(data), data.ToString());
        }

        private static List<ProvinceBorder> GetProvinceBorders(ref int endIndex, byte[] data, int borderCount)
        {
            List<ProvinceBorder> result = new List<ProvinceBorder>();

            for (int i = 0; i < borderCount; i++)
            {
                ProvinceBorder provinceBorder = DeserializeProvinceBorder(ref endIndex, data, borderCount, endIndex);
                endIndex += 7;
                result.Add(provinceBorder);
            }

            return result;
        }

        private static ProvinceBorder DeserializeProvinceBorder(ref int currentIndex, byte[] data, int borderCount, int startIndex = 0)
        {
            int withProvinceID = BinaryUtils.ConvertToInt32(data, currentIndex);
            currentIndex += 10; int pointsXSize = BinaryUtils.ConvertToInt32(data, currentIndex);
            currentIndex += 10; List<short> pointsX = DeserializeListShorts(ref currentIndex, data, pointsXSize);
            currentIndex += 17; List<short> pointsY = DeserializeListShorts(ref currentIndex, data, pointsXSize);
            ProvinceBorder provinceBorder = new ProvinceBorder(withProvinceID, pointsX, pointsY);
            return provinceBorder;
        }
    }
}
