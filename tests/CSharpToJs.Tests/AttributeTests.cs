using CSharpToJs.Core.Attributes;
using CSharpToJs.Core.Interfaces;
using CSharpToJs.Core.Models;
using CSharpToJs.Core.Services;
using CSharpToJs.Tests.Dummies;
using CSharpToJs.Tests.Mocks;
using System;
using System.Linq;
using System.Reflection;
using Xunit;

namespace CSharpToJs.Tests
{
    public class AttributeTests
    {
        

        [Fact]
        public void JsClassConverterAttribute_ThrowsIfNotAClassConverter()
        {
            Action action = () => new JsClassConverterAttribute(typeof(string));

            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void PropertyResolver_ThrowsIfNotAPropertyResolver()
        {
            Action action = () => new PropertyResolverAttribute(typeof(string));

            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void JsPropertyConverterAttribute_ThrowsIfNotAPropertyConverter()
        {
            Action action = () => new JsPropertyConverterAttribute(typeof(string));

            Assert.Throws<ArgumentException>(action);
        }

    }
}
