using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConfigurationChecker.Controller
{
    public class RegexBasedFileNamesReader
    {
        public string DirectoryPath { get; set; }

        public RegexBasedFileNamesReader(string directoryPath)
        {
            DirectoryPath = directoryPath;
        }

        public string[] GetFilenames(string pattern)
        {
            Regex regex = new Regex(pattern);
            string[] fileNames = Directory.GetFiles(DirectoryPath);
            return fileNames.Where(f=> regex.IsMatch(f)).ToArray();
        }
    }
}
