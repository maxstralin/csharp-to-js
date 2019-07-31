using System;
using System.Collections.Generic;
using System.Linq;
using CSharpToJs.Core.Interfaces;
using CSharpToJs.Core.Models;

namespace CSharpToJs.Core.Services
{
    /// <inheritdoc />
    public class JsClassDependencyResolver : IJsClassDependencyResolver
    {
        private readonly List<JsFile> jsFiles;

        /// <inheritdoc />
        public JsClassDependencyResolver(IEnumerable<JsFile> jsFiles)
        {
            this.jsFiles = jsFiles.ToList();
        }

        /// <inheritdoc />
        public IEnumerable<JsFile> Resolve(JsClass jsClass)
        {
            return jsFiles.Where(a => jsClass.Dependencies.Select(b => b.FullName).Contains(a.JsClass.OriginalType.FullName));
        }
    }
}
