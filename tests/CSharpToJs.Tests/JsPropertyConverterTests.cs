using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpToJs.Core.Models;
using CSharpToJs.Core.Services;
using CSharpToJs.Tests.Mocks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Xunit;

namespace CSharpToJs.Tests
{
    public class JsPropertyConverterTests
    {
        [Fact]
        public void DefaultJsPropertyConverterSimpleConversion()
        {
            var dummy = new DummyClass
            {
                Field = "IsField",
                IAmAProperty = "IsProp"
            };
            var propInfo = typeof(DummyClass).GetProperty(nameof(DummyClass.IAmAProperty));
            var orgValue = propInfo.GetValue(dummy);
            var expectedPropName = "iAmAProperty";
            var expectedValue = $"\"{dummy.IAmAProperty}\"";

            var converter = new JsPropertyConverter(propInfo, orgValue, new List<string>(), new List<string>());

            var jsProp = converter.Convert();

            Assert.Same(orgValue, jsProp.OriginalValue);
            Assert.Same(propInfo, jsProp.PropertyInfo);
            Assert.Equal(expectedPropName, jsProp.Name);
            Assert.Equal(JsPropertyType.Plain, jsProp.PropertyType);
            Assert.Equal(expectedValue, jsProp.Value);
        }

        [Fact]
        public void DefaultJsPropertyConverterComplexConversion()
        {
            var dummy = new DummyClass
            {
                IAmAProperty = "IsProp",
                AComplexType = new ComplexType()
                {
                    IsComplex = "very"
                }
            };
            var propInfo = typeof(DummyClass).GetProperty(nameof(DummyClass.AComplexType));
            var orgValue = propInfo.GetValue(dummy);
            var expectedPropName = "aComplexType";
            var expectedValue = "new ComplexType()";

            var converter = new JsPropertyConverter(propInfo, orgValue, new List<string> { "CSharpToJs.Tests.Mocks" }, new List<string>());

            var jsProp = converter.Convert();

            Assert.Same(orgValue, jsProp.OriginalValue);
            Assert.Equal(expectedPropName, jsProp.Name);
            Assert.Equal(JsPropertyType.Instance, jsProp.PropertyType);
            Assert.Equal(expectedValue, jsProp.Value);
        }

        [Fact]
        public void DefaultJsPropertyConverterComplexConversionWhenExcluded()
        {
            var dummy = new DummyClass
            {
                IAmAProperty = "IsProp",
                AComplexType = new ComplexType()
                {
                    IsComplex = "very"
                }
            };
            var propInfo = typeof(DummyClass).GetProperty(nameof(DummyClass.AComplexType));
            var orgValue = propInfo.GetValue(dummy);
            var expectedPropName = "aComplexType";
            var expectedValue = JsonConvert.SerializeObject(dummy.AComplexType, Formatting.None, Settings.SerializerSettings);

            var converter = new JsPropertyConverter(propInfo, orgValue, new List<string> { "CSharpToJs.Tests.Mocks" }, new List<string> { "CSharpToJs.Tests.Mocks" });

            var jsProp = converter.Convert();

            Assert.Same(orgValue, jsProp.OriginalValue);
            Assert.Equal(expectedPropName, jsProp.Name);
            Assert.Equal(JsPropertyType.Plain, jsProp.PropertyType);
            Assert.Equal(expectedValue, jsProp.Value);
        }

        [Fact]
        public void SetCustomNameConverter()
        {
            var converter = new JsPropertyConverter(null, null, null, null);
            var nameConverter = new PropertyNameConverterMock();

            converter.PropertyNameConverter = nameConverter;

            Assert.Equal(nameConverter, converter.PropertyNameConverter);

        }

        [Fact]
        public void EnsureDependenciesAreSerializedForJsIgnore()
        {
            var propResolver = new PropertyResolver();
            var instance = new DummyClass();
            var propValue = instance.IgnoredClass;

            var props = propResolver.GetProperties(typeof(DummyClass));
            var prop = props.Single(a => a.Name == nameof(DummyClass.IgnoredClass));
            var propConverter = new JsPropertyConverter(prop, propValue, null, null);
            var jsProp = propConverter.Convert();

            Assert.Equal(JsPropertyType.Plain, jsProp.PropertyType);
            Assert.Equal(jsProp.Value,
                JsonConvert.SerializeObject(new IgnoredClass(), Formatting.None, Settings.SerializerSettings));
        }
    }
}
