using Toggles.Configuration.Providers.ConfigurationSection;

namespace Toggles.Configuration.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    public class ConfigurationSectionSwitchProvider : FeatureSwitchProvider
    {
        private static FeatureConfiguration _config;

        public ConfigurationSectionSwitchProvider(Configuration configuration)
        {
            ConfigManager = configuration;
        }

        public ConfigurationSectionSwitchProvider()
        {
            ConfigManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }

        public override Dictionary<string, Feature> ReadConfiguration()
        {
            LoadConfiguration();

            LoadSwitches();

            return FeatureSwitches;
        }

        private void LoadConfiguration()
        {
            try
            {
                _config = ConfigManager.GetSection("FeatureConfiguration") as FeatureConfiguration;
            }
            catch (Exception e)
            {
                throw new Exception("Unable to load feature toggle configuration. See inner exception for more details", e);
            }
        }

        private void LoadSwitches()
        {
            FeatureSwitches = new Dictionary<string, Feature>();

            foreach (var feature in _config.Features)
            {
                var toggle = (FeatureElement)feature;
                var switch1 = new Feature() { Name = toggle.Name, State = toggle.State };
                var dependency = GetDependentSwitch(toggle, switch1);

                if (dependency != null)
                    switch1.DependsOn = FeatureSwitches[toggle.DependsOn];

                FeatureSwitches.Add(toggle.Name, switch1);
            }
        }

        private Feature GetDependentSwitch(FeatureElement toggle, Feature switch1)
        {            
            try
            {
                var dependency = FeatureSwitches[toggle.DependsOn];
                return dependency;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
