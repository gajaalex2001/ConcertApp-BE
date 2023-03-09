using ConcertApp.Business.Users;
using ConcertApp.Business.Users.Commands;
using FluentAssertions;
using NUnit.Framework;

namespace ConcertApp.Tests.Business.Users.Extensions
{
    [TestFixture]
    public class CreateUserCommandToUserTests
    {
        private CreateUserCommand _command;

        [Test]
        public void ShouldConvertToUser()
        {
            _command = new CreateUserCommand
            {
                Email = "test.email@yahoo.com",
                Password = "parolafaina",
                FirstName = "Someone",
                LastName = "Special",
                PhoneNumber = "0752331246"
            };

            var result = _command.ToUser();

            result.Email.Should().Be(_command.Email);
            result.Password.Should().Be(_command.Password);
            result.Detail.FirstName.Should().Be(_command.FirstName);
            result.Detail.LastName.Should().Be(_command.LastName);
            result.Detail.PhoneNumber.Should().Be(_command.PhoneNumber);
        }
    }
}
