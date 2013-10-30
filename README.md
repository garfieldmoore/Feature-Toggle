Feature-Toggle
==============

Toggler provides a minimum, and friction free feature toggling API. 

The framework provides a default configuration provider so it's easy to get started;

Simply add the package to your application;

  install-package toggler.net

This will add the below configuration section to your app.config;

      <configSections>
        <!-- For more information on Entity Framework configuration, visit http://go.microsoft.com/fwlink/?LinkID=237468 -->
        <section name="FeatureConfiguration" type="Toggles.Configuration.Providers.ConfigurationSection.FeatureConfiguration, Toggler" />
      </configSections>

      <FeatureConfiguration>
        <Features>
          <add name="FeatureA" isAvailable="true"/>
          <add name="FeatureB" isAvailable="false"/>
          <add name="FeatureC" isAvailable="true" DependsOn="FeatureB"/>
        </Features>
      </FeatureConfiguration>

Now you can start toggling features;

      if (Features.IsAvailable("FeatureA"))
      {
          // Do something useful
          Console.WriteLine("FeatureA is enabled.");
      }

However, one of the principles behind toggler is extensibility...

Extending Toggler
-----------------
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
