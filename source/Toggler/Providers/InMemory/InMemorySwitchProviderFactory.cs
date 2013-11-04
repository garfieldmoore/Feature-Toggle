namespace Toggles.Configuration.Providers.InMemory
{
    using System.Collections.Generic;

    using Toggles.Configuration.Interfaces;

    /// <summary>
    /// An in memory factory implementation for testing purposes
    /// </summary>
    public sealed class InMemorySwitchProviderFactory : ISwitchProviderFactory
    {
        private readonly Dictionary<string, bool> featureDictionary;

        public InMemorySwitchProviderFactory(Dictionary<string, bool> featureDictionary)
        {
            this.featureDictionary = featureDictionary;
        }

        public IProvideSwitches Create()
        {
            return new InMemorySwitchProvider(featureDictionary);
        }
    }
}