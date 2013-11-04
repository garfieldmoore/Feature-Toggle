namespace FeatureToggle.Tests.Unit
{
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using Shouldly;
    using Toggles.Configuration;
    using Toggles.Configuration.Providers.InMemory;

    [TestFixture]
    public class InMemoryProviderSpecs
    {
        [Test]
        public void Should_Create_Provider()
        {
            var dictionary = new Dictionary<string, bool>();

            var factory = new InMemorySwitchProviderFactory(dictionary);
            factory.Create().ShouldBeTypeOf<FeatureSwitchProvider>();
        }

        [Test]
        public void Should_read_feature_configuration()
        {
            var dictionary = new Dictionary<string, bool>();
            dictionary.Add("feature1", true);

            var provider = new InMemorySwitchProvider(dictionary);
            provider.ReadConfiguration();

            provider.FeatureSwitches.Values.ToArray()[0].Name.ShouldBe("feature1");
            provider.FeatureSwitches.Values.ToArray()[0].State.ShouldBe(true);
        }


    }
}