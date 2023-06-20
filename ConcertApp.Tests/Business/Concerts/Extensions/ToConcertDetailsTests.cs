using ConcertApp.Business.Concerts;
using ConcertApp.Data.Models.Concerts;
using ConcertApp.Data.Models.UserConcerts;
using FluentAssertions;
using NUnit.Framework;
using BusinessModels = ConcertApp.Business.Concerts.Models;

namespace ConcertApp.Tests.Business.Users.Extensions
{
    [TestFixture]
    public class ToConcertDetailsTests
    {
        [Test]
        public void ShouldConvertToConcertDetails()
        {
            var now = DateTime.Now;

            var _iqueryable = Enumerable
                .Empty<Concert>()
                .AsQueryable()
                .Append(new Concert
                {
                    Id = 1,
                    Capacity = 1,
                    Description = "description",
                    StartDate = now,
                    EndDate = now.AddDays(2),
                    Genre = MusicGenre.HipHop,
                    Location = "somewhere",
                    Name = "name",
                    UserConcerts = new List<UserConcert>
                    {
                        new UserConcert
                        {
                            Id = 1,
                            ConcertId = 1,
                            UserId = 1,
                            UserStatus = UserStatus.Participant
                        },
                        new UserConcert
                        {
                            Id = 2,
                            ConcertId = 1,
                            UserId = 2,
                            UserStatus = UserStatus.Organizer
                        }
                    }
                });

            var result = _iqueryable
                .ToConcertDetails()
                .FirstOrDefault();

            result.Should().BeOfType<BusinessModels.ConcertDetails>();
            result.NoParticipants.Should().Be(1);
            result.Description.Should().Be("description");
            result.Genre.Should().Be(MusicGenre.HipHop);
            result.Location.Should().Be("somewhere");
            result.StartDate.Should().Be(now);
            result.EndDate.Should().Be(now.AddDays(2));
            result.Id.Should().Be(1);
            result.Name.Should().Be("name");
        }
    }
}
