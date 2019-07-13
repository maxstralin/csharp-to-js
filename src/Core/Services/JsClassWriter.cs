using System;
using System.Linq;
using System.Text;
using CSharpToJs.Core.Interfaces;
using CSharpToJs.Core.Models;

namespace CSharpToJs.Core.Services
{
    public class JsClassWriter : IJsClassWriter
    {
        private readonly IJsClassDependencyResolver dependencyResolver;
        private readonly IJsPropertyWriter jsPropertyWriter;

        public JsClassWriter(IJsClassDependencyResolver dependencyResolver, IJsPropertyWriter jsPropertyWriter)
        {
            this.dependencyResolver = dependencyResolver;
            this.jsPropertyWriter = jsPropertyWriter;
        }
        public string Write(JsClass jsClass)
        {
            var dependencies = dependencyResolver.Resolve(jsClass).ToList();

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("//CSharpToJs: auto");

            foreach (var dependency in dependencies)
            {
                var relativePath = new Uri(jsClass.FilePath).MakeRelativeUri(new Uri(dependency.FilePath)).ToString();
                if (!relativePath.StartsWith("../")) relativePath = $"./{relativePath}";
                var importStatement = $"import {dependency.Name} from '{relativePath}';";

                stringBuilder.AppendLine(importStatement);
            }

            stringBuilder.Append($"class {jsClass.Name} ");
            if (jsClass.InheritsType != null)
            {
                stringBuilder.Append($"extends {dependencies.Single(a => a.OriginalType == jsClass.InheritsType).Name}");
            }

            stringBuilder.AppendLine(" {");
            stringBuilder.AppendLine("\tconstructor() {");

            foreach (var jsProperty in jsClass.Properties)
            {
                stringBuilder.AppendLine($"\t\t{jsPropertyWriter.Write(jsProperty)}");
            }

            stringBuilder.AppendLine("\t}");
            stringBuilder.AppendLine("}");
            stringBuilder.Append($"export default {jsClass.Name};");

            return stringBuilder.ToString();

        }
    }
}
