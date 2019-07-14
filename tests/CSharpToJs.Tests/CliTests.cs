using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpToJs.Cli;
using Xunit;

namespace CSharpToJs.Tests
{
    public class CliTests
    {
        [Fact]
        public void CommandLineFactoryCreation()
        {
            var factory = CommandLineFactory.Create();
            var configPathArgName = "configPath";

            var configPathArg = factory.Arguments.SingleOrDefault(a => a.Name == configPathArgName);

            Assert.NotNull(configPathArg);
            Assert.NotNull(factory.OptionHelp);
        }
    }
}
