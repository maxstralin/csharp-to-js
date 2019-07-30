using System;
using System.Collections.Generic;
using CSharpToJs.Core.Models;

namespace CSharpToJs.Core.Interfaces
{
    /// <summary>
    /// Used to resolve dependencies for a <see cref="JsClass"/>
    /// </summary>
    public interface IJsClassDependencyResolver
    {
        /// <summary>
        /// Takes a <see cref="JsClass"/> and return the <see cref="JsFile"/>s on which it depends
        /// </summary>
        /// <param name="jsClass">The JsClass to resolve for</param>
        /// <returns>An enumerable of <see cref="JsFile"/>s dependencies</returns>
        IEnumerable<JsFile> Resolve(JsClass jsClass);
    }
}