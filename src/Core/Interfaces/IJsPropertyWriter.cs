using CSharpToJs.Core.Models;

namespace CSharpToJs.Core.Interfaces
{
    /// <summary>
    /// Used for writing a Javascript property as a string
    /// </summary>
    public interface IJsPropertyWriter
    {
        /// <summary>
        /// Convert a property into a Javascript string
        /// </summary>
        /// <param name="jsProperty">The <see cref="JsProperty"/> to be written</param>
        /// <returns>A Javascript property as a string</returns>
        string Write(JsProperty jsProperty);
    }
}