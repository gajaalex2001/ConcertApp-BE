using ConcertApp.API.Requests.Concerts;
using ConcertApp.API.Requests.Users;
using FluentAssertions;
using NUnit.Framework;

namespace ConcertApp.Tests.API.Extensions.Users
{
    [TestFixture]
    public class ToGetRecommendationsQueryTests
    {
        private GetRecommendationsRequest _request;

        [Test]
        public void ShouldConvertToGetUpcomingConcertsQuery()
        {
            _request = new GetRecommendationsRequest
            {
                Email = "email"
            };

            var command = _request.ToQuery();

            command.Email.Should().Be(_request.Email);
        }
    }
}
