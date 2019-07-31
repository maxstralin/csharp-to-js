using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using CSharpToJs.Core.Attributes;
using CSharpToJs.Core.Interfaces;
using CSharpToJs.Core.Models;

namespace CSharpToJs.Core.Services
{
    public class JsClassConverter : IJsClassConverter
    {
        public IPropertyResolver PropertyResolver { get; set; } = new PropertyResolver();
        public JsClass Convert(ClassConverterContext context)
        {
            var jsProperties = new Collection<JsProperty>();
            var dependencies = new List<Type>();
            var type = context.Type ?? throw new ArgumentNullException(nameof(context.Type));
            var includedNamespaces = context.IncludedNamespaces?.ToList() ?? new List<string>();
            var excludedNamespaces = context.ExcludedNamespaces?.ToList() ?? new List<string>();
            var isDerived = type.BaseType != null && (includedNamespaces.Any(a => type.BaseType != null && type.BaseType.Namespace.Contains(a)) &&
                                                      !excludedNamespaces.Contains(type.BaseType.Namespace));

            var propertyResolver = type.GetCustomAttribute<PropertyResolverAttribute>()?.PropertyResolver ?? PropertyResolver;

            if (isDerived)
            {
                dependencies.Add(type.BaseType);
            }

            var props = propertyResolver.GetProperties(type);

            var instance = Activator.CreateInstance(type);

            //var relativeOutputPath = GetRelativeOutputPath(type, ns);
            //var filePath = Path.Combine(OutputPath, assemblyDetails.SubFolder ?? string.Empty,
            //    relativeOutputPath, $"{type.Name}.js");

            foreach (var prop in props)
            {
                var customConverter = prop.GetCustomAttribute<JsPropertyConverterAttribute>();
                var propertyConverter = customConverter?.PropertyConverter ?? new JsPropertyConverter();
                var jsProp = propertyConverter.Convert(new PropertyConverterContext
                {
                    PropertyInfo = prop,
                    OriginalValue = prop.GetValue(instance),
                    IncludedNamespaces = includedNamespaces,
                    ExcludedNamespaces = excludedNamespaces
                });
                if (jsProp.PropertyType == JsPropertyType.Instance) dependencies.Add(prop.PropertyType);
                jsProperties.Add(jsProp);
            }

            return new JsClass
            {
                Properties = jsProperties,
                Name = type.Name,
                Dependencies = dependencies.Distinct(),
                OriginalType = type,
            };
        }
    }
}
