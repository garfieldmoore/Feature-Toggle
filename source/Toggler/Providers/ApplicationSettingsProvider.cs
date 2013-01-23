using Toggles.Configuration.Providers.ConfigurationSection;

namespace Toggles.Configuration.Providers
{
    using System.Collections.Generic;
    using System.Configuration;

    public class ApplicationSettingsSwitchProvider : FeatureSwitchProvider   
    {
        private readonly ApplicationFeatureMapper _mapper;

        public ApplicationSettingsSwitchProvider()
        {
            ConfigManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            _mapper= new ApplicationFeatureMapper();
        }


        public ApplicationSettingsSwitchProvider(Configuration configuration)
        {
            ConfigManager = configuration;
        }

        public ApplicationSettingsSwitchProvider(ApplicationFeatureMapper mapper) : this()
        {
            _mapper = mapper;
        }


        public override Dictionary<string, Feature> ReadConfiguration()
        {
            FeatureSwitches = new Dictionary<string, Feature>();
            AppSettingsSection section = ConfigManager.AppSettings;

            foreach (KeyValueConfigurationElement key in section.Settings)
            {
                var feature = _mapper.Map(key);
                FeatureSwitches.Add(feature.Name, feature);
            }

            return FeatureSwitches;
        }
    }
}