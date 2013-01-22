using System;
using System.Configuration;

namespace Toggles.Configuration
{
    public class Features
    {
        private static ISwitchFactory _switchFactory = new FeatureConfigSectionSwitchFactory();

        public static bool IsAvailable(string featureName)
        {
            return  _switchFactory.Create().IsAvaliable(featureName);
        }

        /// <summary>
        /// Sets the factory to use to create the concrete implementation of ISwitch
        /// </summary>
        /// <param name="factory">SwitchFactory to use to create concrete implementations of ISwitch</param>
        /// <remarks>This defaults to the custom Configuration file section</remarks>
        /// <exception cref="ArgumentNullException">Passing null will throw an exception</exception>
        public static void Initialize(ISwitchFactory factory)
        {
            if (factory == null) throw new ArgumentNullException("factory");

            _switchFactory = factory;
        }
    }
}