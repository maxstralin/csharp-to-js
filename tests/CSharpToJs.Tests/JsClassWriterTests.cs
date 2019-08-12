using System;
using System.Collections.Generic;
using System.Text;
using CSharpToJs.Core.Models;
using CSharpToJs.Core.Services;
using CSharpToJs.Tests.Mocks;
using CSharpToJs.Tests.Stubs;
using Xunit;

namespace CSharpToJs.Tests
{
    public class JsClassWriterTests
    {
        [Fact]
        public void JsClassWriter_DependencyResolverCantBeNull()
        {
            Action action = () => new JsClassWriter(null);

            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void JsClassWriterWithoutDependenciesOrProperties()
        {
            var dependencyResolver = new JsClassDependencyResolverMock();
            var writer = new JsClassWriter(dependencyResolver);
            var className = "Class";
            var expectedResult = $"//CSharpToJs: auto{Environment.NewLine}class {className} {{{Environment.NewLine}\tconstructor() {{{Environment.NewLine}\t}}{Environment.NewLine}}}{Environment.NewLine}export default {className};";

            var jsClass = new JsClass("Class", new List<JsProperty>(), new List<Type>(), typeof(string), false);
            var jsFile = new JsFile("Path", jsClass);
            var res = writer.Write(jsFile);

            Assert.Equal(expectedResult, res);
        }

        [Fact]
        public void JsClassWriter_ConstructorSetsProps()
        {
            var dependencyResolver = new JsClassDependencyResolverMock();

            var writer = new JsClassWriter(dependencyResolver);

            Assert.Same(dependencyResolver, writer.DependencyResolver);
        }
    }
}
