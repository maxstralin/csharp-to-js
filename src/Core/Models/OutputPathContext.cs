using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CSharpToJs.Core.Models
{
    public class OutputPathContext
    {
        public JsClass JsClass { get; set; }

        public string ProcessingNamespace { get; set; }

        public AssemblyDetails AssemblyDetails { get; set; }

        public CSharpToJsConfig Config { get; set; }
    }
}
