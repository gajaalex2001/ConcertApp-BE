using ConcertApp.Business.Users;
using ConcertApp.Business.Users.Models;
using ConcertApp.Data.Models.Users;
using FluentAssertions;
using NUnit.Framework;

namespace ConcertApp.Tests.Business.Users.Extensions
{
    [TestFixture]
    public class ToUserInformationTests
    {
        private IQueryable<User> _iqueryable;

        [Test]
        public void ShouldConvertToUserInformation()
        {
            _iqueryable = Enumerable
                .Empty<User>()
                .AsQueryable()
                .Append(new User
                {
                    Id = 1,
                    Email = "testUser@gmail.com",
                    Password = "wow",
                    Detail = new UserDetail
                    {
                        FirstName = "Mama",
                        LastName = "Manu",
                        PhoneNumber = "0740326979"
                    }
                });

            var result = _iqueryable
                .ToUserInformation()
                .FirstOrDefault();

            result.Should().BeOfType<UserInformation>();
            result.Email.Should().Be("testUser@gmail.com");
            result.FirstName.Should().Be("Mama");
            result.LastName.Should().Be("Manu");
            result.PhoneNumber.Should().Be("0740326979");
        }
    }
}
