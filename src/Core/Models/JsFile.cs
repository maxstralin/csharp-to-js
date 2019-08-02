using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpToJs.Core.Models
{
    public class JsFile
    {
        public JsFile(string filePath, JsClass jsClass)
        {
            FilePath = filePath;
            JsClass = jsClass;
        }

        public JsClass JsClass { get; }
        public string FilePath { get; }
    }
}
