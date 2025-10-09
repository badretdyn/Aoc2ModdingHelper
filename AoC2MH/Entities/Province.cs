using Aoc2mh.Entities;
using AoC2mh.Serialization.Java;
using AoC2mh.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2mh.Entities
{
    public class Province : IJavaSerializable, IStringifyable 
    {
        public string FileName { get; set; }

        public int LevelOfPort { get;set; } // 0x14d
        
        public int PortShiftX { get;set; } // 0x151

        public int PortShiftY { get;set; } // 0x155

        //public int NeighboringProvincesSize { get; set; } // size 0x184, 0x18a
        public List<short> NeighboringProvinces { get; set; } //  0x1d5, 0x1dd, 0x1e5, 0x1ed

        //public int NeighboringSeaProvincesSize { get; set; } // 0x1f6, 0x1fc
        public List<short> NeighboringSeaProvinces { get; set; } // 0x206, 0x20e

        //public int PointsXListSize { get; set; } // 0x217, 0x21d
        public List<short> PointsX { get; set; } // 0x221, value 0x227, list end 0x78

        //public int PointsYListSize { get; set; } // 0x618, 
        public List<short> PointsY { get; set; } // 0x622, value 0x628, list end 0xa12


        public List<ProvinceBorder> ProvinceBorders { get; set; } // 

        public ProvinceInfo ProvinceInfo { get; set; }

        public Province(string fileName, int levelOfPort, int portShiftX, int portShiftY, List<short> neighboringProvinces,
            List<short> neighboringSeaProvinces, List<short> pointsX, List<short> pointsY, List<ProvinceBorder> provinceBorder,
            ProvinceInfo provinceInfo)
        {
            FileName = fileName;
            LevelOfPort = levelOfPort;
            PortShiftX = portShiftX;
            PortShiftY = portShiftY;
            //NeighboringProvincesSize = neighboringProvincesSize;
            NeighboringProvinces = neighboringProvinces;
            //NeighboringSeaProvincesSize = neighboringSeaProvincesSize;
            NeighboringSeaProvinces = neighboringSeaProvinces;
            //PointsXListSize = pointsXListSize;
            PointsX = pointsX;
            //PointsYListSize = pointsYListSize;
            PointsY = pointsY;
            ProvinceBorders = provinceBorder;
            ProvinceInfo = provinceInfo;
        }

        public override string ToString()
        {
            string result =
                $"{nameof(Province)}:" +
                $"{{" +
                $"FileName: {FileName}, " +
                $"LevelOfPort: {LevelOfPort}, " +
                $"PortShiftX: {PortShiftX}, " +
                $"PortShiftY: {PortShiftY}, " +
                $"NeighboringProvinces: {NeighboringProvinces}, " +
                $"NeighboringSeaProvinces: {NeighboringSeaProvinces}, " +
                $"pointsX: {PointsX}, " +
                $"PointsY: {PointsY}, " +
                $"ProvinceBorders: {ProvinceBorders}, " +
                $"ProvinceInfo: {ProvinceInfo}" +
                $"}}";

            return result;
        }

        public string ToStringList(int tabCount = 0)
        {
            string result =
                $"{nameof(Province)}:" + "\n" +
                new string('\t', tabCount) + $"{{" + "\n" +
                new string('\t', tabCount + 1) + $"FileName: {FileName}," + "\n" +
                new string('\t', tabCount + 1) + $"LevelOfPort: {LevelOfPort}," + "\n" +
                new string('\t', tabCount + 1) + $"PortShiftX: {PortShiftX}," + "\n" +
                new string('\t', tabCount + 1) + $"PortShiftY: {PortShiftY}," + "\n" +
                new string('\t', tabCount + 1) + $"NeighboringProvinces: {StringUtils.StringifyList(list: NeighboringProvinces, tabCount: tabCount + 1)}," + "\n" +
                new string('\t', tabCount + 1) + $"NeighboringSeaProvinces: {StringUtils.StringifyList(list: NeighboringSeaProvinces, tabCount: tabCount + 1)}," + "\n" +
                new string('\t', tabCount + 1) + $"pointsX: {StringUtils.StringifyList(list: PointsX, tabCount: tabCount + 1)}," + "\n" +
                new string('\t', tabCount + 1) + $"PointsY: {StringUtils.StringifyList(list:PointsY, tabCount: 1)}," + "\n" +
                new string('\t', tabCount + 1) + $"ProvinceBorders: {StringUtils.StringifyList(ProvinceBorders, tabCount: tabCount + 1)}," + "\n" +
                new string('\t', tabCount + 1) + $"ProvinceInfo: {ProvinceInfo.ToString(tabCount + 1)}," + "\n" +
                new string('\t', tabCount) + $"}}";

            return result;
        }

        public byte[] GetTcString()
        {
            throw new NotImplementedException();
        }
    }
}
