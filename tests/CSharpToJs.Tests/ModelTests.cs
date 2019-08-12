using System;
using System.Collections.Generic;
using System.Linq;
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
            var jsProperty = new JsProperty(JsPropertyType.Plain, name, value, null, null);
            var expected = $"this.{name} = {value}";

            var asString = jsProperty.ToString();

            Assert.Equal(expected, asString);
        }

        [Fact]
        public void CSharpToJsConfig_ConstructorSetsProps()
        {
            var path = "Path";
            var assemblies = new List<AssemblyDetails>();
            var outputPath = "OutputPath";

            var config = new CSharpToJsConfig(path, assemblies, outputPath);

            Assert.Equal(path, config.AssembliesPath);
            Assert.Same(assemblies, config.Assemblies);
            Assert.Equal(outputPath, config.OutputPath);
        }

        [Fact]
        public void CSharpToJsConfig_ThrowsOnNullParams()
        {
            Action nullAssembly = () => new CSharpToJsConfig(null, Enumerable.Empty<AssemblyDetails>(), "Path");
            Action nullDetails = () => new CSharpToJsConfig("Path", null, "Path");
            Action nullOutputPath = () => new CSharpToJsConfig("Path", Enumerable.Empty<AssemblyDetails>(), null);

            Assert.Throws<ArgumentException>(nullAssembly);
            Assert.Throws<ArgumentNullException>(nullDetails);
            Assert.Throws<ArgumentException>(nullOutputPath);
        }

        [Fact]
        public void AssemblyDetails_EnumerablesAreNeverNull()
        {
            var details = new AssemblyDetails(string.Empty, null, null, null);

            Assert.NotNull(details.Include);
            Assert.NotNull(details.Exclude);
        }

        [Fact]
        public void AssemblyNamespaceContext_ConstructorSetsProps()
        {
            var assemblyDetails = new AssemblyDetails("name", null, null, null);
            var config = new CSharpToJsConfig("Path", new List<AssemblyDetails>(), "Path");
            var ns = "Namespace";

            var context = new AssemblyNamespaceContext(assemblyDetails, config, ns);

            Assert.Equal(ns, context.ProcessingNamespace);
            Assert.Same(assemblyDetails, context.AssemblyDetails);
            Assert.Same(config, context.Config);
        }
    }
}