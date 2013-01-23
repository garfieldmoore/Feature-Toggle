using Toggles.Configuration.Providers;

namespace Toggles.Configuration.Factories
{
    public class ApplicationSettingsSwitchProviderFactory : ISwitchProviderFactory
    {
        public ISwitch Create()
        {
            var provider = new ApplicationSettingsSwitchProvider();
            provider.ReadConfiguration();

            return provider;
        }
    }
}