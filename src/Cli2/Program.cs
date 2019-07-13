using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using CSharpToJs.Cli;
using CSharpToJs.Core;
using CSharpToJs.Core.Models;
using CSharpToJs.Core.Services;
using McMaster.Extensions.CommandLineUtils;
using Newtonsoft.Json;

namespace CSharpToJs.Cli
{
    class Program
    {
        static int Main(string[] args)
        {
            var app = new CommandLineApplication();
            app.HelpOption();
            
            var configPathArg = app.Argument("configPath",
                "The config path. File must be named csharptojs.config.json. Defaults to executing directory.");
            var configPath = Environment.CurrentDirectory;

            app.OnExecute(() =>
            {
                configPath = configPathArg.Value ?? configPath;

                var config =
                    JsonConvert.DeserializeObject<CSharpToJsConfig>(File.ReadAllText(Path.Combine(configPath, "csharptojs.config.json")));

                var converter = new CSharpToJsConverter(config);

                converter.Convert();
            });

            return app.Execute(args);
        }
    }
}
