using ConcertApp.Business.Concerts;
using ConcertApp.Business.Concerts.Commands;
using ConcertApp.Data.Models.Concerts;
using FluentAssertions;
using NUnit.Framework;

namespace ConcertApp.Tests.Business.Users.Extensions
{
    [TestFixture]
    public class CreateConcertCommandToConcertTests
    {
        private CreateConcertCommand _command;

        [Test]
        public void ShouldConvertToConcert()
        {
            _command = new CreateConcertCommand
            {
                Email = "test.email@yahoo.com",
                Capacity = 100,
                Description = "Description",
                EndDate = DateTime.Now,
                Genre = MusicGenre.Electronic,
                Location = "aici",
                Name = "Name",
                StartDate = DateTime.Now,
            };

            var result = _command.ToConcert();

            result.Capacity.Should().Be(_command.Capacity);
            result.Description.Should().Be(_command.Description);
            result.Genre.Should().Be(_command.Genre);
            result.Location.Should().Be(_command.Location);
            result.Name.Should().Be(_command.Name);
            result.StartDate.Should().Be(_command.StartDate.ToUniversalTime());
            result.EndDate.Should().Be(_command.EndDate.ToUniversalTime());
        }
    }
}
