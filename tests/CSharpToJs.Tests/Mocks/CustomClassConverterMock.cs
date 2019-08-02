using System;
using System.Collections.Generic;
using System.Text;
using CSharpToJs.Core.Interfaces;
using CSharpToJs.Core.Models;

namespace CSharpToJs.Tests.Mocks
{
    public class CustomClassConverterMock : IJsClassConverter
    {
        public JsClass Convert(ClassConverterContext context)
        {
            return new JsClass("Custom", null, null, typeof(CustomClassConverterMock));
        }
    }
}
