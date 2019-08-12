using System.Collections.Generic;
using System.Linq;

namespace CSharpToJs.Core.Models
{
    public class AssemblyDetails
    {
        public AssemblyDetails(string name, string? subFolder, IEnumerable<string>? include, IEnumerable<string>? exclude)
        {
            Name = name;
            SubFolder = subFolder ?? string.Empty;
            Include = include ?? Enumerable.Empty<string>();
            Exclude = exclude ?? Enumerable.Empty<string>();
        }

        /// <summary>
        /// Filename of the assembly, without .dll
        /// </summary>
        public string Name { get;  }
        /// <summary>
        /// Subfolder to output this assembly's JS files to
        /// </summary>
        public string SubFolder { get; }
        /// <summary>
        /// Namespaces to include. Will include everything nested, e.g. "Namespace.A" will include C# classes in "Namespace.A", "Namespace.A.B" and "Namespace.A.B.C"
        /// </summary>
        public IEnumerable<string> Include { get; }
        /// <summary>
        /// Namespaces to exclude. Takes precedence over Include. Will exclude everything nested, see <see cref="Include"/>
        /// </summary>
        public IEnumerable<string> Exclude { get; }
    }
}
