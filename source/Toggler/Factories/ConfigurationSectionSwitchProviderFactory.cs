using Toggles.Configuration.Providers;

namespace Toggles.Configuration.Factories
{
    public class ConfigurationSectionSwitchProviderFactory : ISwitchProviderFactory
    {
        public ISwitch Create()
        {
            var config = new ConfigurationSectionSwitchProvider();            
            config.ReadConfiguration();

            return config;
        }
    }
}