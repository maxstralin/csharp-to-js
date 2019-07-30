using System;
using System.Collections.Generic;
using System.Text;
using CSharpToJs.Core.Interfaces;
using CSharpToJs.Core.Models;

namespace CSharpToJs.Core.Services
{
    /// <inheritdoc />
    public class JsImportWriter : IJsImportWriter
    {
        /// <inheritdoc />
        public string Write(string importName, string relativePath)
        {
            return $"import {importName} from '{relativePath}';";
        }
    }
}
