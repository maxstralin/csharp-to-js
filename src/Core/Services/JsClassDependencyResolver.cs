using System;
using System.Collections.Generic;
using System.Linq;
using CSharpToJs.Core.Interfaces;
using CSharpToJs.Core.Models;

namespace CSharpToJs.Core.Services
{
    public class JsClassDependencyResolver : IJsClassDependencyResolver
    {
        private readonly List<JsClass> jsClasses;

        public JsClassDependencyResolver(IEnumerable<JsClass> jsClasses)
        {
            this.jsClasses = jsClasses.ToList();
        }

        public IEnumerable<JsClass> Resolve(JsClass jsClass)
        {
            return jsClasses.Where(a => jsClass.Dependencies.Select(b => b.FullName).Contains(a.OriginalType.FullName));
        }
    }
}
