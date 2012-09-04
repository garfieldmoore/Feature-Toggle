using System.Configuration;

namespace Toggles.Configuration
{
    public class FeatureConfiguration : ConfigurationSection
    {
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
