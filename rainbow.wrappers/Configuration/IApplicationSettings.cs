using System.Configuration;

namespace Rainbow.Wrappers.Configuration
{
    public interface IApplicationSettings
    {
        KeyValueConfigurationCollection LoadSettings();
    }
}