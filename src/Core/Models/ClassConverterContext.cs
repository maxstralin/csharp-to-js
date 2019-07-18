using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpToJs.Core.Models
{
    public class ClassConverterContext : AssemblyNamespaceContext
    {
        public Type Type { get; set; }
        public IEnumerable<string> IncludedNamespaces { get; set; } = Enumerable.Empty<string>();
        public IEnumerable<string> ExcludedNamespaces { get; set; } = Enumerable.Empty<string>();
    }
}
