using System.Collections.Generic;
using System.Configuration;
using NSubstitute;
using NUnit.Framework;
using Rainbow.Wrappers.Configuration;
using Toggles.Configuration;
using Toggles.Configuration.Providers;
using Toggles.Configuration.Providers.ApplicationSettings;

namespace FeatureToggle.Tests.Unit
{
    [TestFixture]
    public class ApplicationSettingsSwitchProviderSpecs
    {
        private static ApplicationSettingsSwitchProvider _configProvider;
        private static KeyValueFeatureMapper _mapper;
        private static KeyValueConfigurationCollection _keyValueConfigurationCollection = new KeyValueConfigurationCollection();
        private static IApplicationSettings _configReader;

        [Test]
        public void Should_use_mapper()
        {
            Given_a_configuration_provider_with_toggles_configured();

            _configReader.LoadSettings().Returns(_keyValueConfigurationCollection);
            _mapper.Map(_keyValueConfigurationCollection).Returns(new List<Feature>());
           
            _configProvider.ReadConfiguration();

            _mapper.Received().Map(_keyValueConfigurationCollection);            
        }

        [Test]
        public void Should_use_config_reader_to_load_configuration()
        {
            Given_a_configuration_provider_with_toggles_configured();

            _configReader.LoadSettings().Returns(_keyValueConfigurationCollection);
            _mapper.Map(_keyValueConfigurationCollection).Returns(new List<Feature>());

            _configProvider.ReadConfiguration();

            _configReader.Received(1).LoadSettings();
        }

        private static void Given_a_configuration_provider_with_toggles_configured()
        {
            _mapper = Substitute.For<KeyValueFeatureMapper>();
            _configReader = Substitute.For<IApplicationSettings>();
            _configProvider = new ApplicationSettingsSwitchProvider(_configReader, _mapper);
        }
    }
}