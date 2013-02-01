using System.Configuration;
using NSubstitute;
using NUnit.Framework;
using Shouldly;
using Toggles.Configuration.Providers.ApplicationSettings;
using Toggles.Configuration.Providers.ConfigurationSection;
using System.Linq;

namespace FeatureToggle.Tests.Unit
{
    [TestFixture]
    public class KeyValueFeatureMapperTests
    {
        [Test]
        public void Should_map_features()
        {            
            var settings = new KeyValueConfigurationCollection();
            settings.Add(new KeyValueConfigurationElement("Feature", "true"));
            settings.Add(new KeyValueConfigurationElement("Feature1", "false"));
            var mapper = new KeyValueFeatureMapper();

            var feature = mapper.Map(settings).ToList();

            feature.Count.ShouldBe(2);

            feature[0].Name.ShouldBe("Feature");
            feature[0].State.ShouldBe(true);
        }
    }
}