using System.Collections.Generic;
using System.Configuration;
using NUnit.Framework;
using Toggles.Configuration;
using Toggles.Configuration.Factories;
using Toggles.Configuration.Providers;
using Toggles.Configuration.Providers.ConfigurationSection;
using Shouldly;

namespace FeatureToggle.Tests.Unit.DependantToggles
{
    [TestFixture]
    public class DependantSwitchSpecs
    {
        private static Dictionary<string, Feature> _toggles;
        private static ConfigurationSectionSwitchProvider _configProvider;
        private static Configuration _configuration;

        [Test]
        public void Should_load_dependent_switch()
        {
            Given_a_configuration_provider_with_toggles_configured();

            _toggles = _configProvider.ReadConfiguration();

            _toggles.Count.ShouldBe(2);
            _toggles["FeatureB"].DependsOn.ShouldNotBe(null);
            _toggles["FeatureB"].DependsOn.ShouldBeTypeOf<Feature>();
            _toggles["FeatureB"].DependsOn.Name.ShouldBe("FeatureA");
            _toggles["FeatureB"].DependsOn.State.ShouldBe(false);
        }

        [Test]
        public void Should_not_be_available_when_dependant_feature_is_not_available()
        {
            _toggles = _configProvider.ReadConfiguration();
            _toggles["FeatureB"].State.ShouldBe(false);
        }

        [Test]
        public void Should_be_avialable_if_dependent_feature_is_available()
        {
            Given_a_configuration_provider_with_toggles_configured();

            _toggles = _configProvider.ReadConfiguration();
            _configProvider.IsAvaliable("FeatureB").ShouldBe(false);

        }


        private static void Given_a_configuration_provider_with_toggles_configured()
        {
            var fileMap = new ConfigurationFileMap(@"TestData\DependentSwitches.config");
            _configuration = ConfigurationManager.OpenMappedMachineConfiguration(fileMap);

            _configProvider = new ConfigurationSectionSwitchProvider(_configuration);
        }

        [Test]
        public void Should_map_features_collection_to_features()
        {
            Given_a_configuration_provider_with_toggles_configured();
            var settings = _configuration.GetSection("FeatureConfiguration") as FeatureConfiguration;

            var mapper = new ConfigurationFeatureMapper();
            // var feature = mapper.Map(new );

        }


    }

}