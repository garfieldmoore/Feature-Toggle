using System.Configuration;

namespace Toggles.Configuration.Providers.ConfigurationSection
{
    internal class FeatureConfiguration : System.Configuration.ConfigurationSection
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
