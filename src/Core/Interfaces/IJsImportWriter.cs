using CSharpToJs.Core.Models;

namespace CSharpToJs.Core.Interfaces
{
    /// <summary>
    /// Used for creating a JS import statement
    /// </summary>
    public interface IJsImportWriter
    {
        /// <summary>
        /// Create a Javascript import statement string from a name and path
        /// </summary>
        /// <param name="importName">Name of the import</param>
        /// <param name="relativePath">Relative path for the import</param>
        /// <returns>A Javascript import statement string</returns>
        string Write(string importName, string relativePath);
    }
}