using CSharpToJs.Core.Models;

namespace CSharpToJs.Core.Interfaces
{
    /// <summary>
    /// Used for converting a type into a <see cref="JsClass"/>
    /// </summary>
    public interface IJsClassConverter
    {
        /// <summary>
        /// Convert from a context into a JsClass
        /// </summary>
        /// <param name="context">Converter context</param>
        /// <returns>A <see cref="JsClass"/></returns>
        JsClass Convert(ClassConverterContext context);
    }
}