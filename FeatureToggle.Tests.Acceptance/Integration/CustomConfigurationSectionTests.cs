using System.Configuration;
using System.Linq;
using NUnit.Framework;
using Shouldly;
using Toggles.Configuration;
using Toggles.Configuration.Providers.ConfigurationSection;

namespace FeatureToggle.Tests.Acceptance
{
    [TestFixture]
    public class CustomConfigurationSectionTests
    {
        private const string FeatureConfigurationSection = "FeatureConfiguration";
        private static ConfigSectionReader _configProvider;

        [Test]
        public void Should_load_name_value_pair()
        {
            Given_a_configuration_reader_from_file(@"Integration\TestData\KeyNamePair.config");

            var features = _configProvider.LoadConfiguration<FeatureConfiguration>(FeatureConfigurationSection).ToList<FeatureElement>();                       

            features.Count.ShouldBe(1);
            features.FirstOrDefault().Name.ShouldBe("Feature001");
            features.FirstOrDefault().State.ShouldBe(true);
        }

        [Test]
        public void Should_load_dependsOn()
        {
            Given_a_configuration_reader_from_file(@"Integration\TestData\dependsOn.config");

            var features = _configProvider.LoadConfiguration<FeatureConfiguration>(FeatureConfigurationSection).ToList<FeatureElement>();

            features.Count.ShouldBe(1);
            features.FirstOrDefault().DependsOn.ShouldBe("FeatureA");
        }

        [Test]
        public void Should_load_multiple_toggles()
        {
            Given_a_configuration_reader_from_file(@"Integration\TestData\MultipleToggles.config");

            var features = _configProvider.LoadConfiguration<FeatureConfiguration>(FeatureConfigurationSection).ToList<FeatureElement>();

            features.Count.ShouldBe(3);
        }

        private static void Given_a_configuration_reader_from_file(string filePath)
        {
            var fileMap = new ConfigurationFileMap(filePath);
            var configuration = ConfigurationManager.OpenMappedMachineConfiguration(fileMap);
            _configProvider = new ConfigSectionReader(configuration);

        }
    }
}
