using Rainbow.Wrappers.Configuration;
using Toggles.Configuration.Providers.ConfigurationSection;

namespace Toggles.Configuration.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    public class ConfigurationSectionSwitchProvider : FeatureSwitchProvider
    {
        private readonly IConfigurationReader _configurationReader;
        private readonly ConfigurationFeatureMapper _mapper;
        private static FeatureConfiguration _config;

        public ConfigurationSectionSwitchProvider(IConfigurationReader configurationReader, ConfigurationFeatureMapper mapper)
        {
            _configurationReader = configurationReader;
            _mapper = mapper;
        }

        public ConfigurationSectionSwitchProvider()
        {
            _configurationReader = new ConfigSectionReader();
        }

        public void LoadConfiguration()
        {
            try
            {
                _config = _configurationReader.LoadConfiguration<FeatureConfiguration>(FeatureConfiguration.SectionName);
            }
            catch (Exception e)
            {
                throw new Exception("Unable to load feature toggle configuration. See inner exception for more details", e);
            }
        }

        public override IDictionary<string, Feature> ReadConfiguration()
        {
            LoadConfiguration();

            FeatureSwitches = _mapper.Map(_config.Features).ToDictionary();

            return FeatureSwitches;
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
