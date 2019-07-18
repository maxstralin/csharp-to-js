using System;
using System.Collections.Generic;
using CSharpToJs.Core.Models;

namespace CSharpToJs.Core.Interfaces
{
    public interface IJsClassDependencyResolver
    {
        IEnumerable<JsFile> Resolve(JsClass jsClass);
    }
}