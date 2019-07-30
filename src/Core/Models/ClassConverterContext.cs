using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpToJs.Core.Models
{
    /// <summary>
    /// Context of the class conversion
    /// </summary>
    public class ClassConverterContext : AssemblyNamespaceContext
    {
        /// <summary>
        /// The type to be converted
        /// </summary>
        public Type Type { get; set; }
        /// <summary>
        /// Namespaces that are included in the conversion
        /// </summary>
        public IEnumerable<string> IncludedNamespaces { get; set; } = Enumerable.Empty<string>();
        /// <summary>
        /// Namespaces that are excluded in the conversion
        /// </summary>
        public IEnumerable<string> ExcludedNamespaces { get; set; } = Enumerable.Empty<string>();
    }
}
