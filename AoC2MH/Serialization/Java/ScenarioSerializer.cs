using Aoc2mh.Entities;
using Aoc2mh.Utils;

namespace Aoc2mh.Serialization.Java
{
    public static class ScenarioSerializer
    {
        public static Scenario Deserialize(string scenDirPath)
        {
            List<string> filePaths = Directory.GetFiles(scenDirPath).ToList();
            filePaths.Add(Directory.GetFiles(scenDirPath + @"\events")[0]);

            var fileNames = ReposUtils.GetFileNames(filePaths.ToArray());

            string fileName = Path.GetFileName(scenDirPath);
            string fileA = null;
            string fileC = null;
            string fileD = null;
            string fileHre = null;
            ScenarioInfo scenarioInfo = null;
            string filePd = null;
            string fileW = null;
            string fileE = null;

            foreach (string file in fileNames)
            {
                if (file.EndsWith("_A"))
                {
                    fileA = file;
                }
                else if (file.EndsWith("_C"))
                {
                    fileC = file;
                }
                else if (file.EndsWith("_D"))
                {
                    fileD = file;
                }
                else if (file.EndsWith("_HRE"))
                {
                    fileHre = file;
                }
                else if (file.EndsWith("_INFO.json"))
                {
                    scenarioInfo = ScenarioInfoSerializer.DeserializePath(scenDirPath + "\\" + file);
                }
                else if (file.EndsWith("_PD"))
                {
                    filePd = file;
                }
                else if (file.EndsWith("_W"))
                {
                    fileW = file;
                }
                else if (file.EndsWith("_E"))
                {
                    fileE = file;
                }
            }

            Scenario scenario = new Scenario(fileName, fileA, fileC, fileD, fileHre, scenarioInfo, filePd, fileW, fileE);

            return scenario;
        }
    }
}
