using System;
using System.Collections.Generic;
using Toggles.Configuration.Interfaces;

namespace Toggles.Configuration
{
    using Toggles.Configuration.Providers.InMemory;

    public abstract class FeatureSwitchProvider : IProvideSwitches
    {
        protected IChecker SwitchChecker;

        public IDictionary<string, Feature> FeatureSwitches { get; protected set; }

        public abstract void ReadConfiguration();

        protected FeatureSwitchProvider()
        {
            FeatureSwitches = new Dictionary<string, Feature>();
            this.SwitchChecker = new StateChecker();
        }

        public void AddChecker(IChecker checker)
        {
            checker.AddChecker(SwitchChecker);

            this.SwitchChecker = checker;
        }

        public virtual bool IsAvailable(string featureName)
        {
            try
            {
                return this.SwitchChecker.IsAvailable(FeatureSwitches[featureName]);
            }
            catch (Exception e)
            {
                // TODO: create custom exception
                throw new Exception("Unknown feature toggle");
            }
        }
    }
}