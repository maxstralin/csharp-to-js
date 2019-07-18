using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CSharpToJs.Core.Interfaces;
using CSharpToJs.Core.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace CSharpToJs.Core.Services
{
    public class JsPropertyConverter : IJsPropertyConverter
    {
        public IPropertyNameConverter PropertyNameConverter { get; set; } = new PropertyNameConverter();
        public JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
        {
            Converters = new List<JsonConverter> { new StringEnumConverter() },
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            }
        };

        public JsProperty Convert(PropertyConverterContext context)
        {
            var propName = PropertyNameConverter.GetPropertyName(context.PropertyInfo);
            var propValue = context.OriginalValue;

            var jsProp = new JsProperty
            {
                Name = propName,
                OriginalValue = propValue,
                PropertyInfo = context.PropertyInfo
            };

            //Nested complex type which should be instantiated through an import
            if (propValue != null && !context.PropertyInfo.PropertyType.IsEnum && !context.PropertyInfo.PropertyType.IsGenericType &&
                !context.ExcludedNamespaces.Contains(context.PropertyInfo.PropertyType.Namespace) &&
                context.IncludedNamespaces.Any(a => context.PropertyInfo.PropertyType.Namespace.Contains(a)))
            {
                jsProp.Value = $"new {context.PropertyInfo.PropertyType.Name}()";
                jsProp.PropertyType = JsPropertyType.Instance;
            }
            else
            {
                jsProp.Value =
                    JsonConvert.SerializeObject(propValue, Formatting.None, SerializerSettings);
                jsProp.PropertyType = JsPropertyType.Plain;
            }

            return jsProp;
        }
    }
}