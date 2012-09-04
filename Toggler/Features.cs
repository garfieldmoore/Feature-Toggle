using System;
using System.Configuration;

namespace Toggles.Configuration
{
    public class Features
    {
        private static FeatureConfiguration _config;


        public static bool IsAvailable(string featureName)
        {
            try
            {
                _config = ConfigurationManager.GetSection("FeatureConfiguration") as FeatureConfiguration;
            }
            catch (Exception e)
            {
                throw new Exception("Unable to load feature toggle configuration. See inner exception for more details", e);
            }

            foreach (var feature in _config.Features)
            {

                if ((feature as Feature).Name == featureName)
                {
                    return (feature as Feature).State;
                }
            }

            throw new Exception("Unknown feature toggle");
        }
    }
}