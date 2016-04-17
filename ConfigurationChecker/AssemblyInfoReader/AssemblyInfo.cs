namespace AssemblyInfoReader
{
    public class AssemblyInfo
    {
        public string RuntimeVersion { get; private set; }
        public string AssemblyName { get; private set; }

        public AssemblyInfo(string assemblyName, string runtimeVersion)
        {
            AssemblyName = assemblyName;
            RuntimeVersion = runtimeVersion;
        }
    }
}
