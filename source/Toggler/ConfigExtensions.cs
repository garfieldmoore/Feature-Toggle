using System.Collections.Generic;
using System.Linq;

namespace Toggles.Configuration
{
    internal static class ConfigExtensions
    {
        public static List<T> ToList<T>(this FeatureConfiguration config) where T:class 
        {
            return config.Features.Cast<T>().ToList();
        }

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