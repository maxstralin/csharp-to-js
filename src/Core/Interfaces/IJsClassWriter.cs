using CSharpToJs.Core.Models;

namespace CSharpToJs.Core.Interfaces
{
    public interface IClassWriter
    {
        string Write(JsFile jsFile);
    }
}