using Hw.DataAccess;
using Hw.DataModels;
using System;
using System.Threading.Tasks;

namespace Hw.BusinessLogic
{
    /// <summary>
    /// Manages and provides greetings related activities
    /// </summary>
    public class HelloWorldManager : IHelloWorldManager
    {
        IHelloWorldRepository _helloWorldRepository;

        public HelloWorldManager(IHelloWorldRepository helloWorldRepository)
        {
            _helloWorldRepository = helloWorldRepository;
        }

        public async Task GreetAsync(Receipient recepient)
        {
            await _helloWorldRepository.GreetAsync(recepient);
        }
    }
}
