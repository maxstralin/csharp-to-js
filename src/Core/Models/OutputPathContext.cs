using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CSharpToJs.Core.Models
{
    public class OutputPathContext
    {
        public OutputPathContext(JsClass jsClass, string processingNamespace, AssemblyDetails assemblyDetails, CSharpToJsConfig config)
        {
            JsClass = jsClass;
            ProcessingNamespace = processingNamespace;
            AssemblyDetails = assemblyDetails;
            Config = config;
        }

        public JsClass JsClass { get; }

        public string ProcessingNamespace { get; }

        public AssemblyDetails AssemblyDetails { get; }

        public CSharpToJsConfig Config { get; }
    }
}
