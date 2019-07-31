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

        /// <summary>
        /// Override the default converter by providing a specific <see cref="IJsClassConverter"/> type
        /// </summary>
        /// <param name="classConverterType">An <see cref="IJsClassConverter"/> type</param>
        public JsClassConverterAttribute(Type classConverterType)
        {
            if (!typeof(IJsClassConverter).IsAssignableFrom(classConverterType))
            {
                throw new ArgumentException("Type provided is not an implementation of IJsPropertyConverter", nameof(classConverterType));
            }

            ClassConverter = Activator.CreateInstance(classConverterType) as IJsClassConverter;
        }
    }
}
