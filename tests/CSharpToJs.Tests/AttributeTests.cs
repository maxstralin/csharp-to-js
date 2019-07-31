using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CSharpToJs.Core.Attributes;
using CSharpToJs.Core.Interfaces;
using CSharpToJs.Core.Models;
using CSharpToJs.Core.Services;
using CSharpToJs.Tests.Dummies;
using CSharpToJs.Tests.Mocks;
using Xunit;

namespace CSharpToJs.Tests
{
    public class AttributeTests
    {
        [Fact]
        public void JsPropertyConverterAttribute()
        {
            var mock = new CustomPropertyConverterClass();
            var propInfo = mock.GetType().GetProperty(nameof(mock.MyProperty));
            var converterContext = new PropertyConverterContext();

            // The mock always returns "Custom": "Super" as the name/value
            var (expectedName, expectedValue) = ("Custom", "Super");
            var attribute = propInfo.GetCustomAttribute<JsPropertyConverterAttribute>();
            var customConverter = attribute.PropertyConverter;
            var converterInstance = Activator.CreateInstance(customConverter.GetType()) as IJsPropertyConverter;
            var propResult = converterInstance?.Convert(converterContext);


            Assert.NotNull(customConverter);
            Assert.NotNull(propResult);
            Assert.Equal(expectedName, propResult.Name);
            Assert.Equal(expectedValue, propResult.Value);
        }

        [Fact]
        public void DefaultPropertyResolverIgnoreAttribute()
        {
            var propertyResolver = new PropertyResolver();
            var shouldNotContain = nameof(ClassDummy.IShouldBeIgnored);

            var props = propertyResolver.GetProperties(typeof(ClassDummy)).ToList();

            Assert.DoesNotContain(props, a => a.Name == shouldNotContain);
        }

        [Fact]
        public void JsClassConverterAttribute()
        {
            var resolver = new ClassConverterResolver();

            var converter = resolver.Resolve(typeof(CustomClassConverterDummy));

            Assert.IsType<CustomClassConverterMock>(converter);
        }

    }
}
