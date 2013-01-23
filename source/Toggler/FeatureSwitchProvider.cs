using System;
using System.Collections.Generic;

namespace Toggles.Configuration
{
    public abstract class FeatureSwitchProvider : IProvideConfiguration, ISwitch
    {
        protected System.Configuration.Configuration ConfigManager;
        protected Dictionary<string, Feature> FeatureSwitches;

        public abstract Dictionary<string, Feature> ReadConfiguration();

        public virtual bool IsAvaliable(string featureName)
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