using ConcertApp.Business.Users.Commands;
using ConcertApp.Business.Users.Handlers;
using ConcertApp.Data;
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
    public class CreateUserCommandHandlerTests
    {
        private Mock<ConcertAppContext> _context;
        private CreateUserCommandHandler _handler;
        private CreateUserCommand _request;

        [SetUp]
        public void Init()
        {
            _context = new Mock<ConcertAppContext>();
            _handler = new CreateUserCommandHandler(_context.Object);

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
        public async Task ShouldAddUserAsync()
        {
            var result = await _handler.Handle(_request, new CancellationToken());

            _context.Verify(c => c.Users
                .AddAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()), Times.Once);
            _context.Verify(c => c.Users
                .AddAsync(It.Is<User>(obj =>
                    obj.Email == _request.Email &&
                    obj.Password == _request.Password &&
                    obj.Detail.FirstName == _request.FirstName &&
                    obj.Detail.LastName == _request.LastName &&
                    obj.Detail.PhoneNumber == _request.PhoneNumber), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public Task WhenEmailAlreadyExists_ShouldReturnError()
        {
            _request.Email = "dude@gmail.com";
            var expectedResult = JsonSerializer.Serialize(new
            {
                ErrorCode = (int)ErrorCodes.User_EmailAlreadyExists,
                Message = UserErrors.EmailAlreadyExists
            });
            Func<Task> action = async () => await _handler.Handle(_request, new CancellationToken());
            CustomException ex = Assert.ThrowsAsync<CustomException>(async () => await action());

            Assert.AreEqual(ex.Message, expectedResult);
            return Task.CompletedTask;
        }

        private void SetupContext()
        {
            var applicationUsersDetails = new List<UserDetail>
            {
                new UserDetail
                {
                    Id = 1,
                    UserId = 1,
                    FirstName = "Random",
                    LastName = "Dude",
                    PhoneNumber = "0755123321"
                }
            };

            var applicationUsers = new List<User>
            {
                new User
                {
                    Id = 1,
                    Email = "dude@gmail.com",
                    Password = "nicepass"
                }
            };

            _context.Setup(c => c.Users).ReturnsDbSet(applicationUsers);
            _context.Setup(c => c.UsersDetails).ReturnsDbSet(applicationUsersDetails);
        }

        private void CreateRequest()
        {
            _request = new CreateUserCommand
            {
                Email = "outofideas@gmail.com",
                Password = "unlucky",
                FirstName = "That",
                LastName = "Guy",
                PhoneNumber = "0744544269"
            };
        }
    }
}
