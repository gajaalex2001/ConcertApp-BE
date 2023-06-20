using ConcertApp.API.Requests.Concerts;
using ConcertApp.API.Requests.Users;
using FluentAssertions;
using NUnit.Framework;

namespace ConcertApp.Tests.API.Extensions.Users
{
    [TestFixture]
    public class ToGetConcertQueryTests
    {
        private GetConcertRequest _request;

        [Test]
        public void ShouldConvertToGetConcertQuery()
        {
            _request = new GetConcertRequest
            {
                ConcertId = 1,
                Email = "alex@gmail.com"
            };

            var command = _request.ToQuery();

            command.ConcertId.Should().Be(_request.ConcertId);
            command.Email.Should().Be(_request.Email);
        }
    }
}
