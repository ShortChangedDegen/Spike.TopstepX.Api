using FluentAssertions;
using Spike.TopstepX.Api.Common;

namespace Spike.TopstepX.Api.Tests.Common
{
    public class GuardTests
    {
        [Fact]
        public void Guard_ShouldThrowArgumentException_WhenProvidedParamFailsPredicate()
        {
            Func<bool, bool> providedPredicate = x => x == true;
            const bool providedParam = false;
            const string providedParamName = "ProvidedParamName";
            const string providedMessage = "Provided message for the exception";

            var exception = Assert.Throws<ArgumentException>(() => Guard.Predicate(providedPredicate, providedParam, providedParamName, providedMessage));
            exception.Message.Should().StartWith(providedMessage);
            exception.Message.Should().Contain(providedParamName);

        }

        [Fact]
        public void Guard_ShouldReturnProvidedParam_WhenProvidedParamPassesPredicate()
        {
            Func<bool, bool> providedPredicate = x => x == true;
            const bool providedParam = true;
            const string providedParamName = "ProvidedParamName";
            const string providedMessage = "Provided message for the exception";

            Guard.Predicate(providedPredicate, providedParam, providedParamName, providedMessage)
                .Should().Be(providedParam);
        }
    }
}
