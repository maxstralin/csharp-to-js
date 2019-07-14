using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CSharpToJs.Core.Interfaces;

namespace CSharpToJs.Core.Services
{
    public class PropertyResolver : IPropertyResolver
    {
        private readonly Type type;

        public PropertyResolver(Type type)
        {
            this.type = type;
        }
        public IEnumerable<PropertyInfo> GetProperties()
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static |
                               BindingFlags.NonPublic);
        }
    }
}
