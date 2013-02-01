using System.Configuration;

namespace Rainbow.Wrappers.Configuration
{
    public class ApplicationSettingsReader : IApplicationSettings
    {
        private readonly System.Configuration.Configuration _configuration;

        public ApplicationSettingsReader()
        {
            _configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }

        public ApplicationSettingsReader(System.Configuration.Configuration configuration)
        {
            _configuration = configuration;
        }

      
        public KeyValueConfigurationCollection LoadSettings()
        {
            // returns a configuration element collection
            AppSettingsSection section = _configuration.AppSettings;

            return section.Settings;           
        }
    }
}