using System.Configuration;

namespace Toggles.Configuration
{
    public class FeaturesCollection: ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new Feature();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((element) as Feature).Name;
        }

    }
}