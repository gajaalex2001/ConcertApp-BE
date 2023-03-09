using ConcertApp.API.Requests.Users;
using FluentAssertions;
using NUnit.Framework;

namespace ConcertApp.Tests.API.Extensions.Users
{
    [TestFixture]
    public class ToLoginUserQueryTests
    {
        private LoginUserRequest _request;

        [Test]
        public void ShouldConvertToLoginUserQuery()
        {
            _request = new LoginUserRequest
            {
                Email = "test.email@email.com",
                Password = "totallysafepassword"
            };

            var query = _request.ToQuery();

            query.Email.Should().Be(_request.Email);
            query.Password.Should().Be(_request.Password);
        }
    }
}
