using ConcertApp.Business.Concerts;
using ConcertApp.Data.Models.Concerts;
using ConcertApp.Data.Models.UserConcerts;
using FluentAssertions;
using NUnit.Framework;
using BusinessModels = ConcertApp.Business.Concerts.Models;

namespace ConcertApp.Tests.Business.Users.Extensions
{
    [TestFixture]
    public class ToConcertCardTests
    {
        [Test]
        public void ShouldConvertToConcertCard()
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
                    Genre = MusicGenre.Rap,
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
                .ToConcertCard()
                .FirstOrDefault();

            result.Should().BeOfType<BusinessModels.Concert>();
            result.NoParticipants.Should().Be(1);
            result.Description.Should().Be("description");
            result.Genre.Should().Be(MusicGenre.Rap);
            result.Location.Should().Be("somewhere");
            result.StartDate.Should().Be(now);
            result.EndDate.Should().Be(now.AddDays(2));
            result.Id.Should().Be(1);
            result.Name.Should().Be("name");
        }
    }
}
