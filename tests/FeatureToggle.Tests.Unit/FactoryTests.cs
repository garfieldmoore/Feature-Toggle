using NSubstitute;

namespace FeatureToggle.Tests.Unit
{
    using System;
    using NUnit.Framework;
    using Toggles.Configuration;
    using Shouldly;

    [TestFixture]
    public class FactoryTests
    {
        private ISwitch _switcher;
        private ISwitchProviderFactory _switchProviderFactory;

        [Test]
        public void Features_should_invoke_factory()
        {
            Given_a_switch_factory_with_a_switch_initialised();

            Features.IsAvailable("MyFeature");
            _switchProviderFactory.Received().Create();
        }

        [Test]
        public void IsAvailable_should_delegate_to_concrete_switch()
        {
            Given_a_switch_factory_with_a_switch_initialised();

            _switcher.IsAvailable("MyFeature").Returns(true);
            var result = Features.IsAvailable("MyFeature");

            _switcher.Received(1).IsAvailable("MyFeature");
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
            _switchProviderFactory = Substitute.For<ISwitchProviderFactory>();
            _switchProviderFactory.Create().Returns(_switcher);
            Features.Initialize(_switchProviderFactory);
        }
    }
}
