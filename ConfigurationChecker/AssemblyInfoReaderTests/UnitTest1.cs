using System;
using AssemblyInfoReader;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssemblyInfoReaderTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ModulePeKindReader assemblyInfoReader = new ModulePeKindReader(@"c:\Test\X86Dll.dll");
            assemblyInfoReader.ReadInformation();


        }
    }
}
