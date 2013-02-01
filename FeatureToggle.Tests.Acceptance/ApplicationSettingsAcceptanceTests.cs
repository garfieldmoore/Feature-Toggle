using NUnit.Framework;
using Toggles.Configuration;
using Toggles.Configuration.Factories;
using Shouldly;

namespace FeatureToggle.Tests.Acceptance
{
    [TestFixture]
    public class ApplicationSettingsAcceptanceTests
    {
        [Test]
        public void ShouldEvaluateSimpleProperties()
        {
            GivenFeaturesIsConfiguredWithApplicationSettingsSwitchProvider();

            Features.IsAvailable("FeatureD").ShouldBe(true);
            Features.IsAvailable("FeatureE").ShouldBe(false);
        }

        private void GivenFeaturesIsConfiguredWithApplicationSettingsSwitchProvider()
        {
            Features.Initialize(new ApplicationSettingsSwitchProviderFactory());
        }
    }
}