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
        public PropertyResolverMock PropMock = null;

        public IEnumerable<PropertyInfo> GetProperties(Type type)
        {
            return new List<PropertyInfo>
            {
                GetType().GetProperty(nameof(PropMock))
            };
        }
    }
}
