using System.Collections.ObjectModel;
using System.Reflection;
using AssemblyInfoReader;
using ConfigurationChecker.Model;

namespace ConfigurationChecker.Controller
{
    public class DataHandler
    {
        public ObservableCollection<AssemblyRowContent> Content { get; private set; }

        public DataHandler()
        {
            Content = new ObservableCollection<AssemblyRowContent>();
        }

        public void Update(string directoryPath, string pattern)
        {
            Content.Clear();
            RegexBasedFileNamesReader regexBasedFileNamesReader = new RegexBasedFileNamesReader(directoryPath);
            string[] fileNames = regexBasedFileNamesReader.GetFilenames(pattern);
           
            foreach (string fileName in fileNames)
            {
                ModulePeKindReader assemblyInfoReader = new ModulePeKindReader(fileName);
                assemblyInfoReader.ReadInformation();
                PortableExecutableKinds portableExecutableKinds = assemblyInfoReader.PortableExecutableKinds;
                ImageFileMachine imageFileMachine = assemblyInfoReader.ImageFileMachine;
                AssemblyInfo assemblyInfo = assemblyInfoReader.AssemblyInfo;
                AddRowContent(portableExecutableKinds, imageFileMachine, assemblyInfo);
            }
        }

        private void AddRowContent(PortableExecutableKinds portableExecutableKinds, ImageFileMachine imageFileMachine,
            AssemblyInfo assemblyInfo)
        {
            string architectureType = GetArchitectureType(imageFileMachine);
            ArchitectureConfiguration architectureConfiguration = new ArchitectureConfiguration(portableExecutableKinds);
            AssemblyRowContent rowContent = new AssemblyRowContent(assemblyInfo.AssemblyName, architectureType,
                architectureConfiguration, assemblyInfo.RuntimeVersion);
            Content.Add(rowContent);
        }


        private string GetArchitectureType(ImageFileMachine imageFileMachine)
        {
            switch (imageFileMachine)
            {
                case ImageFileMachine.AMD64:
                case ImageFileMachine.IA64:
                    return "64-bit";
                case ImageFileMachine.I386:
                    return "32-bit";
                case ImageFileMachine.ARM:
                    return "ARM";
                default:
                    return "Unknown";
            }
        }
    }
}
