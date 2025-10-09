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
    public class Province : IJavaSerializable
    {
        public string FileName { get; set; }

        public int LevelOfPort { get;set; } // 0x14d
        
        public int PortShiftX { get;set; } // 0x151

        public int PortShiftY { get;set; } // 0x155

        public int NeighboringProvincesSize { get; set; } // size 0x184, 0x18a
        public List<short> NeighboringProvinces { get; set; } //  0x1d5, 0x1dd, 0x1e5, 0x1ed

        public int NeighboringSeaProvincesSize { get; set; } // 0x1f6, 0x1fc
        public List<short> NeighboringSeaProvinces { get; set; } // 0x206, 0x20e

        public int PointsXListSize { get; set; } // 0x217, 0x21d
        public List<short> PointsX { get; set; } // 0x221, value 0x227, list end 0x78

        public int PointsYListSize { get; set; } // 0x618, 
        public List<short> PointsY { get; set; } // 0x622, value 0x628, list end 0xa12


        public List<ProvinceBorder> ProvinceBorders { get; set; } // 

        public ProvinceInfo ProvinceInfo { get; set; }

        public Province(string fileName, int levelOfPort, int portShiftX, int portShiftY, int neighboringProvincesSize, List<short> neighboringProvinces,
            int neighboringSeaProvincesSize, List<short> neighboringSeaProvinces, int pointsXListSize, List<short> pointsX, int pointsYListSize,
            List<short> pointsY, List<ProvinceBorder> provinceBorder, ProvinceInfo provinceInfo)
        {
            FileName = fileName;
            LevelOfPort = levelOfPort;
            PortShiftX = portShiftX;
            PortShiftY = portShiftY;
            NeighboringProvincesSize = neighboringProvincesSize;
            NeighboringProvinces = neighboringProvinces;
            NeighboringSeaProvincesSize = neighboringSeaProvincesSize;
            NeighboringSeaProvinces = neighboringSeaProvinces;
            PointsXListSize = pointsXListSize;
            PointsX = pointsX;
            PointsYListSize = pointsYListSize;
            PointsY = pointsY;
            ProvinceBorders = provinceBorder;
            ProvinceInfo = provinceInfo;
        }

        public override string ToString()
        {
            string result =
                $"{nameof(Province)}:" + "\n" +
                $"{{" + "\n" +
                $"FileName: {FileName}," + "\n" +
                $"LevelOfPort: {LevelOfPort}," + "\n" +
                $"PortShiftX: {PortShiftX}," + "\n" +
                $"PortShiftY: {PortShiftY}," + "\n" +
                $"NeighboringProvincesSize: {NeighboringProvincesSize}," + "\n" +
                $"NeighboringProvinces: {NeighboringProvinces}" + "\n" +
                $"NeighboringSeaProvincesSize: {NeighboringSeaProvincesSize}" + "\n" +
                $"NeighboringSeaProvinces: {NeighboringSeaProvinces}" + "\n" +
                $"PointsXListSize: {PointsXListSize}" + "\n" +
                $"pointsX: {PointsX}" + "\n" +
                $"PointsYListSize: {PointsYListSize}" + "\n" +
                $"PointsY: {PointsY}" + "\n" +
                $"ProvinceBorders: {ProvinceBorders}" + "\n" +
                $"ProvinceInfo: {ProvinceInfo}" + "\n" +
                $"}}";

            return result;
        }

        public string ToStringList(string listElementSeparator = ",\n")
        {
            //string neighboringProvinces = StringUtils.StringifyList(NeighboringProvinces, listElementSeparator);
            //string neighboringSeaProvinces = StringUtils.StringifyList(NeighboringSeaProvinces, listElementSeparator);
            //string pointsX = StringUtils.StringifyList(PointsX, listElementSeparator);
            //string pointsY = StringUtils.StringifyList(PointsY, listElementSeparator);

            string result =
                $"{nameof(Province)}:" + "\n" +
                $"{{" + "\n" +
                "\t" + $"FileName: {FileName}," + "\n" +
                "\t" + $"LevelOfPort: {LevelOfPort}," + "\n" +
                "\t" + $"PortShiftX: {PortShiftX}," + "\n" +
                "\t" + $"PortShiftY: {PortShiftY}," + "\n" +
                "\t" + $"NeighboringProvincesSize: {NeighboringProvincesSize}," + "\n" +
                "\t" + $"NeighboringProvinces: {NeighboringProvinces}" + "\n" +
                "\t" + $"NeighboringSeaProvincesSize: {NeighboringSeaProvincesSize}" + "\n" +
                "\t" + $"NeighboringSeaProvinces: {NeighboringSeaProvinces}" + "\n" +
                "\t" + $"PointsXListSize: {PointsXListSize}" + "\n" +
                "\t" + $"pointsX: {PointsX}" + "\n" +
                "\t" + $"PointsYListSize: {PointsYListSize}" + "\n" +
                "\t" + $"PointsY: {PointsY}" + "\n" +
                "\t" + $"ProvinceBorders: {ProvinceBorders}" + "\n" +
                "\t" + $"ProvinceInfo: {ProvinceInfo}" + "\n" +
                $"}}";

            return result;
        }

        public byte[] GetTcString()
        {
            throw new NotImplementedException();
        }
    }
}
