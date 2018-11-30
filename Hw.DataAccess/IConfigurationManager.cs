namespace Hw.DataAccess
{
    /// <summary>
    /// Interface defining the application configuration/settings
    /// </summary>
    public interface IConfigurationManager
    {
        /// <summary>
        /// Get default repository target
        /// </summary>
        string RepoTarget { get; }
    }
}
