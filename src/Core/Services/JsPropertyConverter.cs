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
        private readonly PropertyInfo propertyInfo;
        private readonly object originalValue;
        private readonly ICollection<string> includedNamespaces;
        private readonly ICollection<string> excludedNamespaces;
        public IPropertyNameConverter PropertyNameConverter { get; set; } = new PropertyNameConverter();
        public JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
        {
            Converters = new List<JsonConverter> { new StringEnumConverter() },
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            }
        };

        public JsPropertyConverter(PropertyInfo propertyInfo, object originalValue, ICollection<string> includedNamespaces, ICollection<string> excludedNamespaces)
        {
            this.propertyInfo = propertyInfo;
            this.originalValue = originalValue;
            this.includedNamespaces = includedNamespaces ?? new List<string>();
            this.excludedNamespaces = excludedNamespaces ?? new List<string>();
        }

        public JsProperty Convert()
        {
            var propName = PropertyNameConverter.GetPropertyName(propertyInfo);
            var propValue = originalValue;

            var jsProp = new JsProperty
            {
                Name = propName,
                OriginalValue = propValue,
                PropertyInfo = propertyInfo
            };

            //Nested complex type which should be instantiated through an import
            if (propValue != null && !propertyInfo.PropertyType.IsEnum && !propertyInfo.PropertyType.IsGenericType &&
                !excludedNamespaces.Contains(propertyInfo.PropertyType.Namespace) &&
                includedNamespaces.Any(a => propertyInfo.PropertyType.Namespace.Contains(a)))
            {
                jsProp.Value = $"new {propertyInfo.PropertyType.Name}();";
                jsProp.PropertyType = JsPropertyType.Instance;
            }
            else
            {
                jsProp.Value =
                    JsonConvert.SerializeObject(propValue, Formatting.None, SerializerSettings) + ";";
                jsProp.PropertyType = JsPropertyType.Plain;
            }

            return jsProp;
        }
    }
}