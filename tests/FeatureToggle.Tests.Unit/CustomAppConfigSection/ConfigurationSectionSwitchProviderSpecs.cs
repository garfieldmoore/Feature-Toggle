using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Rainbow.Wrappers.Configuration;
using Toggles.Configuration;
using Toggles.Configuration.Providers;
using Toggles.Configuration.Providers.ConfigurationSection;
using Shouldly;

namespace FeatureToggle.Tests.Unit
{
    [TestFixture]
    public class ConfigurationSectionSwitchProviderSpecs
    {
        private static ConfigurationSectionSwitchProvider _configProvider;
        private static IConfigurationReader _mockReader;
        private ConfigurationFeatureMapper _mapper;
        private List<Feature> _mappedFeatures;

        [Test]
        public void LoadConfiguration_invokes_configuration_reader()
        {
            Given_a_configuration_provider_with_toggles_configured();
            
            _configProvider.LoadConfiguration();
            _mockReader.Received().LoadConfiguration<FeatureConfiguration>(FeatureConfiguration.SectionName);
        }

        [Test]
        public void ReadConfiguration_invokes_mapper()
        {
            Given_a_configuration_provider_with_toggles_configured();
            _mapper.Map(Arg.Any<FeaturesCollection>()).Returns(new List<Feature>());
            _mockReader.LoadConfiguration<FeatureConfiguration>(FeatureConfiguration.SectionName).Returns(new FeatureConfiguration());
            
            _configProvider.ReadConfiguration();
            
            _mapper.Received(1).Map(Arg.Any<FeaturesCollection>());

        }

        [Test]
        public void ReadConfiguration_invokes_configuration_reader()
        {
            Given_a_configuration_provider_with_toggles_configured();

            _mapper.Map(Arg.Any<FeaturesCollection>()).Returns(new List<Feature>());
            _mockReader.LoadConfiguration<FeatureConfiguration>(FeatureConfiguration.SectionName).Returns(new FeatureConfiguration());

            _configProvider.ReadConfiguration();
            _mockReader.Received(1).LoadConfiguration<FeatureConfiguration>(FeatureConfiguration.SectionName);
        }

        [Test]
        public void ReadConfiguration_invokes_configuration_reader_first_time_only()
        {
            Given_a_configuration_provider_with_a_reader();
            _configProvider.ReadConfiguration();
            _configProvider.ReadConfiguration();
            // This should only happen once as it is suboptimal
            _mockReader.Received(2).LoadConfiguration<FeatureConfiguration>(FeatureConfiguration.SectionName);
        }

        [Test]
        public void ReadConfiguration_returns_mapped_feature_toggles()
        {
            Given_a_configuration_provider_with_a_reader();
            var toggles = _configProvider.ReadConfiguration();
            toggles.ContainsKey("Feature001").ShouldBe(true);
            toggles.Values.ShouldContain(_mappedFeatures[0]);
        }


        private void Given_a_configuration_provider_with_a_reader()
        {
            Given_a_configuration_provider_with_toggles_configured();
            _mappedFeatures = new List<Feature>(){new Feature(){Name="Feature001", State=true}};
            _mapper.Map(Arg.Any<FeaturesCollection>()).Returns(_mappedFeatures);
            _mockReader.LoadConfiguration<FeatureConfiguration>(FeatureConfiguration.SectionName).Returns(new FeatureConfiguration());
        }


        private void Given_a_configuration_provider_with_toggles_configured()
        {
            _mockReader = Substitute.For<IConfigurationReader>();
            _mapper = Substitute.For<ConfigurationFeatureMapper>();
            
            _configProvider = new ConfigurationSectionSwitchProvider(_mockReader, _mapper);
        }
    }
}