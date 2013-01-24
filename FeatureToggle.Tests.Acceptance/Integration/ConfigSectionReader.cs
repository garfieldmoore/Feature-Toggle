using System;
using System.Configuration;

namespace FeatureToggle.Tests.Acceptance
{
    public class ConfigSectionReader : IConfigurationReader
    {
        protected static Configuration Configuration;

        public ConfigSectionReader(Configuration configuration)
        {
            Configuration = configuration;
        }

        public ConfigSectionReader()
        {
            Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }

        public T LoadConfiguration<T>(string section) where T : class
        {
            try
            {
                var config = Configuration.GetSection(section) as T;
                return config;
            }
            catch (Exception e)
            {
                throw new Exception("Unable to load configuration section. See inner exception for more details", e);
            }
        }
    }
}