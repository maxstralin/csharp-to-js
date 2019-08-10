using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpToJs.Core.Models
{
    public class ConfigContext
    {
        public ConfigContext(CSharpToJsConfig config)
        {
            Config = config;
        }

        public CSharpToJsConfig Config { get; }
    }
}
