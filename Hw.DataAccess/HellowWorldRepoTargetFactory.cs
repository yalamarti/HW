using System;
using System.Collections.Generic;

namespace Hw.DataAccess
{
    /// <summary>
    /// Provides a way to construct instance of the default repository target
    /// as configured in the appsettings.json
    /// </summary>
    public class HelloWorldRepoTargetFactory : IHelloWorldRepoTargetFactory
    {
        /// <summary>
        /// Dictionary of repository target type-name to the instance of the repository target implementation
        /// </summary>
        Dictionary<string, IRepoTarget> _repoTargets;
        IConfigurationManager _configurationManager;

        public HelloWorldRepoTargetFactory(IConfigurationManager configurationManager, 
            Dictionary<string, IRepoTarget> repoTargets)
        {
            _configurationManager = configurationManager;
            _repoTargets = repoTargets;
        }

        /// <summary>
        /// Returns the instance of a default repository target
        /// </summary>
        /// <returns></returns>
        public IRepoTarget GetRepoTarget()
        {
            // Get the repository target as configured in the app configuration
            var target = _configurationManager.RepoTarget.ToLower();
            if (_repoTargets.ContainsKey(target))
            {
                // Return matching repository target instance
                return _repoTargets[target];
            }

            throw new Exception($"Unrecognized repo target: {target}");
        }
    }
}
