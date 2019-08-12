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
    public class ConverterTests
    {
        [Fact]
        public void DefaultPropertyNameConverter()
        {
            var dummyClass = new ClassDummy();
            var propertyName = nameof(dummyClass.IAmAProperty);
            var property = dummyClass.GetType().GetProperty(propertyName);
            var expected = "iAmAProperty";
            var converter = new PropertyNameConverter();

            var result = converter.GetPropertyName(property);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void CustomJsPropertyConverterThroughAttribute()
        {
            var mock = new CustomPropertyConverterClass();
            var propInfo = mock.GetType().GetProperty(nameof(mock.MyProperty));
            var converterContext = new PropertyConverterContext(null, null, null, null);

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
        public void JsClassConverterForDerivedClass()
        {
            var converter = new JsClassConverter();
            var derivedClass = typeof(DerivedClassDummy);
            var parentClass = typeof(ClassDummy);
            var namespaces = new[] { "CSharpToJs" };

            var jsClass = converter.Convert(new ClassConverterContext(null, new CSharpToJsConfig("Path", Enumerable.Empty<AssemblyDetails>(), "Path"), null,
                derivedClass, namespaces, null));

            Assert.True(jsClass.IsDerived);
            Assert.Equal(parentClass, jsClass.ParentType);
        }

        [Fact]
        public void DefaultJsClassConverter_DerivedFromExcludedNamespaceShouldNotCountAsDerived()
        {
            var converter = new JsClassConverter();
            var derivedClass = typeof(DerivedClassDummy);
            var namespaces = new[] { "CSharpToJs" };

            var jsClass = converter.Convert(new ClassConverterContext(null, new CSharpToJsConfig("Path", Enumerable.Empty<AssemblyDetails>(), "Path"), null,
                derivedClass, namespaces, new[] { "CSharpToJs.Tests.Dummies" }));

            Assert.False(jsClass.IsDerived);
            Assert.Null(jsClass.ParentType);
        }
    }
}
