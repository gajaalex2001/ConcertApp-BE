using ConcertApp.API.Models;
using ConcertApp.API.Requests.Concerts;
using ConcertApp.API.Requests.Users;
using ConcertApp.Data.Models.UserConcerts;
using FluentAssertions;
using NUnit.Framework;

namespace ConcertApp.Tests.API.Extensions.Users
{
    [TestFixture]
    public class ToGetPageQueryTests
    {
        private GetPageRequest _request;

        [Test]
        public void ShouldConvertToGetPageQuery()
        {
            _request = new GetPageRequest
            {
                Filters = new ConcertFilters
                {
                    Email = "email@yahoo.com",
                    MusicGenre = Data.Models.Concerts.MusicGenre.Rock,
                    UserStatus = UserStatus.Participant
                },
                PageRequest = new PageRequest
                {
                    ItemsPerPage = 10,
                    PageIndex = 1,
                }
            };

            var command = _request.ToQuery();

            command.Email.Should().Be(_request.Filters.Email);
            command.MusicGenre.Should().Be(_request.Filters.MusicGenre);
            command.UserStatus.Should().Be(_request.Filters.UserStatus);
            command.ItemsPerPage.Should().Be(_request.PageRequest.ItemsPerPage);
            command.PageIndex.Should().Be(_request.PageRequest.PageIndex);
        }
    }
}
