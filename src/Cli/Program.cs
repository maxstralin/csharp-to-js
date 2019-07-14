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
        //TODO: Tests..
        static int Main(string[] args)
        {
            var app = CommandLineFactory.Create();
            app.OnExecute(() =>
            {
                var configPath = app.Arguments.SingleOrDefault()?.Value ?? Environment.CurrentDirectory;

                var config =
                    JsonConvert.DeserializeObject<CSharpToJsConfig>(File.ReadAllText(Path.Combine(configPath, "csharptojs.config.json")));

                var converter = new CSharpToJsConverter(config);

                converter.Convert();
            });

            return app.Execute(args);
        }
    }
}
