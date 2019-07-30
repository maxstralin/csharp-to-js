﻿using System;
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

        public JsPropertyConverterAttribute(Type propertyConverter)
        {
            if (!typeof(IJsPropertyConverter).IsAssignableFrom(propertyConverter))
            {
                throw new ArgumentException("Type provided is not an implementation of IJsPropertyConverter", nameof(propertyConverter));
            }

            PropertyConverter = Activator.CreateInstance(propertyConverter) as IJsPropertyConverter;
        }
    }
}
