using Hw.DataModels;
using Newtonsoft.Json;
using System.IO;

namespace Hw.DataAccess
{
    /// <summary>
    /// Handles the retrieval of application configuration
    /// </summary>
    public class ConfigurationManager : IConfigurationManager
    {
        AppConfiguration _appConfiguration;

        public ConfigurationManager(string configFile)
        {
            _appConfiguration = JsonConvert.DeserializeObject<AppConfiguration>(File.ReadAllText(configFile));
        }
        

        public string RepoTarget => _appConfiguration.RepoTarget;
    }
}
