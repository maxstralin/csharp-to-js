using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpToJs.Core.Models
{
    public class JsClass
    {
        public string Name { get; set; }
        public IEnumerable<JsProperty> Properties { get; set; } = Enumerable.Empty<JsProperty>();
        public IEnumerable<Type> Dependencies { get; set; } = Enumerable.Empty<Type>();
        public string FilePath { get; set; }
        public Type OriginalType { get; set; }
    }
}
