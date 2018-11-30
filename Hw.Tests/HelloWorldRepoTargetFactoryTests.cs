using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hw.Console;
using Hw.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Hw.Tests
{
    [TestClass]
    public class HelloWorldRepoTargetFactoryTests : TestBase
    {

        [TestInitialize]
        public void TestInitialize()
        {
        }

        private void SetupFactoryForConsoleTarget(string defaultTarget, string receipientName)
        {
            //
            // Setup
            //
            configurationManagerMock = new Mock<IConfigurationManager>();
            configurationManagerMock.Setup(p => p.RepoTarget).Returns(defaultTarget);

            var r = new DataModels.Receipient { Name = receipientName };
            consoleTargetMock = new Mock<IRepoTarget>();
            fileTargetMock = new Mock<IRepoTarget>();
            consoleTargetMock.Setup(c => c.WriteGreetingAsync(r)).Returns(Task.CompletedTask);

            var repoTargetDictionary = new Dictionary<string, IRepoTarget>
            {
                { RepoTargetConsole,  consoleTargetMock.Object},
                { RepoTargetFile,  fileTargetMock.Object}
            };
            helloWorldRepoTargetFactory = new HelloWorldRepoTargetFactory(configurationManagerMock.Object, repoTargetDictionary);
        }

        [TestMethod]
        public void ShouldRetrieveDefaultTargetFromConfiguration()
        {
            //
            // Setup 
            //
            SetupFactoryForConsoleTarget(RepoTargetConsole, "World");

            //
            // Do work
            //
            var target = helloWorldRepoTargetFactory.GetRepoTarget();


            //
            // Verify
            //
            configurationManagerMock.VerifyGet(v => v.RepoTarget, Times.Once, 
                "Failed to retrieve default RepoTarget from config file!");
        }

        [TestMethod]
        public void ShouldUseConsoleAsDefaultTarget()
        {
            //
            // Setup 
            //
            SetupFactoryForConsoleTarget(RepoTargetConsole, "World");

            //
            // Do work
            //
            var target = helloWorldRepoTargetFactory.GetRepoTarget();


            //
            // Verify
            //
            Assert.IsNotNull(target == consoleTargetMock.Object, 
                "Failed to return the correct Repo Target");
        }

        [TestMethod]
        public void ShouldFailForNotSupportedDefaultTarget()
        {
            //
            // Setup 
            //
            SetupFactoryForConsoleTarget(RepoTargetNotSupported, "World");

            //
            // Do work and verify
            //
            Assert.ThrowsException<Exception>(() => helloWorldRepoTargetFactory.GetRepoTarget(), 
                "Failed to recognize Repo Target that is not supported");
        }
    }
}
