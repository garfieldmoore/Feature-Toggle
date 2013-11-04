using Rainbow.Wrappers.Configuration;
using Toggles.Configuration.Providers.ApplicationSettings;

namespace Toggles.Configuration.Providers
{
    using System.Configuration;

    public class ApplicationSettingsSwitchProvider : FeatureSwitchProvider
    {
        private readonly KeyValueFeatureMapper _mapper;
        private IApplicationSettings _reader;

        protected Configuration ConfigManager;

        public ApplicationSettingsSwitchProvider()
        {
            ConfigManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            _mapper = new KeyValueFeatureMapper();
        }

        public ApplicationSettingsSwitchProvider(IApplicationSettings configReader, KeyValueFeatureMapper mapper)
            : this(mapper)
        {
            _reader = configReader;
            _mapper = mapper;
        }

        internal ApplicationSettingsSwitchProvider(KeyValueFeatureMapper mapper)
        {
            _mapper = mapper;
        }

        public override void ReadConfiguration()
        {
            FeatureSwitches = _mapper.Map(_reader.LoadSettings()).ToDictionary();
        }
    }
}