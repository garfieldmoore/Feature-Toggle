namespace FeatureToggle.Tests.Acceptance
{
    using System.Collections.Generic;

    using NUnit.Framework;

    using Toggles.Configuration;
    using Toggles.Configuration.Providers.InMemory;

    using Shouldly;

    public class FeaureGateWayTests
    {
        [Test]
        public void Should_be_able_create_extension_methods_to_access_switches()
        {
            var features = new Features();
            features.MyFeatureIsAvailable().ShouldBe(true);
        }
    }

    public static class FeatureExtensions
    {
        public static bool MyFeatureIsAvailable(this Features features)
        {
            return true;
        }
    }

}