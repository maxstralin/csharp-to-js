using System;
using System.Linq;
using System.Text;
using CSharpToJs.Core.Interfaces;
using CSharpToJs.Core.Models;

namespace CSharpToJs.Core.Services
{
    /// <inheritdoc />
    public class JsClassWriter : IClassWriter
    {
        public IJsClassDependencyResolver DependencyResolver { get; }
        public IJsPropertyWriter JsPropertyWriter { get; set; } = new JsPropertyWriter();
        public IJsImportWriter JsImportWriter { get; set; } = new JsImportWriter();

        public JsClassWriter(IJsClassDependencyResolver dependencyResolver)
        {
            DependencyResolver = dependencyResolver;
        }

        /// <inheritdoc />
        public string Write(JsFile jsFile)
        {
            var jsClass = jsFile.JsClass;
            var dependencies = DependencyResolver.Resolve(jsClass).ToList();
            var relativePathResolver = new RelativePathResolver();

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("//CSharpToJs: auto");

            foreach (var dependency in dependencies)
            {
                stringBuilder.AppendLine(JsImportWriter.Write(dependency.JsClass.Name, relativePathResolver.Resolve(jsFile.FilePath, dependency.FilePath)));
            }


            stringBuilder.Append($"class {jsClass.Name} sadsda");

            if (jsClass.IsDerived)
            {
                var parentType = jsClass.ParentType;
                var dependency = dependencies.Single(a => a.JsClass.OriginalType == parentType);
                stringBuilder.Append($"extends {dependency.JsClass.Name}");
            }

            stringBuilder.AppendLine(" {");
            stringBuilder.AppendLine("\tconstructor() {");

            foreach (var jsProperty in jsClass.Properties.Where(a => a.PropertyInfo.DeclaringType == jsClass.OriginalType))
            {
                stringBuilder.AppendLine($"\t\t{JsPropertyWriter.Write(jsProperty)};");
            }

            stringBuilder.AppendLine("\t}");
            stringBuilder.AppendLine("}");
            stringBuilder.Append($"export default {jsClass.Name};");

            return stringBuilder.ToString();

        }
    }
}
