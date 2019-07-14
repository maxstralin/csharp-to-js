using System;
using System.Collections.Generic;
using CSharpToJs.Core.Models;

namespace CSharpToJs.Core.Interfaces
{
    public interface IJsClassDependencyResolver
    {
        IEnumerable<JsClass> Resolve(JsClass jsClass);
    }
}