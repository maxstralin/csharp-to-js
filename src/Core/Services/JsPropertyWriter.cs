using CSharpToJs.Core.Interfaces;
using CSharpToJs.Core.Models;

namespace CSharpToJs.Core.Services
{
    /// <inheritdoc />
    public class JsPropertyWriter : IJsPropertyWriter
    {
        /// <inheritdoc />
        public string Write(JsProperty jsProperty)
        {
            if (!jsProperty.PropertyInfo.CanWrite)
            {
                return $@"get {jsProperty.Name}() => {jsProperty.Value}";
            }

            return jsProperty.ToString();
        }
    }
}