using Hw.BusinessLogic;
using Hw.DataModels;
using System.Threading.Tasks;

namespace Hw.Console
{
    /// <summary>
    /// Program Startup class - non-platform specific entry point
    /// </summary>
    public class StartUp
    {
        IHelloWorldManager _helloWorldManager;
        public StartUp(IHelloWorldManager helloWorldManager)
        {
            _helloWorldManager = helloWorldManager;
        }

        /// <summary>
        /// Starts non-platform specific program execution
        /// </summary>
        /// <returns>Nothing</returns>
        public async Task Run()
        {
            // Call into the 'api' to greet 'Jon Doe' hello!
            await _helloWorldManager.GreetAsync(new Receipient { Name = "World" });
        }
    }
}
