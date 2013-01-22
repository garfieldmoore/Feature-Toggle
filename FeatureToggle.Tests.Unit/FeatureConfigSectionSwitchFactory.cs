using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Toggles.Configuration;
using Shouldly;

namespace FeatureToggle.Tests.Unit
{
    [TestFixture]
    public class FeatureConfigSectionSwitchFactoryTest
    {
        [Test]
        public void Create_should_return_concrete_implementation()
        {
            var featureFactory = new FeatureConfigSectionSwitchFactory();

            var switcher = featureFactory.Create();
            switcher.ShouldNotBe(null);
            switcher.ShouldBeTypeOf<FeatureConfigSectionSwitch>();
        }

    }
}
