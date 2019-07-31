using CSharpToJs.Core.Attributes;
using CSharpToJs.Tests.Mocks;

namespace CSharpToJs.Tests.Dummies
{
    [JsClassConverter(typeof(CustomClassConverterMock))]
    public class CustomClassConverterDummy
    {

    }
}
