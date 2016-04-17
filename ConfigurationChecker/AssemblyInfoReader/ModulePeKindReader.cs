using System.Reflection;

namespace AssemblyInfoReader
{
    public class ModulePeKindReader
    {
        public PortableExecutableKinds PortableExecutableKinds { get; private set; }
        public ImageFileMachine ImageFileMachine { get; private set; }
        private string AssemblyPath { get; set; }
        public  AssemblyInfo AssemblyInfo { get; private set; }
        public ModulePeKindReader(string assemblyPath)
        {
            AssemblyPath = assemblyPath;
        }

        public void ReadInformation()
        {
            Assembly assembly = Assembly.ReflectionOnlyLoadFrom(AssemblyPath);
            AssemblyInfo = new AssemblyInfo(assembly.FullName, assembly.ImageRuntimeVersion);
            Module module = assembly.GetModules()[0];
            PortableExecutableKinds peKind;
            ImageFileMachine machine;
            module.GetPEKind(out peKind, out machine);
            UpdatePeKind(peKind, machine);
        }

        private void UpdatePeKind(PortableExecutableKinds peKind, ImageFileMachine machine)
        {
            PortableExecutableKinds = peKind;
            ImageFileMachine = machine;
        }
    }
}
