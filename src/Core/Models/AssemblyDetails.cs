using System.Collections.Generic;
using System.Linq;

namespace CSharpToJs.Core.Models
{
    public class AssemblyDetails
    {
        public string Name { get; set; }
        public string SubFolder { get; set; } = "";
        public IEnumerable<string> Include { get; set; } = Enumerable.Empty<string>();
        public IEnumerable<string> Exclude { get; set; } = Enumerable.Empty<string>();
    }
}
