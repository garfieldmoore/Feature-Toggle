using NUnit.Framework;
using Toggles.Configuration;
using Toggles.Configuration.Factories;
using Shouldly;

namespace FeatureToggle.Tests.Acceptance
{
    [TestFixture]
    public class ConfigurationSectionTests
    {
        [Test]
        public void ShouldEvaluatePropertyStates()
        {
            GivenAFeaturesGatewayInitializedWithConfigurationSectionSwitchProvider();

            Features.IsAvailable("FeatureA").ShouldBe(true);
            Features.IsAvailable("FeatureB").ShouldBe(false);
        }

        [Test, Ignore]
        public void Should_Evaluate_dependant_features()
        {
            GivenAFeaturesGatewayInitializedWithConfigurationSectionSwitchProvider();
            Features.IsAvailable("FeatureC").ShouldBe(false);
        }


        private void GivenAFeaturesGatewayInitializedWithConfigurationSectionSwitchProvider()
        {
            Features.Initialize(new ConfigurationSectionSwitchProviderFactory());
        }
    }
}