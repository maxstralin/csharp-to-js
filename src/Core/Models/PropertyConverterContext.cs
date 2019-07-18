using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CSharpToJs.Core.Models
{
    public class PropertyConverterContext
    {
        public PropertyInfo PropertyInfo { get; set; }
        public object OriginalValue { get; set; }
        public IEnumerable<string> IncludedNamespaces { get; set; } = Enumerable.Empty<string>();
        public IEnumerable<string> ExcludedNamespaces { get; set; } = Enumerable.Empty<string>();
    }
}
