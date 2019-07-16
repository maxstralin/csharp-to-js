using System;
using System.Collections.Generic;
using System.Text;
using CSharpToJs.Core.Attributes;

namespace CSharpToJs.Tests.Mocks
{
    [JsIgnore]
    public class IgnoredClass
    {
        public bool Prop { get; set; }
    }
}
