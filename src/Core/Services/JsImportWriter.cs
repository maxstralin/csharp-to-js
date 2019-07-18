using System;
using System.Collections.Generic;
using System.Text;
using CSharpToJs.Core.Interfaces;
using CSharpToJs.Core.Models;

namespace CSharpToJs.Core.Services
{
    public class JsImportWriter : IJsImportWriter
    {
        public string Write(string importName, string relativePath)
        {
            //var relativePath = new Uri(mainClass.FilePath).MakeRelativeUri(new Uri(dependency.FilePath)).ToString();
            //if (!relativePath.StartsWith("../")) relativePath = $"./{relativePath}";
            return $"import {importName} from '{relativePath}';";
        }
    }
}
