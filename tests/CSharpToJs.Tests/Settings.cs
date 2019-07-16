using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace CSharpToJs.Tests
{
    public static class Settings
    {
        public static JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
        {
            Converters = new List<JsonConverter>
            {
                new StringEnumConverter()
            },
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
    }
}
