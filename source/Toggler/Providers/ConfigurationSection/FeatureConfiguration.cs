using System.Configuration;
using Toggles.Configuration.Providers.ConfigurationSection;

namespace Toggles.Configuration
{
    internal class FeatureConfiguration : ConfigurationSection
    {
        public static readonly string SectionName = "FeatureConfiguration";

        [ConfigurationProperty("Features", IsRequired = true, IsDefaultCollection = false)]
        public FeaturesCollection Features
        {
            get
            {
                return base["Features"] as FeaturesCollection;
            }

            set
            {
                base["Features"] = value;
            }
        }        
    }
}
