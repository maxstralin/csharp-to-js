using System;
using System.Collections.Generic;

namespace CSharpToJs.Core.Interfaces
{
    public interface IAssemblyTypeResolver
    {
        IEnumerable<Type> Resolve();
    }
}