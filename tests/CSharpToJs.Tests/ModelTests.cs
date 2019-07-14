using System;
using CSharpToJs.Core.Models;
using Xunit;

namespace CSharpToJs.Tests
{
    public class ModelTests
    {
        [Fact]
        public void JsPropertyToString()
        {
            var value = "value";
            var name = "name";
            var jsProperty = new JsProperty
            {
                Value = value,
                Name = name
            };
            var expected = $"this.{name} = {value}";

            var asString = jsProperty.ToString();

            Assert.Equal(expected, asString);
        }
    }
}
