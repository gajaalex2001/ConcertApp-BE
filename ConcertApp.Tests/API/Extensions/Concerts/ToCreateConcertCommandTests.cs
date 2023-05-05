using ConcertApp.API.Requests.Concerts;
using ConcertApp.Data.Models.Concerts;
using FluentAssertions;
using NUnit.Framework;

namespace ConcertApp.Tests.API.Extensions.Users
{
    [TestFixture]
    public class ToCreateConcertCommandTests
    {
        private CreateConcertRequest _request;

        [Test]
        public void ShouldConvertToCreateConcertCommand()
        {
            _request = new CreateConcertRequest
            {
                Email = "test.email@email.com",
                Capacity = 100,
                Description = "description",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                Genre = MusicGenre.Rock,
                Location = "somewhere",
                Name = "name",
            };

            var command = _request.ToCommand();

            command.Email.Should().Be(_request.Email);
            command.Capacity.Should().Be(_request.Capacity);
            command.Description.Should().Be(_request.Description);
            command.StartDate.Should().Be(_request.StartDate);
            command.EndDate.Should().Be(_request.EndDate);
            command.Genre.Should().Be(_request.Genre);
            command.Location.Should().Be(_request.Location);
            command.Name.Should().Be(_request.Name);
        }
    }
}
