using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using CSharpToJs.Core.Attributes;
using CSharpToJs.Core.Interfaces;
using CSharpToJs.Core.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using NuGet.Configuration;

namespace CSharpToJs.Core.Services
{
    public class CSharpToJsConverter : ICSharpToJsConverter
    {
        private readonly CSharpToJsConfig config;
        public string OutputPath { get; }

        public bool NoClean => config.NoClean;

        private List<string> IncludedNamespaces { get; }
        private List<string> ExcludedNamespaces { get; }

        private List<JsFile> JsFiles { get; } = new List<JsFile>();

        public CSharpToJsConverter(CSharpToJsConfig config)
        {
            this.config = config;
            OutputPath = Path.GetFullPath(config.OutputPath);
            IncludedNamespaces = config.Assemblies.SelectMany(a => a.Include).ToList();
            ExcludedNamespaces = config.Assemblies.SelectMany(a => a.Exclude).ToList();
        }

        private void LoadReferencesViaNugetCache(Assembly assembly)
        {
            //TODO: I highly doubt this is a good solution but all tries with AssemblyLoadContext etc that Google provided definitely didn't work, neither McMaster's plugin solution. Or it was just me not doing it correctly :)
            var refs = assembly.GetReferencedAssemblies().ToList();

            //As a fallback, we go through the default nuget location on the machine to load references assemblies
            var nugetFolder = SettingsUtility.GetGlobalPackagesFolder(Settings.LoadDefaultSettings(null));

            foreach (var assemblyName in refs)
            {
                var versionParts = assemblyName.Version.ToString().Split('.').ToList();
                for (var i = versionParts.Count - 1; i > 2; i--)
                {
                    if (versionParts[i] == "0") versionParts.RemoveAt(i);
                    else break;
                }

                var versionString = string.Join(".", versionParts);

                var path = Path.Combine(nugetFolder, assemblyName.Name.ToLower(), versionString, "lib");
                if (!Directory.Exists(path)) continue;
                //TODO: I would imagine that this could cause some issues with multiple build, e.g. netstandard1.6 and netstandard2.0 but not tested enough
                var directories = Directory.EnumerateDirectories(path)
                    .Where(a => a.Contains("netcore") || a.Contains("netstandard")).ToList();

                foreach (var directory in directories)
                {
                    var files = Directory.EnumerateFiles(directory, "*.dll").ToList();
                    foreach (var file in files)
                    {
                        Assembly.LoadFrom(file);
                    }
                }

            }
        }

        private void CleanOutputDirectory()
        {
            if (!Directory.Exists(OutputPath)) return;
            Directory.Delete(OutputPath, true);
        }

        private void CreateOutputDirectory()
        {
            Directory.CreateDirectory(OutputPath);
        }

        //TODO: This needs to be split up, not very SOLID atm
        public bool Convert()
        {
            if (!NoClean) CleanOutputDirectory();
            CreateOutputDirectory();

            var classConverter = new JsClassConverter();
            var outputPathResolver = new OutputPathResolver();

            foreach (var assemblyDetails in config.Assemblies)
            {
                Console.WriteLine($"Getting types in {assemblyDetails.Name}");
                var assembly = Assembly.LoadFrom(Path.Combine(config.AssembliesPath, assemblyDetails.Name + ".dll"));

                if (config.UseNugetCacheResolver) LoadReferencesViaNugetCache(assembly);

                foreach (var ns in assemblyDetails.Include)
                {
                    var typeResolver = new AssemblyTypeResolver(assembly, ns, ExcludedNamespaces);
                    var foundTypes = typeResolver.Resolve().ToList();

                    Console.WriteLine($"Found {foundTypes.Count} types in {ns}");

                    foreach (var type in foundTypes)
                    {
                        var jsClass = classConverter.Convert(new ClassConverterContext
                        {
                            Type = type,
                            ExcludedNamespaces = ExcludedNamespaces,
                            IncludedNamespaces = IncludedNamespaces,
                            ProcessingNamespace = ns,
                            AssemblyDetails = assemblyDetails,
                            Config = config
                        });
                        var outputPathContext = new OutputPathContext
                        {
                            JsClass = jsClass,
                            AssemblyDetails = assemblyDetails,
                            Config = config,
                            ProcessingNamespace = ns
                        };
                        var jsFile = new JsFile
                        {
                            FilePath = outputPathResolver.Resolve(outputPathContext),
                            JsClass = jsClass
                        };
                        JsFiles.Add(jsFile);
                    }
                }
            }

            var dependencyResolver = new JsClassDependencyResolver(JsFiles);
            var writer = new JsClassWriter(dependencyResolver);

            //TODO: Should be its own class for writing files
            foreach (var jsFile in JsFiles)
            {
                var res = writer.Write(jsFile);


                Directory.CreateDirectory(Path.GetDirectoryName(jsFile.FilePath));
                Console.WriteLine($"Writing {jsFile.FilePath}");
                File.WriteAllText(jsFile.FilePath, res);
            }

            Console.WriteLine("Done");

            return true;

        }
    }
}