Feature-Toggle
==============

Toggler provides a minimum feature toggling API that allows extension.  The framework allows developers to add custom feature configuration providers.

The example below extends the framework to provide an in-memory configuration provider.  This made is easier to unit test!


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
