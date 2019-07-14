using System;
using System.Collections.Generic;
using System.Reflection;

namespace CSharpToJs.Core.Interfaces
{
    public interface IPropertyResolver
    {
        IEnumerable<PropertyInfo> GetProperties(Type type);
    }
}