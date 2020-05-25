using FluentAssertions;
using NUnit.Framework;
using Weatherly.Domain.Exceptions;
using Weatherly.Domain.ValueObjects;

namespace Weatherly.Domain.UnitTests.ValueObjects
{
    public class AdAccountTests
    {
        [Test]
        public void ShouldHaveCorrectDomainAndName()
        {
            const string accountString = "ATP\\RaresE";

            var account = AdAccount.For(accountString);

            account.Domain.Should().Be("ATP");
            account.Name.Should().Be("RaresE");
        }

        [Test]
        public void ToStringReturnsCorrectFormat()
        {
            const string accountString = "ATP\\RaresE";

            var account = AdAccount.For(accountString);

            var result = account.ToString();

            result.Should().Be(accountString);
        }

        [Test]
        public void ImplicitConversionToStringResultsInCorrectString()
        {
            const string accountString = "ATP\\RaresE";

            var account = AdAccount.For(accountString);

            string result = account;

            result.Should().Be(accountString);
        }

        [Test]
        public void ExplicitConversionFromStringSetsDomainAndName()
        {
            const string accountString = "ATP\\RaresE";

            var account = (AdAccount)accountString;

            account.Domain.Should().Be("ATP");
            account.Name.Should().Be("RaresE");
        }

        [Test]
        public void ShouldThrowAdAccountInvalidExceptionForInvalidAdAccount()
        {
            FluentActions.Invoking(() => (AdAccount)"ATPRaresE")
                .Should().Throw<AdAccountInvalidException>();
        }
    }
}
