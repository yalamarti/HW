using Hw.DataAccess;
using Moq;

namespace Hw.Tests
{
    public class TestBase
    {
        protected const string RepoTargetConsole = "console";
        protected const string RepoTargetFile = "file";
        protected const string RepoTargetNotSupported = "db";

        protected Mock<IConfigurationManager> configurationManagerMock;
        protected Mock<IRepoTarget> consoleTargetMock;
        protected Mock<IRepoTarget> fileTargetMock;
        protected HelloWorldRepoTargetFactory helloWorldRepoTargetFactory;
    }
}
