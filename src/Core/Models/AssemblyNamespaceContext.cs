using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpToJs.Core.Models
{
    public class AssemblyNamespaceContext : AssemblyContext
    {
        public AssemblyNamespaceContext(AssemblyDetails assemblyDetails, CSharpToJsConfig config, string processingNamespace) : base(assemblyDetails, config)
        {
            ProcessingNamespace = processingNamespace;
        }

        public string ProcessingNamespace { get; }

    }
}
