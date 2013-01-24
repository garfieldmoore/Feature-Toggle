using System.Collections.Generic;
using System.Configuration;
using NSubstitute;
using NUnit.Framework;
using Toggles.Configuration;
using Toggles.Configuration.Providers;
using Toggles.Configuration.Providers.ConfigurationSection;

namespace FeatureToggle.Tests.Unit
{
    [TestFixture]
    public class ApplicationConfigurationMapperSpecs
    {
        private static Dictionary<string, Feature> _toggles;
        private static ApplicationSettingsSwitchProvider _configProvider;
        private static ApplicationFeatureMapper _mapper;

        [Test]
        public void Should_map_features()
        {
            var mapper = new ApplicationFeatureMapper();
            // Create the KeyValueConfigurationElement.
            KeyValueConfigurationElement element =
              new KeyValueConfigurationElement(
              "myAdminTool", "admin.aspx");


            Feature feature = mapper.Map(element);

            //            feature.Name.ShouldBe("Feature");
            //            feature.State.ShouldBe(true);
        }

        [Test]
        public void Should_use_mapper()
        {
            Given_a_configuration_provider_with_toggles_configured();

            _mapper.Map(Arg.Any<KeyValueConfigurationElement>()).ReturnsForAnyArgs(new Feature() { Name = "Feature", State = true });
            
            _configProvider.ReadConfiguration();
            _mapper.ReceivedWithAnyArgs().Map(Arg.Any<KeyValueConfigurationElement>());
        }

        private static void Given_a_configuration_provider_with_toggles_configured()
        {
            _mapper = Substitute.For<ApplicationFeatureMapper>();

            _configProvider = new ApplicationSettingsSwitchProvider(_mapper);
        }
    }
}