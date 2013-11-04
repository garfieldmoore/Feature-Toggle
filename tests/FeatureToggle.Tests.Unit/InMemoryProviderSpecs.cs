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
            var dictionary = GivenAnEnabledFeature();

            var provider = new InMemorySwitchProvider(dictionary);
            provider.ReadConfiguration();

            provider.FeatureSwitches.Values.ToArray()[0].Name.ShouldBe("feature1");
            provider.FeatureSwitches.Values.ToArray()[0].State.ShouldBe(true);
        }

        private static Dictionary<string, bool> GivenAnEnabledFeature()
        {
            var dictionary = new Dictionary<string, bool>();
            dictionary.Add("feature1", true);
            return dictionary;
        }

        [Test]
        public void Should_be_able_to_add_checkers_onto_features()
        {
            var checker = new StateChecker();
            var featureDictionary = new Dictionary<string, bool>();
            featureDictionary.Add("feature", true);

            var provider = new InMemorySwitchProvider(featureDictionary);
            provider.AddChecker(checker);

            provider.ReadConfiguration();
            provider.IsAvailable("feature").ShouldBe(true);
        }

    }
}