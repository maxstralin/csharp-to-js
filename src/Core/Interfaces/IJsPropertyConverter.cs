using System.Reflection;
using CSharpToJs.Core.Models;

namespace CSharpToJs.Core.Interfaces
{
    /// <summary>
    /// Uses <see cref="PropertyInfo"/> to convert into a <see cref="JsProperty"/>
    /// </summary>
    public interface IJsPropertyConverter
    {
        /// <summary>
        /// Used for converting <see cref="PropertyConverterContext"/> into a <see cref="JsProperty"/>
        /// </summary>
        /// <param name="context">Converter context</param>
        /// <returns>A <see cref="JsProperty"/></returns>
        JsProperty Convert(PropertyConverterContext context);
    }
}