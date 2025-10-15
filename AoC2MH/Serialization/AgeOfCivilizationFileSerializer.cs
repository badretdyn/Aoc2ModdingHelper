using Aoc2mh.Entities;

namespace Aoc2mh.Serialization;

public static class AgeOfCivilizationFileSerializer
{
    public static AgeOfCivilizationsFile Deserialize(string dirPath)
    {
        string[] dirPaths = Directory.GetDirectories(dirPath);
        string[] dirNames = new string[dirPaths.Length];

        for (int i = 0; i < dirPaths.Length; i++)
        {
            string dirName = Path.GetFileName(dirPaths[i]);
            dirNames[i] = dirName;
        }

        string[] filePaths = Directory.GetFiles(dirPath);
        List<string> fileNames = new List<string>();

        for (int i = 0; i < filePaths.Length; i++)
        {
            string fileName = Path.GetFileName(filePaths[i]);
            if (fileName == "Age_of_Civilizations")
                continue;
            fileNames.Add(fileName);

        }

        AgeOfCivilizationsFile aocf = new AgeOfCivilizationsFile(dirNames, fileNames.ToArray());

        return aocf;
    }

    public static string Serialize(AgeOfCivilizationsFile aocf)
    {
        string result = "";
        result = string.Join(';', aocf.Dirs);
        result += ';';
        result += string.Join(';', aocf.Files);
        result += ';';

        return result;
    }
}
