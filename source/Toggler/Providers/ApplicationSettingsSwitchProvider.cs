using Rainbow.Wrappers.Configuration;
using Toggles.Configuration.Providers.ApplicationSettings;

namespace Toggles.Configuration.Providers
{
    using System.Collections.Generic;
    using System.Configuration;

    public class ApplicationSettingsSwitchProvider : FeatureSwitchProvider   
    {
        private readonly KeyValueFeatureMapper _mapper;
        private IApplicationSettings _reader;
        public ApplicationSettingsSwitchProvider()
        {
            ConfigManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            _mapper= new KeyValueFeatureMapper();
        }
       
        internal ApplicationSettingsSwitchProvider(IApplicationSettings configReader, KeyValueFeatureMapper mapper):this(mapper)
        {
            _reader = configReader;
            _mapper = mapper;
        }

        internal ApplicationSettingsSwitchProvider(KeyValueFeatureMapper mapper)
        {
            _mapper = mapper;
        }

        public override IDictionary<string, Feature> ReadConfiguration()
        {
            FeatureSwitches = new Dictionary<string, Feature>();

            FeatureSwitches = _mapper.Map(_reader.LoadSettings()).ToDictionary();

            return FeatureSwitches;
        }
    }
}