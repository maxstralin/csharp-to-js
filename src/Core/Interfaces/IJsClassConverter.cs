using CSharpToJs.Core.Models;

namespace CSharpToJs.Core.Interfaces
{
    public interface IJsClassConverter
    {
        JsClass Convert(ClassConverterContext context);
    }
}