using System.Configuration;

namespace Toggles.Configuration
{
    public class Feature : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get
            {
                return base["name"] as string;
            }
            set
            {
                base["name"] = value;
            }
        }

        [ConfigurationProperty("isAvailable", DefaultValue = false)]
        public bool State
        {
            get
            {
                return (bool)base["isAvailable"];
            }
            set
            {
                base["state"] = value;
            }
        }
    }
}