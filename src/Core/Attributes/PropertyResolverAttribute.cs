using System;
using System.Collections.Generic;
using System.Text;
using CSharpToJs.Core.Interfaces;

namespace CSharpToJs.Core.Attributes
{
    /// <summary>
    /// Override the default resolver by providing a specific <see cref="IPropertyResolver"/> type
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class PropertyResolverAttribute : Attribute
    {
        public Type PropertyResolver { get; }

        /// <summary>
        /// Override the default resolver by providing a specific <see cref="IPropertyResolver"/> type
        /// </summary>
        /// <param name="propertyResolverType">An <see cref="IPropertyResolver"/> type</param>
        public PropertyResolverAttribute(Type propertyResolverType)
        {
            if (!typeof(IPropertyResolver).IsAssignableFrom(propertyResolverType))
            {
                throw new ArgumentException($"Type provided is not an implementation of {nameof(IPropertyResolver)}", nameof(propertyResolverType));
            }
            PropertyResolver = propertyResolverType;
        }
    }
}
