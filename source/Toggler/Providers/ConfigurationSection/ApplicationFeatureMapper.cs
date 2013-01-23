using System.Configuration;

namespace Toggles.Configuration.Providers.ConfigurationSection
{
    public class ApplicationFeatureMapper : IFeatureMapper<KeyValueConfigurationElement>
    {
        public virtual Feature Map(KeyValueConfigurationElement objectToMap)
        {
            bool value = bool.Parse(objectToMap.Value);

            var featureSwitch = new Feature() {Name = objectToMap.Key, State = value};
            return featureSwitch;
        }
    }
}