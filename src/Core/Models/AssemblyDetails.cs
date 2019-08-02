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

        public string Name { get;  }
        public string SubFolder { get; }
        public IEnumerable<string> Include { get; }
        public IEnumerable<string> Exclude { get; }
    }
}
