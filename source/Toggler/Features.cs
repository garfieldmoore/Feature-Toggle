
namespace Toggles.Configuration
{
    using System;
    using Factories;
    using Toggles.Configuration.Interfaces;

    public sealed class Features
    {
        private static ISwitchProviderFactory switchProviderFactory = new ConfigurationSectionSwitchProviderFactory();

        private static IProvideSwitches switchProvider;

        public static bool IsAvailable(string featureName)
        {
            switchProvider = switchProviderFactory.Create();
            switchProvider.ReadConfiguration();

            return switchProvider.IsAvailable(featureName);
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

            switchProviderFactory = factory;
        }
    }
}