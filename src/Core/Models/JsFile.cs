using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace CSharpToJs.Core.Models
{
    public class JsFile
    {
        public JsFile([NotNull] string filePath, [NotNull] JsClass jsClass)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException("Value cannot be null or empty.", nameof(filePath));
            FilePath = filePath;
            JsClass = jsClass ?? throw new ArgumentNullException(nameof(jsClass));
        }

        public JsClass JsClass { get; }
        public string FilePath { get; }
    }
}
