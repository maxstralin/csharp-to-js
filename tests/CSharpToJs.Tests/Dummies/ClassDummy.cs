using System.Diagnostics.CodeAnalysis;
using CSharpToJs.Core.Attributes;

namespace CSharpToJs.Tests.Dummies
{
    public class ClassDummy
    {
        public string IAmAProperty { get; set; }

        // ReSharper disable once UnusedMember.Local
        [ExcludeFromCodeCoverage]
        private string PrivateAutoProperty { get; set; }

        public string Field = "";

        public int IntegerProp { get; set; }

        public ComplexTypeDummy AComplexType { get; set; } = new ComplexTypeDummy();

        [JsIgnore]
        public string IShouldBeIgnored { get; set; } = "true";

        public bool BoolProp { get; set; } 

        public IgnoredDummy IgnoredClass { get; set; } = new IgnoredDummy();

    }
}
