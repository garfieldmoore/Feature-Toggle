using System.Collections.Generic;
using System.Configuration;

namespace Toggles.Configuration.Providers.ApplicationSettings
{
    internal class KeyValueFeatureMapper : IFeatureMapper<KeyValueConfigurationCollection>
    {
        public virtual List<Feature> Map(KeyValueConfigurationCollection keyValueConfigurationCollection)
        {
            var features = new List<Feature>();

            foreach (var key in keyValueConfigurationCollection.AllKeys)
            {

                var featureSwitch = new Feature() { Name = key, State = bool.Parse(keyValueConfigurationCollection[key].Value) };
                features.Add(featureSwitch);
           }

            return features;
        }
    }
}