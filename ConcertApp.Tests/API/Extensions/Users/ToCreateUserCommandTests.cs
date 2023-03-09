using ConcertApp.API.Requests.Users;
using FluentAssertions;
using NUnit.Framework;

namespace ConcertApp.Tests.API.Extensions.Users
{
    [TestFixture]
    public class ToCreateUserCommandTests
    {
        private CreateUserRequest _request;

        [Test]
        public void ShouldConvertToCreateUserCommand()
        {
            _request = new CreateUserRequest
            {
                Email = "test.email@email.com",
                Password = "totallysafepassword",
                FirstName = "Hugh",
                LastName = "Mongous",
                PhoneNumber = "0775123321"
            };

            var command = _request.ToCommand();

            command.Email.Should().Be(_request.Email);
            command.Password.Should().Be(_request.Password);
            command.FirstName.Should().Be(_request.FirstName);
            command.LastName.Should().Be(_request.LastName);
            command.PhoneNumber.Should().Be(_request.PhoneNumber);
        }
    }
}
