using System;
using System.Collections.Generic;
using System.Configuration;
using NSubstitute;
using NUnit.Framework;
using Toggles.Configuration;
using Shouldly;
using Toggles.Configuration.Providers;
using Toggles.Configuration.Providers.ConfigurationSection;

namespace FeatureToggle.Tests.Unit
{
    [TestFixture]
    public class FeatureConfigurationSectionSwitchSpecs
    {
        private static Dictionary<string, Feature> _toggles;
        private static ConfigurationSectionSwitchProvider _configProvider;
        private ApplicationFeatureMapper _mapper;

        [Test]
        public void Read_should_return_switch_configuration()
        {
            Given_a_configuration_provider_with_toggles_configured();

            _toggles = _configProvider.ReadConfiguration();
            _toggles.Count.ShouldBe(1);
            _toggles["Entity Framework"].State.ShouldBe(true);
        }

        [Test]
        public void IsAvailable_should_return_state_of_switch()
        {
            Given_a_configuration_provider_with_toggles_configured();
            _configProvider.ReadConfiguration();
            _configProvider.IsAvaliable("Entity Framework").ShouldBe(true);
        }

        [Test]
        public void Should_throw_exception_when_feature_switch_unknown()
        {
            Given_a_configuration_provider_with_toggles_configured();
            _configProvider.ReadConfiguration();

            Assert.Throws<Exception>(() => _configProvider.IsAvaliable("Unknown").ShouldBe(true));
        }

        private static void Given_a_configuration_provider_with_toggles_configured()
        {
            var fileMap = new ConfigurationFileMap(@"TestData\AppSettings.config");
            var configuration = ConfigurationManager.OpenMappedMachineConfiguration(fileMap);

            _configProvider = new ConfigurationSectionSwitchProvider(configuration);
        }
    }
}