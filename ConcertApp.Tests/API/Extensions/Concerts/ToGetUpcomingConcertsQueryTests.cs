using ConcertApp.API.Requests.Concerts;
using ConcertApp.API.Requests.Users;
using FluentAssertions;
using NUnit.Framework;

namespace ConcertApp.Tests.API.Extensions.Users
{
    [TestFixture]
    public class ToGetUpcomingConcertsQueryTests
    {
        private GetUpcomingConcertsRequest _request;

        [Test]
        public void ShouldConvertToGetUpcomingConcertsQuery()
        {
            _request = new GetUpcomingConcertsRequest
            {
                CurrentDate = DateTime.Now,
                Email = "email"
            };

            var command = _request.ToQuery();

            command.Email.Should().Be(_request.Email);
            command.CurrentDate.Should().Be(_request.CurrentDate);
        }
    }
}
