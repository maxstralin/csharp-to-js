using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CSharpToJs.Core.Attributes;
using CSharpToJs.Core.Interfaces;

namespace CSharpToJs.Core.Services
{
    /// <inheritdoc />
    public class AssemblyTypeResolver : IAssemblyTypeResolver
    {
        private readonly Assembly assembly;
        private readonly string ns;
        private readonly IEnumerable<string> excludedNamespaces;

        /// <summary>
        /// Used to get types to be serialized in an assembly
        /// </summary>
        /// <param name="assembly">Assembly to look in</param>
        /// <param name="ns">Namespace for the types</param>
        /// <param name="excludedNamespaces">Namespaces to exclude</param>
        public AssemblyTypeResolver(Assembly assembly, string ns, IEnumerable<string> excludedNamespaces)
        {
            this.assembly = assembly;
            this.ns = ns;
            this.excludedNamespaces = excludedNamespaces ?? Enumerable.Empty<string>();
        }

        /// <inheritdoc />
        public IEnumerable<Type> Resolve()
        {
            return assembly.GetExportedTypes().Where(a =>
                !a.ContainsGenericParameters && !a.IsInterface && !a.IsEnum && !Attribute.IsDefined(a, typeof(JsIgnoreAttribute)) && a.Namespace.StartsWith(ns) &&
                !excludedNamespaces.Contains(a.Namespace));
        }
    }
}
