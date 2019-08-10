using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CSharpToJs.Core.Models
{
    public class PropertyConverterContext
    {
        public PropertyConverterContext(PropertyInfo propertyInfo, object? originalValue, IEnumerable<string>? includedNamespaces, IEnumerable<string>? excludedNamespaces)
        {
            PropertyInfo = propertyInfo;
            OriginalValue = originalValue;
            IncludedNamespaces = includedNamespaces ?? Enumerable.Empty<string>();
            ExcludedNamespaces = excludedNamespaces ?? Enumerable.Empty<string>();
        }

        public PropertyInfo PropertyInfo { get; }
        public object? OriginalValue { get; }
        public IEnumerable<string> IncludedNamespaces { get; } 
        public IEnumerable<string> ExcludedNamespaces { get; } 
    }
}
