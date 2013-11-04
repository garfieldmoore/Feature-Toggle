using Rainbow.Wrappers.Configuration;
using Toggles.Configuration.Providers.ConfigurationSection;

namespace Toggles.Configuration.Providers
{
    using System;

    public class ConfigurationSectionSwitchProvider : FeatureSwitchProvider
    {
        private readonly IConfigurationReader _configurationReader;
        private readonly ConfigurationFeatureMapper _mapper;
        private static FeatureConfiguration _config;

        // TODO: put this on abstract class so it needs to be implemented in factory
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

        public override void ReadConfiguration()
        {
            LoadConfiguration();

            FeatureSwitches = _mapper.Map(_config.Features).ToDictionary();
        }
    }
}
