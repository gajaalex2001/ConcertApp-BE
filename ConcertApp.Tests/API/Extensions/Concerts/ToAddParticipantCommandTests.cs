using ConcertApp.API.Requests.Concerts;
using ConcertApp.API.Requests.Users;
using FluentAssertions;
using NUnit.Framework;

namespace ConcertApp.Tests.API.Extensions.Users
{
    [TestFixture]
    public class ToAddParticipantCommandTests
    {
        private AddParticipantRequest _request;

        [Test]
        public void ShouldConvertToAddParticipantCommand()
        {
            _request = new AddParticipantRequest
            {
                Email = "test.email@email.com",
                ConcertId = 1,
            };

            var command = _request.ToCommand();

            command.Email.Should().Be(_request.Email);
            command.ConcertId.Should().Be(_request.ConcertId);
        }
    }
}
