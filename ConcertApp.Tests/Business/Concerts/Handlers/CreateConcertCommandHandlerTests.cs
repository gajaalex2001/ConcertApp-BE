using ConcertApp.Business.Concerts.Commands;
using ConcertApp.Business.Concerts.Handlers;
using ConcertApp.Data;
using ConcertApp.Data.Models.Concerts;
using ConcertApp.Data.Models.UserConcerts;
using ConcertApp.Data.Models.Users;
using Moq;
using Moq.EntityFrameworkCore;
using NUnit.Framework;
using System.Text.Json;
using Utility.ErrorMessages;
using Utility.Exceptions.ErrorCodes;
using Utility.Exceptions.Models;

namespace ConcertApp.Tests.Business.Users.Handlers
{
    [TestFixture]
    public class CreateConcertCommandHandlerTests
    {
        private Mock<ConcertAppContext> _context;
        private CreateConcertCommandHandler _handler;
        private CreateConcertCommand _request;

        [SetUp]
        public void Init()
        {
            _context = new Mock<ConcertAppContext>();
            _handler = new CreateConcertCommandHandler(_context.Object);

            CreateRequest();
            SetupContext();
        }

        [TearDown]
        public void Clean()
        {
            _context = null;
            _handler = null;
        }

        [Test]
        public async Task ShouldCallSaveChangesAsync()
        {
            var result = await _handler.Handle(_request, new CancellationToken());

            _context.Verify(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public async Task ShouldAddConcertAsync()
        {
            var result = await _handler.Handle(_request, new CancellationToken());

            _context.Verify(c => c.Concerts
                .AddAsync(It.IsAny<Concert>(), It.IsAny<CancellationToken>()), Times.Once);
            _context.Verify(c => c.Concerts
                .AddAsync(It.Is<Concert>(obj =>
                    obj.Capacity == _request.Capacity &&
                    obj.Description == _request.Description &&
                    obj.StartDate == _request.StartDate.ToUniversalTime() &&
                    obj.EndDate == _request.EndDate.ToUniversalTime()), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public Task WhenEmailNotFound_ShouldReturnError()
        {
            _request.Email = "dude@gmail.com";
            var expectedResult = JsonSerializer.Serialize(new
            {
                ErrorCode = (int)ErrorCodes.User_AccountNotFound,
                Message = UserErrors.NotFound
            });
            Func<Task> action = async () => await _handler.Handle(_request, new CancellationToken());
            CustomException ex = Assert.ThrowsAsync<CustomException>(async () => await action());

            Assert.AreEqual(ex.Message, expectedResult);
            return Task.CompletedTask;
        }

        private void SetupContext()
        {
            var appConcerts = new List<Concert>
            {
                new Concert
                {
                    Id = 1,
                    Capacity = 1,
                    Description = "Test",
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow,
                    Genre = MusicGenre.Rock,
                    Location = "somewhere",
                    Name = "Test",
                    UserConcerts = new List<UserConcert>
                    {
                        new UserConcert
                        {
                            Id = 1,
                            ConcertId = 1,
                            UserId = 1,
                            UserStatus = UserStatus.Organizer,
                        }
                    }
                }
            };

            var applicationUsersDetails = new List<UserDetail>
            {
                new UserDetail
                {
                    Id = 1,
                    FirstName = "Hehe",
                    LastName = "LastHehe",
                    PhoneNumber = "1234567890"
                }
            };

            var applicationUsers = new List<User>
            {
                new User
                {
                    Id = 1,
                    Email = "hehe@gmail.com",
                    Password = "123",
                }
            };

            _context.Setup(c => c.Concerts).ReturnsDbSet(appConcerts);
            _context.Setup(c => c.Users).ReturnsDbSet(applicationUsers);
            _context.Setup(c => c.UsersDetails).ReturnsDbSet(applicationUsersDetails);
        }

        private void CreateRequest()
        {
            _request = new CreateConcertCommand
            {
                Email = "hehe@gmail.com",
                Capacity = 100,
                Description = "Description",
                Name = "Name",
                Genre = MusicGenre.Indie,
                EndDate = DateTime.Now,
                StartDate = DateTime.Now,
                Location = "somewhere"
            };
        }
    }
}
