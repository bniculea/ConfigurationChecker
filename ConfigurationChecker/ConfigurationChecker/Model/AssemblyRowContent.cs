
using AssemblyInfoReader;

namespace ConfigurationChecker.Model
{
    public class AssemblyRowContent
    {
        public string AssemblyName { get; private set; }
        public string Architecture { get; private set; }
        public ArchitectureConfiguration ArchitectureConfiguration { get; set; }
        public string RuntimeVersion { get; set; }

        public AssemblyRowContent(string assemblyName, string architecture, ArchitectureConfiguration architectureConfiguration, string runtimeVersion)
        {
            AssemblyName = assemblyName;
            Architecture = architecture;
            ArchitectureConfiguration = architectureConfiguration;
            RuntimeVersion = runtimeVersion;
        }
    }
}
