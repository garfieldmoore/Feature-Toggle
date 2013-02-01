using Rainbow.Wrappers.Configuration;
using Toggles.Configuration.Providers;
using Toggles.Configuration.Providers.ConfigurationSection;

namespace Toggles.Configuration.Factories
{
    public class ConfigurationSectionSwitchProviderFactory : ISwitchProviderFactory
    {
        public ISwitch Create()
        {
            var config = new ConfigurationSectionSwitchProvider(new ConfigSectionReader(), new ConfigurationFeatureMapper());            
            config.ReadConfiguration();

            return config;
        }
    }
}