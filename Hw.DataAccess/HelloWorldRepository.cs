using System.Text;
using System.Threading.Tasks;
using Hw.DataModels;

namespace Hw.DataAccess
{
    /// <summary>
    /// Provides the HelloWorld repository functionality
    /// </summary>
    public class HelloWorldRepository : IHelloWorldRepository
    {
        /// <summary>
        /// Factory that allows for determining the repository target - viz., console or file or ...
        /// </summary>
        IHelloWorldRepoTargetFactory _repoTargetFactory;

        public HelloWorldRepository(IHelloWorldRepoTargetFactory repoTargetFactory)
        {
            _repoTargetFactory = repoTargetFactory;
        }

        /// <summary>
        /// Greet the specified receipient
        /// </summary>
        /// <param name="recepient">Receipient of the greeting</param>
        /// <returns></returns>
        public async Task GreetAsync(Receipient recepient)
        {
            // Get the repository target and 'write' the greeting
            await _repoTargetFactory.GetRepoTarget().WriteGreetingAsync(recepient);
        }
    }
}
