using System;
using System.Collections.Generic;

namespace CSharpToJs.Core.Interfaces
{
    /// <summary>
    /// Used to get types to be serialized in an assembly
    /// </summary>
    public interface IAssemblyTypeResolver
    {
        /// <summary>
        /// Resolves types in an assembly to be serialized
        /// </summary>
        /// <returns>An enumerable of types</returns>
        IEnumerable<Type> Resolve();
    }
}