using System.Configuration;

namespace Toggles.Configuration.Providers.ConfigurationSection
{
    public class FeatureElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return base["name"] as string; }
            set { base["name"] = value; }
        }

        [ConfigurationProperty("isAvailable", DefaultValue = false)]
        public bool State
        {
            get { return (bool)base["isAvailable"]; }
            set { base["state"] = value; }
        }

        [ConfigurationProperty("DependsOn", IsRequired = false, DefaultValue = "")]
        public string DependsOn
        {
            get { return base["DependsOn"] as string; }
            set { base["DependsOn"] = value; }
        }
    }
}