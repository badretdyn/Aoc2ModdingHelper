using Aoc2mh.Serialization.Java;
using Aoc2mh.Utils;
using static Aoc2mh.Entities.ScenarioInfo;

namespace Aoc2mh.Entities;

public class Scenario : IJavaSerializable
{
    public string FileName { get; set; } // folder and first file

    public string FileA { get; set; }

    public string FileC { get; set; }

    public string FileD { get; set; }

    public string FileHre { get; set; }

    public ScenarioInfo ScenarioInfo { get; set; } // _INFO, description

    public string FilePd { get; set; }

    public string FileW { get; set; }

    public string FileE { get; set; } // events

    public Scenario(string fileName, string fileA, string fileC, string fileD, string fileHre, ScenarioInfo scenarioInfo, string filePd, string fileW, string fileE)
    {
        FileName = fileName;
        FileA = fileA;
        FileC = fileC;
        FileD = fileD;
        FileHre = fileHre;
        ScenarioInfo = scenarioInfo;
        FilePd = filePd;
        FileW = fileW;
        FileE = fileE;
    }

    public override string ToString()
    {
        string result =
            $"{nameof(Scenario)}:" +
            $"{{" +
            $"FileName: {FileName}, " +
            $"FileA: {FileA}, " +
            $"FileC: {FileC}, " +
            $"FileD: {FileD}, " +
            $"FileHre: {FileHre}, " +
            $"ScenarioInfo: {ScenarioInfo}, " +
            $"FilePd: {FilePd}, " +
            $"FileW: {FileW}, " +
            $"FileE: {FileE}" +
            $"}}";

        return result;
    }

    public string ToStringList(int tabCount = 0)
    {

        string result =
            $"{nameof(Scenario)}:" + "\n" +
            new string('\t', tabCount) + $"{{" + "\n" +
            new string('\t', tabCount + 1) + $"FileName: {FileName}," + "\n" +
            new string('\t', tabCount + 1) + $"FileA: {FileA}," + "\n" +
            new string('\t', tabCount + 1) + $"FileC: {FileC}," + "\n" +
            new string('\t', tabCount + 1) + $"FileD: {FileD}," + "\n" +
            new string('\t', tabCount + 1) + $"FileHre: {FileHre}," + "\n" +
            new string('\t', tabCount + 1) + $"ScenarioInfo: {ScenarioInfo.ToStringList(tabCount + 1)}," + "\n" +
            new string('\t', tabCount + 1) + $"FilePd: {FilePd}," + "\n" +
            new string('\t', tabCount + 1) + $"FileW: {FileW}," + "\n" +
            new string('\t', tabCount + 1) + $"FileE: {FileE}," + "\n" +
            new string('\t', tabCount) + $"}}";

        return result;
    }

    public byte[] GetTcString()
    {
        throw new NotImplementedException();
    }

    public void Rename(string newName)
    {
        this.FileA = this.FileA.Replace(FileName, newName);
        this.FileC = this.FileC.Replace(FileName, newName);
        this.FileD = this.FileD.Replace(FileName, newName);
        this.FileHre = this.FileHre.Replace(FileName, newName);
        this.ScenarioInfo.FileName = this.ScenarioInfo.FileName.Replace(FileName, newName);
        this.FilePd = this.FilePd.Replace(FileName, newName);
        this.FileW = this.FileW.Replace(FileName, newName);
        this.FileE = this.FileE.Replace(FileName, newName);
        this.FileName = newName;
    }
}
