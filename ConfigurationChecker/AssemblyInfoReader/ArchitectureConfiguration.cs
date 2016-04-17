using System.Reflection;

namespace AssemblyInfoReader
{
    public class ArchitectureConfiguration
    {
        public PortableExecutableKinds PortableExecutableKinds { get; private set; }

        public ArchitectureConfiguration(PortableExecutableKinds portableExecutableKinds)
        {
            PortableExecutableKinds = portableExecutableKinds;
        }
    }
}
