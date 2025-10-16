namespace Aoc2mh.Utils
{
    public static class ReposUtils
    {
        public static string[] GetDirNames(string[] dirPaths)
        {
            List<string> dirNames = new List<string>();

            for (int i = 0; i < dirPaths.Length; i++)
            {
                string dirName = Path.GetFileName(dirPaths[i]);
                dirNames.Add(dirName);
            }

            return dirNames.ToArray();
        }

        public static string[] GetFileNames(string[] filePaths, bool ignoreAocFile = false)
        {
            List<string> fileNames = new List<string>();

            for (int i = 0; i < filePaths.Length; i++)
            {
                string fileName = Path.GetFileName(filePaths[i]);
                if (fileName == "Age_of_Civilizations" && ignoreAocFile)
                    continue;
                fileNames.Add(fileName);

            }

            return fileNames.ToArray();
        }
    }
}
