using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CSharpToJs.Core.Models;
using CSharpToJs.Core.Services;
using CSharpToJs.Tests.Mocks;
using Xunit;

namespace CSharpToJs.Tests
{
    public class ServiceTests
    {
        [Fact]
        public void DefaultDependencyResolver()
        {
            var dependencyClass = new JsClass
            {
                OriginalType = typeof(string)
            };
            var resolvingClass = new JsClass
            {
                Dependencies = new List<Type> {typeof(string)}
            };
            var classes = new List<JsClass>{dependencyClass, resolvingClass};
            var resolver = new JsClassDependencyResolver(classes);

            var resolved = resolver.Resolve(resolvingClass);

            Assert.Contains(resolved, a => a.OriginalType == typeof(string));
        }

        [Fact]
        public void DefaultPropertyWriter()
        {
            var propertyWriter = new JsPropertyWriter();
            var value = "value";
            var name = "name";
            var property = new JsProperty
            {
                Value = value,
                Name = name
            };
            var expected = $"this.{name} = {value}";

            var result = propertyWriter.Write(property);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void DefaultPropertyNameConverter()
        {
            var dummyClass = new DummyClass();
            var propertyName = nameof(dummyClass.IAmAProperty);
            var property = dummyClass.GetType().GetProperty(propertyName);
            var expected = "iAmAProperty";
            var converter = new PropertyNameConverter();

            var result = converter.GetPropertyName(property);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void DefaultPropertyResolver()
        {
            var propertyResolver = new PropertyResolver();
            var shouldNotContain = nameof(DummyClass.Field);
            var shouldContain = nameof(DummyClass.IAmAProperty);

            var props = propertyResolver.GetProperties(typeof(DummyClass)).ToList();

            Assert.DoesNotContain(props, a => a.Name == shouldNotContain);
            Assert.Contains(props, a => a.Name == shouldContain);
        }

    }
}
