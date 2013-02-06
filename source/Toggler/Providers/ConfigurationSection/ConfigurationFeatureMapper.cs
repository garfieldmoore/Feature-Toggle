using System.Collections.Generic;

namespace Toggles.Configuration.Providers.ConfigurationSection
{
    internal class ConfigurationFeatureMapper : IFeatureMapper<FeaturesCollection>
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
}