using System;
using System.Collections.Generic;
using System.Text;
using CSharpToJs.Core.Interfaces;

namespace CSharpToJs.Core.Attributes
{
    /// <summary>
    /// Override the default converter by providing a specific <see cref="IJsClassConverter"/> type
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class JsClassConverterAttribute : Attribute
    {
        public IJsClassConverter ClassConverter { get; }

        public JsClassConverterAttribute(Type classConverter)
        {
            if (!typeof(IJsClassConverter).IsAssignableFrom(classConverter))
            {
                throw new ArgumentException("Type provided is not an implementation of IJsPropertyConverter", nameof(classConverter));
            }

            ClassConverter = Activator.CreateInstance(classConverter) as IJsClassConverter;
        }
    }
}
