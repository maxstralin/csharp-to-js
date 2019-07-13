using System;
using System.Diagnostics;
using System.Reflection;

namespace ConsoleAppSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //See if global tool is installed
            var startInfo = new ProcessStartInfo("cmd", "/c dotnet tool list --global")
            {
                RedirectStandardOutput = true
            };
            var process = new Process
            {
                StartInfo = startInfo
            };
            process.Start();
            var output = process.StandardOutput.ReadToEnd();
            var isInstalled = output.Contains("csharp-to-js");
            //See if tool is installed

            //Install if not installed
            if (!isInstalled) Process.Start("cmd", "/c dotnet tool install csharp-to-js --global");
            //Install if not installed

            Console.WriteLine(Environment.CurrentDirectory);

            var runProcess = new Process
            {
                StartInfo = new ProcessStartInfo("cmd", $"/K cd {Environment.CurrentDirectory} /c csharptojs")
                {
                    RedirectStandardOutput = true,
                }
            };
            runProcess.Start();

            var output2 = runProcess.StandardOutput.ReadToEnd();

        }
    }
}
