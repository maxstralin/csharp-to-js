using System.Collections.Generic;
using System.Linq;

namespace CSharpToJs.Core.Models
{
    public class CSharpToJsConfig
    {
        public CSharpToJsConfig(string assembliesPath, IEnumerable<AssemblyDetails> assemblies, string outputPath)
        {
            AssembliesPath = assembliesPath;
            Assemblies = assemblies;
            OutputPath = outputPath;
        }

        public string AssembliesPath { get; }
        public IEnumerable<AssemblyDetails> Assemblies { get; }
        public bool NoClean { get; set; } = false;
        public bool UseNugetCacheResolver { get; set; } = false;
        public string OutputPath { get;  }
    }
}
