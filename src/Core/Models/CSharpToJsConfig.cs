using System.Collections.Generic;
using System.Linq;

namespace CSharpToJs.Core.Models
{
    public class CSharpToJsConfig
    {
        public string AssembliesPath { get; set; }
        public IEnumerable<AssemblyDetails> Assemblies { get; set; } = Enumerable.Empty<AssemblyDetails>();
        public bool NoClean { get; set; } = false;
        public bool UseNugetCacheResolver { get; set; } = false;
        public string OutputPath { get; set; }
    }
}
