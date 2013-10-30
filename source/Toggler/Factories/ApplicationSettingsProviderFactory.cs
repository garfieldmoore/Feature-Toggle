using Rainbow.Wrappers.Configuration;
using Toggles.Configuration.Interfaces;
using Toggles.Configuration.Providers;
using Toggles.Configuration.Providers.ApplicationSettings;
using Toggles.Configuration.Providers.ConfigurationSection;

namespace Toggles.Configuration.Factories
{
    public class ApplicationSettingsSwitchProviderFactory : ISwitchProviderFactory
    {
        public IProvideSwitches Create()
        {
            var provider = new ApplicationSettingsSwitchProvider(new ApplicationSettingsReader(), new KeyValueFeatureMapper());

            return provider;
        }
    }
}