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
        public ClassConverterContext(AssemblyDetails assemblyDetails, CSharpToJsConfig config, string processingNamespace, Type type, IEnumerable<string>? includedNamespaces, IEnumerable<string>? excludedNamespaces) : base(assemblyDetails, config, processingNamespace)
        {
            Type = type;
            IncludedNamespaces = includedNamespaces ?? Enumerable.Empty<string>();
            ExcludedNamespaces = excludedNamespaces ?? Enumerable.Empty<string>();
        }

        /// <summary>
        /// The type to be converted
        /// </summary>
        public Type Type { get; }
        /// <summary>
        /// Namespaces that are included in the conversion
        /// </summary>
        public IEnumerable<string> IncludedNamespaces { get; }
        /// <summary>
        /// Namespaces that are excluded in the conversion
        /// </summary>
        public IEnumerable<string> ExcludedNamespaces { get; }
    }
}
