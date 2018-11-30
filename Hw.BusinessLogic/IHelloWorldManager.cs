using Hw.DataModels;
using System.Threading.Tasks;

namespace Hw.BusinessLogic
{
    /// <summary>
    /// Interface defining the behavior of the HelloWorld Manager. 
    /// </summary>
    public interface IHelloWorldManager
    {
        /// <summary>
        /// Greets a person
        /// </summary>
        /// <param name="recepient">Receipient of the greeting</param>
        /// <returns>None</returns>
        Task GreetAsync(Receipient recepient);
    }
}
