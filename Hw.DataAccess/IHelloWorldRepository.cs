using Hw.DataModels;
using System;
using System.Threading.Tasks;

namespace Hw.DataAccess
{
    /// <summary>
    /// Interface defining the behaviour of the HelloWorld repository .
    /// </summary>
    public interface IHelloWorldRepository
    {
        /// <summary>
        /// Greets receipient with a greeting
        /// </summary>
        /// <param name="recepient">Receipient of the greeting</param>
        /// <returns>Nothing</returns>
        Task GreetAsync(Receipient recepient);
    }
}
