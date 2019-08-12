using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using CSharpToJs.Core.Models;
using CSharpToJs.Core.Services;
using CSharpToJs.Tests.Dummies;
using CSharpToJs.Tests.Mocks;
using Xunit;

namespace CSharpToJs.Tests
{
    public class ResolverTests
    {
        [Fact]
        public void DefaultOutputPathResolver()
        {
            var resolver = new OutputPathResolver();
            var ns = "CSharpToJs.Tests";
            var jsClass = new JsClass("DummyClass", null, null, typeof(ResolverTests), false);
            var assemblyDetails = new AssemblyDetails(ns, string.Empty, null, null);
            var outputPath = "C:/Dummy";
            var expectedPath = $"{outputPath}{Path.DirectorySeparatorChar}DummyClass.js";
            
            var context = new OutputPathContext(jsClass, ns, assemblyDetails, new CSharpToJsConfig(string.Empty, null, outputPath));
            var res = resolver.Resolve(context);
            
            Assert.Equal(expectedPath, res);
        }

        [Fact]
        public void DefaultDependencyResolver()
        {
            var dependencyClass = new JsFile(String.Empty,
                new JsClass(string.Empty, Enumerable.Empty<JsProperty>(), Enumerable.Empty<Type>(), typeof(string), false));

            var resolvingClass = new JsFile(string.Empty, new JsClass
                (
                    string.Empty, Enumerable.Empty<JsProperty>(), new List<Type> { typeof(string) }, GetType(), false
                )
            );
            var jsFiles = new List<JsFile> { dependencyClass, resolvingClass };
            var resolver = new JsClassDependencyResolver(jsFiles);

            var resolved = resolver.Resolve(resolvingClass.JsClass);

            Assert.Contains(resolved, a => a.JsClass.OriginalType == typeof(string));
        }

        [Fact]
        public void DefaultPropertyResolver()
        {
            var propertyResolver = new PropertyResolver();
            var shouldNotContain = nameof(ClassDummy.Field);
            var shouldContain = nameof(ClassDummy.IAmAProperty);
            var privateAutoPropertyName = "PrivateAutoProperty";

            var props = propertyResolver.GetProperties(typeof(ClassDummy)).ToList();

            Assert.DoesNotContain(props, a => a.Name == shouldNotContain);
            Assert.DoesNotContain(props, a => a.Name == privateAutoPropertyName);
            Assert.Contains(props, a => a.Name == shouldContain);
        }

        [Fact]
        public void DefaultAssemblyTypeResolver()
        {
            var assembly = Assembly.LoadFrom(Path.Combine(Environment.CurrentDirectory, "CSharpToJs.Tests.dll"));
            var resolver = new AssemblyTypeResolver(assembly, "CSharpToJs.Tests", null);

            var types = resolver.Resolve().ToList();

            Assert.Contains(typeof(ClassDummy), types);
            Assert.DoesNotContain(typeof(IgnoredDummy), types);
        }

        [Fact]
        public void DefaultClassConverterInResolver()
        {
            var resolver = new ClassConverterResolver();

            Assert.IsType<JsClassConverter>(resolver.DefaultClassConverter);
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
        public void ClassConverterResolverForAttribute()
        {
            var resolver = new ClassConverterResolver();

            var converter = resolver.Resolve(typeof(CustomClassConverterDummy));

            Assert.IsType<CustomClassConverterMock>(converter);
        }
        [Fact]
        public void PropertyResolverThroughAttribute()
        {
            var classConverter = new JsClassConverter();
            var type = typeof(CustomPropertyResolverDummy);
            var expectedName = "propMock";

            var jsClass = classConverter.Convert(new ClassConverterContext(null, new CSharpToJsConfig(null, null, null), null, type, null, null));
            var props = jsClass.Properties.ToList();
            var prop = props.Single();

            Assert.Equal(expectedName, prop.Name);
        }
    }
}
