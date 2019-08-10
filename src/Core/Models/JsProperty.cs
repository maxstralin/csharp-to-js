using System;
using System.Reflection;

namespace CSharpToJs.Core.Models
{
    public class JsProperty
    {
        public JsProperty(JsPropertyType propertyType, string name, string value, object? originalValue, PropertyInfo propertyInfo)
        {
            PropertyType = propertyType;
            Name = name;
            Value = value;
            OriginalValue = originalValue;
            PropertyInfo = propertyInfo;
        }

        public JsPropertyType PropertyType { get; }
        public string Name { get; }
        public string Value { get;}
        public object? OriginalValue { get; }
        public PropertyInfo PropertyInfo { get; }
        public override string ToString()
        {
            return $"this.{Name} = {Value}";
        }
    }
}
