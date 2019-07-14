using System;
using System.Collections.Generic;
using System.Text;
using CSharpToJs.Core.Interfaces;
using CSharpToJs.Core.Models;

namespace CSharpToJs.Core.Services
{
    public class JsImportWriter : IJsImportWriter
    {
        public string Write(JsClass mainClass, JsClass dependency)
        {
            var relativePath = new Uri(mainClass.FilePath).MakeRelativeUri(new Uri(dependency.FilePath)).ToString();
            if (!relativePath.StartsWith("../")) relativePath = $"./{relativePath}";
            return $"import {dependency.Name} from '{relativePath}';";
        }
    }
}
