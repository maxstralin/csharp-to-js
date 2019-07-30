using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CSharpToJs.Core.Attributes;
using CSharpToJs.Core.Interfaces;

namespace CSharpToJs.Core.Services
{
    public class PropertyResolver : IPropertyResolver
    {
        public IEnumerable<PropertyInfo> GetProperties(Type type)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Static).Where(prop => !Attribute.IsDefined(prop, typeof(JsIgnoreAttribute)));
        }
    }
}
