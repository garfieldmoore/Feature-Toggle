using Toggles.Configuration.Interfaces;

namespace Toggles.Configuration
{
    using System;
    using Factories;

    public class Features
    {
        private static ISwitchProviderFactory _switchProviderFactory = new ConfigurationSectionSwitchProviderFactory();

        public static bool IsAvailable(string featureName)
        {
            return  _switchProviderFactory.Create().IsAvailable(featureName);
        }

        /// <summary>
        /// Sets the factory to use to create the concrete implementation of ISwitch
        /// </summary>
        /// <param name="factory">SwitchFactory to use to create concrete implementations of ISwitch</param>
        /// <remarks>This defaults to the custom Configuration file section</remarks>
        /// <exception cref="ArgumentNullException">Passing null will throw an exception</exception>
        public static void Initialize(ISwitchProviderFactory factory)
        {
            if (factory == null) throw new ArgumentNullException("factory");

            _switchProviderFactory = factory;
        }
    }
}