using ConcertApp.API.Requests.Concerts;
using ConcertApp.API.Requests.Users;
using FluentAssertions;
using NUnit.Framework;

namespace ConcertApp.Tests.API.Extensions.Users
{
    [TestFixture]
    public class ToRemoveParticipantCommandTests
    {
        private RemoveParticipantRequest _request;

        [Test]
        public void ShouldConvertToRemoveParticipantCommand()
        {
            _request = new RemoveParticipantRequest
            {
                Email = "test.email@email.com",
                ConcertId = 1
            };

            var command = _request.ToCommand();

            command.Email.Should().Be(_request.Email);
            command.ConcertId.Should().Be(_request.ConcertId);
        }
    }
}
