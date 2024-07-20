using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk.Loader
{
    internal class FileSelector
    {
        // Default path to country lists directory
        private const string defaultPath = @"..\..\..\Country Lists\";

        private string[] Files { get; }

        public FileSelector(string path = defaultPath)
        {
            Files = Directory.GetFiles(path);
        }

        public string SelectFile(int id)
        {
            if (id < 0 || id >= Files.Length) return defaultPath + "countries-manual.json";   
            return Files[id];
        }

        public void ListFiles()
        {
            for (int i = 0; i < Files.Length; i++)
            {
                Console.WriteLine($">{i}: {Files[i]}");
            }
        }
    }
}
