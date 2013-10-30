using Rainbow.Wrappers.Configuration;
using Toggles.Configuration.Interfaces;
using Toggles.Configuration.Providers;
using Toggles.Configuration.Providers.ConfigurationSection;

namespace Toggles.Configuration.Factories
{
    public class ConfigurationSectionSwitchProviderFactory : ISwitchProviderFactory
    {
        public IProvideSwitches Create()
        {
            var config = new ConfigurationSectionSwitchProvider(new ConfigSectionReader(), new ConfigurationFeatureMapper());

            return config;
        }
    }
}