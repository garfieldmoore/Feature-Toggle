namespace FeatureToggle.Tests.Acceptance
{
    using System.Collections.Generic;
    using NUnit.Framework;
    using Shouldly;
    using Toggles.Configuration;
    using Toggles.Configuration.Interfaces;

    public class ExtendingToggler
    {
        [Test]
        public void Should_allow_new_providers()
        {
            Features.Initialize(new InMemorySwitchProviderFactory());

            Features.IsAvailable("Feature1").ShouldBe(true);
            Features.IsAvailable("Feature2").ShouldBe(false);
        }

    }

    public class InMemorySwitchProviderFactory : ISwitchProviderFactory
    {
        public IProvideSwitches Create()
        {
            return new InMemorySwitchProvider();
        }
    }

    public class InMemorySwitchProvider : FeatureSwitchProvider
    {
        public override void ReadConfiguration()
        {
            FeatureSwitches.Add("Feature1", new Feature() { Name = "Feature1", State = true });
            FeatureSwitches.Add("Feature2", new Feature() { Name = "Feature1", State = false });
        }
    }
}