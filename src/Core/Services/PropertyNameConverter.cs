using System;
using System.Reflection;
using CSharpToJs.Core.Interfaces;

namespace CSharpToJs.Core.Services
{
    public class PropertyNameConverter : IPropertyNameConverter
    {
        public string GetPropertyName(PropertyInfo propertyInfo)
        {
            var span = propertyInfo.Name.AsSpan();
            return span[0].ToString().ToLower()+span.Slice(1).ToString();
        }
    }
}
