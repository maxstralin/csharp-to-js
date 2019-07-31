using System;
using System.Reflection;
using CSharpToJs.Core.Interfaces;

namespace CSharpToJs.Core.Services
{
    /// <inheritdoc />
    public class PropertyNameConverter : IPropertyNameConverter
    {
        /// <inheritdoc />
        public string GetPropertyName(PropertyInfo propertyInfo)
        {
            var span = propertyInfo.Name.AsSpan();
            return span[0].ToString().ToLower()+span.Slice(1).ToString();
        }
    }
}
