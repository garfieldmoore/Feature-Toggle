using System.Collections.Generic;
using System.Configuration;
using NUnit.Framework;
using Toggles.Configuration;
using Toggles.Configuration.Factories;
using Toggles.Configuration.Providers;
using Shouldly;

namespace FeatureToggle.Tests.Unit
{
    [TestFixture]
    public class ApplicationConfigurationProviderSpecs
    {
        private static Dictionary<string, Feature> _toggles;
        private static ApplicationSettingsSwitchProvider _configProvider;

        [Test]
        public void Should_read_from_applicaiton_settings()
        {
            Given_a_application_settings_provider();

            var switches = _configProvider.ReadConfiguration();
            switches.Count.ShouldBe(1);
            switches["Feature001"].State.ShouldBe(true);
        }

        [Test]
        public void IsAvailable_should_return_feature_toggle_value()
        {
            Given_a_application_settings_provider();
            
            _configProvider.ReadConfiguration();
            _configProvider.IsAvaliable("Feature001").ShouldBe(true);


        }

        private void Given_a_application_settings_provider()
        {
            var fileMap = new ConfigurationFileMap(@"TestData\appSettings.config");
            var configuration = ConfigurationManager.OpenMappedMachineConfiguration(fileMap);

            _configProvider = new ApplicationSettingsSwitchProvider();
        }
    }
}