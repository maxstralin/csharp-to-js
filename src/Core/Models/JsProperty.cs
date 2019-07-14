using System;
using System.Reflection;

namespace CSharpToJs.Core.Models
{
    public class JsProperty
    {
        public JsPropertyType PropertyType { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public object OriginalValue { get; set; }
        public PropertyInfo PropertyInfo { get; set; }
        public override string ToString()
        {
            return $"this.{Name} = {Value}";
        }
    }
}
