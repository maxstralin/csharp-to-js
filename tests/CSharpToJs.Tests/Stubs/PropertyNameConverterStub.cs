using System;
using System.Reflection;
using CSharpToJs.Core.Interfaces;

namespace CSharpToJs.Tests.Stubs
{
    public class PropertyNameConverterStub : IPropertyNameConverter
    {
        public string GetPropertyName(PropertyInfo propertyInfo)
        {
            throw new NotImplementedException();
        }
    }
}
