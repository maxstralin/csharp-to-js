using System;
using System.Collections.Generic;
using System.Text;
using CSharpToJs.Core.Attributes;

namespace CSharpToJs.Tests.Mocks
{
    public class CustomPropertyConverterClass
    {
        [JsPropertyConverter(typeof(JsPropertyConverterMock))]
        public string MyProperty { get; set; } = "Yes";
    }
}
