using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using CSharpToJs.Core.Interfaces;

namespace CSharpToJs.Tests.Mocks
{
    public class PropertyNameConverterMock : IPropertyNameConverter
    {
        public string GetPropertyName(PropertyInfo propertyInfo)
        {
            throw new NotImplementedException();
        }
    }
}
