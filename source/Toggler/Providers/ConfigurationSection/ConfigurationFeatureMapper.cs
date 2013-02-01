using System.Collections.Generic;

namespace Toggles.Configuration.Providers.ConfigurationSection
{
    public class ConfigurationFeatureMapper : IFeatureMapper<FeaturesCollection>
    {
        public virtual List<Feature> Map(FeaturesCollection featuresCollection)
        {
            var features = new List<Feature>();
            foreach (FeatureElement featureElement in featuresCollection)
            {
                features.Add(new Feature() { Name = featureElement.Name, State = featureElement.State });
            }
            return features;
        }
    }

    public static class ConfigurationExtensions
    {
        public static IDictionary<string, Feature> ToDictionary(this IEnumerable<Feature> features)
        {
            var featureList = new Dictionary<string, Feature>();
            foreach (var featureSwitch in features)
            {
                featureList.Add(featureSwitch.Name, featureSwitch);
            }

            return featureList;
        }

    }
}