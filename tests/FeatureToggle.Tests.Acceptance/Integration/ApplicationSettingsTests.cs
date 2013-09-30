using NUnit.Framework;
using Rainbow.Wrappers.Configuration;
using Shouldly;

namespace FeatureToggle.Tests.Acceptance.Integration
{
    [TestFixture]
    public class ApplicationSettingsTests
    {
        private static ApplicationSettingsReader _configProvider;

        [Test]
        public void Should_Load_settings()
        {
            Given_a_configuration_reader_from_file();
            var features = _configProvider.LoadSettings();

            var keys = features.AllKeys;
            keys.Length.ShouldBe(2);
            keys[0].ShouldBe("FeatureD");
        }

        private static void Given_a_configuration_reader_from_file()
        {
            _configProvider = new ApplicationSettingsReader();

        }
    }
}