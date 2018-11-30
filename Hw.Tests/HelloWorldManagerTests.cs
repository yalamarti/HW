using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Hw.DataAccess;
using System.Threading.Tasks;
using Hw.BusinessLogic;
using Hw.DataModels;

namespace Hw.Tests
{
    /// <summary>
    /// HellowWorldManager Unit Tests
    /// </summary>
    [TestClass]
    public class HelloWorldManagerTests : TestBase
    {
        protected HelloWorldManager helloWorldManager;
        protected IHelloWorldRepository helloWorldRepository;

        private void Setup(string defaultTarget, string receipientName)
        {
            //
            // Setup
            //
            configurationManagerMock = new Mock<IConfigurationManager>();
            configurationManagerMock.Setup(p => p.RepoTarget).Returns(defaultTarget);

            var r = new DataModels.Receipient { Name = receipientName };
            consoleTargetMock = new Mock<IRepoTarget>();
            fileTargetMock = new Mock<IRepoTarget>();
            //consoleTargetMock.Setup(c => c.WriteGreetingAsync(r)).Returns(Task.CompletedTask);

            var repoTargetDictionary = new Dictionary<string, IRepoTarget>
            {
                { RepoTargetConsole,  consoleTargetMock.Object},
                { RepoTargetFile,  fileTargetMock.Object}
            };

            helloWorldRepoTargetFactory = new HelloWorldRepoTargetFactory(configurationManagerMock.Object, repoTargetDictionary);
            helloWorldRepository = new HelloWorldRepository(helloWorldRepoTargetFactory);

            helloWorldManager = new HelloWorldManager(helloWorldRepository);
        }

        [TestMethod]
        public async Task ShouldGreetSpecifiedReceipientOnConsole()
        {
            const string ReceipientName = "World";
            //
            // Setup
            //
            Setup(RepoTargetConsole, ReceipientName);

            //
            // Do work
            //
            await helloWorldManager.GreetAsync(new Receipient { Name = ReceipientName });

            consoleTargetMock.Verify(c => c.WriteGreetingAsync(It.Is<Receipient>(r => r.Name == ReceipientName)),
                "Failed to display the greeting on the Console");
        }


        [TestMethod]
        public async Task ShouldFailToGreetSpecifiedReceipientOnNotSupportedTarget()
        {
            const string ReceipientName = "World";
            //
            // Setup
            //
            Setup(RepoTargetNotSupported, ReceipientName);

            //
            // Do work
            //
            await Assert.ThrowsExceptionAsync<Exception>(async () => await helloWorldManager.GreetAsync(new Receipient { Name = ReceipientName }),
                "Failed to throw exception for a not-supported repo target");

            consoleTargetMock.Verify(c => c.WriteGreetingAsync(It.IsAny<Receipient>()), Times.Never,
                "Incorrectly attempted to write to console target for a not-supported repo target");
        }

        [TestMethod]
        public async Task ShouldGreetSpecifiedReceipientByWritingToFile()
        {
            const string ReceipientName = "World";
            //
            // Setup
            //
            Setup(RepoTargetFile, ReceipientName);

            //
            // Do work
            //
            await helloWorldManager.GreetAsync(new Receipient { Name = ReceipientName });

            //
            // Verify
            //
            fileTargetMock.Verify(c => c.WriteGreetingAsync(It.Is<Receipient>(r => r.Name == ReceipientName)),
                "Failed to display the greeting in the file");
        }
    }
}
