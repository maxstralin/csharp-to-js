using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using CSharpToJs.Core.Attributes;
using CSharpToJs.Core.Interfaces;

namespace CSharpToJs.Core.Services
{
    public class ClassConverterResolver
    {
        public readonly IJsClassConverter DefaultClassConverter = new JsClassConverter();

        public IJsClassConverter Resolve(Type type)
        {
            var customConverter = type.GetCustomAttribute<JsClassConverterAttribute>();
            return customConverter?.ClassConverter ?? DefaultClassConverter;
        }

    }
}
