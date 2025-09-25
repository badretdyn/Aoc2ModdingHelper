using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Aoc2ModdingHelper
{
    public static class Repos
    {
        public static byte[] GetFileBytes(string path)
        {
            byte[] content = File.ReadAllBytes(path);
            return content;
        }

        public static void WriteFile(string path, string content)
        {
            if (!path.Contains(@":\"))
                path = Directory.GetCurrentDirectory() + path;

            File.WriteAllText(path, content);
        }
    }
}
