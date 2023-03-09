using ConcertApp.Business.Users.Handlers;
using ConcertApp.Business.Users.Queries;
using ConcertApp.Data;
using ConcertApp.Data.Models.Users;
using FluentAssertions;
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
    public class LoginUserQueryHandlerTests
    {
        private Mock<ConcertAppContext> _context;
        private LoginUserQueryHandler _handler;
        private LoginUserQuery _request;

        [SetUp]
        public void Init()
        {
            _context = new Mock<ConcertAppContext>();
            _handler = new LoginUserQueryHandler(_context.Object);

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
        public async Task ShouldReturnCorrectUserInformation()
        {
            var result = await _handler.Handle(_request, new CancellationToken());

            result.Email.Should().Be("dude@gmail.com");
            result.FirstName.Should().Be("Random");
            result.LastName.Should().Be("Dude");
            result.PhoneNumber.Should().Be("0755123321");
        }

        [Test]
        public Task WhenUsingInvalidEmail_ShouldReturnError()
        {
            _request.Email = "guy@gmail.com";
            var expectedResult = JsonSerializer.Serialize(new
            {
                ErrorCode = (int)ErrorCodes.User_AccountNotFound,
                Message = UserErrors.WrongCredentials
            });
            Func<Task> action = async () => await _handler.Handle(_request, new CancellationToken());
            CustomException ex = Assert.ThrowsAsync<CustomException>(async () => await action());

            Assert.AreEqual(ex.Message, expectedResult);
            return Task.CompletedTask;
        }

        [Test]
        public Task WhenUsingInvalidPassword_ShouldReturnError()
        {
            _request.Password = "nonexistent";
            var expectedResult = JsonSerializer.Serialize(new
            {
                ErrorCode = (int)ErrorCodes.User_AccountNotFound,
                Message = UserErrors.WrongCredentials
            });
            Func<Task> action = async () => await _handler.Handle(_request, new CancellationToken());
            CustomException ex = Assert.ThrowsAsync<CustomException>(async () => await action());

            Assert.AreEqual(ex.Message, expectedResult);
            return Task.CompletedTask;
        }

        private void SetupContext()
        {
            var applicationUsers = new List<User>
            {
                new User
                {
                    Id = 1,
                    Email = "dude@gmail.com",
                    Password = "nicepass",
                    Detail = new UserDetail
                    {
                        Id = 1,
                        UserId = 1,
                        FirstName = "Random",
                        LastName = "Dude",
                        PhoneNumber = "0755123321"
                    }
                }
            };

            _context.Setup(c => c.Users).ReturnsDbSet(applicationUsers);
        }

        private void CreateRequest()
        {
            _request = new LoginUserQuery
            {
                Email = "dude@gmail.com",
                Password = "nicepass"
            };
        }
    }
}
