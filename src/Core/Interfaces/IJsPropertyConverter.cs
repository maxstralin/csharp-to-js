using System.Reflection;
using CSharpToJs.Core.Models;

namespace CSharpToJs.Core.Interfaces
{
    public interface IJsPropertyConverter
    {
        JsProperty Convert();
    }
}