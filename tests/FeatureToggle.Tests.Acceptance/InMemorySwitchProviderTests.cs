namespace FeatureToggle.Tests.Acceptance
{
    using System.Collections.Generic;

    using NUnit.Framework;

    using Toggles.Configuration;
    using Toggles.Configuration.Providers.InMemory;

    using Shouldly;

    public class InMemorySwitchProviderTests
    {
        [Test]
        public void Should_set_feature_availability()
        {
            var dictionary = new Dictionary<string, bool>();
            dictionary.Add("feature1", true);
            dictionary.Add("feature2", false);

            Features.Initialize(new InMemorySwitchProviderFactory(dictionary));
            Features.IsAvailable("feature1").ShouldBe(true);
            Features.IsAvailable("feature2").ShouldBe(false);
        }

    }
}