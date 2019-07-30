using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpToJs.Core.Services
{
    public class RelativePathResolver
    {
        public string Resolve(string path1, string path2)
        {
            var relativePath = new Uri(path1).MakeRelativeUri(new Uri(path2)).ToString();
            if (!relativePath.StartsWith("../")) relativePath = $"./{relativePath}";
            return relativePath;
        }
    }
}
