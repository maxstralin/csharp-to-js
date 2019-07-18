using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using CSharpToJs.Core.Models;
using CSharpToJs.Core.Services;
using CSharpToJs.Tests.Mocks;
using Newtonsoft.Json;
using Xunit;

namespace CSharpToJs.Tests
{
    public class ServiceTests
    {
        [Fact]
        public void DefaultDependencyResolver()
        {
            var dependencyClass = new JsFile
            {
                JsClass = new JsClass
                {
                    OriginalType = typeof(string)
                }
            };
            var resolvingClass = new JsFile
            {
                JsClass = new JsClass
                {
                    Dependencies = new List<Type> { typeof(string) }
                }
            };
            var jsFiles = new List<JsFile> { dependencyClass, resolvingClass };
            var resolver = new JsClassDependencyResolver(jsFiles);

            var resolved = resolver.Resolve(resolvingClass.JsClass);

            Assert.Contains(resolved, a => a.JsClass.OriginalType == typeof(string));
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
            var privateAutoPropertyName = "PrivateAutoProperty";

            var props = propertyResolver.GetProperties(typeof(DummyClass)).ToList();

            Assert.DoesNotContain(props, a => a.Name == shouldNotContain);
            Assert.DoesNotContain(props, a => a.Name == privateAutoPropertyName);
            Assert.Contains(props, a => a.Name == shouldContain);
        }

        [Fact]
        public void DefaultPropertyResolverIgnoreAttribute()
        {
            var propertyResolver = new PropertyResolver();
            var shouldNotContain = nameof(DummyClass.IShouldBeIgnored);

            var props = propertyResolver.GetProperties(typeof(DummyClass)).ToList();

            Assert.DoesNotContain(props, a => a.Name == shouldNotContain);
        }

        [Fact]
        public void JsImportWriter()
        {
            var writer = new JsImportWriter();
            var mainFile = new JsFile
            {
                JsClass = new JsClass
                {
                    Name = "Main",
                },
                FilePath = Path.Combine(Environment.CurrentDirectory, "Main.js")
            };
            var dependencyNested = new JsFile
            {
                JsClass = new JsClass
                {
                    Name = "Dep1",
                },
                FilePath = Path.Combine(Environment.CurrentDirectory, "subfolder", "Dep1.js")
            };
            var dependencyAbove = new JsFile
            {
                JsClass = new JsClass
                {
                    Name = "Dep2",
                },
                FilePath = Path.Combine(Environment.CurrentDirectory, "../", "Dep2.js")
            };

            var relativePathResolver = new RelativePathResolver();

            var statementNested = writer.Write(dependencyNested.JsClass.Name, relativePathResolver.Resolve(mainFile.FilePath, dependencyNested.FilePath));
            var statementAbove = writer.Write(dependencyAbove.JsClass.Name, relativePathResolver.Resolve(mainFile.FilePath, dependencyAbove.FilePath));

            Assert.Equal("import Dep1 from './subfolder/Dep1.js';", statementNested);
            Assert.Equal("import Dep2 from '../Dep2.js';", statementAbove);
        }

        [Fact]
        public void DefaultAssemblyTypeResolver()
        {
            var assembly = Assembly.LoadFrom(Path.Combine(Environment.CurrentDirectory, "CSharpToJs.Tests.dll"));
            var resolver = new AssemblyTypeResolver(assembly, "CSharpToJs.Tests.Mocks", null);

            var types = resolver.Resolve();

            Assert.Contains(typeof(DummyClass), types);
            Assert.DoesNotContain(typeof(IgnoredClass), types);
        }
    }
}
