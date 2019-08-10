using System;
using System.Collections.Generic;
using System.Text;
using CSharpToJs.Core.Attributes;
using CSharpToJs.Tests.Mocks;

namespace CSharpToJs.Tests.Dummies
{
    [PropertyResolver(typeof(PropertyResolverMock))]
    public class CustomPropertyResolverDummy
    {

    }
}
