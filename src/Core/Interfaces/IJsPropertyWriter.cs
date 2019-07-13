using CSharpToJs.Core.Models;

namespace CSharpToJs.Core.Interfaces
{
    public interface IJsPropertyWriter
    {
        string Write(JsProperty jsProperty);
    }
}