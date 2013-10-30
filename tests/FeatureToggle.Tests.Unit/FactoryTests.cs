using NSubstitute;
using Toggles.Configuration.Interfaces;

namespace FeatureToggle.Tests.Unit
{
    using System;
    using NUnit.Framework;
    using Shouldly;
    using Toggles.Configuration;

    [TestFixture]
    public class FactoryTests
    {
        public class GivenFeatureGateway
        {
            private IProvideSwitches _switcher;
            private ISwitchProviderFactory _switchProviderFactory;

            [Test]
            public void Should_invoke_factory_first_time()
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

            [Test]
            public void Should_read_configuration()
            {
                Given_a_switch_factory_with_a_switch_initialised();

                Features.IsAvailable("MyFeature");

                _switcher.Received(1).ReadConfiguration();
               
            }

            private void Given_a_switch_factory_with_a_switch_initialised()
            {
                _switcher = Substitute.For<IProvideSwitches>();
                _switchProviderFactory = Substitute.For<ISwitchProviderFactory>();
                _switchProviderFactory.Create().Returns(_switcher);
                Features.Initialize(_switchProviderFactory);
            }
        }
    }
}