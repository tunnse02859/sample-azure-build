using System;
using System.IO;

namespace Selenium_Sample.utilities
{
    public class FilePath
    {
        public static void CreateFolder(string path)
        {
            Directory.CreateDirectory(path);
        }
        public static void DeleteFolder(string path)
        {
            Directory.Delete(path);
        }
        public static void CreateFile(string path)
        {
            File.Create(path);
        }
        public static void DeleteFile(string path)
        {
            File.Delete(path);
        }
    }
}
