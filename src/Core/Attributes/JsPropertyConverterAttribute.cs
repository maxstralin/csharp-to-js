using System;
using System.Collections.Generic;
using System.Text;
using CSharpToJs.Core.Interfaces;

namespace CSharpToJs.Core.Attributes
{
    /// <summary>
    /// Override the default converter by providing a specific <see cref="IJsPropertyConverter"/> type
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class JsPropertyConverterAttribute : Attribute
    {
        public IJsPropertyConverter PropertyConverter { get; }

        /// <summary>
        /// Override the default converter by providing a specific <see cref="IJsPropertyConverter"/> type
        /// </summary>
        /// <param name="propertyConverterType">An <see cref="IJsPropertyConverter"/> type</param>
        public JsPropertyConverterAttribute(Type propertyConverterType)
        {
            if (!typeof(IJsPropertyConverter).IsAssignableFrom(propertyConverterType))
            {
                throw new ArgumentException("Type provided is not an implementation of IJsPropertyConverter", nameof(propertyConverterType));
            }

            PropertyConverter = Activator.CreateInstance(propertyConverterType) as IJsPropertyConverter;
        }
    }
}
