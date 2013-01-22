using System;
using NSubstitute;
using NUnit.Framework;
using Toggles.Configuration;
using Shouldly;

namespace FeatureToggle.Tests.Unit
{
    [TestFixture]
    public class FactoryTests
    {
        private ISwitch _switcher;
        private ISwitchFactory _switchFactory;

        [Test]
        public void Features_should_invoke_factory()
        {
            Given_a_switch_factory_with_a_switch_initialised();

            Features.IsAvailable("MyFeature");
            _switchFactory.Create().Received(1);
        }

        [Test]
        public void IsAvailable_should_delegate_to_concrete_switch()
        {
            Given_a_switch_factory_with_a_switch_initialised();

            _switcher.IsAvaliable("MyFeature").Returns(true);
            var result = Features.IsAvailable("MyFeature");

            _switcher.Received(1).IsAvaliable("MyFeature");
           result.ShouldBe(true);
        }

        [Test]
        public void Initialize_should_throw_exception_for_null_switchfactory()
        {
            bool exceptionThrown = false;

            try
            {
                Features.Initialize(null);
            }
            catch (ArgumentNullException)
            {
                exceptionThrown = true;
            }
            
            exceptionThrown.ShouldBe(true);
        }

        private void Given_a_switch_factory_with_a_switch_initialised()
        {
            _switcher = Substitute.For<ISwitch>();
            _switchFactory = Substitute.For<ISwitchFactory>();
            _switchFactory.Create().Returns(_switcher);
            Features.Initialize(_switchFactory);
        }
    }
}
