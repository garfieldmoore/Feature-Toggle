using System;
using System.Collections.Generic;
using Toggles.Configuration.Interfaces;

namespace Toggles.Configuration
{
    public abstract class FeatureSwitchProvider : IProvideConfiguration, ISwitch
    {
        protected System.Configuration.Configuration ConfigManager;
        protected IDictionary<string, Feature> FeatureSwitches;

        public abstract IDictionary<string, Feature> ReadConfiguration();

        public virtual bool IsAvailable(string featureName)
        {
            try
            {
                if (FeatureSwitches[featureName].DependsOn != null)
                {
                    return FeatureSwitches[featureName].State && FeatureSwitches[featureName].DependsOn.State;
                }
                
                return FeatureSwitches[featureName].State;
            }
            catch (Exception e)
            {
                throw new Exception("Unknown feature toggle");
            }
        }
    }
}