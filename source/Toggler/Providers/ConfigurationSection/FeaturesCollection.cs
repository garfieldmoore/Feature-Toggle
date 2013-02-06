using System.Configuration;

namespace Toggles.Configuration.Providers.ConfigurationSection
{
    internal class FeaturesCollection: ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new FeatureElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((element) as FeatureElement).Name;
        }

    }
}