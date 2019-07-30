using CSharpToJs.Core.Models;

namespace CSharpToJs.Core.Interfaces
{
    public interface IJsImportWriter
    {
        string Write(string importName, string relativePath);
    }
}