using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using CSharpToJs.Core.Interfaces;

namespace CSharpToJs.Tests.Mocks
{
    public class PropertyResolverMock : IPropertyResolver
    {
        public PropertyResolverMock PropMock { get; } = null;

        public IEnumerable<PropertyInfo> GetProperties(Type type)
        {
            return GetType().GetProperties();
        }
    }
}
