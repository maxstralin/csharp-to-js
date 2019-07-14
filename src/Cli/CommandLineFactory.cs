using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CSharpToJs.Core.Models;
using CSharpToJs.Core.Services;
using McMaster.Extensions.CommandLineUtils;
using Newtonsoft.Json;

namespace CSharpToJs.Cli
{
    public static class CommandLineFactory
    {
        public static CommandLineApplication Create()
        {
            var app = new CommandLineApplication();
            app.HelpOption();

            app.Argument("configPath",
                "The config path. File must be named csharptojs.config.json. Defaults to executing directory.");

            return app;
        }
    }
}
