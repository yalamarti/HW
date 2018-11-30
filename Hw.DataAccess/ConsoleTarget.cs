using System;
using System.Threading.Tasks;
using Hw.DataModels;

namespace Hw.DataAccess
{
    /// <summary>
    /// Interface defining the behaviour of a 'console' as a repository target.
    /// </summary>
    public class ConsoleTarget : IRepoTarget
    {
        /// <summary>
        /// Writes a greeting for the specified receipient, to the console 
        /// </summary>
        /// <param name="receipient">Receipient of the greeting</param>
        public async Task WriteGreetingAsync(Receipient receipient)
        {
            Console.WriteLine($"Hello {receipient.Name}!");
            await Task.FromResult(0);
        }
    }
}
