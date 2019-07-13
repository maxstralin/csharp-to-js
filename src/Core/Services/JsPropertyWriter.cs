using CSharpToJs.Core.Interfaces;
using CSharpToJs.Core.Models;

namespace CSharpToJs.Core.Services
{
    public class JsPropertyWriter : IJsPropertyWriter
    {
        public string Write(JsProperty jsProperty) => jsProperty.ToString();
    }
}
