using System;
using System.Linq;
using System.Text;
using CSharpToJs.Core.Interfaces;
using CSharpToJs.Core.Models;

namespace CSharpToJs.Core.Services
{
    public class JsClassWriter : IClassWriter
    {
        public IJsClassDependencyResolver DependencyResolver { get; }
        public IJsPropertyWriter JsPropertyWriter { get; set; } = new JsPropertyWriter();
        public IJsImportWriter JsImportWriter { get; set; } = new JsImportWriter();

        public JsClassWriter(IJsClassDependencyResolver dependencyResolver)
        {
            DependencyResolver = dependencyResolver;
        }

        public string Write(JsFile jsFile)
        {
            var jsClass = jsFile.JsClass;
            var dependencies = DependencyResolver.Resolve(jsClass).ToList();
            var relativePathResolver = new RelativePathResolver();

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("//CSharpToJs: auto");

            foreach (var dependency in dependencies)
            {
                stringBuilder.AppendLine(JsImportWriter.Write(jsClass.Name, relativePathResolver.Resolve(jsFile.FilePath, dependency.FilePath)));
            }


            stringBuilder.Append($"class {jsClass.Name} ");

            //TODO: Not sure if this is the right place to decide if it's a derived class
            var inherits = dependencies.SingleOrDefault(a => a.JsClass.OriginalType == jsClass.OriginalType.BaseType);
            if (inherits != null)
            {
                stringBuilder.Append($"extends {inherits.JsClass.Name}");
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
