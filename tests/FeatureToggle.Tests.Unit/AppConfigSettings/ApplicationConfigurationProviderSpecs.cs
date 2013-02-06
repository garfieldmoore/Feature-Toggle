using System.Collections.Generic;
using System.Configuration;
using NSubstitute;
using NUnit.Framework;
using Rainbow.Wrappers.Configuration;
using Toggles.Configuration;
using Toggles.Configuration.Providers;
using Shouldly;
using Toggles.Configuration.Providers.ApplicationSettings;

namespace FeatureToggle.Tests.Unit
{
    [TestFixture]
    public class ApplicationConfigurationProviderSpecs
    {
        private static ApplicationSettingsSwitchProvider _configProvider;
        private IApplicationSettings _configReader;
        private KeyValueFeatureMapper _mapper;

        [Test]
        public void Should_invoke_application_settings_reader()
        {
            Given_a_application_settings_provider();

            _configProvider.ReadConfiguration();
            _configReader.Received(1).LoadSettings();
        }

        [Test]
        public void Should_invoke_mapper_with_reader_results()
        {
            Given_a_application_settings_provider();

            var keyValueConfigurationCollection = new KeyValueConfigurationCollection();
            _configReader.LoadSettings().Returns(keyValueConfigurationCollection);
             _configProvider.ReadConfiguration();
            _mapper.Received(1).Map(keyValueConfigurationCollection);

        }

        [Test]
        public void IsAvailable_should_return_feature_toggle_value()
        {
            Given_a_application_settings_provider();
            
            _configProvider.ReadConfiguration();
            _configProvider.IsAvailable("Feature001").ShouldBe(true);
        }

        private void Given_a_application_settings_provider()
        {           
            _configReader = Substitute.For<IApplicationSettings>();
            _configReader.LoadSettings().Returns(new KeyValueConfigurationCollection());
            _mapper = Substitute.For<KeyValueFeatureMapper>();
            _mapper.Map(Arg.Any<KeyValueConfigurationCollection>()).Returns(new List<Feature>(){new Feature(){Name = "Feature001", State = true}});
            _configProvider = new ApplicationSettingsSwitchProvider(_configReader, _mapper);
        }
    }
}