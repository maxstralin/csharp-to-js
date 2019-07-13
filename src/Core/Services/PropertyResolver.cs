﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CSharpToJs.Core.Interfaces;

namespace CSharpToJs.Core.Services
{
    public class PropertyResolver : IPropertyResolver
    {
        private readonly Type type;
        private readonly bool isDerived;

        public PropertyResolver(Type type, bool isDerived)
        {
            this.type = type;
            this.isDerived = isDerived;
        }
        public IEnumerable<PropertyInfo> GetProperties()
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static |
                               BindingFlags.NonPublic).Where(a => !isDerived || a.DeclaringType == type);
        }
    }
}
