using System.Collections.Generic;
using Toggles.Configuration.Interfaces;

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
}