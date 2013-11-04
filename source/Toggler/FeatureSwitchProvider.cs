using System;
using System.Collections.Generic;
using Toggles.Configuration.Interfaces;

namespace Toggles.Configuration
{
    public abstract class FeatureSwitchProvider : IProvideSwitches
    {
        protected System.Configuration.Configuration ConfigManager;

        public IDictionary<string, Feature> FeatureSwitches { get; protected set; }

        public abstract void ReadConfiguration();

        protected FeatureSwitchProvider()
        {
            FeatureSwitches = new Dictionary<string, Feature>();
        }

        public virtual bool IsAvailable(string featureName)
        {
            try
            {
//                if (FeatureSwitches[featureName].DependsOn != null)
//                {
//                    return FeatureSwitches[featureName].State && FeatureSwitches[featureName].DependsOn.State;
//                }

                return FeatureSwitches[featureName].State;
            }
            catch (Exception e)
            {
                // TODO: create custom exception
                throw new Exception("Unknown feature toggle");
            }
        }
    }
}