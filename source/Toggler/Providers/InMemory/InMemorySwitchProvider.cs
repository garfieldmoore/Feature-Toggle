namespace Toggles.Configuration.Providers.InMemory
{
    using System.Collections.Generic;

    using Toggles.Configuration;

    /// <summary>
    /// An in memory feature switch implementation for testing purposes
    /// </summary>
    public sealed class InMemorySwitchProvider : FeatureSwitchProvider
    {
        private readonly Dictionary<string, bool> featureDictionary;

        public InMemorySwitchProvider(Dictionary<string, bool> featureDictionary)
        {
            this.featureDictionary = featureDictionary;
        }

        public override void ReadConfiguration()
        {
            foreach (var featureSwitch in featureDictionary)
            {
                FeatureSwitches.Add(featureSwitch.Key, new Feature(){Name=featureSwitch.Key, State = featureSwitch.Value});
            }
        }
    }
}