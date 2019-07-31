using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace CSharpToJs.Core.Attributes
{
    /// <summary>
    /// Used to ignore a property or class
    /// </summary>
    [UsedImplicitly]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class JsIgnoreAttribute : Attribute
    {
    }
}
