using Hw.DataModels;
using System.Threading.Tasks;

namespace Hw.DataAccess
{
    /// <summary>
    /// Interface defining the behaviour of a repository target.
    /// </summary>
    public interface IRepoTarget
    {
        /// <summary>
        /// Writes greeting to the repository target e.g., console or file
        /// </summary>
        /// <param name="receipient"></param>
        /// <returns>Nothing</returns>
        Task WriteGreetingAsync(Receipient receipient);
    }
}
