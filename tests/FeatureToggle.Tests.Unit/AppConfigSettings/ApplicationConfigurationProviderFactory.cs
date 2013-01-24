using NUnit.Framework;
using Shouldly;
using Toggles.Configuration.Factories;
using Toggles.Configuration.Providers;

namespace FeatureToggle.Tests.Unit
{
    [TestFixture]
    public class ApplicationConfigurationProviderFactoryTests
    {
        [Test]
        public void Create_should_return_concrete_implementation()
        {
            var featureFactory = new ApplicationSettingsSwitchProviderFactory();

            var switcher = featureFactory.Create();
            switcher.ShouldNotBe(null);
            switcher.ShouldBeTypeOf<ApplicationSettingsSwitchProviderFactory>();
        }
    }
}