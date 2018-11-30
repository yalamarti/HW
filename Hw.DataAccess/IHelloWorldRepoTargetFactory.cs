namespace Hw.DataAccess
{
    /// <summary>
    /// Interface defining the behaviour of a repository target factory.
    /// </summary>
    public interface IHelloWorldRepoTargetFactory
    {
        /// <summary>
        /// Returns the default repository target
        /// </summary>
        IRepoTarget GetRepoTarget();
    }
}
