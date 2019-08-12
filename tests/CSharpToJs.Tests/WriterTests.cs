using System;
using System.IO;
using System.Linq;
using System.Reflection;
using CSharpToJs.Core.Attributes;
using CSharpToJs.Core.Interfaces;
using CSharpToJs.Core.Models;
using CSharpToJs.Core.Services;
using CSharpToJs.Tests.Dummies;
using CSharpToJs.Tests.Mocks;
using Xunit;

namespace CSharpToJs.Tests
{
    public class WriterTests
    {
        [Fact]
        public void DefaultPropertyWriter()
        {
            var propertyWriter = new JsPropertyWriter();
            var value = "value";
            var name = "name";
            var property = new JsProperty(JsPropertyType.Plain, name, value, null, new PropertyInfoStub());
                var expected = $"this.{name} = {value}";

            var result = propertyWriter.Write(property);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void DefaultPropertyWriterForReadonlyProperty()
        {
            var propertyWriter = new JsPropertyWriter();
            var propConverter = new JsPropertyConverter();
            var dummy = new ComplexTypeDummy();
            var expected = $"get {nameof(dummy.Readonly).ToLower()}() => true";
                
            var prop = dummy.GetType().GetProperty(nameof(dummy.Readonly));
            var originalValue = prop.GetValue(dummy);
            var jsProp = propConverter.Convert(new PropertyConverterContext(prop, originalValue, null, null));
            var writtenProp = propertyWriter.Write(jsProp);
            
            Assert.Equal(expected, writtenProp);
        }

        [Fact]
        public void JsImportWriter()
        {
            var writer = new JsImportWriter();
            var mainFile = new JsFile(Path.Combine(Environment.CurrentDirectory, "Main.js"),
                new JsClass("Main", Enumerable.Empty<JsProperty>(), Enumerable.Empty<Type>(), GetType(), false));

            var dependencyNested = new JsFile(
                Path.Combine(Environment.CurrentDirectory, "subfolder", "Dep1.js"),
                new JsClass("Dep1", Enumerable.Empty<JsProperty>(), Enumerable.Empty<Type>(), GetType(), false));

            var dependencyAbove = new JsFile(Path.Combine(Environment.CurrentDirectory, "../", "Dep2.js"),
                new JsClass("Dep2", Enumerable.Empty<JsProperty>(), Enumerable.Empty<Type>(), GetType(), false)
            );

            var relativePathResolver = new RelativePathResolver();

            var statementNested = writer.Write(dependencyNested.JsClass.Name, relativePathResolver.Resolve(mainFile.FilePath, dependencyNested.FilePath));
            var statementAbove = writer.Write(dependencyAbove.JsClass.Name, relativePathResolver.Resolve(mainFile.FilePath, dependencyAbove.FilePath));

            Assert.Equal("import Dep1 from './subfolder/Dep1.js';", statementNested);
            Assert.Equal("import Dep2 from '../Dep2.js';", statementAbove);
        }

    }
}
