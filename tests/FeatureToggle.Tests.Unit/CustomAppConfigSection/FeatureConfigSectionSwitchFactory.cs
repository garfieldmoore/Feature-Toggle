using System.Configuration;
using NUnit.Framework;
using Shouldly;
using Toggles.Configuration.Factories;
using Toggles.Configuration.Providers;

namespace FeatureToggle.Tests.Unit
{
    [TestFixture]
    public class FeatureConfigSectionSwitchFactoryTest
    {
        private static ConfigurationSectionSwitchProvider _configProvider;

        [Test]
        public void Create_should_return_concrete_implementation()
        {
            var featureFactory = new ConfigurationSectionSwitchProviderFactory();

            var switcher = featureFactory.Create();
            switcher.ShouldNotBe(null);
            switcher.ShouldBeTypeOf<ConfigurationSectionSwitchProvider>();
        }

        [Test]
        public void Create_should_invoke_read_configuration()
        {
            var featureFactory = new ConfigurationSectionSwitchProviderFactory();

            var switcher = featureFactory.Create();
            switcher.IsAvaliable("Entity Framework");
        }

        private static void Given_a_configuration_provider_with_toggles_configured()
        {
            var fileMap = new ConfigurationFileMap(@"TestData\DependentSwitches.config");
            var configuration = ConfigurationManager.OpenMappedMachineConfiguration(fileMap);

            _configProvider = new ConfigurationSectionSwitchProvider(configuration);
        }
    }
}
