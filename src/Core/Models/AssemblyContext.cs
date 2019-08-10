
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpToJs.Core.Models
{
    public class AssemblyContext : ConfigContext
    {
        public AssemblyContext(AssemblyDetails assemblyDetails, CSharpToJsConfig config) : base(config) 
        {
            AssemblyDetails = assemblyDetails;
        }
        public AssemblyDetails AssemblyDetails { get; }
    }
}
