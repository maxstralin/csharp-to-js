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
    /// <inheritdoc />
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

        /// <inheritdoc />
        public JsProperty Convert(PropertyConverterContext context)
        {
            var propName = PropertyNameConverter.GetPropertyName(context.PropertyInfo);
            var propValue = context.OriginalValue;


            JsPropertyType propertyType;
            string propertyValue;

            //Nested complex type which should be instantiated through an import
            if (propValue != null && !context.PropertyInfo.PropertyType.IsEnum && !context.PropertyInfo.PropertyType.IsGenericType &&
                !context.ExcludedNamespaces.Contains(context.PropertyInfo.PropertyType.Namespace) &&
                context.IncludedNamespaces.Any(a => context.PropertyInfo.PropertyType.Namespace.Contains(a)))
            {
                propertyValue = $"new {context.PropertyInfo.PropertyType.Name}()";
                propertyType = JsPropertyType.Instance;
            }
            else
            {
                propertyValue =
                    JsonConvert.SerializeObject(propValue, Formatting.None, SerializerSettings);
                propertyType = JsPropertyType.Plain;
            }

            var jsProp = new JsProperty
            (
                propertyType: propertyType,
                value: propertyValue,
                name: propName,
                originalValue: propValue,
                propertyInfo: context.PropertyInfo
            );

            return jsProp;
        }
    }
}