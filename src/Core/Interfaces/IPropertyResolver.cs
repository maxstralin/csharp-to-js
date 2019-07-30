using System;
using System.Collections.Generic;
using System.Reflection;

namespace CSharpToJs.Core.Interfaces
{
    /// <summary>
    /// Resolves properties for a type
    /// </summary>
    public interface IPropertyResolver
    {
        /// <summary>
        /// Returns properties for the provided type
        /// </summary>
        /// <param name="type">Type to resolve properties for</param>
        /// <returns>An enumerable of <see cref="PropertyInfo"/> for the resolved properties</returns>
        IEnumerable<PropertyInfo> GetProperties(Type type);
    }
}