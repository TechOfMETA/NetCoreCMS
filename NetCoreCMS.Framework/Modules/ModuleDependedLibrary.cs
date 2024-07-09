using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NetCoreCMS.Framework.Modules
{
    public class ModuleDependedLibrary
    {
        public ModuleDependedLibrary()
        {
            AssemblyPaths = new Dictionary<string, Assembly>();
        }

        public string ModuleName { get; set; }
        public Dictionary<string, Assembly> AssemblyPaths { get; set; }
    }
}
