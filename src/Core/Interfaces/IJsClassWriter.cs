using CSharpToJs.Core.Models;

namespace CSharpToJs.Core.Interfaces
{
    public interface IJsClassWriter
    {
        string Write(JsClass jsClass);
    }
}