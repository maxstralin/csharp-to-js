using System;
using System.Collections.Generic;
using System.Text;
using CSharpToJs.Core.Interfaces;
using CSharpToJs.Core.Models;

namespace CSharpToJs.Tests.Mocks
{
    class JsPropertyConverterMock : IJsPropertyConverter
    {
        public JsProperty Convert(PropertyConverterContext context)
        {
            return new JsProperty
            {
                Name = "Custom",
                Value = "Super"
            };
        }
    }
}
