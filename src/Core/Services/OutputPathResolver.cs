using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CSharpToJs.Core.Models;

namespace CSharpToJs.Core.Services
{
    public class OutputPathResolver
    {
        public string Resolve(OutputPathContext context)
        {
            //TODO: .NET Standard 2.1 has Linq.SkipLast(1);
            var path = context.JsClass.OriginalType.FullName?.Replace($"{context.ProcessingNamespace}.", string.Empty).Split('.').ToList() ?? throw new ArgumentNullException(nameof(context.JsClass.OriginalType.FullName));

            var pathParts = Enumerable.Empty<string>().Append(Environment.CurrentDirectory).Append(context.Config.OutputPath).Append(context.AssemblyDetails.SubFolder ?? string.Empty).Concat(path.Take(path.Count - 1))
                .Append(context.AssemblyDetails.SubFolder).Append($"{context.JsClass.Name}.js");

            return Path.Combine(pathParts.ToArray());
        }
    }
}
