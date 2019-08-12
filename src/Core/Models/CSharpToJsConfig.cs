using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace CSharpToJs.Core.Models
{
    public class CSharpToJsConfig
    {
        public CSharpToJsConfig([NotNull] string assembliesPath, [NotNull] IEnumerable<AssemblyDetails> assemblies,
            [NotNull] string outputPath)
        {
            if (string.IsNullOrEmpty(assembliesPath))
                throw new ArgumentException("Value cannot be null or empty.", nameof(assembliesPath));
            if (string.IsNullOrEmpty(outputPath))
                throw new ArgumentException("Value cannot be null or empty.", nameof(outputPath));
            AssembliesPath = assembliesPath;
            Assemblies = assemblies ?? throw new ArgumentNullException(nameof(assemblies));
            OutputPath = outputPath;
        }

        /// <summary>
        /// Relative path to the binaries, e.g. bin/Debug/netstandard2.0
        /// </summary>
        public string AssembliesPath { get; }
        /// <summary>
        /// Details of the assemblies to convert in
        /// </summary>
        public IEnumerable<AssemblyDetails> Assemblies { get; }
        /// <summary>
        /// The relative path to the execution path which the JS files will be outputted
        /// </summary>
        public string OutputPath { get; }

        /// <summary>
        /// Default false. If true, the output path won't be deleted before output
        /// </summary>
        public bool NoClean { get; set; } = false;
        /// <summary>
        /// Experimental and not recommended at the moment. If true, uses the default Nuget package location to find assembly dependencies
        /// </summary>
        public bool UseNugetCacheResolver { get; set; } = false;
        
    }
}
