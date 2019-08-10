using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpToJs.Core.Models
{
    public class JsClass
    {
        public JsClass(string name, IEnumerable<JsProperty> properties, IEnumerable<Type> dependencies, Type originalType, bool isDerived)
        {
            Name = name;
            Properties = properties;
            Dependencies = dependencies;
            OriginalType = originalType;
            IsDerived = isDerived;
        }

        public string Name { get; }
        public IEnumerable<JsProperty> Properties { get; }
        public IEnumerable<Type> Dependencies { get; }
        public Type OriginalType { get; }
        public bool IsDerived { get; }
        public Type? ParentType { get; set; }
    }
}
