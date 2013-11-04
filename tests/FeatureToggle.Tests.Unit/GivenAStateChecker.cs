namespace FeatureToggle.Tests.Unit
{
    using System.Collections.Generic;
    using NSubstitute;
    using NUnit.Framework;
    using Shouldly;
    using Toggles.Configuration;
    using Toggles.Configuration.Providers.InMemory;


    public class GivenAStateChecker
    {
        private static InMemorySwitchProvider provider;

        private static Dictionary<string, bool> features;

        private static IChecker checker;

        [Test]
        public void Should_check_state()
        {
            var checker = new StateChecker();
            checker.IsAvailable(new Feature() { State = true }).ShouldBe(true);
        }

        [Test]
        public void checker_should_call_internal_checker()
        {
            var checker = new StateChecker();
            var newChecker = Substitute.For<IChecker>();
            checker.AddChecker(newChecker);

            var feature = new Feature() { State = true };
            checker.IsAvailable(feature);

            newChecker.Received(1).IsAvailable(feature);
        }

        [Test]
        public void Should_check_for_new_checkers()
        {
            var checker = new StateChecker();

            checker.IsAvailable(new Feature() { State = true }).ShouldBe(true);
        }


        [Test]
        public void provider_should_call_checker()
        {
            GivenAnEnabledFeature();
            GivenAProviderWithAChecker();

            provider.ReadConfiguration();
            provider.IsAvailable("feature1");

            checker.Received(1).IsAvailable(Arg.Any<Feature>());
        }

        [Test]
        public void provider_should_return_checked_result()
        {
            GivenAnEnabledFeature();
            GivenAProviderWithAChecker();
            checker.IsAvailable(Arg.Any<Feature>()).Returns(true);

            provider.ReadConfiguration();
            provider.IsAvailable("feature1").ShouldBe(true);
        }

        [Test]
        public void provide_should_call_all_checkers()
        {
            GivenAnEnabledFeature();
            GivenAProviderWithAChecker();

            provider.ReadConfiguration();
            provider.IsAvailable("feature1");

            checker.Received(1).IsAvailable(Arg.Any<Feature>());
        }

        private static void GivenAProviderWithAChecker()
        {
            provider = new InMemorySwitchProvider(features);
            checker = Substitute.For<IChecker>();
            provider.AddChecker(checker);
        }

        private static void GivenAnEnabledFeature()
        {
            features = new Dictionary<string, bool>();
            features.Add("feature1", true);
            return;
        }

    }
}