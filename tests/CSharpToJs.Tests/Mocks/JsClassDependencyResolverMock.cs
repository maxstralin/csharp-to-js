using System.Collections.Generic;
using System.Linq;
using CSharpToJs.Core.Interfaces;
using CSharpToJs.Core.Models;

namespace CSharpToJs.Tests.Mocks
{
    public class JsClassDependencyResolverMock : IJsClassDependencyResolver
    {
        public IEnumerable<JsFile> Resolve(JsClass jsClass)
        {
            return Enumerable.Empty<JsFile>();
        }
    }
}
