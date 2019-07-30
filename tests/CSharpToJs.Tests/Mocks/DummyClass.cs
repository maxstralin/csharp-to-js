using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using CSharpToJs.Core.Attributes;

namespace CSharpToJs.Tests.Mocks
{
    public class DummyClass
    {
        public string IAmAProperty { get; set; }

        // ReSharper disable once UnusedMember.Local
        [ExcludeFromCodeCoverage]
        private string PrivateAutoProperty { get; set; }

        public string Field = "";

        public int IntegerProp { get; set; }

        public ComplexType AComplexType { get; set; } = new ComplexType();

        [JsIgnore]
        public string IShouldBeIgnored { get; set; } = "true";

        public bool BoolProp { get; set; } 

        public IgnoredClass IgnoredClass { get; set; } = new IgnoredClass();

    }
}
